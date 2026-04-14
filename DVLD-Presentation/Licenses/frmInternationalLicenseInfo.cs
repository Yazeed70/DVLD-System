using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmInternationalLicenseInfo : Form
    {
        int _InternationalLicenseID;
        clsInternationalLicense _InternationalLicense;
        public frmInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();

            _InternationalLicenseID = InternationalLicenseID;
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            clsApplication IApplication;
            _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);
            if( _InternationalLicense != null && (IApplication = clsApplication.Find(_InternationalLicense.ApplicationID)) != null)
            {
                clsPerson Person = clsPerson.Find(IApplication.ApplicantPersonID);
                lblName.Text = Person.FullName;
                lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                lblLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
                lblNationalNo.Text = Person.NationalNo;
                lblGendor.Text = Person.Gendor == (int)clsPerson.enGendor.Male ? "Male" : "Female";
                lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
                lblApplicationID.Text = IApplication.ApplicationID.ToString();
                lblIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
                lblDateOfBirth.Text = Person.DateOfBirth.ToShortDateString();
                lblDriverID.Text = _InternationalLicense.DriverID.ToString();
                lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();

                if(Person.ImagePath != "")
                {
                    try
                    {
                        pbImage.Image = Image.FromFile(Person.ImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("International License not found or application does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
