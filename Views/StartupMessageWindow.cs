
using System;
using System.Windows.Forms;
using Lexicon.Legacy2019.IViews;

namespace Lexicon.Legacy2019.Screens
{
    public partial class StartupMessageWindow : Form, IView
    {
        public StartupMessageWindow()
        {
            InitializeComponent();
        }

        public ConfirmNavigation ConfirmNavigateToNextScreen { get; set; }
        public ConfirmNavigation ConfirmNavigateToPreviousScreen { get; set; }
        public object CurrentItem { get; set; }
        public object Datasource { get; set; }
        public string NextFormName { get; set; }
        public string Place { get; set; }
        public string PlaceState { get; set; }
        public string PreviousFormName { get; set; }
        public string Psu { get; set; }

        public event EventHandler CloseAll;
        public event EventHandler NextScreen;
        public event EventHandler PreviousScreen;
        public event EventHandler UpdateItem;

        public void Add(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void Cancel(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void Clear()
        {
            
        }
        public void Message(string caption, string message, MessageBoxButtons buttonValue, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, buttonValue, icon);
        }

        public void MoveFirst(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void MoveLast(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void MoveNext(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void MovePrevious(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void Save(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
