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
    public partial class frmInternationalDLApplication : Form
    {
        enum enMode { New = 1, Update = 2 }

        enMode _Mode;
        int LicenseID = -1, PersonID = -1;
        clsInternationalLicense _InternationalLicense;
        clsApplication _IApplication;
        public frmInternationalDLApplication()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;

            _Mode = enMode.New;
        }
        public frmInternationalDLApplication(int licenseID)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;

            LicenseID = licenseID;
            _Mode = enMode.Update;
        }

        private void _LoadData()
        {
            if (_Mode == enMode.Update)
            {
                txtLicenseID.Text = LicenseID.ToString();
                gbSearch.Enabled = false;
                _Search();
                return;
            }
            string CurrentDate = DateTime.Now.ToShortDateString();
            lblInternationalLAppID.Text = "[????]";
            lblAppDate.Text = CurrentDate;
            lblIssueDate.Text = CurrentDate;
            lblFees.Text = "[????]";
            lblInternationalLAppID.Text = "[????]";
            lblInternationalLAppID.Text = "[????]";
            lblExpirationDate.Text = CurrentDate;
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;

            lnklblShowLicensesInfo.Enabled = false;
            lnklblShowLicensesHistory.Enabled = false;
            btnIssue.Enabled = false;

            txtLicenseID.Focus();
        }

        private void frmInternationalDLApplication_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _Search()
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text))
            {
                MessageBox.Show("Please enter a License ID to search.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicenseID.Focus();
                return;
            }
            if (_Mode == enMode.New)
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
            if(!clsLicense.isLicenseExist(LicenseID))
            {
                MessageBox.Show("The provided License ID does not correspond to an existing license.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Text = "";
                txtLicenseID.Focus();
                return;
            }
            ctrlDriverLicenseInfo1.LoadData(LicenseID);
            PersonID = ctrlDriverLicenseInfo1.GetPersonID();
            lblLocalLicenseID.Text = LicenseID.ToString();
            lblFees.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.NewInternationalLicense).ApplicationFees.ToString();
            if (clsInternationalLicense.isInternationalLicenseExistByLocalLicenseID(LicenseID))
            {
                _InternationalLicense = clsInternationalLicense.FindByLocalLicenseID(LicenseID);
                if (_InternationalLicense != null)
                {
                    clsApplication App = clsApplication.Find(_InternationalLicense.ApplicationID);
                    lblInternationalLAppID.Text = _InternationalLicense.ApplicationID.ToString();
                    lblAppDate.Text = App.ApplicationDate.ToShortDateString();
                    lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
                    lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                    lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();
                    lblCreatedBy.Text = clsUser.Find(_InternationalLicense.CreatedByUserID).UserName;

                    lnklblShowLicensesInfo.Enabled = true;
                    lnklblShowLicensesHistory.Enabled = true;
                    btnIssue.Enabled = false;

                    MessageBox.Show($"Person already have an active international license with ID = {_InternationalLicense.InternationalLicenseID}",
                        "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                //else
                //{
                //    MessageBox.Show("No International DL Application found with the provided License ID.", "Information",
                //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

            }
            //else
            //{
            //    MessageBox.Show("The provided License ID does not correspond to an International License.", "Error",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            lnklblShowLicensesHistory.Enabled = true;
            btnIssue.Enabled = true;


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _Search();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(_Issue())
            {
                _Mode = enMode.Update;
                //_LoadData();
                lnklblShowLicensesInfo.Enabled = true;
                lnklblShowLicensesHistory.Enabled = true;
                btnIssue.Enabled = false;
                gbSearch.Enabled = false;

                lblInternationalLAppID.Text = _InternationalLicense.ApplicationID.ToString();
                lblAppDate.Text = _IApplication.ApplicationDate.ToShortDateString();
                lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
                //lblFees.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.NewInternationalLicense).ApplicationFees.ToString();
                lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();
                //lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;

            }
        }

        private bool _Issue()
        {
            if(!clsLicense.isLicenseExist(LicenseID))
            {
                MessageBox.Show("Invalid License ID", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (!clsInternationalLicense.IsAllowedToAddNew(LicenseID))
            {
                MessageBox.Show("You are not allowed to issue a new International Driving License for this Local License ID.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                return false;
            }
            clsPerson person = clsPerson.Find(PersonID);
            if (person == null)
            {
                return false;
            }
            _IApplication = new clsApplication();
            _IApplication.ApplicantPersonID = person.ID;
            _IApplication.ApplicationDate = DateTime.Now;
            _IApplication.ApplicationTypeID = (int)clsApplicationTypes.enApplicationType.NewInternationalLicense;
            _IApplication.ApplicationStatus = (int)clsApplication.enApplicationStatus.Completed;
            _IApplication.LastStatusDate = DateTime.Now;
            _IApplication.PaidFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.NewInternationalLicense).ApplicationFees;
            _IApplication.CreatedByUserID = clsGlobal.CurrentUser.ID;
            if (_IApplication.Save())
            {

                _InternationalLicense = new clsInternationalLicense();
                _InternationalLicense.ApplicationID = _IApplication.ApplicationID;
                _InternationalLicense.DriverID = clsLicense.Find(LicenseID).DriverID;
                _InternationalLicense.IssuedUsingLocalLicenseID = LicenseID;
                _InternationalLicense.IssueDate = DateTime.Now;
                _InternationalLicense.IsActive = true;
                _InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.ID;
                if (_InternationalLicense.Save())
                {
                    MessageBox.Show($"International License Issued Successfully with ID = {_InternationalLicense.InternationalLicenseID}",
                        "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return true;
                }

            }
                    

                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            return false;

        }

        private void lnklblShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_InternationalLicense != null)
            {
                frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(_InternationalLicense.InternationalLicenseID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No International License information available.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lnklblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(LicenseID <= 0)
            {
                MessageBox.Show("Please search for a valid License ID first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!clsLicense.isLicenseExist(LicenseID))
            {
                MessageBox.Show("Invalid License ID", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            frmLicenseHistory frm = new frmLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void frmInternationalDLApplication_Activated(object sender, EventArgs e)
        {
            txtLicenseID.Focus();
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
