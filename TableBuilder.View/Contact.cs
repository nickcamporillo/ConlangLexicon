using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using TableBuilder.NET.Common;
using TableBuilder.NET.IViews;
using TableBuilder.NET.Presenters;
using System.Collections.Generic;

namespace TableBuilder.NET
{
    public partial class Contact : Form, IViewContact, IView//, IViewDebug
    {
        public event PropertyChangedEventHandler BuilderInfoChanged;
        public event PropertyChangingEventHandler BuilderInfoChanging;

        public event PropertyChangedEventHandler ContactInfoChanged;
        public event PropertyChangingEventHandler ContactInfoChanging;

        public event EventHandler NextScreen;
        public event EventHandler PreviousScreen;
        public event EventHandler ReturnHome;
        public event EventHandler CloseAll;
        public event EventHandler UpdateItem;
        public event EventHandler MarkForDeletion;
        public event EventHandler UnmarkForDeletion;
        public event EventHandler ToggleDeletion;
        public event EventHandler SettingStatus;

        public event EventHandler RecordChange;

        public event EventHandler PreEdit;
        public event KeyPressEventHandler TextDataChanged;

        public event EventHandler AddBuilder;
        public event EventHandler AddContact;
        public event EventHandler AssignContact;
        public event EventHandler ContactMaximumReached;

        public event EventHandler SaveContact;
        public event EventHandler SaveNewContact;
        public event EventHandler SaveBuilder;
        public event EventHandler SaveAll;
        public event EventHandler SaveUponPrompt;

        public event EventHandler StateSelected;

        public event EventHandler Reinit;
        public event EventHandler RefreshScreenFromPreviousScreen;
        public event EventHandler Cancel;       

        private IPresenter _presenter;

        private const string MSG_SAVE_ON_DEPART = "Do you want to save the changes you just made to the builder contact form?";

        #region Properties
        public bool AddAllowed
        {
            get { return btnAddContact.Enabled; }
            set
            {
                btnAddContact.Enabled = value;
            }
        }

        public string Debugger
        {
            get { return txtDebug.Text; }
            set { txtDebug.Text = value; }
        }

        public string Debugger_2
        {
            get { return txtDebug_2.Text; }
            set { txtDebug_2.Text = value; }
        }

