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
    public partial class frmReleaseLicense : Form
    {
        int LicenseID = -1;
        clsLicense _License;
        clsDetainedLicense _DetainedLicense;
        enum enMode { New =1,Update=2 }

        enMode _Mode;
        public frmReleaseLicense()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;

            _Mode = enMode.New;
        }

        public frmReleaseLicense(int licenseID)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;

            LicenseID = licenseID;
            _Mode = enMode.Update;

        }

        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

            frmLicenseHistory frm = new frmLicenseHistory(clsDriver.Find(_License.DriverID).PersonID);
            frm.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            _Release();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _Search();
        }

        private void _LoadData()
        {
            if(_Mode == enMode.Update)
            {
                txtLicenseID.Text = LicenseID.ToString();
                gbSearch.Enabled = false;
                //txtLicenseID.Enabled = false;
                _Search();
                return;
            }

            string CurrentDate = DateTime.Now.ToShortDateString();
            lblDetainID.Text = "[????]";
            lblDetainDate.Text = CurrentDate;
            lblAppFees.Text = "[$$$$]";
            lblTotalFees.Text = "[$$$$]";
            lblLicenseID.Text = "[????]";
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblFineFees.Text = "[$$$$]";
            lblDetainAppID.Text = "[????]";

            lnklblShowLicensesHistory.Enabled = false;
            lnklblShowLicensesInfo.Enabled = false;
            btnRelease.Enabled = false;

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
            if(_Mode == enMode.New)
            {
                if (!int.TryParse(txtLicenseID.Text, out LicenseID))
                {
                    MessageBox.Show("Please enter a valid License ID.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLicenseID.Text = "";
                    txtLicenseID.Focus();
                    return;
                }
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
            lblLicenseID.Text = LicenseID.ToString();


            if (!clsDetainedLicense.isLicenseDetained(_License.LicenseID))
            {
                MessageBox.Show("Selected License is Not Detained, choose another license", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DetainedLicense = clsDetainedLicense.FindByLicenseID(_License.LicenseID);
            if (_DetainedLicense == null)
            {
                MessageBox.Show("No Detained License found for the provided License ID.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblDetainID.Text = _DetainedLicense.DetainID.ToString();
            lblDetainDate.Text = _DetainedLicense.DetainDate.ToShortDateString();

            decimal AppFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationFees;
            decimal FineFees = _DetainedLicense.FineFees;
            decimal TotalFees = AppFees + FineFees;
            lblAppFees.Text = AppFees.ToString();
            lblFineFees.Text = FineFees.ToString();
            lblTotalFees.Text = TotalFees.ToString();
            lblCreatedBy.Text = clsUser.Find(_DetainedLicense.CreatedByUserID).UserName;

            lnklblShowLicensesHistory.Enabled = true;
            btnRelease.Enabled = true;
            return;

        }

        private bool _Release()
        {
            if (_License == null || _DetainedLicense == null)
            {
                MessageBox.Show("Please search for a valid License ID first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicenseID.Text = "";
                txtLicenseID.Focus();
                return false;
            }
            _DetainedLicense = clsDetainedLicense.FindByLicenseID(_License.LicenseID);
            if(_DetainedLicense == null)
            {
                MessageBox.Show("No Detained License found for the provided License ID.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLicenseID.Text = "";
                txtLicenseID.Focus();
                return false;
            }

            clsApplication NewApp = new clsApplication();
            NewApp.ApplicantPersonID = clsDriver.Find(_License.DriverID).PersonID;
            NewApp.ApplicationDate = DateTime.Now;
            NewApp.ApplicationTypeID = (int)clsApplicationTypes.enApplicationType.ReleaseDetainedDrivingLicsense;
            NewApp.ApplicationStatus = (int)clsApplication.enApplicationStatus.Completed;
            NewApp.LastStatusDate = DateTime.Now;
            NewApp.PaidFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationFees;
            NewApp.CreatedByUserID = clsGlobal.CurrentUser.ID;

            if ((MessageBox.Show("Are you sure you want to Release this detained license?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes))
            {
                return false;
            }

            if (NewApp.Save())
            {
                _DetainedLicense.ReleaseApplicationID = NewApp.ApplicationID;
                _DetainedLicense.ReleaseDate = DateTime.Now;
                _DetainedLicense.ReleaseByUserID = clsGlobal.CurrentUser.ID;
                _DetainedLicense.IsReleased = true;
                if (_DetainedLicense.Save())
                {
                    lblDetainAppID.Text = NewApp.ApplicationID.ToString();
                    MessageBox.Show($"Detained License Released Successfully.",
                        "License Released", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ctrlDriverLicenseInfo1.LoadData(_DetainedLicense.LicenseID);
                    //txtLicenseID.Text = "";
                    btnRelease.Enabled = false;
                    lnklblShowLicensesHistory.Enabled = true;
                    lnklblShowLicensesInfo.Enabled = true;
                    gbSearch.Enabled = false;
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

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmReleaseLicense_Activated(object sender, EventArgs e)
        {
            txtLicenseID.Focus();
        }
    }
}
