using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TableBuilder.NET.View.UserControls
{
    public partial class SearchBox : UserControl
    {
        public enum SearchMode
        {
            DynamicSeach = 1, //This is also the default
            ControlFSeach = 2
        }

        public event EventHandler InvokeSearch;   

        private const char CONTROL_F = '\u0006';

        [Browsable(true)]
        public SearchMode SearchType { get; set; }

        [Browsable(true)]
        public string InstructionText
        {
            get { return lblInstrx.Text; }
            set { lblInstrx.Text = value; }
        }
        public string IconLocation
        {
            get { return picBox.ImageLocation; }
            set { picBox.ImageLocation = value; }
        }
        public string SearchText
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }
        public SearchBox()
        {
            InitializeComponent();

            txtSearch.KeyPress += TxtSearch_KeyPress;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (SearchType != SearchMode.ControlFSeach)
            {
                InvokeSearch?.Invoke(sender, e);
            }
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SearchType == SearchMode.ControlFSeach)
            {
                if (e.KeyChar == CONTROL_F)
                {
                    InvokeSearch?.Invoke(sender, e);
                }
            }
        }

        public void ClearSearchBox(object sender, EventArgs e)
        {
            ClearSearchBox();
        }

        public void ClearSearchBox()
        {
            txtSearch.Text = string.Empty;
        }

        /* I researched on removing that annoying "ding" sound when user presses <ENTER>. For instructions on how to do that, goto
         *  https://stackoverflow.com/questions/6290967/stop-the-ding-when-pressing-enter
         * However, the commentator on the referring page to that link advised: "Personally, I would suggest against it. If a user has 
         * sounds on at the system level I don't think your app should ignore them. For example, as Peter pointed out, 
         * the user could be blind or have other accessibility issues."  So this is a 508 Requirement????
         */
        private void picBox_Click(object sender, EventArgs e)
        {
            InvokeSearch?.Invoke(sender, e);
        }

        public void ClearSearchBox(object sender, EventHandler e)
        {
            txtSearch.Text = string.Empty;
        }
    }
}
