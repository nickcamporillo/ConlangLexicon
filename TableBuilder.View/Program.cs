//[CBorillo] For the purpose of development in coordination with Marc Reber, length checking on the command lines will be disabled for now
#undef ENABLE_LENGTH_CHECKING

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TableBuilder.NET.Common;
using TableBuilder.NET.IViews;
using TableBuilder.NET.Presenters;
using System.Configuration;
using TableBuilder.NET.Services;
using System.Data.SQLite;
using System.Diagnostics;
using log4net.Appender;
using log4net.Config;
using log4net;
using log4net.Repository.Hierarchy;

namespace TableBuilder.NET
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
        private const string CONFIG_CNX_STRING = "CNX";

        //Exception message strings
        private const string ERR_GENERAL = "Please contact system administrator.";
        private const string ERR_GENERAL_CAPTION = "Issue initializing Builder Table application";
        //private const string ERR_INCORRECT_NUM_ARGS = "Number of parameters incorrect";
        //private const string ERR_INCORRECT_FORMAT_ARGS = "Parameter format incorrect";

        //User-input-related stuff
        private const char KEYPRESS_ENTER = '\r';
        private const char KEYPRESS_TAB = '\t';

        //Form-related stuff
        private static IList<IView> forms;

        private const string BPOID = "BPoid";
        private const string BUILDER = "Builder";
        private const string CONTACT = "Contact";
        private const string BUILDER_ENTRY = "BuilderEntry";

        private const int STARTING_FORM = 0;
        private const int STANDARD_FORM_SIZE = 321;

        #endregion


        //https://stackify.com/log4net-guide-dotnet-logging/
        //Recipe for simplified configuration by using app.config: https://www.codeproject.com/Tips/1107824/Perfect-Log-Net-with-Csharp
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] commandLine)
        {
            SetLogLocation(commandLine, "TableBuilder.log");

            log.Info($"== Begin Logging [{DateTime.Now.ToLocalTime()}] ==");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Error += Application_Error;
            Activate += Application_Activate;
            Deactivate += Application_Deactivate;

            RunProgram(commandLine);            
        }

        //Programatically set the log file's location dynamically to database's containing folder; how-to located here: https://stackoverflow.com/questions/17560396/log4net-how-to-set-logger-file-name-dynamically
        private static void SetLogLocation(string[] commandLine, string fileName)
        {
            CommandLineVals pVals = new CommandLineVals();
            bool commandLineisValid = ValidateCommandLine(commandLine, ref pVals);

            if (!commandLineisValid)
                return; //The value in the app.config will be used as a default value instead

            string logPath = (pVals.DatabasePath.EndsWith("\\") ? $@"{pVals.DatabasePath}{fileName}" : $@"{pVals.DatabasePath}\{fileName}");

            XmlConfigurator.Configure();
            Hierarchy heirarchy = (Hierarchy)LogManager.GetRepository();

            foreach (IAppender appender in heirarchy.Root.Appenders)
            {
                if (appender is FileAppender)
                {
                    FileAppender fa = (FileAppender)appender;
                    fa.File = logPath;
                    fa.ActivateOptions();
                    break;
                }
            }
        }

        private static void RunProgram(string[] commandLine)
        {
            ITableBuilderService service = null;
            StartupMessageWindow messager = new StartupMessageWindow();

            //Stuff vals from command line parameters into this convenience struct; see document "BTA System Interface v03.doc"
            try
            {
                CommandLineVals pVals = new CommandLineVals();
                bool commandLineisValid = ValidateCommandLine(commandLine, ref pVals);
                if (!commandLineisValid)
                {
                    log.Error($"Command line failed to validate {pVals.ToString()}");
                    throw new Exception(ERR_GENERAL);
                }

                //Note: You want only ONE service, so that all forms will have data in-sync;
                //Moreover, you need initialize it only once, and that would be out here
                //in class "Program"
                if (!string.IsNullOrWhiteSpace(pVals.DatabasePath))
                {
                    pVals.DatabasePath = (pVals.DatabasePath.EndsWith(@"\") ? pVals.DatabasePath : $@"{pVals.DatabasePath}\");

                    ConnectionStringSettingsCollection cnxStrings = ConfigurationManager.ConnectionStrings;
                    string cnxString = cnxStrings[CONFIG_CNX_STRING].ConnectionString;
                    cnxString = cnxString.Replace("*", pVals.DatabasePath);

                    SQLiteConnection cnx = new SQLiteConnection();
                    service = new TableBuilderService(cnx, pVals.SelectBCCFlag, pVals.Prod_or_Tran, pVals.Interview_Period, pVals.FRCode, pVals.Control_Number, pVals.CaseID, cnxString);
                }

                service.Activate();

                forms = new List<IView>();
                forms.Add(CreateForm(typeof(BPOID), service));
                forms.Add(CreateForm(typeof(Builder), service));
                forms.Add(CreateForm(typeof(Contact), service));

                Application.Run(forms[STARTING_FORM] as Form);
            }
            catch (Exception ex)
            {
                log.Error($"Exception: {ex.Message}");

                if (service != null)
                {
                    service.Dispose();
                    service = null;
                }

                messager.Message(ERR_GENERAL_CAPTION, ERR_GENERAL, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                messager.Dispose();
            }
        }
        
        //This is the Form Factory method
        private static IView CreateForm(Type typ, ITableBuilderService service)
        {
            IView form = null;
            IPresenter pres = null;            

            string versionNumber = ConfigurationManager.AppSettings[APP_VERSION_CONFIG].ToString();
            string prefix = $"Builder Table Application version {versionNumber} - ";
            string suffix = string.Empty;

            if (typ == typeof(BPOID))
            {
                suffix = "BPOID";
                pres = new BPoidPresenter(service);
                form = new BPOID(pres);
                form.Name = BPOID;
                form.PreviousFormName = string.Empty;
                form.NextFormName = BUILDER;

                //Set "false" for the Previous screen, bc this is the first screen (there's no previous screen to move to.
                //Since this is read-only screen, it should always have permission to move forward.
                form.ConfirmNavigateToPreviousScreen = ConfirmNavigation.StayOnCurrentScreen;
                form.ConfirmNavigateToNextScreen = ConfirmNavigation.MoveToNextScreen;
                form.CloseAll += Form_CloseAll;
            }
            else if (typ == typeof(Builder))
            {
                suffix = "Builder";
                pres = new BuilderPresenter(service);
                form = new Builder(pres);
                form.Name = BUILDER;
                form.PreviousFormName = BPOID;
                form.NextFormName = CONTACT;

                //This is also a read-only screen.  Since it's the middle screen, it should always have unconditional permission to move forward and backwards.
                form.ConfirmNavigateToPreviousScreen = ConfirmNavigation.MoveToNextScreen;
                form.ConfirmNavigateToNextScreen = ConfirmNavigation.MoveToNextScreen;

                //We assume next step is adding a Contact bc the grid will be populated at this point with the cursor
                //pointed at the first record on the grid.  Clicking on the "Add Builder" button should toggle
                //to AddBuilder mode to create a new Builder.
                ((IViewBuilder)form).EntryMode = BuilderEntryMode.Default;
                                
                ((IViewBuilder)form).AddContact += Program_AddContact;
                ((IViewBuilder)form).AddContact += Form_NextScreen;

                ((IViewBuilder)form).AddBuilder += Program_AddBuilder;
                ((IViewBuilder)form).AddBuilder += Form_NextScreen;

                form.CloseAll += Form_CloseAll;

            }

            else if (typ == typeof(Contact))
            {
                suffix = "Contact";
                pres = new ContactsPresenter(service);
                form = new Contact(pres);
                
                form.Name = CONTACT;
                form.PreviousFormName = BUILDER;
                form.NextFormName = string.Empty;

                //Set "false" for the Next screen, bc this is the last screen.  Because we are in the Factory method for these
                //forms, we *initialize* the capability to move to the previous screen, but this form in combination with its
                //Presenter is going to make the final decision on whether to set this flag to its ultimate value.
                form.ConfirmNavigateToPreviousScreen = ConfirmNavigation.MoveToNextScreen;
                form.ConfirmNavigateToNextScreen = ConfirmNavigation.StayOnCurrentScreen;

                form.CloseAll += Form_CloseAll;

                //Since this is the creation-point of the form, initialize to RO-mode only
                ((IViewContact)(form)).AddNewBuilder(false);
            }

            form.Text = prefix + suffix;
            if(form.GetType()==typeof(Form))
            {
                //Can't do the following - access is private:
                //((Form)(form)).CenterToScreen();

                //...and this executes too late, so you have to also do this inside the Form:
                //this.WindowState = FormWindowState.Maximized;

                //...however, these props are accessible here and occur at real-time
                ((Form)(form)).MaximizeBox = false;
                ((Form)(form)).MinimizeBox = true;
            }
            
            form.NextScreen += Form_NextScreen;
            form.PreviousScreen += Form_PreviousScreen;
            ((Form)(form)).FormClosing += Program_FormClosing;

            return form;
        }

        //If you don't do this, you won't have a PSU or BPOID to link it with the previous form.
        private static void Program_AddBuilder(object sender, EventArgs e)
        {
            IViewBuilder view = GetSendingForm(sender) as IViewBuilder;
            if (view != null)
            {
                IViewContact f = forms.Where(c => c.Name.Equals(CONTACT)).FirstOrDefault() as IViewContact;
                if (f != null)
                {
                    f.AddNewBuilder(true);
                    f.Clear();
                }
            }
        }

        //This method fires before "Form_NextScreen(object sender, EventArgs e)"
        //[Deprecate] I don't think this is being used anymore
        private static void Program_AddContact(object sender, EventArgs e)
        {
            IViewPlaceState view = GetSendingForm(sender) as IViewPlaceState;
            if (view != null)
            {
                IViewContact f = forms.Where(c => c.Name.Equals(CONTACT)).FirstOrDefault() as IViewContact;
                if (f != null)
                {
                    f.Psu = view.Psu;
                    f.Bpoid = view.Bpoid;
                    f.Place = view.Place;
                    f.State = view.PlaceState;
                    f.AddNewBuilder(true);                    
                }
            }
        }

        private static void Form_CloseAll(object sender, EventArgs e)
        {
            forms[2].Close();
            forms[1].Close();
            forms[0].Close();
            forms.Clear();
            forms = null;
        }

        //Invoke any cleanup if necessary
        private static void Program_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Actually, this means that the user may have clicked on the "x" button, in
            //which case ALL forms must release resources...actually, why not ask Mike?
            //Maybe we should disable the "x" button.

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
                        
                        if (currentForm is IViewContact)
                        {
                            ((IViewContact)(currentForm)).IsBuilderPropertiesChanged = false;
                            ((IViewContact)(currentForm)).IsContactPropertiesChanged = false;
                            ((IViewContact)(currentForm)).EntryMode = BuilderEntryMode.Default;
                            currentForm.ConfirmNavigateToPreviousScreen = ConfirmNavigation.MoveToNextScreen;

                            ((IViewContact)(currentForm)).AddNewBuilder(false);
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

            if (currentForm != null)
            {
                if (!string.IsNullOrEmpty(currentForm.NextFormName) && currentForm.ConfirmNavigateToNextScreen == ConfirmNavigation.MoveToNextScreen)
                {
                    nextForm = forms.Where(c => c.Name.Equals(currentForm.NextFormName)).FirstOrDefault();
                    if (nextForm != null)
                    {
                        SetFormAttributes(ref nextForm, currentForm, NavigationDirection.Forward);
                        nextForm.Show();
                    }
                }

                currentForm.Hide();
            }
        }
        private static IView GetSendingForm(object sender)
        {
            IView sendingForm = null; ;

            Control ctrl = sender as Control;
            if (ctrl != null && ctrl.Parent != null)
            {
                sendingForm = ctrl.Parent as IView;
                sendingForm = (sendingForm != null ? sendingForm : ((IView)sender));
            }
            else
            {
                sendingForm = ((IView)sender);
            }

            return sendingForm;
        }
        private static void SetFormAttributes(ref IView view, IView sendingForm, NavigationDirection direction)
        {
            string sendingFormName = sendingForm.Name;
            string targetViewName = view.Name;            

            //Suppose that IViewContact is in Add New Building mode.  The PlaceState is going to be empty...so when you return from IViewContact back to IViewBuilder, you don't want to
            //erase the value in IViewBuilder's PlaceState field...that's supposed to be based only on the value from the PlaceState field value of the preceding form, IViewBPOID.
            if (!(sendingForm is IViewContact))
            {
                view.Psu = sendingForm.Psu;
                view.Bpoid = sendingForm.Bpoid;
                view.Place = sendingForm.Place;
                view.PlaceState = sendingForm.PlaceState;
            }

            if (view is IViewBuilderCode)
            {
                if (view is IViewContact && ((IViewContact)(view)).EntryMode != BuilderEntryMode.AddBuilderAndContact)
                {
                    ((IViewBuilderCode)(view)).BuilderCode = Utilities.GetPropertyValue(sendingForm, "BuilderCode");
                }
            }
            
            if (direction == NavigationDirection.Forward)
            {
                if (sendingFormName.Equals(BPOID))
                {
                    //No attributes needed to set
                }
                else if (sendingFormName.Equals(BUILDER))
                {
                    //Need to set the Contact form to the appropriate mode.
                    //[CBorillo] 06/28/2018: I think we can get rid of this now, but do this only during last-cleanup, after all other refactoring is done.                   
                    if (sendingForm is IViewBuilder && ((IViewBuilder)sendingForm).EntryMode == BuilderEntryMode.AddBuilderAndContact && view is IViewContact)
                    {
                        ((IViewContact)(view)).EntryMode = BuilderEntryMode.AddBuilderAndContact;
                    }
                }
            }
            else if (direction == NavigationDirection.Backward)
            {

                if (sendingFormName.Equals(CONTACT))
                {
                    //Toggle off the "Add Builder" and "Add Contact Modes"...this is the only slightly tricky part in going backwards.
                   
                    if (sendingForm is IViewContact)
                    {
                        ((IViewContact)(sendingForm)).EntryMode = BuilderEntryMode.Default;

                        if (view is IViewBuilder)
                        {
                            ((IViewBuilder)(view)).EntryMode = BuilderEntryMode.Default;
                        }
                        
                    }                    
                }
            }
        }

        #endregion

        #region "Command-Line Helper Functions and Data Structures

        //[CBorillo] :Struct to store the command line values            
        //--- Here's a sample command line required, based on current SQLLite data: 
        //--> 75954,003055,201010SI,Y,par00001,00007,0005,T,000000000000000000000001,00000001,Data Source=C:\SONC\TableBuilder.NET\Data\BuilderTable.sqlite; Version=3    
        struct CommandLineVals
        {
            public string PSU;
            public string BPOID;
            public string Interview_Period;
            public string SelectBCCFlag;
            public string FRCode;
            public string Builder_Code;
            public string Contact_Code;
            public string Prod_or_Tran;
            public string Control_Number;
            public string CaseID;
            public string DatabasePath;

            public bool IsValidCommandLine()
            {
                const int LENGTH_PSU = 5;
                const int LENGTH_BPOID = 6;
                const int LENGTH_INTERVIEW_PERIOD = 8;
                const int LENGTH_BCC_FLAG = 1;
                const int LENGTH_FRCODE = 8;
                //const int LENGTH_BUILDER_CODE = 5;   //Per specs should be 10, but is only 5 in Sqlite; this parm is allowed to be empty bc it might be at a given session a Builder has not been created yet
                //const int LENGTH_CONTACT_CODE = 4;   //Per specs should be 9, but is only 4 in Sqlite; this parm is allowed to be empty bc if a Builder hasn't been created, it follows it can't have Contacts either
                const int LENGTH_PRD_TRN = 1;
                const int LENGTH_CONTROL = 24;
                const int LENGTH_CASEID = 8;

                bool retVal = true;

                retVal = IsCorrectLength(PSU, LENGTH_PSU) && IsCorrectLength(BPOID, LENGTH_BPOID) && IsCorrectLength(Interview_Period, LENGTH_INTERVIEW_PERIOD) && 
                    IsCorrectLength(SelectBCCFlag, LENGTH_BCC_FLAG) && IsCorrectLength(FRCode, LENGTH_FRCODE) && IsCorrectLength(Prod_or_Tran, LENGTH_PRD_TRN) &&                     
                    IsCorrectLength(Control_Number, LENGTH_CONTROL) && IsCorrectLength(CaseID, LENGTH_CASEID);

                if (retVal == false)
                    return retVal;

                //---- Now check for valid vals --------
                retVal = (Interview_Period.ToUpper().EndsWith("SI") || Interview_Period.ToUpper().EndsWith("SL") || Interview_Period.ToUpper().EndsWith("NP"));

                if (retVal == false)
                    return retVal;

                retVal = (SelectBCCFlag.ToUpper().EndsWith("Y") || SelectBCCFlag.ToUpper().EndsWith("N"));

                if (retVal == false)
                    return retVal;

                retVal = (Prod_or_Tran.ToUpper().EndsWith("P") || Prod_or_Tran.ToUpper().EndsWith("T"));

                return retVal;
            }

            public override string ToString()
            {
                return $"PSU={PSU}\nBPOID={BPOID}\nInterviewPeriod={Interview_Period}\nSelectBccFlag={SelectBCCFlag}\nFRCode={FRCode}\nBuilderCode={Builder_Code}\nContactCode={Contact_Code}\nProdOrTran={Prod_or_Tran}\nControlNumber={Control_Number}\nCaseId={CaseID}\n";
            }
            
            private bool IsCorrectLength(string target, int requiredLength)
            {
                bool retVal = false;

                retVal = !(string.IsNullOrWhiteSpace(target) || target.Length != requiredLength);

                return retVal;
            }            
        }

        private static bool ValidateCommandLine(string[] commandLine, ref CommandLineVals pVals)
        {
            string[] parms;
            bool isCommandLineParmsCorrect = false;
            bool retVal = false;

            //According to the orig VBA code, it's going to be one command line, with delimiter ","
            //During development, goto "TableBuilder.NET.View" project props and in textbox 
            //"Command Line Arguments" (in the "Debug" side menu) and enter appropriate vals.
            //Expect 10 values and stuff in the previous vars appropriately
            //Need a guard here!
            if (commandLine == null || commandLine.Length == 0)
            {
                log.Error("Command line is empty");
                throw new Exception(ERR_GENERAL);
            }

            if (commandLine != null && commandLine.Length > 0)
            {
                //We really should expect only array containing the commandline, but when the commandline[0] is split, there should be 11 vals
                parms = commandLine[0].Split(',');

                //Need a guard here!
                if (parms == null || parms.Length < 10)
                {
                    log.Error("Null parameters found; pass empty parameters as comma-delimited args");
                    throw new Exception(ERR_GENERAL);
                }

                pVals.PSU = parms[0];
                pVals.BPOID = parms[1];
                pVals.Interview_Period = parms[2];
                pVals.SelectBCCFlag = parms[3];
                pVals.FRCode = parms[4];
                pVals.Builder_Code = parms[5];
                pVals.Contact_Code = parms[6];
                pVals.Prod_or_Tran = parms[7];
                pVals.Control_Number = parms[8];
                pVals.CaseID = parms[9];
                
                if(parms.Length == 11)
                    pVals.DatabasePath = parms[10];
            }

#if ENABLE_LENGTH_CHECKING

            isCommandLineParmsCorrect = pVals.IsValidCommandLine();
            if (!isCommandLineParmsCorrect)
            {
                log.Error("Incorrect parameter format");
                throw new Exception(ERR_GENERAL);
            }
#endif
            retVal = true;
            return retVal;
        }
#endregion

#region "Other Helper funcs"
        static bool Authenticate()
        {
            bool retVal = false;
            string jamesBond = Utilities.GetJamesBond();

            return retVal;
        }
        static void Application_Activate(object sender, EventArgs e)
        {
            //set the property to our new object
            log4net.LogicalThreadContext.Properties["activityid"] = new ActivityIdHelper();

            log.Debug("Application_Activate");
        }

        static void Application_Deactivate(object sender, EventArgs e)
        {
            //set the property to our new object
            log4net.LogicalThreadContext.Properties["activityid"] = new ActivityIdHelper();
            log.Debug("Application_Deactivate");
        }

        static void Application_Error(object sender, EventArgs e)
        {
            //set the property to our new object
            log4net.LogicalThreadContext.Properties["activityid"] = new ActivityIdHelper();
            log.Debug("Application_Error");
        }


#endregion
    }

    public class ActivityIdHelper
    {
        public override string ToString()
        {
            if (Trace.CorrelationManager.ActivityId == Guid.Empty)
            {
                Trace.CorrelationManager.ActivityId = Guid.NewGuid();
            }

            return Trace.CorrelationManager.ActivityId.ToString();
        }
    }
}
