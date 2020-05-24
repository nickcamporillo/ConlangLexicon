using System;
using System.Drawing;
using System.Windows.Forms;
using TableBuilder.NET.Common;
using TableBuilder.NET.IViews;
using TableBuilder.NET.Presenters;
using TableBuilder.NET.View.UserControls;

namespace TableBuilder.NET
{
    public partial class Builder : Form, IViewBuilder, IViewPlaceState, IViewBpoid//,IViewDebug
    {
        public event EventHandler AddBuilder;
        public event EventHandler AddContact;
        public event EventHandler MarkForDeletion;
        public event EventHandler UnmarkForDeletion; 
        public event EventHandler UpdateItem;
        public event EventHandler NextScreen;
        public event EventHandler PreviousScreen;
        public event EventHandler CloseAll;
        public event DataGridViewCellEventHandler UpdateCellEnd;
        public event DataGridViewCellEventHandler MovedNextRecord;
        public event EventHandler RecordChange;
        public event EventHandler InvokeSearch;

        private IPresenter _presenter;


        #region "Properties"
        public ConfirmNavigation ConfirmNavigateToPreviousScreen { get; set; }
        public ConfirmNavigation ConfirmNavigateToNextScreen { get; set; }
        public string PreviousFormName { get; set; }
        public string NextFormName { get; set; }
        public bool IsSearch { get; set; }
        public string SearchText
        {
            get { return searchBox.SearchText; }
            set {; }
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
        public string PlaceState
        {
            get { return placeHeader.PlaceState; }
            set { placeHeader.PlaceState = value; }
        }

        public string Place
        {
            get { return placeHeader.Place; }
            set { placeHeader.Place = value; }
        }
        public string State
        {
            get { return placeHeader.PlaceState; }
            set { placeHeader.PlaceState = value; }
        }
        public object CurrentItem
        {
            get
            {
                return (dgBuilders.CurrentRow != null ? dgBuilders.CurrentRow.DataBoundItem : null);
            }
            set {; }
        }
        public object Datasource
        {
            get { return dgBuilders.DataSource; }
            set { dgBuilders.DataSource = value; }
        }
        
        public string BuilderCode
        {
            //get { return txtBuilderCode.Text; }
            //set
            //{
            //    txtBuilderCode.Text = value;
            //}
            get;set;
        }
        public string SurveyType
        {
            get;
            set;
        }
        public BuilderEntryMode EntryMode
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get { return btnMarkForDeletion.Enabled; }
            set
            {
                btnMarkForDeletion.Enabled = value;
                btnUndelete.Enabled = !value;
            }
        }
        #endregion
        public Builder()
        {
            InitializeComponent();   
        }

        public Builder(IPresenter presenter)
        {
            InitializeComponent();

            _presenter = presenter;
            this.Load += Builder_Load;
            this.Load += RedrawFormOnInit;
        }
        private void DgBuilders_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            BuilderCode = Utilities.GetPropertyValue(CurrentItem,"BuilderCode").ToString();
        }

        private void Builder_Load(object sender, EventArgs e)
        {
            _presenter.Setup(this);

            //Set whatever initializations have to be done before re-drawing the Form, such as calling these 2 private/internal methods/props
            //(they can't be set by the Form Factory due to access level) and setting up other Event handlers
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;

            //We want the user to be able to type in search box which automatically narrows the result set.  
            //Faster and less annyoing than hitting "<CTRL>-F" after typing into search box
            searchBox.SearchType = SearchBox.SearchMode.DynamicSeach;

            LoadEventHandlers();

            Activated += ((BuilderPresenter)(_presenter)).RefreshBuilderDataBinding;
            //Activated += UpdateItem; //See Presenter. This is hooked up to "RefreshBuilder(object sender, EventArgs e)"
        }
        private void LoadEventHandlers()
        {
            SetCrudEventHandlers();
            SetSearchBoxEventHandlers();
            SetFormNavigationHandlers();
        }
        private void SetSearchBoxEventHandlers()
        {
            //Set the properties eventhandlers for invoking the Search.  In the Presenter, you'll have to do the same thing in the "WireEvents" method
            searchBox.InvokeSearch += InvokeSearch;
            searchBox.InvokeSearch += RedrawFormOnInit;
            InvokeSearch += SearchBox_InvokeSearch;
            searchBox.InvokeSearch += InvokeSearch;

            //Need to clear out the SearchBox user control if this form routes to another screen:
            dgBuilders.Click += DgBuilders_Click;
            dgBuilders.DoubleClick += DgBuilders_DoubleClick;
            dgBuilders.DoubleClick += searchBox.ClearSearchBox;
            btnBackToBpoid.Click += searchBox.ClearSearchBox;
            btnContacts.Click += searchBox.ClearSearchBox;
            btnAddBuilder.Click += searchBox.ClearSearchBox;

           

        }

        private void DgBuilders_Click(object sender, EventArgs e)
        {
            string bldcode = BuilderCode;
            CurrentItem = dgBuilders.CurrentRow;

            //BuilderCode = Utilities.GetPropertyValue(CurrentItem, "BuilderCode").ToString();
        }

        private void DgBuilders_DoubleClick(object sender, EventArgs e)
        {
            CurrentItem = dgBuilders.CurrentRow;
            string bldcode = BuilderCode;

            //BuilderCode = Utilities.GetPropertyValue(CurrentItem, "BuilderCode").ToString();
            //_lockProperties = true;
        }

