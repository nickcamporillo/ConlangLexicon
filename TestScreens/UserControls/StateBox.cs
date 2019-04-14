using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TableBuilder.NET
{
    public partial class StateBox : UserControl
    {
        public event EventHandler SelectedValueChanged;

        public string State
        {
            get
            {
                var s = cmbState.SelectedItem;
                return cmbState.SelectedItem.ToString();
            }
            set
            {
                string t = value;
                cmbState.DisplayMember = t;
                cmbState.SelectedItem = t;
            }
        }

        public StateBox()
        {
            InitializeComponent();
            this.Load += StateBox_Load;            
        }

        private void StateBox_Load(object sender, EventArgs e)
        {
            List<string> states = new List<string>();
            cmbState.Text = string.Empty;
            if (cmbState == null || cmbState.Items == null || cmbState.Items.Count > 50)
            {
                return;
            }

            cmbState.Items.Clear();

            states.Add("");
            states.Add("AL");
            states.Add("AK");
            states.Add("AZ");
            states.Add("AR");
            states.Add("CA");
            states.Add("CO");
            states.Add("CT");
            states.Add("DE");
            states.Add("FL");
            states.Add("GA");
            states.Add("HI");
            states.Add("ID");
            states.Add("IL");
            states.Add("IN");
            states.Add("IA");
            states.Add("KS");
            states.Add("KY");
            states.Add("LA");
            states.Add("ME");
            states.Add("MD");
            states.Add("MA");
            states.Add("MI");
            states.Add("MN");
            states.Add("MS");
            states.Add("MO");
            states.Add("MT");
            states.Add("NE");
            states.Add("NV");
            states.Add("NH");
            states.Add("NJ");
            states.Add("NM");
            states.Add("NY");
            states.Add("NC");
            states.Add("ND");
            states.Add("OH");
            states.Add("OK");
            states.Add("OR");
            states.Add("PA");
            states.Add("RI");
            states.Add("SC");
            states.Add("SD");
            states.Add("TN");
            states.Add("TX");
            states.Add("UT");
            states.Add("VT");
            states.Add("VA");
            states.Add("WA");
            states.Add("WV");
            states.Add("WI");
            states.Add("WY");

            cmbState.DataSource = states;
            cmbState.SelectedIndex = 0;

            //Force user to use the arrow, do not enter the text part directly
            cmbState.DropDownStyle = ComboBoxStyle.DropDownList;


            //Attach event handlers to delegates
            cmbState.SelectedValueChanged += CmbState_SelectedValueChanged;
        }

        private void CmbState_SelectedValueChanged(object sender, EventArgs e)
        {
            string s = "Placeholder if you want to add additional events";
            //InvokeEvents();
        }

        private void InvokeEvents()
        {
            SelectedValueChanged(this, new EventArgs());
        }
    }
}
