using System;
using System.ComponentModel;
using System.Windows.Forms;
using Utilties;

namespace TestScreens
{
    public partial class SearchBox : UserControl
    {

        public event EventHandler InvokeSearch;   

        private const char CONTROL_F = '\u0006';

        [Browsable(true)]
        public SearchMode SearchType
        {
            get
            {
                var srchMode = SearchMode.ByEntry;
                if (cmbSearchType.SelectedIndex == 1)
                    srchMode = SearchMode.ByMeaning;

                return srchMode;
            }

            set
            {
                cmbSearchType.SelectedIndex = 0;
                if (value == SearchMode.ByMeaning)
                    cmbSearchType.SelectedIndex = 1;
            }
        }

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

            txtSearch.TextChanged += TxtSearch_TextChanged;
            cmbSearchType.SelectedIndexChanged += CmbSearchType_SelectedIndexChanged;
        }

        private void CmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (SearchType != SearchMode.None)
            {
                InvokeSearch?.Invoke(sender, e);
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
            if (InvokeSearch != null)
                return;

            InvokeSearch.Invoke(sender, e);
        }

        public void ClearSearchBox(object sender, EventHandler e)
        {
            txtSearch.Text = string.Empty;
        }
    }
}
