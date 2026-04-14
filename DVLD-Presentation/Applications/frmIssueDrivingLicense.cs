using DVLD_Business;
using DVLD_Presentation.Global_Classes;
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
    public partial class frmIssueDrivingLicense: Form
    {

        int _LDLAppID;
        

        public frmIssueDrivingLicense(int LDLAppID)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;

            _LDLAppID = LDLAppID;

        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            ctrlLocalDrivingLicenseInfo1.LoadData(_LDLAppID);
            txtNotes.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void _Save()
        {
            clsLocalDLApplication _LocalDLApplication = clsLocalDLApplication.Find(_LDLAppID);
            if (_LocalDLApplication == null)
            {
                MessageBox.Show("No Local Driving License Application found with the given ID.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            clsDriver Driver = new clsDriver();
            clsLicense License = new clsLicense();
            clsApplication App = clsApplication.Find(_LocalDLApplication.ApplicationID);

            int LicenseID = clsLicense.GetActiveLicenseIDByPersonID(App.ApplicantPersonID, _LocalDLApplication.LicenseClassID);
            if ( LicenseID != -1)
            {
                MessageBox.Show("This Person already has a License issued.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            Driver = clsDriver.FindByPersonID(App.ApplicantPersonID);
            if (Driver == null)
            {
                Driver.PersonID = App.ApplicantPersonID;
                Driver.CreatedByUserID = clsGlobal.CurrentUser.ID;
                Driver.CreatedDate = DateTime.Now;
                if(!Driver.Save())
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            else
            {
                License.DriverID = Driver.DriverID;
            }
            License.ApplicationID = App.ApplicationID;
            License.LicenseClass = _LocalDLApplication.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.Find(_LocalDLApplication.LicenseClassID).DefaultValidityLength);
            License.Notes = txtNotes.Text.Trim();
            License.PaidFees = clsLicenseClass.Find(_LocalDLApplication.LicenseClassID).ClassFees;
            License.IsActive = true;
            License.IssueReason = (int)clsLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = clsGlobal.CurrentUser.ID;
            if (License.Save())
            {
                App.ApplicationStatus = (int)clsApplication.enApplicationStatus.Completed;
                App.LastStatusDate = DateTime.Now;
                if (App.Save())
                {
                    MessageBox.Show($"License Issued Successfully with License ID = {License.LicenseID}", "Saved",
                     MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    this.Close();
                }

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
