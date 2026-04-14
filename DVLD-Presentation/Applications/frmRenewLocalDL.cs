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
    public partial class frmRenewLocalDL : Form
    {
        int LicenseID = -1;
        clsLicense _License;
        clsApplication _RenewApplication;
        public frmRenewLocalDL()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            _Renew();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRenewLocalDL_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            string CurrentDate = DateTime.Now.ToShortDateString();
            lblRenewLAppID.Text = "[????]";
            //lblAppDate.Text = CurrentDate;
            lblIssueDate.Text = CurrentDate;
            lblAppFees.Text = "[$$$$]";
            lblLicenseFees.Text = "[$$$$]";
            lblRenewedLicenseID.Text = "[????]";
            lblOldLicenseID.Text = "[????]";
            lblExpirationDate.Text = CurrentDate;
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblTotalFees.Text = "[$$$$]";

            lnklblShowLicensesHistory.Enabled = false;
            lnklblShowLicensesInfo.Enabled = false;
            btnRenew.Enabled = false;

            txtLicenseID.Focus();
        }

        private void _Search()
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text))
            {
                MessageBox.Show("Please enter a License ID to search.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicenseID.Text = "";
                txtLicenseID.Focus();
                return;
            }
            //int LicenseID;
            if (int.TryParse(txtLicenseID.Text, out LicenseID))
            {
                if (!clsLicense.isLicenseExist(LicenseID))
                {
                    MessageBox.Show("Invalid License ID", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    txtLicenseID.Text = "";
                    txtLicenseID.Focus();
                    return;
                }
                _License = clsLicense.Find(LicenseID);
                ctrlDriverLicenseInfo1.LoadData(LicenseID);
                lblOldLicenseID.Text = LicenseID.ToString();
                int AppFees = (int)clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.RenewDrivingLicenseService).ApplicationFees;
                int LicenseFees = (int)clsLicenseClass.Find(clsLicense.Find(LicenseID).LicenseClass).ClassFees;
                lblAppFees.Text = AppFees.ToString();
                lblLicenseFees.Text = LicenseFees.ToString();
                lblTotalFees.Text = (LicenseFees + AppFees).ToString();
                if (!_License.isAllowedToRenew())
                {
                    MessageBox.Show($"Selected License is not yet expiared, it will expire on: {_License.ExpirationDate.ToShortDateString()}",
                        "Not Allowed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lnklblShowLicensesHistory.Enabled = true;
                //lnklblShowLicensesInfo.Enabled = true;
                btnRenew.Enabled = true;
                return;

            }
            else
            {
                MessageBox.Show("Please enter a valid License ID.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Text = "";
                txtLicenseID.Focus();
            }

        }

        private bool _Renew()
        {
            if (_License == null)
            {
                MessageBox.Show("Please search for a valid License ID first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicenseID.Text = "";
                txtLicenseID.Focus();
                return false;
            }


            clsApplication OldApp = clsApplication.Find(_License.ApplicationID);
            if (OldApp == null)
            {
                MessageBox.Show("No Application found for the provided License ID.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            
            if (!_License.isAllowedToRenew())
            {
                MessageBox.Show($"Selected License is not yet expiared, it will expire on: {_License.ExpirationDate.ToShortDateString()}",
                    "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Text = "";
                txtLicenseID.Focus();
                return false;
            }
            if(_License.isHasActiveLicense(OldApp.ApplicantPersonID))
            {
                MessageBox.Show("The selected person already has an active license at the same class.\nCannot renew at this time.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Text = "";
                txtLicenseID.Focus();
                return false;
            }


            if ((MessageBox.Show("Are you sure you want to Renew the license?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes))
            {
                return false;
            }
            clsApplication NewApp = new clsApplication();
            NewApp.ApplicantPersonID = OldApp.ApplicantPersonID;
            NewApp.ApplicationDate = DateTime.Now;
            NewApp.ApplicationTypeID = (int)clsApplicationTypes.enApplicationType.RenewDrivingLicenseService;
            NewApp.ApplicationStatus = (int)clsApplication.enApplicationStatus.Completed;
            NewApp.LastStatusDate = DateTime.Now;
            NewApp.PaidFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.RenewDrivingLicenseService).ApplicationFees;
            NewApp.CreatedByUserID = clsGlobal.CurrentUser.ID;
            if (NewApp.Save())
            {
                _License.IsActive = false; // Deactivate the old license
                if (!_License.Save())
                {
                    MessageBox.Show("Error: License is not saved successfully.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return false;
                }
                clsLicense NewLicense = new clsLicense();
                NewLicense.ApplicationID = NewApp.ApplicationID;
                NewLicense.DriverID = _License.DriverID;
                NewLicense.LicenseClass = _License.LicenseClass;
                NewLicense.IssueDate = DateTime.Now;
                NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.Find(_License.LicenseClass).DefaultValidityLength);
                NewLicense.Notes = txtNote.Text;
                NewLicense.PaidFees = clsLicenseClass.Find(_License.LicenseClass).ClassFees;
                NewLicense.IsActive = true;
                NewLicense.IssueReason = (int)clsLicense.enIssueReason.Renew;
                NewLicense.CreatedByUserID = clsGlobal.CurrentUser.ID;
                if (NewLicense.Save())
                {
                    lblRenewLAppID.Text = NewApp.ApplicationID.ToString();
                    //lblAppDate.Text = NewApp.ApplicationDate.ToShortDateString();
                    lblIssueDate.Text = NewLicense.IssueDate.ToShortDateString();
                    txtNote.Text = NewLicense.Notes;
                    lblRenewedLicenseID.Text = NewLicense.LicenseID.ToString();
                    lblExpirationDate.Text = NewLicense.ExpirationDate.ToShortDateString();
                    lblCreatedBy.Text = NewLicense.CreatedByUserID.ToString();
                    MessageBox.Show($"Licensed Renewed Successfully with ID = {NewLicense.LicenseID}",
                        "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    gbSearch.Enabled= false;
                    //txtLicenseID.Text = "";
                    btnRenew.Enabled = false;
                    lnklblShowLicensesInfo.Enabled = true;

                    return true;
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

        }
        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _Search();
        }

        private void lnklblShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_License == null)
            {
                MessageBox.Show("Please search for a valid License ID first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicenseID.Text = "";
                txtLicenseID.Focus();
                return;
            }

            frmLicenseInfo frm = new frmLicenseInfo(_License.LicenseID);
            frm.ShowDialog();
        }

        private void lnklblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_License == null)
            {
                MessageBox.Show("Please search for a valid License ID first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicenseID.Text = "";
                txtLicenseID.Focus();
                return;
            }
            if (!clsLicense.isLicenseExist(_License.LicenseID))
            {
                MessageBox.Show("Invalid License ID", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtLicenseID.Text = "";
                txtLicenseID.Focus();
                return;
            }

            frmLicenseHistory frm = new frmLicenseHistory(_License.LicenseID);
            frm.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmRenewLocalDL_Activated(object sender, EventArgs e)
        {
            txtLicenseID.Focus();
        }
    }
}
