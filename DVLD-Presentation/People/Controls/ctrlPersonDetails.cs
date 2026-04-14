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
using System.IO;

namespace DVLD_Presentation
{
    public partial class ctrlPersonDetails: UserControl
    {
        int _PersonID = -1;
        clsPerson _Person;
        public ctrlPersonDetails()
        {
            InitializeComponent();
        }
        public int PersonID
        {
            get { return _PersonID; }
        }

        public void ClearData()
        {
            lblPersonID.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblFullName.Text = "[???]";
            lblGender.Text = "[???]";
            lblEmail.Text = "[???]";
            lblAddress.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
            lblPhone.Text = "[???]";
            pbImage.ImageLocation=null;
            lblCountry.Text = "[???]";
        }

        public void LoadData(int PersonID)
        {
            _PersonID = PersonID;
            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("No Person with PersonID = " + _PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearData();
                return; 
            }
            llEditPersonDetails.Enabled = true;
            string FullName;
            lblPersonID.Text = _Person.ID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            if (_Person.ThirdName != "")
                FullName = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
            else
                FullName = _Person.FirstName + " " + _Person.SecondName + " " + _Person.LastName;

            lblFullName.Text = FullName;
            if (_Person.Gendor == 0)
                lblGender.Text = "Male";
            else
                lblGender.Text = "Female";
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text= _Person.DateOfBirth.ToShortDateString();
            lblPhone.Text = _Person.Phone;
            if (_Person.ImagePath != "" && File.Exists(_Person.ImagePath))
            {
                pbImage.ImageLocation = _Person.ImagePath;
            }
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;

            //this will select the country in the combobox.
            //cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(Person.NationalityCountryID).CountryName);
        }

        private void ctrlPersonDetails_Load(object sender, EventArgs e)
        {

        }

        private void _ShowEditPersonDetails()
        {
            if(_PersonID == -1)
            {
                MessageBox.Show("Please select a person first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmAddEditPerson frm = new frmAddEditPerson(_PersonID);
            frm.DataBack += frm2_DataBack;
            frm.ShowDialog();
        }

        private void llEditPersonDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowEditPersonDetails();
        }

        private void frm2_DataBack(object sender, int PersonID)
        {
            if (PersonID != -1)
                LoadData(_Person.ID);
        }
    }
}
