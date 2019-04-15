using System;
using System.Drawing;
using System.Windows.Forms;
using IPresenters;
using IViews;
using Models;
using Presenters;
using LexServices;

namespace TestScreens
{
    public partial class LexiconEntryScreen : Form, IViewLexiconEntryScreen
    {
        private LexiconEntryPresenter<LexiconRaw,ILexiconService<LexiconRaw>> _presenter;

        public event EventHandler PageMoveCompleted;

        public event EventHandler Insert;
        public event EventHandler Delete;
        public event EventHandler UpdateItem;
        public event EventHandler NextScreen;
        public event EventHandler PreviousScreen;
        public event EventHandler CloseAll;
        public event EventHandler RecordChanged;

        private string _msg = string.Empty;

        #region "Properties"

        private bool _isAdding = false;
        public bool IsAddingNewRecord
        {
            get { return lblMode.Text.Equals("Adding"); }
            set { lblMode.Text = (value ? "Adding" : "Editing"); }
        }

        public object Datasource { get; set; }
        public object CurrentItem { get; set; }

        public string PreviousFormName { get; set; }
        public string NextFormName { get; set; }
        public ConfirmNavigation ConfirmNavigateToPreviousScreen { get; set; }
        public ConfirmNavigation ConfirmNavigateToNextScreen { get; set; }

        public int Id
        {
            get { return int.Parse(lblId.Text); }
            set { lblId.Text = value.ToString();}
        }

        public string LanguageId 
        {
            get {return lblLanguageId.Text; }
            set {lblLanguageId.Text = value;} 
        }

        public string Entry 
        { 
            get { return txtEntry.Text; } 
            set 
            { 
                txtEntry.Text = value;
                txtEntryDisplay.Text = value;
            } 
        }

        public string Meaning 
        { 
            get { return txtMeaning.Text; } 
            set 
            { 
                txtMeaning.Text = value;
                txtMeaningDisplay.Text = value;
            } 
        }

        public string SecondaryMeanings { get { return txtSecondaryMeanings.Text; } set { txtSecondaryMeanings.Text = value; } }

        public string Pos { get { return txtPos.Text; } set { txtPos.Text = value; } }

        public string PosSubtype { get { return txtPosSubtype.Text; } set { txtPosSubtype.Text = value; } }

        public string Gender { get { return txtGender.Text; } set { txtGender.Text = value; } }

        public string NounIncorporatedForm { get { return txtNounIncorporatedForm.Text; } set { txtNounIncorporatedForm.Text = value; } }

        public string AlternateForms { get { return txtAlternateForms.Text; } set { txtAlternateForms.Text = value; } }

        public string Dialect { get { return txtDialect.Text; } set { txtDialect.Text = value; } }

        public string Register { get { return txtRegister.Text; } set { txtRegister.Text = value; } }

        public string Domain { get { return txtDomain.Text; } set { txtDomain.Text = value; } }

        public string Synonyms { get { return txtSynonyms.Text; } set { txtSynonyms.Text = value; } }

        public string Etymology { get { return txtEtymology.Text; } set { txtEtymology.Text = value; } }

        public string IPA { get { return txtIPA.Text; } set { txtIPA.Text = value; } }

        public string GrammaticalNotes { get { return txtGrammaticalNotes.Text; } set { txtGrammaticalNotes.Text = value; } }

        public string AdditionalNotes { get { return txtAdditionalNotes.Text; } set { txtAdditionalNotes.Text = value; } }

        public string EntryDate { get { return txtEntryDate.Text; } set { txtEntryDate.Text = value; } }

        public string DeactivatedDate { get { return txtDeactivatedDate.Text; } set { txtDeactivatedDate.Text = value; } }
        #endregion

        public LexiconEntryScreen()
        {
            InitializeComponent();
        }

        public LexiconEntryScreen(IPresenter presenter)
        {
            InitializeComponent();

            _presenter = presenter as LexiconEntryPresenter<LexiconRaw, ILexiconService<LexiconRaw>>;
        }

        private void Screen_Load(object sender, EventArgs e)
        {
            //Set whatever initializations have to be done before re-drawing the Form, such as calling these 2 private/internal methods/props
            //(they can't be set by the Form Factory due to access level) and setting up other Event handlers
            CenterToScreen();
            WindowState = FormWindowState.Maximized;
            tabControl1.Location = new Point(this.Width / 4, tabControl1.Location.Y + 30);
            tabControl1.Height = tabControl1.Height + 30;
            panelDateControl.Location = new Point(tabControl1.Right / 2 - 30, panelDateControl.Location.Y);

            LoadEventHandlers();
            SetFormNavigationHandlers();
           
        }

