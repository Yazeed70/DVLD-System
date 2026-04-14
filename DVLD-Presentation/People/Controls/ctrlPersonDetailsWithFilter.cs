using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD_Presentation
{
    public partial class ctrlPersonDetailsWithFilter: UserControl
    {
        int _PersonID = -1;
        string _NationalNo;
        clsPerson _Person;

        public event Action <int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        enum encbFilter
        {
            PersonID,
            NationalNo
        }
        public ctrlPersonDetailsWithFilter()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get { return ctrlPersonDetails1.PersonID; }
        }

        public bool EnableFilter
        {
            get { return gbFilter.Enabled; }
            set
            {
                gbFilter.Enabled = value;
                gbFilter.Enabled = value;
            }
        }

        private void _Search()
        {
            if (cbFilter.SelectedItem == null || string.IsNullOrEmpty(txtFilter.Text))
            {
                MessageBox.Show($"Please Enter correct Info", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtFilter.Focus();
                return;
            }
                

            if ((encbFilter)cbFilter.SelectedItem == encbFilter.PersonID)
            {
                _PersonID = int.TryParse(txtFilter.Text, out int result) ? result : -1;
                _Person = clsPerson.Find(_PersonID);
            }
            else if ((encbFilter)cbFilter.SelectedItem == encbFilter.NationalNo)
            {
                _NationalNo = txtFilter.Text;
                _Person = clsPerson.Find(_NationalNo);
            }


            if (_Person != null)
            { 
                ctrlPersonDetails1.LoadData(_Person.ID);
                //txtFilter.Text = "";
                if(OnPersonSelected != null && FilterEnabled)
                {
                    PersonSelected(_Person.ID); // Raise the event with the selected PersonID
                }
            }
            else
            {
                MessageBox.Show($"No Person with {cbFilter.Text} = {txtFilter.Text}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtFilter.Focus();
                ctrlPersonDetails1.ClearData();
            }


        }
        
        private void _FillcbFilter()
        {
            cbFilter.DataSource = Enum.GetValues(typeof(encbFilter));
            cbFilter.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _Search();
        }

        private void ctrlPersonDetailsWithFilter_Load(object sender, EventArgs e)
        {
            _FillcbFilter();
        }

        public void _LoadData(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                MessageBox.Show("No Person with PersonID = " + _PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtFilter.Text = _Person.ID.ToString();
            gbFilter.Enabled = false;
            ctrlPersonDetails1.LoadData(_Person.ID);

        }

        private void cbFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctrlPersonDetails1.ClearData();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.DataBack += frm2_DataBack;
            frm.ShowDialog();
        }

        private void frm2_DataBack(object sender, int PersonID)
        {
            if (PersonID != -1)
            {
                _PersonID = PersonID;
                txtFilter.Text = PersonID.ToString();
                cbFilter.SelectedIndex = 0; // Set the filter to PersonID
                _Search();
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)Keys.Enter)
            {
                _Search();
                e.Handled = true; // Prevent the beep sound on Enter key press
            }

            if((encbFilter)cbFilter.SelectedItem == encbFilter.PersonID)
            {
                //allow only numbers
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        public void FilterFocus()
        {
            txtFilter.Focus();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