        public ConfirmNavigation ConfirmNavigateToPreviousScreen { get; set; }
        public ConfirmNavigation ConfirmNavigateToNextScreen { get; set; }
        public bool SaveOnDepart { get; set; }
        public bool FinishedLoading
        {
            get { return uiContactInfo.IsLoaded; }
            set {; }
        }
        public bool IsBuilderPropertiesChanged
        {
            get { return uiBuilderInfo.IsChanged; }
            set
            {
                uiBuilderInfo.IsChanged = value;                
            }
        }
        public bool IsContactPropertiesChanged
        {
            get { return uiContactInfo.IsChanged; }
            set
            {
                uiContactInfo.IsChanged = value;
            }
        }
        public bool EnableContactEntry
        {
            get { return btnAddContact.Enabled;}
            set { btnAddContact.Enabled = value;}
        }
        public string ContactCode
        {
            get { return uiContactInfo.ContactCode; }
            set
            {
                txContactCode.Text = value;
                uiContactInfo.ContactCode = value;
            }
        }
        public string PreviousFormName { get; set; }
        public string NextFormName { get; set; }               
        public BuilderEntryMode EntryMode { get; set; }
        public bool AddNewContact { get; set; }
        public object Datasource { get; set; }
        public object CurrentItem
        {
            get
            {
                return (dgContacts.CurrentRow != null ? dgContacts.CurrentRow.DataBoundItem : null);
            }
            set {; }
        }
        public object DatasourceBuilders { get; set; }
        public object DatasourceContactItem
        {
            get {  return (dgContacts.CurrentRow != null ? dgContacts.CurrentRow.DataBoundItem : null);}
            set {;}
        }
        public object DatasourceContacts
        {
            get { return dgContacts.DataSource; }
            set { dgContacts.DataSource = value; }
        }
        public object DatasourceStates
        {
            get { return uiBuilderInfo.Datasource; }
        }
        public string State
        {
            get { return uiBuilderInfo.BuilderState; }
            set
            {
                uiBuilderInfo.BuilderState = value;
            }
        }
        public string Place
        {
            get { return placeHeader.Place; }
            set { placeHeader.Place = value; }
        }
        public string PlaceState
        {
            get { return placeHeader.PlaceState; }
            set { placeHeader.PlaceState = value; }
        }
        public string Psu
        {
            get { return placeHeader.Psu; }
            set { placeHeader.Psu = value; }
        }
        public string Bpoid
        {
            get { return placeHeader.Bpoid; }
            set { placeHeader.Bpoid = value; }
        }
        public string BuilderCode
        {
            get { return txtBuilderCode.Text; }
            set
            {
                txtBuilderCode.Text = value;
                uiBuilderInfo.BuilderCode = value;
            }
        }
        public string BuilderName
        {
            get { return uiBuilderInfo.BuilderName; }
            set { uiBuilderInfo.BuilderName = value;}
        }
        public string BuilderAddress
        {
            get { return uiBuilderInfo.BuilderAddress; }
            set { uiBuilderInfo.BuilderAddress = value; }
        }
        public string BuilderPostOffice
        {
            get { return uiBuilderInfo.BuilderPostOffice; }
            set
            {
                uiBuilderInfo.BuilderPostOffice = value;
            }
        }
        public string Zip
        {
            get { return uiBuilderInfo.Zip; }
            set { uiBuilderInfo.Zip = value; }
        }
        public string BuilderState
        {
            get { return uiBuilderInfo.BuilderState; }
            set { uiBuilderInfo.BuilderState = value; }
        }
        public string ContactName
        {
            get { return uiContactInfo.ContactName; }
            set { uiContactInfo.ContactName = value; }
        }
        public string Phone_1
        {
            get { return uiContactInfo.FirstPhone; }
            set { uiContactInfo.FirstPhone = value; }
        }
        public string PhoneExt_1
        {
            get { return uiContactInfo.FirstPhoneExt; }
            set { uiContactInfo.FirstPhoneExt = value; }
        }
        public string PhoneType_1
        {
            get { return uiContactInfo.FirstPhoneType; }
            set { uiContactInfo.FirstPhoneType = value; }
        }
        public string Phone_2
        {
            get { return uiContactInfo.SecondPhone; }
            set { uiContactInfo.SecondPhone = value; }
        }
        public string PhoneExt_2
        {
            get { return uiContactInfo.SecondPhoneExt; }
            set { uiContactInfo.SecondPhoneExt = value; }
        }
        public string PhoneType_2
        {
            get { return uiContactInfo.SecondPhoneType; }
            set { uiContactInfo.SecondPhoneType = value; }
        }
        public string Phone_3
        {
            get { return uiContactInfo.ThirdPhone; }
            set { uiContactInfo.ThirdPhone = value; }
        }
        public string PhoneExt_3
        {
            get { return uiContactInfo.ThirdPhoneExt; }
            set { uiContactInfo.ThirdPhoneExt = value; }
        }
        public string PhoneType_3
        {
            get { return uiContactInfo.ThirdPhoneType; }
            set { uiContactInfo.ThirdPhoneType = value; }
        }
        public string BestTimeCall
        {
            get { return uiContactInfo.BestTimeToCall; }
            set { uiContactInfo.BestTimeToCall = value; }
        }
        public string ContactNotes
        {
            get { return uiContactInfo.ContactNotes; }
            set { uiContactInfo.ContactNotes = value; }
        }
        public string LastDateAssigned
        {
            get { return uiContactInfo.LastDateAssigned; }
            set { uiContactInfo.LastDateAssigned = value; }
        }
        public string DateAdded
        {
            get { return uiContactInfo.DateAdded; }
            set { uiContactInfo.DateAdded = value; }
        }
        public string MarkedForDeletion
        {
            get { return uiContactInfo.MarkForDeletion == true ? "Yes" : "No"; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    uiContactInfo.MarkForDeletion = (value.ToUpper().Equals("YES") || value.Equals("1") ? true : false);
                }
            }
        }
        public OutcomeInfo OutcomeMessage
        {
            get;set;
        }

        public bool EnableFileOutput
        {
            get { return btnWriteFiles.Enabled; }
            set { btnWriteFiles.Enabled = value; }
        }
        #endregion
        public Contact()
        {
            InitializeComponent();          
        }
        public Contact(IPresenter presenter)
        {
            InitializeComponent();
            
            _presenter = presenter;

            btnAddContact.Click += ClearContactWidgetForNewContactEntry;

            //Presenter.Setup(this) must happen immediately after assignment to the private "_presenter" field, here in the Constructor!!!
            _presenter.Setup(this);  

            this.Load += Contact_Load;
            this.Load += RefreshScreenFromPreviousScreen;

            //Attaching to the Activated event must happen, here in the Constructor, before the Load event!!!
            //Otherwise the fields in the Form won't be updated when you first enter it - they'll be empty!!!
            this.Activated += UpdateItem;
        }
        private void Contact_Load(object sender, EventArgs e)
        {
            //Set whatever initializations have to be done before re-drawing the Form, such as calling these 2 private/internal methods/props
            //(they can't be set by the Form Factory due to access level) and setting up other Event handlers
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
            dgContacts.Width = 1000;

            Activated += ReinitializeBuilderUserControl;

            LoadEventHandlers();
            
            //This will disable the uiContactControl if need be (e.g. the 9-Contact threshold has been reached) 
            PreEdit.Invoke(sender, e);
        }

