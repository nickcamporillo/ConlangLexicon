using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace TableBuilder.NET
{
    public partial class ContactControl : UserControl, INotifyPropertyChanging, INotifyPropertyChanged
    {
        public EventHandler SelectedItemChanged;
        public KeyPressEventHandler TextDataChanged;

        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;

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
        public bool IsEnabled
        {
            get { return this.Enabled; }
            set
            {
                this.Enabled = value;
            }
        }
        
        public string ContactName
        {
            get{ return txtContactName.Text;}
            set
            {
                if (LockProperties) return;
                
                PropertyChanging?.Invoke(txtContactName, new PropertyChangingEventArgs("ContactName"));
                txtContactName.Text = value;
                PropertyChanged?.Invoke(txtContactName, new PropertyChangedEventArgs("ContactName"));
            }
        }
        public string FirstPhone
        {
            get { return txtFirstPhone.Text; }
            set
            {
                if (LockProperties) return;

                PropertyChanging?.Invoke(txtFirstPhone, new PropertyChangingEventArgs("FirstPhone"));
                txtFirstPhone.Text = value;
                PropertyChanged?.Invoke(txtFirstPhone, new PropertyChangedEventArgs("FirstPhone"));            
            }
        }
        public string SecondPhone
        {
            get { return txtSecondPhone.Text; }
            set
            {
                if (LockProperties) return;
                
                PropertyChanging?.Invoke(txtSecondPhone, new PropertyChangingEventArgs("SecondPhone"));
                txtSecondPhone.Text = value;
                PropertyChanged?.Invoke(txtSecondPhone, new PropertyChangedEventArgs("SecondPhone"));                
            }
        }
        public string ThirdPhone
        {
            get { return txtThirdPhone.Text; }
            set
            {
                if (LockProperties) return;
                
                PropertyChanging?.Invoke(txtThirdPhone, new PropertyChangingEventArgs("ThirdPhone"));
                txtThirdPhone.Text = value;
                PropertyChanged?.Invoke(txtThirdPhone, new PropertyChangedEventArgs("ThirdPhone"));                
            }
        }
        public string FirstPhoneExt
        {
            get { return txtFirstPhoneExt.Text; }
            set
            {
                if (LockProperties) return;

                PropertyChanging?.Invoke(txtFirstPhoneExt, new PropertyChangingEventArgs("FirstPhoneExt"));
                txtFirstPhoneExt.Text = value;
                PropertyChanged?.Invoke(txtFirstPhoneExt, new PropertyChangedEventArgs("FirstPhoneExt"));                
            }
        }
        public string SecondPhoneExt
        {
            get { return txtSecondPhoneExt.Text; }
            set
            {
                if (LockProperties) return;

                PropertyChanging?.Invoke(txtSecondPhoneExt, new PropertyChangingEventArgs("SecondPhoneExt"));
                txtSecondPhoneExt.Text = value;
                PropertyChanged?.Invoke(txtSecondPhoneExt, new PropertyChangedEventArgs("SecondPhoneExt"));                
            }
        }
        public string ThirdPhoneExt
        {
            get { return txtThirdPhoneExt.Text; }
            set
            {
                if (LockProperties) return;
                
                PropertyChanging?.Invoke(txtThirdPhoneExt, new PropertyChangingEventArgs("ThirdPhoneExt"));
                txtThirdPhoneExt.Text = value;
                PropertyChanged?.Invoke(txtThirdPhoneExt, new PropertyChangedEventArgs("ThirdPhoneExt"));                
            }
        }
        public string FirstPhoneType
        {
            get { return cmbPhoneTypeOne.Text; }
            set
            {
                if (LockProperties) return;
                
                PropertyChanging?.Invoke(cmbPhoneTypeOne, new PropertyChangingEventArgs("FirstPhoneType"));
                cmbPhoneTypeOne.Text = value;
                PropertyChanged?.Invoke(cmbPhoneTypeOne, new PropertyChangedEventArgs("FirstPhoneType"));                
            }
        }
        public string SecondPhoneType
        {
            get { return cmbPhoneTypeTwo.Text; }
            set
            {
                if (LockProperties) return;
                
                PropertyChanging?.Invoke(cmbPhoneTypeTwo, new PropertyChangingEventArgs("SecondPhoneType"));
                cmbPhoneTypeTwo.Text = value;
                PropertyChanged?.Invoke(cmbPhoneTypeTwo, new PropertyChangedEventArgs("SecondPhoneType"));                
            }
        }
        public string ThirdPhoneType
        {
            get { return cmbPhoneTypeThree.Text; }
            set
            {
                if (LockProperties) return;
                
                PropertyChanging?.Invoke(cmbPhoneTypeThree, new PropertyChangingEventArgs("ThirdPhoneType"));
                cmbPhoneTypeThree.Text = value;
                PropertyChanged?.Invoke(cmbPhoneTypeThree, new PropertyChangedEventArgs("ThirdPhoneType"));                
            }
        }
        public string BestTimeToCall
        {
            get { return txtBestTimeCall.Text; }
            set
            {
                if (LockProperties) return;
                
                PropertyChanging?.Invoke(txtBestTimeCall, new PropertyChangingEventArgs("BestTimeToCall"));
                txtBestTimeCall.Text = value;
                PropertyChanged?.Invoke(txtBestTimeCall, new PropertyChangedEventArgs("BestTimeToCall"));                
            }
        }
        public string ContactNotes
        {
            get { return txtContactNotes.Text; }
            set
            {
                if (LockProperties) return;

                PropertyChanging?.Invoke(txtContactNotes, new PropertyChangingEventArgs("ContactNotes"));
                txtContactNotes.Text = value;
                PropertyChanged?.Invoke(txtContactNotes, new PropertyChangedEventArgs("ContactNotes"));                
            }
        }
        public string DateAdded
        {
            get { return txtDateAdded.Text; }
            set
            {
                if (LockProperties) return;

                PropertyChanging?.Invoke(txtDateAdded, new PropertyChangingEventArgs("DateAdded"));
                txtDateAdded.Text = value;
                PropertyChanged?.Invoke(txtDateAdded, new PropertyChangedEventArgs("DateAdded"));                
            }
        }
        public string LastDateAssigned
        {
            get { return txtDateAssigned.Text; }
            set
            {
                if (LockProperties) return;
                
                PropertyChanging?.Invoke(txtDateAssigned, new PropertyChangingEventArgs("LastDateAssigned"));
                txtDateAssigned.Text = value;
                PropertyChanged?.Invoke(txtDateAssigned, new PropertyChangedEventArgs("LastDateAssigned"));                
            }
        }
        public bool MarkForDeletion
        {
            get { return cmbMarkForDeletion.SelectedIndex == 1; }
            set
            {
                if (LockProperties) return;
                
                PropertyChanging?.Invoke(cmbMarkForDeletion, new PropertyChangingEventArgs("MarkForDeletion"));
                cmbMarkForDeletion.SelectedIndex = (value == true ? 1 : 0);
                PropertyChanged?.Invoke(cmbMarkForDeletion, new PropertyChangedEventArgs("MarkForDeletion"));               
            }
        }
        public string ContactCode
        {
            get { return txtContactCode.Text; }
            set
            {
                if (LockProperties) return;
                
                PropertyChanging?.Invoke(txtContactCode, new PropertyChangingEventArgs("ContactCode"));
                txtContactCode.Text = value;
                PropertyChanged?.Invoke(txtContactCode, new PropertyChangedEventArgs("ContactCode"));               
            }
        }

        public ContactControl()
        {
            InitializeComponent();

            LockProperties = false;

            //This textbox if for debugging only.  Make visible if needed.  But should never be enabled
            txtContactCode.Enabled = false;
            txtContactCode.Visible = true;
            lblContactCode.Visible = txtContactCode.Visible;

            cmbPhoneTypeOne.DataSource = InitPhoneTypes();
            cmbPhoneTypeTwo.DataSource = InitPhoneTypes();
            cmbPhoneTypeThree.DataSource = InitPhoneTypes();

            IsLoaded = true;

            IsChanged = false;
        }
        
        public void WireBuilderControlEvents()
        {
            SelectedItemChanged += SelectionChanged;
            cmbPhoneTypeOne.SelectedIndexChanged += SelectedItemChanged;
            cmbPhoneTypeTwo.SelectedIndexChanged += SelectedItemChanged;
            cmbPhoneTypeThree.SelectedIndexChanged += SelectedItemChanged;
            cmbMarkForDeletion.SelectedIndexChanged += SelectedItemChanged;

            TextDataChanged += ItemChanged;
            txtContactName.KeyPress += TextDataChanged;
            txtContactNotes.KeyPress += TextDataChanged;
            txtBestTimeCall.KeyPress += TextDataChanged;

            txtFirstPhone.KeyPress += TextDataChanged;
            txtSecondPhone.KeyPress += TextDataChanged;
            txtThirdPhone.KeyPress += TextDataChanged;

            txtFirstPhoneExt.KeyPress += TextDataChanged;
            txtSecondPhoneExt.KeyPress += TextDataChanged;
            txtThirdPhoneExt.KeyPress += TextDataChanged;
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

        private void SelectionChanged(object sender, EventArgs e)
        {
            string propNameFromControl = string.Empty;

            if (IsLoaded)
            {
                IsChanged = true;                
            }

            ComboBox cmbBox = sender as ComboBox;
            if (cmbBox != null)
            {
                propNameFromControl = cmbBox.Name.Replace("cmb", "");

                PropertyChanging.Invoke(this, new PropertyChangingEventArgs(propNameFromControl));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propNameFromControl));
            }
        }
        private IList<string> InitPhoneTypes()
        {
            IList<string> phoneTypes = new List<string>();
            phoneTypes.Add("");
            phoneTypes.Add("Home");
            phoneTypes.Add("Work");
            phoneTypes.Add("Cell");
            phoneTypes.Add("Other");
            phoneTypes.Add("Fax");

            return phoneTypes;
        }
        public void Clear()
        {
            _isChanged = false;
            LockProperties = false;
            ContactName = string.Empty;
            FirstPhone = string.Empty;
            SecondPhone = string.Empty;
            ThirdPhone = string.Empty;
            FirstPhoneExt = string.Empty;
            SecondPhoneExt = string.Empty;
            ThirdPhoneExt = string.Empty;
            FirstPhoneType = string.Empty;
            SecondPhoneType = string.Empty;
            ThirdPhoneType = string.Empty;
            BestTimeToCall = string.Empty;
            ContactNotes = string.Empty;
            DateAdded = string.Empty;
            LastDateAssigned = string.Empty;
        }
    }
}