        private void LoadEventHandlers()
        {
            btnNext.Click += Message;
            btnNext.Click += SaveRecord;
            btnNext.Click += MoveNextRecord;

            btnPrevious.Click += Message;
            btnPrevious.Click += SaveRecord;
            btnPrevious.Click += MovePreviousRecord;

            btnCancelTab1.Click += Cancel;
            btnCancelTab1.Click += EnableButtonsOnSaveOrCancelOrReturn;

            btnCancelTab2.Click += Cancel;
            btnCancelTab2.Click += EnableButtonsOnSaveOrCancelOrReturn;
            //btnCancelTab1.Click += SetAddModeOff;  (No, you might be in the middle of an Add, and want to restart your Add again!)

            btnSaveTab1.Click += SaveRecord;
            btnSaveTab1.Click += EnableButtonsOnSaveOrCancelOrReturn;
            btnSaveTab1.Click += SetAddModeOff;

            btnSaveTab2.Click += SaveRecord;
            btnSaveTab2.Click += EnableButtonsOnSaveOrCancelOrReturn;
            btnSaveTab2.Click += SetAddModeOff;

            btnReturntoWordListGrid.Click += PromptSaveOnDepartIfChanged;
            btnReturntoWordListGrid.Click += SetAddModeOff;
            btnReturntoWordListGrid.Click += ReturnToPreviousScreen;

            btnAdd.Click += DisableButtonsOnAdd;
            btnAdd.Click += Message;
        }

        private void SetAddModeOff(object sender, EventArgs e)
        {
            IsAddingNewRecord = false;
        }

        private void ReturnToPreviousScreen(object sender, EventArgs e)
        {
            PreviousScreen?.Invoke(sender, e);
        }

        private void PromptSaveOnDepartIfChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Add code here - use PropertyChangedEvents", "Not implemented",MessageBoxButtons.OK);
        }

        private void DisableButtonsOnAdd(object sender, EventArgs e)
        {
            ToggleButtonEnabling(false);
        }

        private void EnableButtonsOnSaveOrCancelOrReturn(object sender, EventArgs e)
        {
            ToggleButtonEnabling(true);
        }

        private void ToggleButtonEnabling(bool enable)
        {
            btnDeactivate.Enabled = enable;
            btnReactivate.Enabled = enable;
            btnFirst.Enabled = enable;
            btnLast.Enabled = enable;
            btnNext.Enabled = enable;
            btnPrevious.Enabled = enable;
            btnAdd.Enabled = enable;
        }

        public void RefreshData()
        {
            PageMoveCompleted?.Invoke(this, new EventArgs());
        }

        private void SetFormNavigationHandlers()
        {
            btnReturntoWordListGrid.Click += ClearAll;
            btnReturntoWordListGrid.Click += NextScreen;
            //btnF10.Click += CloseAll;
        }

        private void ClearAll(object sender, EventArgs e)
        {
            Id = 0;
            Entry = string.Empty;
            IPA = string.Empty;
            Meaning = string.Empty;
            SecondaryMeanings = string.Empty;
            Synonyms = string.Empty;

            Dialect = string.Empty;
            Register = string.Empty;

            Gender = string.Empty;
            NounIncorporatedForm = string.Empty;
            Pos = string.Empty;
            PosSubtype = string.Empty;
            Domain = string.Empty;

            Etymology = string.Empty;
            GrammaticalNotes = string.Empty;
            AdditionalNotes = string.Empty;
            AlternateForms = string.Empty;
            EntryDate = string.Empty;
            DeactivatedDate = string.Empty;
        }

        public void MovePreviousRecord(object sender, EventArgs e)
        {
            _msg = "Previous record";
        }

        public void MoveNextRecord(object sender, EventArgs e)
        {
            //stuff here
            _msg = "Next record";
        }

        public void MoveFirstRecord(object sender, EventArgs e)
        {
            _msg = "First record";
        }

        public void MoveLastRecord(object sender, EventArgs e)
        {
            //stuff here
            _msg = "Last record";
        }

        public void Cancel(object sender, EventArgs e)
        {
            //stuff here
            _msg = "Cancel";
        }

        public void AddRecord(object sender, EventArgs e)
        {
            //stuff here
            _msg = "Add record";
        }

        public void SaveRecord(object sender, EventArgs e)
        {
            _msg = "Saving record";
            UpdateItem?.Invoke(sender, e);
        }

        public void Close(object sender, EventArgs e)
        {
            //stuff here
        }

        private void Message(object sender, EventArgs e)
        {
            MessageBox.Show(_msg);
        }

        public void OnMoveCompleted(object sender, EventArgs e)
        {            
            PageMoveCompleted?.Invoke(sender, e);
            txtEntry.Focus();
            txtEntry.SelectAll();
        }
    }
}