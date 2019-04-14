using System;
using System.Windows.Forms;
using IViews;
using IPresenters;
using Utilties;

namespace TestScreens
{
    public partial class WordListGrid : Form, IViewWordListGrid
    {
        public event EventHandler AddingRecord;
        public event EventHandler PageMoveCompleted;
        public event EventHandler UpdateItem;
        public event EventHandler NextScreen;
        public event EventHandler PreviousScreen;
        public event EventHandler CloseAll;
        public event DataGridViewCellEventHandler UpdateCellEnd;
        public event DataGridViewCellEventHandler MovedNextRecord;
        public event EventHandler RecordChanged;
        public event EventHandler InvokeSearch;

        private IPresenter _presenter;

        #region "Properties"
        public SearchMode SearchType
        {
            get { return searchBox.SearchType; }
            set { searchBox.SearchType = value; }
        }

        public string SearchText
        {
            get { return searchBox.SearchText; }
            set {; }
        }

        public bool SearchFromStart
        {
            get { return rbStartsWith.Checked; }
        }

        public bool SearchWordContains
        {
            get { return rbContains.Checked; }
        }

        public int Id
        {
            get { return int.Parse(lblId.Text); }
            set { lblId.Text = value.ToString(); }
        }

        public int LanguageId { get; set; }

        public object CurrentItem
        {
            get
            {
                return (dgWordList.CurrentRow != null ? dgWordList.CurrentRow.DataBoundItem : null);
            }
            set {; }
        }
        public object Datasource
        {
            get { return dgWordList.DataSource; }
            set { dgWordList.DataSource = value; }
        }

        #endregion

        public WordListGrid()
        {
            InitializeComponent();   
        }

        public WordListGrid(IPresenter presenter)
        {
            InitializeComponent();

            _presenter = presenter;
            this.Load += Screen_Load;
            this.Load += RedrawFormOnInit;

            dgWordList.SelectionChanged += DgWordList_SelectionChanged;

            dgWordList.RowHeadersVisible = false;
            dgWordList.AllowUserToResizeRows = false;
            dgWordList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgWordList.EditMode = DataGridViewEditMode.EditProgrammatically;

            btnAddWord.Click += AddingRecord;
            btnAddWord.Click += btnAddWord_Click;
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            string s = "click";
        }

        private void DgBuilders_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //BuilderCode = Utilities.GetPropertyValue(CurrentItem,"BuilderCode").ToString();
        }

        private void Screen_Load(object sender, EventArgs e)
        {
            //Set whatever initializations have to be done before re-drawing the Form, such as calling these 2 private/internal methods/props
            //(they can't be set by the Form Factory due to access level) and setting up other Event handlers
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;

            //We want the user to be able to type in search box which automatically narrows the result set.  
            //Faster and less annyoing than hitting "<CTRL>-F" after typing into search box
            searchBox.SearchType = SearchMode.None;

            LoadEventHandlers();

            //Activated += ((BuilderPresenter)(_presenter)).RefreshBuilderDataBinding;
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
            dgWordList.Click += Grid_Click;
            dgWordList.DoubleClick += Grid_DoubleClick;

            //dgWordList.DoubleClick += searchBox.ClearSearchBox;
            dgWordList.SelectionChanged += RecordChanged;
            dgWordList.SelectionChanged += DgWordList_SelectionChanged;

            rbStartsWith.Click += searchBox.ClearSearchBox;
            rbContains.Click += searchBox.ClearSearchBox;
        }

        private void DgWordList_SelectionChanged(object sender, EventArgs e)
        {
            //var x = dgWordList.CurrentRow.DataBoundItem;
            var xy = CurrentItem;
        }

        private void Grid_Click(object sender, EventArgs e)
        {
            //CurrentItem = dgWordList.CurrentRow;
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            //CurrentItem = dgWordList.CurrentRow;
        }

        private void SetToAddMode(object sender, EventArgs e)
        {
            bool isAdd = true;
            AddingRecord?.Invoke(sender, e);
        }

        private void SetFormNavigationHandlers()
        {
            dgWordList.DoubleClick += NextScreen;
            btnAddWord.Click += SetToAddMode;
            btnAddWord.Click += NextScreen;
            btnEditData.Click += NextScreen;
            btnF10.Click += CloseAll;
        }
        private void SetCrudEventHandlers()
        {
            //[CBorillo] Don't use this, it's out-of-sync when it fires, the values in the previous row are retained at the time of its firing.
            //dgBuilders.RowEnter += MovedNextRecord; 

            //[CBorillo] ...So instead, use "CellEnter" event, it fires after the RowEnter event, which is when the CurrentItem is fully-synched
            dgWordList.CellEnter += MovedNextRecord;
            dgWordList.DataBindingComplete += RetitleColumnHeaders;
        }

        //This is supposed to fire when you do <CTRL>-F.  I've disarmed that for now, selecting Dynamic Search instead, but if you need this, it's here waiting for you.
        private void SearchBox_InvokeSearch(object sender, EventArgs e)
        {
            string s = "3";
            
        }
        //This needs to execute when a Search has already been finished, otherwise a requery on the grid will screw up the rendering
        private void RedrawFormOnInit(object sender, EventArgs e)
        {
            //--- Initial settings by designer ---
            //Window size: 1110, 668
            //Grid size: 1097, 400

            //Override designer:            
            const int GRID_WIDTH = 1150;         
            const int ENTRY_COLUMN_WIDTH = 350;

            searchBox.Width = 700;
            dgWordList.Width = GRID_WIDTH;

            dgWordList.Columns[0].Visible = false;
            if (dgWordList.Columns.Count > 2)
            {
                dgWordList.Columns[1].Width = ENTRY_COLUMN_WIDTH;
            }
        }
        private void RetitleColumnHeaders(object sender, EventArgs e)
        {
            //Don't tell me I can't do Lambdas or LINQ with the Datagrid columns if the entity is from anonymous entity!
            string[] initialColumnNames = { "BuilderCode", "BuilderName", "DateAdded", "DateAssigned", "DeleteFlag"};
            string[] finalColumnNames = { "Builder Code", "Builder Name", "Date Added", "Date Assigned", "Delete Flag" };
            if (dgWordList.Columns != null && dgWordList.Columns.Count > 0)
            {
                for (int i=0;i< initialColumnNames.Length;i++)
                {
                    if (dgWordList.Columns[initialColumnNames[i]] != null)
                    {
                        dgWordList.Columns[initialColumnNames[i]].HeaderText = finalColumnNames[i]; 
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


        public string PreviousFormName { get; set; }
        public string NextFormName { get; set; }
        public ConfirmNavigation ConfirmNavigateToPreviousScreen { get; set; }
        public ConfirmNavigation ConfirmNavigateToNextScreen { get; set; }

        public void MoveFirstRecord(object sender, EventArgs e)
        {
            
        }

        public void MoveLastRecord(object sender, EventArgs e)
        {
            
        }

        public void MoveNextRecord(object sender, EventArgs e)
        {
            
        }

        public void MovePreviousRecord(object sender, EventArgs e)
        {
            
        }

        public void Cancel(object sender, EventArgs e)
        {
            
        }

        public void SaveRecord(object sender, EventArgs e)
        {
            
        }

        public void AddRecord(object sender, EventArgs e)
        {
            
        }

        public void Close(object sender, EventArgs e)
        {
            
        }
    }
}