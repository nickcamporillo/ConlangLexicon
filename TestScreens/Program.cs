using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;

using log4net.Appender;
using log4net.Config;
using log4net;
using log4net.Repository.Hierarchy;

using IViews;
using IServices;
using IRepository;
using Repositories;
using IPresenters;
using Presenters;
using Models;
using Services;
using IModels;
using log = Utilities.LoggerFacade;

namespace TestScreens
{
    static class Program
    {
        static EventHandler Error;
        static EventHandler Activate;
        static EventHandler Deactivate;

        enum NavigationDirection
        {
            Forward = 1,
            Backward = 2
        }

        #region "Local Constants"
        //Configuration name in app.config
        private const string APP_VERSION_CONFIG = "APPLICATION_VERSION";
        private const string CONFIG_CNX_STRING = "DbEntities";
        private const string LOG_DIR = "LOG_DIR";

        //Exception message strings
        private const string ERR_GENERAL = "Please contact system administrator.";
        private const string ERR_GENERAL_CAPTION = "Issue initializing Lexicon application";
        //private const string ERR_INCORRECT_NUM_ARGS = "Number of parameters incorrect";
        //private const string ERR_INCORRECT_FORMAT_ARGS = "Parameter format incorrect";

        //User-input-related stuff
        private const char KEYPRESS_ENTER = '\r';
        private const char KEYPRESS_TAB = '\t';

        //Form-related stuff
        private static IList<IView> forms;

        private const string LEXICON_ENTRY_SCREEN = "LexiconEntryScreen";
        private const string WORD_LIST_SCREEN = "WordListGrid";

        private const int STARTING_FORM = 0;
        private const int STANDARD_FORM_SIZE = 321;

        #endregion


        //https://stackify.com/log4net-guide-dotnet-logging/
        //Recipe for simplified configuration by using app.config: https://www.codeproject.com/Tips/1107824/Perfect-Log-Net-with-Csharp
        //private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] commandLine)
        {
            log.Info($"== Begin Logging [{DateTime.Now.ToLocalTime()}] ==");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Error += Application_Error;
            //Activate += Application_Activate;
            //Deactivate += Application_Deactivate;

            try
            {
                RunProgram(commandLine);
            }
            catch(Exception ex)
            {
                log.Fatal("Fatal error in Controller", ex);
            }
        }

