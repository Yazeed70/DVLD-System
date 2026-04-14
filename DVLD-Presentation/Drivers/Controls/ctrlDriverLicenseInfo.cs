using DVLD_Business;
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
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        int _LicenseID, _PersonID;
        //clsLocalDLApplication _LocalDLApplication;
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public int GetPersonID()
        {
            if(_PersonID != -1) 
                return _PersonID;

            return -1;
        }

        private void _LoadData()
        {
            //_LocalDLApplication = clsLocalDLApplication.Find(_LDLAppID);
            
            clsLicense License = clsLicense.Find(_LicenseID);
            clsApplication App = clsApplication.Find(License.ApplicationID);
            clsPerson PersonInfo = clsPerson.Find(App.ApplicantPersonID);

            if (License != null || PersonInfo != null)
            {
                _PersonID = PersonInfo.ID;
                lblClass.Text = clsLicenseClass.Find(License.LicenseClass).ClassName;
                lblName.Text = PersonInfo.FirstName + " " + PersonInfo.SecondName + " " + PersonInfo.ThirdName + " " + PersonInfo.LastName;
                lblLicenseID.Text = License.LicenseID.ToString();
                lblNationalNo.Text = PersonInfo.NationalNo;
                lblGendor.Text= PersonInfo.Gendor == 0 ? "Male" : "Female";
                lblIssueDate.Text = License.IssueDate.ToShortDateString();
                lblIssueReason.Text = License.GetIssueReason();
                if (License.Notes != "")
                    lblNotes.Text = License.Notes;
                else
                    lblNotes.Text = "No Notes";

                lblIsActive.Text = License.IsActive ? "Yes" : "No";
                lblDateOfBirth.Text = PersonInfo.DateOfBirth.ToShortDateString();
                lblDriverID.Text = License.DriverID.ToString();
                lblExpirationDate.Text = License.ExpirationDate.ToShortDateString();
                lblIsDetained.Text = clsDetainedLicense.isLicenseDetained(License.LicenseID) ? "Yes" : "No";

                string ImagePath = PersonInfo.ImagePath;
                if (ImagePath != "")
                {
                    if (File.Exists(ImagePath))
                        pbImage.Load(ImagePath);
                    else
                        MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Something went wrong", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                //this.Close();
            }

        }

        public void LoadData(int LicenseID)
        {
            _LicenseID = LicenseID;
            if (!clsLicense.isLicenseExist(_LicenseID))
            {
                MessageBox.Show("Invalid License ID", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            _LoadData();
        }

        private void ctrlDriverLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