        private void ReinitializeBuilderUserControl(object sender, EventArgs e)
        {
            PreEdit.Invoke(sender, e);
        }

        private void LoadEventHandlers()
        {            
            dgContacts.SelectionChanged += RecordChange;
            dgContacts.DataSourceChanged += ReformatContactsGrid;

            //Presenter's eventhandlers attached to the BuilderInfo UI
            //uiBuilderInfo.PropertyChanged += UiBuilderInfo_PropertyChanged;
            uiBuilderInfo.TextDataChanged += TextDataChanged;
            uiBuilderInfo.SelectedStateChanged += StateSelected;
            uiBuilderInfo.PropertyChanged += BuilderInfoChanged;
            uiBuilderInfo.PropertyChanging += BuilderInfoChanging;

            uiBuilderInfo.WireBuilderControlEvents();

            //Presenter's eventhandlers attached to the ContactInfo UI
            uiContactInfo.TextDataChanged += TextDataChanged;
            uiContactInfo.SelectedItemChanged += ToggleDeletion;
            uiContactInfo.PropertyChanged += ContactInfoChanged;
            uiContactInfo.PropertyChanging += ContactInfoChanging;

            uiContactInfo.WireBuilderControlEvents();

            btnAddContact.Click += PreEdit;
            //Supposed to prepare for a new Contact, not actually save it by clearing out the Contact block fields              
            btnAddContact.Click += AddContact;
            btnAssignContact.Click += AssignContact;

            //Saving evenhandlers
            btnSaveEdits.Click += SaveEdits;
            btnBackToBuilders.Click += SaveAndLeave;

            btnCancel.Click += CancelChanges;

            btnBackToBuilders.Click += PreviousScreen;
            btnF10.Click += CloseAll;
        }

        private void SaveAndLeave(object sender, EventArgs e)
        {            
            bool retVal = ((ContactsPresenter)(_presenter)).DataHasChanged();
            if (retVal)
            {
                //Buffer variables to counteract the auto-refresh of the Activated event, which reverts the widgets back to their original vals:
                string builderName = BuilderName;
                string builderAddress = BuilderAddress;
                string builderPostOffice = BuilderPostOffice;
                string builderState = BuilderState;
                string builderZip = Zip;

                string contactName = ContactName;
                string contactCode = ContactCode;
                string contactNotes = ContactNotes;

                string phone_1 = Phone_1;
                string phone_2 = Phone_2;
                string phone_3 = Phone_3;
                string phoneExt_1 = PhoneExt_1;
                string phoneExt_2 = PhoneExt_2;
                string phoneExt_3 = PhoneExt_3;
                string phoneType_1 = PhoneType_1;
                string phoneType_2 = PhoneType_2;
                string phoneType_3 = PhoneType_3;

                string markedForDeletion = MarkedForDeletion;
                string lastDateAssigned = LastDateAssigned;
                string dateAdded = DateAdded;

                //This MessageBox fires off the Activated event!!!!
                //As a result, you have to do this reshuffle: save widget data to the buffer vars in the method, and then after the MessageBox fires and triggers
                //the Activated event, re-stuff the values from the buffer values back into the properties fields (which are connected directly to widgets) in this form.
                var rslt = MessageBox.Show("Do you want to save the changes you just made to the builder contact form?", "Save Changes?", MessageBoxButtons.YesNoCancel);
                if (rslt == DialogResult.Yes)
                {
                    BuilderName = builderName;
                    BuilderAddress = builderAddress;
                    BuilderPostOffice = builderPostOffice;
                    BuilderState = builderState;
                    Zip = builderZip;

                    ContactName = contactName;
                    ContactCode = contactCode;
                    ContactNotes = contactNotes;

                    Phone_1 = phone_1;
                    Phone_2 = phone_2;
                    Phone_3 = phone_3;
                    PhoneExt_1 = phoneExt_1;
                    PhoneExt_2 = phoneExt_2;
                    PhoneExt_3 = phoneExt_3;
                    PhoneType_1 = phoneType_1;
                    PhoneType_2 = phoneType_2;
                    PhoneType_3 = phoneType_3;

                    MarkedForDeletion = markedForDeletion;
                    LastDateAssigned = lastDateAssigned;
                    DateAdded = dateAdded;

                    ((ContactsPresenter)(_presenter)).UpdateAll(sender,e);
                }
            }
        }

