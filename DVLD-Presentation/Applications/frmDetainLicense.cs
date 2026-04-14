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
    public partial class frmDetainLicense : Form
    {
        int LicenseID = -1;
        clsLicense _License;
        public frmDetainLicense()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            _Search();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            _Detain();
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
        
        private void _LoadData()
        {
            string CurrentDate = DateTime.Now.ToShortDateString();
            lblDetainID.Text = "[????]";
            lblDetainDate.Text = CurrentDate;
            NUDFineFees.Value = 0;
            lblLicenseID.Text = "[????]";
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;

            lnklblShowLicensesHistory.Enabled = false;
            lnklblShowLicensesInfo.Enabled = false;
            btnDetain.Enabled = false;

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
            lblLicenseID.Text = LicenseID.ToString();


            if (clsDetainedLicense.isLicenseDetained(_License.LicenseID))
            {
                MessageBox.Show("Selected License is already Detain, choose another license", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lnklblShowLicensesHistory.Enabled = true;
            btnDetain.Enabled = true;
            return;

        }

        private bool _Detain()
        {
            if (_License == null)
            {
                MessageBox.Show("Please search for a valid License ID first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicenseID.Text = "";
                txtLicenseID.Focus();
                return false;
            }

            clsDetainedLicense DetainLicense = new clsDetainedLicense();
            DetainLicense.LicenseID = _License.LicenseID;
            DetainLicense.DetainDate = DateTime.Now;
            DetainLicense.FineFees = NUDFineFees.Value;
            DetainLicense.CreatedByUserID = clsGlobal.CurrentUser.ID;
            DetainLicense.IsReleased = false;

            if ((MessageBox.Show("Are you sure you want to Detain this license?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes))
            {
                return false;
            }

            if (DetainLicense.Save())
            {
                lblDetainID.Text = DetainLicense.DetainID.ToString();
                lblDetainDate.Text = DetainLicense.DetainDate.ToShortDateString();
                lblLicenseID.Text = DetainLicense.LicenseID.ToString();
                lblCreatedBy.Text = DetainLicense.CreatedByUserID.ToString();
                MessageBox.Show($"License Detained Successfully with ID = {DetainLicense.DetainID}",
                    "License Detained", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                ctrlDriverLicenseInfo1.LoadData(DetainLicense.LicenseID);
                //txtLicenseID.Text = "";
                btnDetain.Enabled = false;
                NUDFineFees.Enabled = false;
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

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmDetainLicense_Activated(object sender, EventArgs e)
        {
            txtLicenseID.Focus();
        }
    }
}
