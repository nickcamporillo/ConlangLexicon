using System.Windows.Forms;

namespace TableBuilder.NET
{
    public partial class PlaceHeader : UserControl
    {
        public string Bpoid
        {
            get { return txtBpoid.Text; }
            set { txtBpoid.Text = value; }
        }
        public string Psu
        {
            get { return txtPsu.Text; }
            set { txtPsu.Text = value; }
        }

        public string Place
        {
            get { return txtPlace.Text; }
            set { txtPlace.Text = value; }
        }

        public string PlaceState
        {
            get { return txtPlaceState.Text; }
            set {txtPlaceState.Text = value;}
        }

        public PlaceHeader()
        {
            InitializeComponent();
        }
    }
}