        private void SetFormNavigationHandlers()
        {
            dgBuilders.DoubleClick += NextScreen;
            btnBackToBpoid.Click += PreviousScreen;
            btnContacts.Click += NextScreen; ;
            btnF10.Click += CloseAll;

            //This *is* a form navigation handler.  You go to the Contacts screen when you hit it, PLUS all the fields are blank
            btnAddBuilder.Click += AddBuilder;
        }
        private void SetCrudEventHandlers()
        {
            //[CBorillo] Don't use this, it's out-of-sync when it fires, the values in the previous row are retained at the time of its firing.
            //dgBuilders.RowEnter += MovedNextRecord; 

            //[CBorillo] ...So instead, use "CellEnter" event, it fires after the RowEnter event, which is when the CurrentItem is fully-synched
            dgBuilders.CellEnter += RefreshBuilderCode;
            dgBuilders.CellEnter += MovedNextRecord;
            dgBuilders.DataBindingComplete += RetitleColumnHeaders;

            btnMarkForDeletion.Click += MarkForDeletion;
            btnUndelete.Click += UnmarkForDeletion;
        }

        private void RefreshBuilderCode(object sender, DataGridViewCellEventArgs e)
        {
            BuilderCode = Utilities.GetPropertyValue(CurrentItem, "BuilderCode").ToString();
        }

        //This is supposed to fire when you do <CTRL>-F.  I've disarmed that for now, selecting Dynamic Search instead, but if you need this, it's here waiting for you.
        private void SearchBox_InvokeSearch(object sender, EventArgs e)
        {
            IsSearch = true;           
        }
        //This needs to execute when a Search has already been finished, otherwise a requery on the grid will screw up the rendering
        private void RedrawFormOnInit(object sender, EventArgs e)
        {
            //--- Initial settings by designer ---
            //Window size: 1110, 668
            //Grid size: 1097, 400

            //Override designer:            
            const int TOP_LINE_FOR_BUTTONS = 100;
            const int LEFT_EDGE_WIDGETS = 100;
            const int GRID_WIDTH = 1097;
            const int BTN_HEIGHT = 30;

            const int BUTTON_X_OFFSET = 170;
            const int F10_X_OFFSET = 150;            
            
            const int PLACENAME_COLUMN_WIDTH = 550;
            
            placeHeader.Left = LEFT_EDGE_WIDGETS - 10;

            btnBackToBpoid.Height = BTN_HEIGHT;
            btnAddBuilder.Height = BTN_HEIGHT;
            btnMarkForDeletion.Height = BTN_HEIGHT;
            btnUndelete.Height = BTN_HEIGHT;
            btnContacts.Height = BTN_HEIGHT;
            btnF10.Height = BTN_HEIGHT;

            btnBackToBpoid.Location = new Point(LEFT_EDGE_WIDGETS, TOP_LINE_FOR_BUTTONS);
            btnAddBuilder.Location = new Point(btnBackToBpoid.Location.X + BUTTON_X_OFFSET, TOP_LINE_FOR_BUTTONS);
            btnMarkForDeletion.Location = new Point(btnAddBuilder.Location.X + BUTTON_X_OFFSET, TOP_LINE_FOR_BUTTONS);
            btnUndelete.Location = new Point(btnMarkForDeletion.Location.X + BUTTON_X_OFFSET, TOP_LINE_FOR_BUTTONS);

            btnContacts.Location = new Point(btnUndelete.Location.X + BUTTON_X_OFFSET, TOP_LINE_FOR_BUTTONS);
            btnF10.Location = new Point(btnContacts.Location.X + F10_X_OFFSET, TOP_LINE_FOR_BUTTONS);

            searchBox.Location = new Point(LEFT_EDGE_WIDGETS, btnF10.Location.Y + 80);

            dgBuilders.Width = GRID_WIDTH;
            dgBuilders.Location = new Point(LEFT_EDGE_WIDGETS, btnContacts.Location.Y + 150);

            if(dgBuilders.Columns.Count > 2)
            {
                dgBuilders.Columns[1].Width = PLACENAME_COLUMN_WIDTH;
            }
        }
        private void RetitleColumnHeaders(object sender, EventArgs e)
        {
            //Don't tell me I can't do Lambdas or LINQ with the Datagrid columns if the entity is from anonymous entity!
            string[] initialColumnNames = { "BuilderCode", "BuilderName", "DateAdded", "DateAssigned", "DeleteFlag"};
            string[] finalColumnNames = { "Builder Code", "Builder Name", "Date Added", "Date Assigned", "Delete Flag" };
            if (dgBuilders.Columns != null && dgBuilders.Columns.Count > 0)
            {
                for (int i=0;i< initialColumnNames.Length;i++)
                {
                    if (dgBuilders.Columns[initialColumnNames[i]] != null)
                    {
                        dgBuilders.Columns[initialColumnNames[i]].HeaderText = finalColumnNames[i]; 
                    } 
                }                
            }
        }

        public void ResetFlags()
        {
        }
        public void Clear()
        {
        }

        //This is a Hack!!! Fix this later to proper MVP!
        private void btnContacts_Click(object sender, EventArgs e)
        {

            BuilderCode = Utilities.GetPropertyValue(CurrentItem, "BuilderCode");
            txtBuilderCode.Text = string.Empty;
        }
    }
}