        private void SaveEdits(object sender, EventArgs e)
        {
            ((ContactsPresenter)(_presenter)).UpdateAll(sender,e);            
            MessageBox.Show("Saved");
        }

        private void CancelChanges(object sender, EventArgs e)
        {
            ((ContactsPresenter)(_presenter)).CancelChanges(sender, e);
        }

        private void ClearContactWidgetForNewContactEntry(object sender, EventArgs e)
        {
            EntryMode = BuilderEntryMode.AddContactOnly;
            uiContactInfo.Clear();
        }
      
        private void ReformatContactsGrid(object sender, EventArgs e)
        {
            string[] names = { "ContactName", "PhoneNum1", "PhoneType1", "DeleteFlag", "BestTime" };

            List<DataGridViewColumn> columns = null;
            List<DataGridViewColumn> invisibilColumns = null;

            if (dgContacts.Columns == null)
            {
                return;                
            }

            columns = dgContacts.Columns.Cast<DataGridViewColumn>().ToList().Where(c=> c.Name.Equals(names[0]) || c.Name.Equals(names[1]) || c.Name.Equals(names[2]) || c.Name.Equals(names[3]) || c.Name.Equals(names[4])).ToList();
            foreach (var col in columns)
            {
                col.Visible = true;
            }

            invisibilColumns = dgContacts.Columns.Cast<DataGridViewColumn>().ToList().Where(c => !c.Name.Equals(names[0]) && !c.Name.Equals(names[1]) && !c.Name.Equals(names[2]) && !c.Name.Equals(names[3]) && !c.Name.Equals(names[4])).ToList();
            
            foreach (var inv in invisibilColumns)
            {
                inv.Visible = false;
            }

            if (columns != null && columns.Count == 5)
            {
                columns[0].HeaderText = "Contacts";
                columns[0].Width = 300;
                columns[1].HeaderText = "First Phone";
                columns[2].HeaderText = "Type";
                columns[3].HeaderText = "Mark for Deletion";
                columns[4].HeaderText = "Best Time to Call";
                columns[4].Width = 300;
            }
        }

        public void Clear()
        {
            Datasource = null;
            DatasourceBuilders = null;
            CurrentItem = null;
            DatasourceContactItem = null;
            DatasourceContacts = null;
            uiBuilderInfo.Clear();
            uiContactInfo.Clear();
            //This may be required if, for example, you've reached the limit of 9 contacts allowed
            uiContactInfo.Enabled = true;
                                
            BuilderCode = string.Empty;
            BuilderName = string.Empty;
            BuilderAddress = string.Empty;
            BuilderPostOffice = string.Empty;
            BuilderState = string.Empty;
            Zip = string.Empty;
        }   
        private void btnWriteFiles_Click(object sender, EventArgs e)
        {
            string prompt = "Is the owner the same as the builder?";
            string caption = "Owner/Builder";
            OwnershipType ownershipType = OwnershipType.NonOwner;

            var answer = MessageBox.Show(prompt, caption, MessageBoxButtons.YesNoCancel);

            ownershipType = (answer == DialogResult.Yes ? OwnershipType.Owner : OwnershipType.NonOwner);
            bool retVal = ((ContactsPresenter)(_presenter)).WriteOutputFiles(ownershipType);

            if (retVal)
                MessageBox.Show("Files successfully created", "Files Created");
            else
                MessageBox.Show("Problem with creating files", "Issue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnSaveEdits_Click(object sender, EventArgs e)
        {
            string s = "3";
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            AllowEditing(true);
        }

        private void btnEditBuilderContact_Click(object sender, EventArgs e)
        {
            AllowEditing(true);
        }

        private void AllowEditing(bool arg)
        {
            uiBuilderInfo.Enabled = arg;
            uiContactInfo.Enabled = arg;
        }

        public void AddNewBuilder(bool addNew)
        {
            AllowEditing(addNew);
            EntryMode = (addNew ? EntryMode = BuilderEntryMode.AddBuilderAndContact : EntryMode);
        }
    }
}
