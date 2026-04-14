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
    public partial class frmReplacementLicense : Form
    {
        int LicenseID = -1;
        clsLicense _License;
        clsApplication _RenewApplication;
        public frmReplacementLicense()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
        }

        private void frmReplacementLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _Search();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            _Replace();
        }

        private void lnklblShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void _LoadData()
        {
            //txtLicenseID.AutoCompleteCustomSource.Add();
            //DataColumn LicensesID = clsLicense.GetAllLicenses().Columns[0];
            foreach (DataRow row in clsLicense.GetAllLicenses().Rows)
            {
                txtLicenseID.AutoCompleteCustomSource.Add(row["LicenseID"].ToString());
            }
            string CurrentDate = DateTime.Now.ToShortDateString();
            lblReplacementLAppID.Text = "[????]";
            lblAppDate.Text = CurrentDate;
            lblAppFees.Text = "[$$$$]";
            lblReplacedLicenseID.Text = "[????]";
            lblOldLicenseID.Text = "[????]";
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;

            lnklblShowLicensesHistory.Enabled = false;
            lnklblShowLicensesInfo.Enabled = false;
            btnReplace.Enabled = false;

            txtLicenseID.Focus();
        }

        private void _Search()
        {
            if (txtLicenseID.Text == "")
            {
                MessageBox.Show("Please enter a License ID to search.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicenseID.Text = "";
                txtLicenseID.Focus();
                return;
            }

            if (!int.TryParse(txtLicenseID.Text, out LicenseID))
            {
                MessageBox.Show("Please enter a valid License ID.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Text = "";
                txtLicenseID.Focus();
                return;
            }

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
            //int AppFees = (int)clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType).ApplicationFees;
            //lblAppFees.Text = AppFees.ToString();
            if (!_License.IsActive)
            {
                MessageBox.Show("Selected License is Not Active, choose an active license", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lnklblShowLicensesHistory.Enabled = true;
            btnReplace.Enabled = true;
            return;

        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLostLicense.Checked)
            {
                lblAppFees.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.ReplacementLostDrivingLicense).ApplicationFees.ToString();
            }
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            if(rbDamagedLicense.Checked)
            {
                lblAppFees.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.ReplacementDamagedDrivingLicense).ApplicationFees.ToString();
            }
        }

        private bool _Replace()
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

            if (!_License.isAllowedToReplace())
            {
                MessageBox.Show($"Selected License is Not Active, choose an active license.",
                    "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Text = "";
                txtLicenseID.Focus();
                return false;
            }
            //if (_License.isHasActiveLicense(OldApp.ApplicantPersonID))
            //{
            //    MessageBox.Show("The selected person already has an active license at the same class.\nCannot renew at this time.",
            //        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtLicenseID.Text = "";
            //    txtLicenseID.Focus();
            //    return false;
            //}


            if ((MessageBox.Show("Are you sure you want to Replace this license?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes))
            {
                return false;
            }
            clsApplication NewApp = new clsApplication();
            if (rbDamagedLicense.Checked)
            {
                NewApp.ApplicationTypeID = (int)clsApplicationTypes.enApplicationType.ReplacementDamagedDrivingLicense;
                NewApp.PaidFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.ReplacementDamagedDrivingLicense).ApplicationFees;
            }
            else if (rbLostLicense.Checked)
            {
                NewApp.ApplicationTypeID = (int)clsApplicationTypes.enApplicationType.ReplacementLostDrivingLicense;
                NewApp.PaidFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.ReplacementLostDrivingLicense).ApplicationFees;
            }
            else
            {
                MessageBox.Show("Please select the reason for replacement.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            NewApp.ApplicantPersonID = OldApp.ApplicantPersonID;
            NewApp.ApplicationDate = DateTime.Now;
            NewApp.ApplicationStatus = (int)clsApplication.enApplicationStatus.Completed;
            NewApp.LastStatusDate = DateTime.Now;
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
                NewLicense.ExpirationDate = _License.ExpirationDate;
                NewLicense.Notes = _License.Notes;
                NewLicense.PaidFees = clsLicenseClass.Find(_License.LicenseClass).ClassFees;
                NewLicense.IsActive = true;
                if(rbDamagedLicense.Checked) 
                    NewLicense.IssueReason = (int)clsLicense.enIssueReason.ReplacementForDamaged;
                else if(rbLostLicense.Checked)
                    NewLicense.IssueReason = (int)clsLicense.enIssueReason.ReplacementForLost;

                    NewLicense.CreatedByUserID = clsGlobal.CurrentUser.ID;
                if (NewLicense.Save())
                {
                    lblReplacementLAppID.Text = NewApp.ApplicationID.ToString();
                    lblAppDate.Text = NewApp.ApplicationDate.ToShortDateString();
                    lblReplacedLicenseID.Text = NewLicense.LicenseID.ToString();
                    lblCreatedBy.Text = NewLicense.CreatedByUserID.ToString();
                    MessageBox.Show($"Licensed Replaced Successfully with ID = {NewLicense.LicenseID}",
                        "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    //txtLicenseID.Text = "";
                    btnReplace.Enabled = false;
                    lnklblShowLicensesInfo.Enabled = true;
                    gbSearch.Enabled = false;
                    gbReplacementFor.Enabled = false;

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

        private void txtLicenseID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Prevent the beep sound on Enter key
                btnSearch.PerformClick(); // Trigger the search button click event
            }
        }

        private void frmReplacementLicense_Activated(object sender, EventArgs e)
        {
            txtLicenseID.Focus();
        }
    }

}
