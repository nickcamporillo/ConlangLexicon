﻿using System;
using System.Drawing;
using System.Windows.Forms;
using IPresenters;
using IViews;
using Models;
using Presenters;
using Services;

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

        public int Id
        {
            get { return int.Parse(lblId.Text); }
            set { lblId.Text = value.ToString();}
        }

        public int LanguageId 
        {
            get 
            {
                var retVal = 0;
                bool success = int.TryParse(lblLanguageId.Text, out retVal);
 
                return (success ? retVal : -99); 
            }
            set
            {
                lblLanguageId.Text = value.ToString();
            } 
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
            SetTabOrder();
            //Activated += ((BuilderPresenter)(_presenter)).RefreshBuilderDataBinding;
            //Activated += UpdateItem; //See Presenter. This is hooked up to "RefreshBuilder(object sender, EventArgs e)"
        }

        private void LoadEventHandlers()
        {
            btnFirst.Click += Message;
            btnFirst.Click += SaveRecord;
            btnFirst.Click += MoveFirstRecord;            

            btnLast.Click += Message;
            btnLast.Click += SaveRecord;
            btnLast.Click += MoveLastRecord;            

            btnNext.Click += Message;
            btnNext.Click += SaveRecord;
            btnNext.Click += MoveNextRecord;

            btnPrevious.Click += Message;
            btnPrevious.Click += SaveRecord;
            btnPrevious.Click += MovePreviousRecord;

            btnCancelTab1.Click += Cancel;
            btnCancelTab2.Click += Cancel;

            btnSaveTab1.Click += SaveRecord;
            btnSaveTab2.Click += SaveRecord;

            btnAdd.Click += Message;
            btnAdd.Click += SaveRecord;
            btnAdd.Click += AddRecord;
        }
        private void SetTabOrder()
        {
            txtEntry.TabIndex = 1;
            txtMeaning.TabIndex = 2;
            txtSecondaryMeanings.TabIndex = 3;
            txtNounIncorporatedForm.TabIndex = 4;
            txtAlternateForms.TabIndex = 5;
            txtGender.TabIndex = 6;
            txtPos.TabIndex = 7;
            txtPosSubtype.TabIndex = 8;
            txtDomain.TabIndex = 9;
            txtIPA.TabIndex = 10;

            panelDialectAndRegister.TabIndex = 11;

            txtDialect.TabIndex = 13;
            txtRegister.TabIndex = 14;
            btnSaveTab1.TabIndex = 15;
            btnAdd.TabIndex = 16;
            btnCancelTab1.TabIndex = 17;
            btnGotoWordListGrid.TabIndex = 18;

            panelEtymologyAndSynonyms.TabIndex = 19;

            txtEtymology.TabIndex = 20;
            txtSynonyms.TabIndex = 21;

            panelNotes.TabIndex = 22;
            txtGrammaticalNotes.TabIndex = 23;
            
            txtAdditionalNotes.TabIndex = 24;

            btnSaveTab2.TabIndex = 101;
            btnCancelTab2.TabIndex = 102;
            btnReturnToWordListGrid.TabIndex = 103;

            panelDateControl.TabIndex = 200;
            btnDeactivate.TabIndex = 201;
            btnReactivate.TabIndex = 202;

        }
        public void RefreshData()
        {
            PageMoveCompleted?.Invoke(this, new EventArgs());
        }

        private void SetFormNavigationHandlers()
        {
            btnGotoWordListGrid.Click += ClearAll;
            btnGotoWordListGrid.Click += NextScreen;

            btnReturnToWordListGrid.Click += ClearAll;
            btnReturnToWordListGrid.Click += NextScreen;
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

            IsAddingNewRecord = false;
        }

        public override void Refresh()
        {

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
            _msg = "Click 'Ok' to continue.";
            try
            {
                UpdateItem?.Invoke(sender, e);
                IsAddingNewRecord = false;
                MessageBox.Show(_msg, "Record Saved", MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Check log", "Record NOT Saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
            }
        }

        public void Close(object sender, EventArgs e)
        {
            //stuff here
        }

        private void Message(object sender, EventArgs e)
        {
            MessageBox.Show(_msg);
        }

        public object Datasource
        {
            get;
            set;
        }

        public object CurrentItem
        {
            get;
            set;
        }

        public string PreviousFormName { get; set; }
        public string NextFormName { get; set; }
        public ConfirmNavigation ConfirmNavigateToPreviousScreen { get; set; }
        public ConfirmNavigation ConfirmNavigateToNextScreen { get; set; }
    }
}