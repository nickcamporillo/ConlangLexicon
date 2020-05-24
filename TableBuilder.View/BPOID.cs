using System;
using System.Windows.Forms;
using System.Drawing;
using TableBuilder.NET.IViews;
using TableBuilder.NET.Presenters;
using TableBuilder.NET.Common;

namespace TableBuilder.NET
{
    public partial class BPOID : Form, IViewBpoid, IViewPlaceState
    {
        public event EventHandler NextScreen;
        public event EventHandler PreviousScreen;
        public event EventHandler CloseAll;
        public event EventHandler UpdateItem;
        public event DataGridViewCellEventHandler UpdateCellEnd;
        public event DataGridViewCellEventHandler MovedNextRecord;

        bool IsInitialized = false;

        private IPresenter _presenter;

        const char KEYPRESS_ENTER = '\r';
        const char KEYPRESS_TAB = '\t';

        #region Properties
        public ConfirmNavigation ConfirmNavigateToPreviousScreen { get; set; }
        public ConfirmNavigation ConfirmNavigateToNextScreen { get; set; }
        public string PreviousFormName { get; set; }
        public string NextFormName { get; set; }
        public string Psu
        {
            get;
            set;
        }
        public string Bpoid
        {
            get { return txtBpoid.Text; }
            set { txtBpoid.Text = value; }
        }

        public string PlaceState
        {
            get;
            set;
        }
        public string BuilderCode
        {
            get;
            set;
        }

        public string Place
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }

        public object CurrentItem
        {
            set {; }
            get
            {
                if (dgBuilders.CurrentRow != null)
                    return dgBuilders.CurrentRow.DataBoundItem;
                else
                    return null;
            }
            
        }
        public object Datasource
        {
            get { return dgBuilders.DataSource; }
            set { dgBuilders.DataSource = value; }
        }

        #endregion

        public BPOID()
        {
            InitializeComponent();
        }
        public BPOID(IPresenter presenter)
        {
            InitializeComponent();

            _presenter = presenter;
            _presenter.Setup(this);

            this.Load += BPoid_Load;
            this.Load += RedrawFormOnInit;
            this.Load += SetTexts;
        
            //This textbox is for debugging purposes - set to Visible=true to see if when you click on the grid you get the right Bpoid
            txtBpoid.Visible = true;
        }
        private void BPoid_Load(object sender, EventArgs e)
        {
            //Set whatever initializations have to be done before re-drawing the Form, such as calling these 2 private/internal methods/props
            //(they can't be set by the Form Factory due to access level) and setting up other Event handlers
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;

            dgBuilders.CellValidated += UpdateCellEnd;
            dgBuilders.Click += SetTexts;            

            dgBuilders.KeyPress += BPOID_KeyPress;            
            btnDisplayBuilders.Click += UpdateItem;

            SetFormNavigationHandlers();         
        }

        private void SetFormNavigationHandlers()
        {
            dgBuilders.DoubleClick += NextScreen;
            btnDisplayBuilders.Click += NextScreen;
            btnF10.Click += CloseAll;         
        }

        private void BPOID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyPressedOnGrid = e.KeyChar;
            bool isSame = keyPressedOnGrid.Equals(KEYPRESS_ENTER) || keyPressedOnGrid.Equals(KEYPRESS_TAB);
            if (isSame)
            {
                NextScreen.Invoke(dgBuilders, e);
            }
        }

        private void RedrawFormOnInit(object sender, EventArgs e)
        {
            //--- Initial settings by designer ---
            //Window size: 1110, 668
            //Grid size: 1097, 400
            //Window X: 0
            //Grid X: 20

            const int LABEL_INFO_Y = 16;
            const int LABEL_INFO_X_OFFSET = 200;
            const int BUTTONS_Y = 146;
            const int F10_OFFSET = 150;
            const int PLACENAME_COLUMN_WIDTH = 750;
            const int DGBUILDERS_X = 100;

            //const int TOP_LINE = 146
            //const int BTN_HEIGHT = 30;

            //Override designer:            
            this.lblInfo.Location = new Point(this.ClientSize.Width / 2, LABEL_INFO_Y);
            this.lblInfo.Location = new Point(this.Size.Width - (this.Size.Width / 2) - LABEL_INFO_X_OFFSET, this.lblInfo.Location.Y);

            this.btnDisplayBuilders.Location = new Point(this.Width/2, BUTTONS_Y);
            this.btnF10.Location = new Point(btnDisplayBuilders.Location.X + F10_OFFSET, this.btnDisplayBuilders.Location.Y);

            this.dgBuilders.Location = new Point(DGBUILDERS_X, dgBuilders.Location.Y);
            this.dgBuilders.Columns[2].Width = PLACENAME_COLUMN_WIDTH;
        }

        private void SetTexts(object sender, EventArgs e)
        {
            Bpoid = Utilities.GetPropertyValue(CurrentItem, "Bpoid");
            Psu = Utilities.GetPropertyValue(CurrentItem, "Psu");
            Place = Utilities.GetPropertyValue(CurrentItem, "PlaceName");
            PlaceState = Utilities.GetPropertyValue(CurrentItem, "PlaceState");
        }

        public void ResetFlags()
        {

        }
        public void Clear()
        {
        }

    }
}
