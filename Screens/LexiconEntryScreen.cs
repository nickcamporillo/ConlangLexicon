using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using IPresenters;
using IViews;
using Presenters;

namespace Screens
{
    public partial class LexiconEntryScreen : Form, IViewLexiconEntryScreen
    {
        private LexiconEntryPresenter _presenter;

        #region "Properties"

        public EventHandler CallSave;

        public event EventHandler UpdateItem;
        public event EventHandler NextScreen;
        public event EventHandler PreviousScreen;
        public event EventHandler CloseAll;

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

            _presenter = presenter as LexiconEntryPresenter;
            this.Load += Screen_Load;
            //this.Load += RedrawFormOnInit;
        }

        private void Screen_Load(object sender, EventArgs e)
        {

            //Set whatever initializations have to be done before re-drawing the Form, such as calling these 2 private/internal methods/props
            //(they can't be set by the Form Factory due to access level) and setting up other Event handlers
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;

            LoadEventHandlers();

            //Activated += ((BuilderPresenter)(_presenter)).RefreshBuilderDataBinding;
            //Activated += UpdateItem; //See Presenter. This is hooked up to "RefreshBuilder(object sender, EventArgs e)"
        }

        private void LoadEventHandlers()
        {            
            tabControl1.Location = new Point(this.Width / 4, tabControl1.Location.Y + 30);
            tabControl1.Height = tabControl1.Height + 30;
            panelDateControl.Location = new Point(tabControl1.Right / 2 - 30, panelDateControl.Location.Y);

            btnFirst.Click += new EventHandler(MoveFirst);
            btnLast.Click += new EventHandler(MoveLast);

            btnNext.Click += new EventHandler(MoveNext);
            btnPrevious.Click += new EventHandler(MovePrevious);

            btnCancelTab1.Click +=new EventHandler(Cancel);
            btnCancelTab2.Click += new EventHandler(Cancel);

            btnSaveTab1.Click += new EventHandler(Save);
            btnSaveTab2.Click += new EventHandler(Save);

            btnAdd.Click += new EventHandler(Add);

            SetFormNavigationHandlers();
        }

        private void SetFormNavigationHandlers()
        {
            //btnBackToBpoid.Click += PreviousScreen;
            btnGotoWordListGrid.Click += NextScreen;
            //btnF10.Click += CloseAll;
        }

        public void MovePrevious(object sender, EventArgs e)
        {
            MessageBox.Show("backward");
        }

        public void MoveNext(object sender, EventArgs e)
        {
            MessageBox.Show("forward");
        }

        public void MoveFirst(object sender, EventArgs e)
        {
            MessageBox.Show("first");
        }

        public void MoveLast(object sender, EventArgs e)
        {
            MessageBox.Show("last");
        }

        public void Cancel(object sender, EventArgs e)
        {
            MessageBox.Show("cancel");
        }

        public void Add(object sender, EventArgs e)
        {
            MessageBox.Show("add new record");
        }

        public void Save(object sender, EventArgs e)
        {
            //string sql = CreateSqlInsert();

            if(CallSave != null)            
                CallSave.Invoke(this, new EventArgs());

            MessageBox.Show("save changes");
        }

        public void Close(object sender, EventArgs e)
        {
            string sql = CreateSqlInsert();

            MessageBox.Show("save changes");
        }

        private string CreateSqlInsert()
        {
            string sqlInsert = string.Empty;

            string substring1 = "'LanguageId','Entry','IPA','Meaning','SecondaryMeanings','Synonyms','Dialect','Register','Gender','NounIncorporatedForm','Pos','PosSubtype','Domain','Etymology','GrammaticalNotes','AdditionalNotes','AlternateForms','EntryDate','DeactivatedDate'";
            string substring2 = "{0},N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16}',N'{17}',N'{18}'";
            List<string> items = new List<string>();
            
            items.Add(LanguageId.ToString());
             
            Entry = (string.IsNullOrEmpty(Entry) ? "" :  Entry);            
            IPA = (string.IsNullOrEmpty(IPA) ? "" : IPA);             
            Meaning = (string.IsNullOrEmpty(Meaning) ? "" : Meaning);            
            SecondaryMeanings = (string.IsNullOrEmpty(SecondaryMeanings) ? "" : SecondaryMeanings);            
            Synonyms = (string.IsNullOrEmpty(Synonyms) ? "" :  Synonyms);       
            
            Dialect = (string.IsNullOrEmpty(Dialect) ? "" : Dialect);            
            Register = (string.IsNullOrEmpty(Register) ? "" : Register);

            Gender = (string.IsNullOrEmpty(Gender) ? "" : Gender);            
            NounIncorporatedForm = (string.IsNullOrEmpty(NounIncorporatedForm) ? "" : NounIncorporatedForm);            
            Pos = (string.IsNullOrEmpty(Pos) ? "" : Pos);            
            PosSubtype = (string.IsNullOrEmpty(PosSubtype) ? "" : PosSubtype);            
            Domain = (string.IsNullOrEmpty(Domain) ? "" : Domain);
            
            Etymology = (string.IsNullOrEmpty(Etymology) ? "" : Etymology);            
            GrammaticalNotes = (string.IsNullOrEmpty(GrammaticalNotes) ? "" :GrammaticalNotes);            
            AdditionalNotes = (string.IsNullOrEmpty(AdditionalNotes) ? "" : AdditionalNotes);            
            AlternateForms = (string.IsNullOrEmpty(AlternateForms) ? "" : AlternateForms);
            
            EntryDate = (string.IsNullOrEmpty(EntryDate) ? "" : EntryDate);             
            DeactivatedDate = (string.IsNullOrEmpty(DeactivatedDate) ? "" : DeactivatedDate);	

            items.Add(Entry);
            items.Add(IPA);
            items.Add(Meaning);
            items.Add(SecondaryMeanings);
            items.Add(Synonyms);

            items.Add(Dialect);
            items.Add(Register);

            items.Add(Gender);
            items.Add(NounIncorporatedForm);
            items.Add(Pos);
            items.Add(PosSubtype);
            items.Add(Domain);

            items.Add(Etymology);
            items.Add(GrammaticalNotes);
            items.Add(AdditionalNotes);
            items.Add(AlternateForms);
            items.Add(EntryDate);
            items.Add(DeactivatedDate);

            sqlInsert = string.Format("INSERT INTO LexiconRaw (" + substring1 + ") VALUES (" + substring2 + ")", items.ToArray());

            return sqlInsert;
        }

        public object Datasource
        {
            get; set;
        }

        public object CurrentItem
        {
            get; set;
        }

        public string PreviousFormName { get; set; }
        public string NextFormName { get; set; }
        public ConfirmNavigation ConfirmNavigateToPreviousScreen { get; set; }
        public ConfirmNavigation ConfirmNavigateToNextScreen { get; set; }
    }
}