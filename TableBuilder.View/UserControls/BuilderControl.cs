using System;
using System.ComponentModel;
using System.Windows.Forms;
using TableBuilder.NET.Common;

namespace TableBuilder.NET.View.UserControls
{
    public partial class BuilderControl : UserControl, INotifyPropertyChanging, INotifyPropertyChanged
    {   
        public EventHandler SelectedStateChanged;
        public KeyPressEventHandler TextDataChanged;

        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;

        #region "Properties"
        private bool _isChanged = false;
        public bool IsLoaded { get; set; }

        [Browsable(true)]
        public bool LockProperties { get; set; }

        [Browsable(true)]
        public bool IsChanged
        {
            get { return _isChanged; }
            set
            {
                if (LockProperties) return;
                
                _isChanged = value;                
            }
        }
        public object Datasource
        {
            get { return cmbState.DataSource; }
            private set { cmbState.DataSource = value;}
        }
        public string BuilderCode
        {
            get { return txtBuilderCode.Text; }
            set { txtBuilderCode.Text = value; }
        }
        public string BuilderName
        {
            get { return txtBuilderName.Text; }
            set
            {
                if (LockProperties) return;
                
                PropertyChanging?.Invoke(txtBuilderName, new PropertyChangingEventArgs("BuilderName"));
                txtBuilderName.Text = value;
                PropertyChanged?.Invoke(txtBuilderName, new PropertyChangedEventArgs("BuilderName"));
            }
        }
        public string BuilderAddress
        {
            get { return txtBuilderAddress.Text; }
            set
            {
                if (LockProperties) return;

                PropertyChanging?.Invoke(txtBuilderAddress, new PropertyChangingEventArgs("BuilderAddress"));
                txtBuilderAddress.Text = value;
                PropertyChanged?.Invoke(txtBuilderAddress, new PropertyChangedEventArgs("BuilderAddress"));
            }
        }
        public string BuilderPostOffice
        {
            get { return txtBuilderPostOffice.Text; }
            set
            {
                if (LockProperties) return;

                PropertyChanging?.Invoke(txtBuilderPostOffice, new PropertyChangingEventArgs("BuilderPostOffice"));
                txtBuilderPostOffice.Text = value;
                PropertyChanged?.Invoke(txtBuilderPostOffice, new PropertyChangedEventArgs("BuilderPostOffice"));
            }
        }
        public string Zip
        {
            get { return txtZip.Text; }
            set
            {
                if (LockProperties) return;

                PropertyChanging?.Invoke(txtZip, new PropertyChangingEventArgs("Zip"));
                txtZip.Text = value;
                PropertyChanged?.Invoke(txtZip, new PropertyChangedEventArgs("Zip"));
            }
        }
        public string BuilderState
        {
            get { return cmbState.Text; }
            set
            {
                if (LockProperties) return;

                PropertyChanging?.Invoke(cmbState, new PropertyChangingEventArgs("BuilderState"));
                cmbState.Text = value;
                PropertyChanged?.Invoke(cmbState, new PropertyChangedEventArgs("BuilderState"));
            }
        }
        #endregion
        public BuilderControl()
        {
            InitializeComponent();

            LockProperties = false;

            cmbState.DataSource = Utilities.GetStateAbbreviations();

            //--This textbox is for debugging.  Make it visible if needed:
            txtBuilderCode.Enabled = false;
            txtBuilderCode.Visible = true;
            lblBuilderCode.Visible = txtBuilderCode.Visible;

            IsLoaded = true;
            IsChanged = false;
        }

        public void WireBuilderControlEvents()
        {
            cmbState.SelectedIndexChanged += SelectedStateChanged;

            TextDataChanged += ItemChanged;

            txtBuilderCode.KeyPress += TextDataChanged;
            txtBuilderName.KeyPress += TextDataChanged;
            txtBuilderAddress.KeyPress += TextDataChanged;
            txtBuilderPostOffice.KeyPress += TextDataChanged;
            txtZip.KeyPress += TextDataChanged;
        }

        private void ItemChanged(object sender, EventArgs e)
        {
            string propNameFromControl = string.Empty;
            IsChanged = true;

            TextBox txtBox = sender as TextBox;
            if (txtBox != null)
            {
                propNameFromControl = txtBox.Name.Replace("txt", "");

                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propNameFromControl));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propNameFromControl));
            }
        }

        public void Clear()
        {
            txtZip.Text = string.Empty;
            txtBuilderPostOffice.Text = string.Empty;
            txtBuilderAddress.Text = string.Empty;
            txtBuilderName.Text = string.Empty;
            txtBuilderCode.Text = string.Empty;
        }

    }
}
