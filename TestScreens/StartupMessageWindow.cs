using System;
using System.Windows.Forms;
using IViews;

namespace TestScreens
{
    public partial class StartupMessageWindow : Form, IView
    {
        public StartupMessageWindow()
        {
            InitializeComponent();
        }

        public ConfirmNavigation ConfirmNavigateToNextScreen { get; set; }
        public ConfirmNavigation ConfirmNavigateToPreviousScreen { get; set; }

        public int Id { get; set; }
        public object CurrentItem { get; set; }
        public object Datasource { get; set; }
        public string NextFormName { get; set; }
        public string Place { get; set; }
        public string PlaceState { get; set; }
        public string PreviousFormName { get; set; }
        public string Psu { get; set; }

        public event EventHandler CloseAll;
        public event EventHandler PageMoveCompleted;

        public event EventHandler NextScreen;
        public event EventHandler PreviousScreen;
        public event EventHandler UpdateItem;
        public event EventHandler RecordChanged;

        public void AddRecord(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void Cancel(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void RefreshData()
        {

        }

        public void Clear()
        {
            
        }
        public void Message(string caption, string message, MessageBoxButtons buttonValue, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, buttonValue, icon);
        }

        public void MoveFirstRecord(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void MoveLastRecord(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void MoveNextRecord(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void MovePreviousRecord(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void SaveRecord(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