        static void RunProgram(string[] commandLine)
        {
            StartupMessageWindow messager = new StartupMessageWindow();

            log.Info("Initializing - Instantiating service");
            IServiceFactory<LexiconRaw> fact = new LexiconServiceFactory<LexiconRaw>();

            var lexService = fact.CreatService();

            try
            {
                log.Info("Initializing - creating forms");

                forms = new List<IView>();
                forms.Add(CreateForm(typeof(WordListGrid), lexService));
                forms.Add(CreateForm(typeof(LexiconEntryScreen), lexService));

                Application.Run(forms[STARTING_FORM] as Form);
            }
            catch (Exception ex)
            {
                log.Error($"Exception in Controller: {ex.Message}");

                if (lexService != null)
                {
                    lexService.Dispose();
                    lexService = null;
                }

                messager.Message(ERR_GENERAL_CAPTION, ERR_GENERAL, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                messager.Dispose();
            }
        }

        //This is the Form Factory method
        static IView CreateForm<T>(Type typ, IService<T> service) where T: class, new()
        {
            IView form = null;
            IPresenter pres = null;

            string versionNumber = ConfigurationManager.AppSettings[APP_VERSION_CONFIG].ToString();
            string prefix = $"Lexicon Manager 2019 {versionNumber} - ";
            string suffix = string.Empty;

            if (typ == typeof(WordListGrid))
            {
                suffix = "Word List Grid";                
                pres = new WordListPresenter<LexiconRaw, ILexiconService<LexiconRaw>>(service as ILexiconService<LexiconRaw>);
                form = new WordListGrid(pres);

                form.Name = LEXICON_ENTRY_SCREEN;
                form.PreviousFormName = string.Empty;
                form.NextFormName = WORD_LIST_SCREEN;

                ((IViewWordListGrid)(form)).AddingRecord += Program_AddingRecord;

                //Set "false" for the Previous screen, bc this is the first screen (there's no previous screen to move to.
                //Since this is read-only screen, it should always have permission to move forward.
                form.ConfirmNavigateToPreviousScreen = ConfirmNavigation.StayOnCurrentScreen;
                form.ConfirmNavigateToNextScreen = ConfirmNavigation.MoveToNextScreen;
                
            }
            else if (typ == typeof(LexiconEntryScreen))
            {
                suffix = "Data Entry Screen";
                pres = new LexiconEntryPresenter<LexiconRaw,ILexiconService<LexiconRaw>>(service as ILexiconService<LexiconRaw>);
                form = new LexiconEntryScreen(pres);
                form.Name = WORD_LIST_SCREEN;
                form.PreviousFormName = LEXICON_ENTRY_SCREEN;
                form.NextFormName = LEXICON_ENTRY_SCREEN;               

                //This is also a read-only screen.  Since it's the middle screen, it should always have unconditional permission to move forward and backwards.
                form.ConfirmNavigateToPreviousScreen = ConfirmNavigation.MoveToNextScreen;
                form.ConfirmNavigateToNextScreen = ConfirmNavigation.MoveToNextScreen;                
            }

            if (pres != null && form != null)
            {
                //Can't do the following - access is private:
                //((Form)(form)).CenterToScreen();

                //...and this executes too late, so you have to also do this inside the Form:
                //this.WindowState = FormWindowState.Maximized;

                form.MaximizeBox = false;
                form.MinimizeBox = true;

                pres.Setup(form);
                form.Text = prefix + suffix;

                form.PageMoveCompleted += Mamag;
                form.NextScreen += Form_NextScreen;
                form.PreviousScreen += Form_PreviousScreen;
                form.FormClosing += Program_FormClosing;
                form.CloseAll += Form_CloseAll;
            }

            return form;
        }

        private static void Program_AddingRecord(object sender, EventArgs e)
        {
            string s = "Program.cs";
            var wordList = forms.SingleOrDefault(c => c.GetType() == typeof(WordListGrid)) as IViewWordListGrid;
            var entryScreen = forms.SingleOrDefault(c => c.GetType() == typeof(LexiconEntryScreen)) as IViewLexiconEntryScreen;
            if (wordList != null && entryScreen != null)
            {
                entryScreen.IsAddingNewRecord = true;
                entryScreen.LanguageId = wordList.LanguageId;
            }
        }

        private static void Form_CloseAll(object sender, EventArgs e)
        {
            foreach (var f in forms)
            {
                f.Close();
            }
            forms.Clear();
            forms = null;
        }

        //Invoke any cleanup if necessary
        private static void Program_FormClosing(object sender, FormClosingEventArgs e)
        {
            IView sendingView = GetSendingForm(sender);

            if (sendingView != null)
            {
                string name = sendingView.Name;
                foreach (var form in forms)
                {
                    form.Dispose();
                }
            }
        }

        #region "Navigation Methods and Related Funcs"
        private static void Form_PreviousScreen(object sender, EventArgs e)
        {
            IView currentForm = null;
            IView nextForm = null;

            currentForm = GetSendingForm(sender);

            if (currentForm != null && currentForm.ConfirmNavigateToPreviousScreen == ConfirmNavigation.MoveToNextScreen)
            {
                if (!string.IsNullOrEmpty(currentForm.PreviousFormName))
                {
                    nextForm = forms.Where(c => c.Name.Equals(currentForm.PreviousFormName)).FirstOrDefault();
                    if (nextForm != null)
                    {
                        SetFormAttributes(ref nextForm, currentForm, NavigationDirection.Backward);

                        if (currentForm is IViewWordListGrid)
                        {
                            currentForm.ConfirmNavigateToPreviousScreen = ConfirmNavigation.MoveToNextScreen;
                        }

                        nextForm.Show();
                    }
                }

                currentForm.Hide();
            }
        }
        private static void Form_NextScreen(object sender, EventArgs e)
        {
            IView currentForm = null;
            IView nextForm = null;
            
            currentForm = GetSendingForm(sender);

            var tst = currentForm.CurrentItem;

            if (currentForm != null)
            {
                if (!string.IsNullOrEmpty(currentForm.NextFormName) && currentForm.ConfirmNavigateToNextScreen == ConfirmNavigation.MoveToNextScreen)
                {
                    nextForm = forms.Where(c => c.Name.Equals(currentForm.NextFormName)).FirstOrDefault();
                    if (nextForm != null)
                    {
                        SetFormAttributes(ref nextForm, currentForm, NavigationDirection.Forward);
                        nextForm.RefreshData();
                        nextForm.Show();
                    }
                }

                currentForm.Hide();
            }
        }

        private static void Mamag(object sender, EventArgs e)
        {
            string s = "3";
        }

        private static IView GetSendingForm(object sender)
        {
            Control ctrl;
            IView sendingForm = sender as IView;

            if (sendingForm != null)
            {
                return sendingForm;
            }

            ctrl = sender as Control;

            sendingForm = GetParentRecursively(ctrl);

            return sendingForm;
        }

        //I created this bc sometimes controls are contained in more controls.  This walks up the container ladder
        private static IView GetParentRecursively(Control ctrl)
        {
            IView view = ctrl.Parent as IView;

            if (view != null)
            {
                return ctrl.Parent as IView;
            }
            else
            {
                return GetParentRecursively(ctrl.Parent.Parent);
            }
        }

        private static void SetFormAttributes(ref IView targetForm, IView sendingForm, NavigationDirection direction)
        {
            string sendingFormName = sendingForm.Name;
            string targetViewName = targetForm.Name;

            if (sendingForm is IViewWordListGrid)
            {
                targetForm.CurrentItem = sendingForm.CurrentItem;
            }
            else if (sendingForm is IViewLexiconEntryScreen)
            {

                //view.Psu = sendingForm.Psu;
            }
            

            if (direction == NavigationDirection.Forward)
            {
                if (sendingFormName.Equals(LEXICON_ENTRY_SCREEN))
                {
                    //No attributes needed to set
                }
                else if (sendingFormName.Equals(WORD_LIST_SCREEN))
                {

                }
            }
        }

        #endregion
    }
}
