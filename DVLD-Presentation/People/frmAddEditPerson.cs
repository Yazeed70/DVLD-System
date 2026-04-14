using DVLD.Classes;
using DVLD_Business;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmAddEditPerson: Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _PersonID;
        clsPerson _Person;

        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            _Mode = enMode.Update;
        }
        
        public frmAddEditPerson()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }

        private void _LoadData()
        {
            _FillCountriesInComoboBox();
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            //ctlAddAndEditPerson1._FillCountriesInComoboBox();
            //ctrlAddEditPerson1.UpdateNationalityCountryID("Jordan");
            cbCountry.Text = "Jordan";

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                this.Text = "Add New Person";
                //ctrlAddEditPerson1.UpdateMode();
                _Person = new clsPerson();
                return;
            }

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID);
                this.Close();

                return;
            }
            lblMode.Text = $"Edit Person ID =  {_Person.ID}";
            this.Text = "Edit Person";

            lblPersonID.Text = _Person.ID.ToString();
            txtNationalNo.Text = _Person.NationalNo;
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            if (_Person.ThirdName != "")
                txtThirdName.Text = _Person.ThirdName;

            txtLastName.Text = _Person.LastName;
            if (_Person.Gendor == 0)
                rbtnMale.Checked = true;
            else
                rbtnFemale.Checked = true;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            txtPhone.Text = _Person.Phone;
            if (_Person.ImagePath != "")
            {
                pbImage.ImageLocation = _Person.ImagePath;
                llRemoveImage.Visible = true;
            }

            //this will select the country in the combobox.
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Person.NationalityCountryID).CountryName);

            //ctrlAddEditPerson1._LoadData(_Person); old code
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //ctrlAddEditPerson1.GetPersonDataFromForm(ref _Person);
            GetPersonDataFromForm();
            if (_Person.Save())
                    MessageBox.Show("Data Saved Successfully.");
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.");

            _Mode = enMode.Update;
            lblMode.Text = $"Edit Person ID =  {_Person.ID}";
            this.Text = "Edit Person";
            lblPersonID.Text = _Person.ID.ToString();
            //ctrlAddEditPerson1.UpdateMode($"Edit Person ID =  {_Person.ID}");
            //ctrlAddEditPerson1.UpdatePersonID(_Person.ID);

            DataBack?.Invoke(this, _Person.ID);

        }

        public void GetPersonDataFromForm()
        {

            if (!_HandlePersonImage())
                return;


            //if (int.TryParse(lblPersonID.Text, out int id))
            //{
            //    _Person.ID = id;
            //}

            // National No (from TextBox)
            _Person.NationalNo = txtNationalNo.Text.Trim();

            // First Name (from TextBox)
            _Person.FirstName = txtFirstName.Text.Trim();

            // Second Name (from TextBox)
            _Person.SecondName = txtSecondName.Text.Trim();

            // Third Name (from TextBox, optional)
            _Person.ThirdName = string.IsNullOrEmpty(txtThirdName.Text.Trim()) ? "" : txtThirdName.Text.Trim();

            // Last Name (from TextBox)
            _Person.LastName = txtLastName.Text.Trim();

            // Gender (from RadioButtons)
            _Person.Gendor = (short)(rbtnMale.Checked ? 0 : 1); // Or use Gender enum: _Person.Gender = rbtnMale.Checked ? Gender.Male : Gender.Female;

            // Email (from TextBox)
            _Person.Email = txtEmail.Text.Trim();

            // Address (from TextBox)
            _Person.Address = txtAddress.Text.Trim();

            // Date of Birth (from DateTimePicker)
            _Person.DateOfBirth = dtpDateOfBirth.Value;

            // Phone (from TextBox)
            _Person.Phone = txtPhone.Text.Trim();

            // Image Path (from PictureBox, assuming you save the path or handle the image differently)
            if (pbImage.Image != null && !string.IsNullOrEmpty(pbImage.ImageLocation))
            {
                _Person.ImagePath = pbImage.ImageLocation; // Use ImageLocation for the file path
            }
            else
            {
                _Person.ImagePath = ""; // Default or clear if no image
            }

            // Nationality Country ID (from ComboBox)
            int CountryID = clsCountry.Find(cbCountry.Text).CountryID;
            if (cbCountry.SelectedItem != null)
            {
                // If cbCountry is bound to a data source with ValueMember (e.g., CountryID)
                _Person.NationalityCountryID = CountryID;
            }

        }

        struct CountryItem
        {
            public string Text;
            public int Value;
            public CountryItem(string Text, int Value)
            {
                this.Text = Text;
                this.Value = Value;
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _LoadData();
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
