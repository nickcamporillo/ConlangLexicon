using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableBuilder.NET.IViews;

namespace TableBuilder.NET
{
    public partial class StartupMessageWindow : Form, IView
    {
        public StartupMessageWindow()
        {
            InitializeComponent();
        }

        public string Bpoid { get; set; }

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

        public void Clear()
        {
            
        }
        public void Message(string caption, string message, MessageBoxButtons buttonValue, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, buttonValue, icon);
        }
    }
}
