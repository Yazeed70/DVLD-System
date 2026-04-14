using DVLD.Classes;
using DVLD_Business;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class ctrlAddEditPerson: UserControl
    {
        //public ctrlAddEditPerson()
        //{
        //    InitializeComponent();
        //}

        public void _LoadData(clsPerson Person)
        {
            if (Person == null)
                return;
            lblPersonID.Text = Person.ID.ToString();
            txtNationalNo.Text = Person.NationalNo;
            txtFirstName.Text = Person.FirstName;
            txtSecondName.Text = Person.SecondName;
            if (Person.ThirdName != "")
                txtThirdName.Text = Person.ThirdName;

            txtLastName.Text = Person.LastName;
            if (Person.Gendor == 0)
                rbtnMale.Checked = true;
            else
                rbtnFemale.Checked = true;
            txtEmail.Text = Person.Email;
            txtAddress.Text = Person.Address;
            dtpDateOfBirth.Value = Person.DateOfBirth;
            txtPhone.Text = Person.Phone;
            if (Person.ImagePath != "")
            {
                pbImage.Load(Person.ImagePath);
            }

            //this will select the country in the combobox.
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(Person.NationalityCountryID).CountryName);

        }

        

        public void GetPersonDataFromForm(ref clsPerson Person)
        {
            if (int.TryParse(lblPersonID.Text, out int id))
            {
                Person.ID = id;
            }

            // National No (from TextBox)
            Person.NationalNo = txtNationalNo.Text.Trim();

            // First Name (from TextBox)
            Person.FirstName = txtFirstName.Text.Trim();

            // Second Name (from TextBox)
            Person.SecondName = txtSecondName.Text.Trim();

            // Third Name (from TextBox, optional)
            Person.ThirdName = string.IsNullOrEmpty(txtThirdName.Text.Trim()) ? "" : txtThirdName.Text.Trim();

            // Last Name (from TextBox)
            Person.LastName = txtLastName.Text.Trim();

            // Gender (from RadioButtons)
            Person.Gendor = (short)(rbtnMale.Checked ? 0 : 1); // Or use Gender enum: Person.Gender = rbtnMale.Checked ? Gender.Male : Gender.Female;

            // Email (from TextBox)
            Person.Email = txtEmail.Text.Trim();

            // Address (from TextBox)
            Person.Address = txtAddress.Text.Trim();

            // Date of Birth (from DateTimePicker)
            Person.DateOfBirth = dtpDateOfBirth.Value;

            // Phone (from TextBox)
            Person.Phone = txtPhone.Text.Trim();

            // Image Path (from PictureBox, assuming you save the path or handle the image differently)
            if (pbImage.Image != null && !string.IsNullOrEmpty(pbImage.ImageLocation))
            {
                Person.ImagePath = pbImage.ImageLocation; // Use ImageLocation for the file path
            }
            else
            {
                Person.ImagePath = ""; // Default or clear if no image
            }

            // Nationality Country ID (from ComboBox)
            int CountryID = clsCountry.Find(cbCountry.Text).CountryID;
            if (cbCountry.SelectedItem != null)
            {
                // If cbCountry is bound to a data source with ValueMember (e.g., CountryID)
                Person.NationalityCountryID = CountryID;
            }

        }

        public void UpdateMode(string Mode)
        {
            lblMode.Text = Mode;
        }
        
        public void UpdatePersonID(int PersonID)
        {
            lblPersonID.Text = PersonID.ToString();
        }
        
        public void UpdateNationalityCountryID(string NationalityCountryID)
        {
            cbCountry.Text = NationalityCountryID;
        }

        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();
            List<string> lCountries = new List<string>();

            foreach (DataRow row in dtCountries.Rows)
            {

                lCountries.Add((string)row["CountryName"]);

            }
            cbCountry.DataSource = lCountries;
        }
        
        private void _UpdateDate()
        {
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }

        private void ctrlAddEditPerson_Load(object sender, EventArgs e)
        {
            _FillCountriesInComoboBox();
            _UpdateDate();
        }

        private void llOpenFileDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pbImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            pbImage.ImageLocation = null;
            llRemoveImage.Visible = false;


        }
    }
}
