using DVLD.Classes;
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
    public partial class frmManageLocalDLApplications: Form
    {

        private enum enStatus
        {
            All = 0,
            New = 1,
            Cancelled = 2,
            Completed = 3
        }
        private enum encbFilter
        {
            None,
            LDLAppID,
            NationalNo,
            FullName,
            Status
        }

        private encbFilter _enSelectedIndex;
        private enStatus _enSelectedActiveIndex;
        
        private DataTable _dtAllLDLApplications;

        public frmManageLocalDLApplications()
        {
            InitializeComponent();
            clsUtil.ApplyCustomStyle(ref dgvAllApplications);
        }

        private void frmManageLocalDLApplications_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _EnableContextMenu()
        {
            _EnabledFalseAll();
            if (!Enum.TryParse<enStatus>((string)dgvAllApplications.CurrentRow.Cells[6].Value, out enStatus result))
            {
                MessageBox.Show("Something went wrong", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return; 
            }
            if(result == enStatus.Cancelled)
            {
                //_EnabledFalseAll();
                
                return;
            }
            _EnabledTrueAll();
            switch ((int)dgvAllApplications.CurrentRow.Cells[5].Value)
            {
                case 0:
                    {
                        visionTestToolStripMenuItem.Enabled = true;
                        writtenTestToolStripMenuItem.Enabled = false;
                        streetTestToolStripMenuItem.Enabled = false;

                        tsmIssueDrivingLicense.Enabled = false;
                        tsmShowLicense.Enabled = false;
                        break;
                    }

                case 1:
                    {
                        visionTestToolStripMenuItem.Enabled = false;
                        writtenTestToolStripMenuItem.Enabled = true;
                        streetTestToolStripMenuItem.Enabled = false;

                        tsmIssueDrivingLicense.Enabled = false;
                        tsmShowLicense.Enabled = false;
                        break;
                    }

                case 2:
                    {
                        visionTestToolStripMenuItem.Enabled = false;
                        writtenTestToolStripMenuItem.Enabled = false;
                        streetTestToolStripMenuItem.Enabled = true;

                        tsmIssueDrivingLicense.Enabled = false;
                        tsmShowLicense.Enabled = false;
                        break;
                    }

                case 3:
                    {
                        visionTestToolStripMenuItem.Enabled = false;
                        writtenTestToolStripMenuItem.Enabled = false;
                        streetTestToolStripMenuItem.Enabled = false;

                        tsmEditApplication.Enabled = false;
                        tsmDeleteApplication.Enabled = false;
                        tsmCancelApplication.Enabled = false;
                        tsmScheduleTest.Enabled = false;
                        tsmIssueDrivingLicense.Enabled = true;
                        tsmShowLicense.Enabled = false;
                        break;
                    }
                default:
                    {
                        visionTestToolStripMenuItem.Enabled = false;
                        writtenTestToolStripMenuItem.Enabled = false;
                        streetTestToolStripMenuItem.Enabled = false;

                        tsmIssueDrivingLicense.Enabled = false;
                        tsmShowLicense.Enabled = false;
                        break;
                    }
            }

            if((string)dgvAllApplications.CurrentRow.Cells[6].Value == "Completed")
            {
                tsmIssueDrivingLicense.Enabled = false;
                tsmShowLicense.Enabled = true;
            }


        }

        private void _EnabledFalseAll()
        {
            tsmEditApplication.Enabled = false;
            tsmDeleteApplication.Enabled = false;
            tsmCancelApplication.Enabled = false;
            tsmScheduleTest.Enabled = false;
            tsmIssueDrivingLicense.Enabled = false;
            tsmShowLicense.Enabled = false;
        }
        
        private void _EnabledTrueAll()
        {
            tsmEditApplication.Enabled = true;
            tsmDeleteApplication.Enabled = true;
            tsmCancelApplication.Enabled = true;
            tsmScheduleTest.Enabled = true;
            tsmIssueDrivingLicense.Enabled = true;
            tsmShowLicense.Enabled = true;
        }

        private void _RefreshApplicationsList()
        {
            _dtAllLDLApplications = clsLocalDLApplication.GetAllLocalDrivingLicenseApplicationsView();
            dgvAllApplications.DataSource = _dtAllLDLApplications;
            _RefreshCountLabel();
            if (dgvAllApplications.Rows.Count > 0)
            {

                dgvAllApplications.Columns[0].HeaderText = "L.D.L.AppID";
                //dgvAllApplications.Columns[0].Width = 70;

                dgvAllApplications.Columns[1].HeaderText = "Driving Class";
                //dgvAllApplications.Columns[1].Width = 250;

                dgvAllApplications.Columns[2].HeaderText = "National No.";
                //dgvAllApplications.Columns[2].Width = 100;

                dgvAllApplications.Columns[3].HeaderText = "Full Name";
                //dgvAllApplications.Columns[3].Width = 300;

                dgvAllApplications.Columns[4].HeaderText = "Application Date";
                //dgvAllApplications.Columns[4].Width = 100;

                dgvAllApplications.Columns[5].HeaderText = "Passed Tests";
                //dgvAllApplications.Columns[5].Width = 100;
                
                dgvAllApplications.Columns[6].HeaderText = "Status";
                //dgvAllApplications.Columns[6].Width = 100;
            }
        }

        private void _RefreshCountLabel()
        {
            lblRecords.Text = dgvAllApplications.Rows.Count.ToString();
        }

        private void _LoadData()
        {
            _RefreshApplicationsList();
            cbFilter.DataSource = Enum.GetValues(typeof(encbFilter));
            cbStatus.DataSource = Enum.GetValues(typeof(enStatus));
            cbFilter.SelectedIndex = (int)encbFilter.None;
            cbStatus.SelectedIndex = (int)enStatus.All;
            
        }

        private void frmManageApplications_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _FilterStatus()
        {

            if (cbStatus.SelectedItem == null)
            {
                cbStatus.SelectedIndex = 0; // Default to All if no selection
            }
            _enSelectedActiveIndex = (enStatus)cbStatus.SelectedItem;

            switch (_enSelectedActiveIndex)
            {
                case enStatus.Completed:
                    _dtAllLDLApplications.DefaultView.RowFilter = "Status = 'Completed'";
                    break;

                case enStatus.Cancelled:
                    _dtAllLDLApplications.DefaultView.RowFilter = "Status = 'Cancelled'";
                    break;

                case enStatus.New:
                    _dtAllLDLApplications.DefaultView.RowFilter = "Status = 'New'";
                    break;

                case enStatus.All:
                    _dtAllLDLApplications.DefaultView.RowFilter = null;
                    break;

                default:
                    _dtAllLDLApplications.DefaultView.RowFilter = null;
                    break;
            }
            _RefreshCountLabel();

        }

        private void _FilterData()
        {
            _enSelectedIndex = (encbFilter)cbFilter.SelectedIndex;
            switch (_enSelectedIndex)
            {
                case encbFilter.None:
                    txtFilter.Visible = false;
                    _dtAllLDLApplications.DefaultView.RowFilter = null;
                    break;

                case encbFilter.LDLAppID:
                    _dtAllLDLApplications.DefaultView.RowFilter = $"LocalDrivingLicenseApplicationID = {txtFilter.Text}";
                    break;

                case encbFilter.NationalNo:
                    _dtAllLDLApplications.DefaultView.RowFilter = $"NationalNo like '{txtFilter.Text}%'";
                    break;

                case encbFilter.FullName:
                    _dtAllLDLApplications.DefaultView.RowFilter = $"FullName like '{txtFilter.Text}%'";
                    break;

                case encbFilter.Status:
                    {
                        break;
                    }

                default:
                    _dtAllLDLApplications.DefaultView.RowFilter = null;
                    break;
            }
            _RefreshCountLabel();
        }


        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtAllLDLApplications.DefaultView.RowFilter = null;
            _RefreshCountLabel();

            if ((encbFilter)cbFilter.SelectedIndex == encbFilter.Status)
            {
                txtFilter.Visible = false;
                cbStatus.Visible = true;
                cbStatus.SelectedIndex = (int)enStatus.All; // Reset to All
                cbStatus.Focus();
            }
            else if ((encbFilter)cbFilter.SelectedIndex == encbFilter.None)
            {
                txtFilter.Visible = false;
                cbStatus.Visible = false;
            }
            else if (cbFilter.SelectedItem != null)
            {
                _enSelectedIndex = (encbFilter)cbFilter.SelectedItem;
                txtFilter.Text = "";
                cbStatus.Visible = false;
                txtFilter.Visible = true;
                txtFilter.Focus();
            }

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (txtFilter.Text != "")
                _FilterData();
            else
                _RefreshApplicationsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
           _FilterStatus();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplication frm = new frmLocalDrivingLicenseApplication();
            frm.ShowDialog();
            _RefreshApplicationsList();
        }

        private void tsmShowApplicationDetailes_Click(object sender, EventArgs e)
        {
            _ShowApplicationDetailes();
        }

        private void _ShowApplicationDetailes()
        {
            frmApplicationDetails frm = new frmApplicationDetails((int)dgvAllApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplicationsList();
        }

        private void tsmEditApplication_Click(object sender, EventArgs e)
        {
            _EditApplication();
        }

        private void _EditApplication()
        {
            frmLocalDrivingLicenseApplication frm = new frmLocalDrivingLicenseApplication((int)dgvAllApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplicationsList();
        }

        private void tsmDeleteApplication_Click(object sender, EventArgs e)
        {
            _DeleteApplication();
        }

        private void _DeleteApplication()
        {
            if((string)dgvAllApplications.CurrentRow.Cells[6].Value != "Completed")
            {
                if (MessageBox.Show("Are you sure you want to delete this application?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    return;
                }
                clsLocalDLApplication LDLApp = clsLocalDLApplication.Find((int)dgvAllApplications.CurrentRow.Cells[0].Value);
                clsApplication App = clsApplication.Find(LDLApp.ApplicationID);

                if (clsLocalDLApplication.DeleteLocalDrivingLicenseApplication(LDLApp.LocalDrivingLicenseApplicationID))
                {
                    if (clsApplication.DeleteApplication(App.ApplicationID))
                    {
                        MessageBox.Show("Application deleted Successfully.", "Deleted",
                     MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        _RefreshApplicationsList();
                    }
                }
                else
                    MessageBox.Show("The application is related to another tables", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
            else
                MessageBox.Show("You cannot delete a complated application", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void tsmCancelApplication_Click(object sender, EventArgs e)
        {
            _CancelApplication();
        }

        private void _CancelApplication()
        {
            if ((string)dgvAllApplications.CurrentRow.Cells[6].Value == "New")
            {
                if (MessageBox.Show("Are you sure you want to Cancel this application?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    return;
                }
                clsLocalDLApplication LDLApp = clsLocalDLApplication.Find((int)dgvAllApplications.CurrentRow.Cells[0].Value);
                clsApplication App = clsApplication.Find(LDLApp.ApplicationID);
                App.ApplicationStatus = 2;
                if (App.Save())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Deleted",
                     MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    _RefreshApplicationsList();
                }
            }
            else
                MessageBox.Show("You cannot cancel a completed application", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // tag = 1 , Vision Test
            _TestAppointment((ToolStripMenuItem)sender);
        }

        private void _TestAppointment(ToolStripMenuItem s)
        {
            frmTestAppointments frm = new frmTestAppointments(
                (int)dgvAllApplications.CurrentRow.Cells[0].Value, Convert.ToByte(s.Tag));
            frm.ShowDialog();
            _RefreshApplicationsList();

        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // tag = 2 , Written Test
            _TestAppointment((ToolStripMenuItem)sender);
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // tag = 3 , Street Test
            _TestAppointment((ToolStripMenuItem)sender);
        }

        private void tsmIssueDrivingLicense_Click(object sender, EventArgs e)
        {
            _IssueDrivingLicense();
        }

        private void _IssueDrivingLicense()
        {
            frmIssueDrivingLicense frm = new frmIssueDrivingLicense((int)dgvAllApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplicationsList();
        }

        private void tsmShowLicense_Click(object sender, EventArgs e)
        {
            _ShowLicense();
        }

        private void _ShowLicense()
        {
            // 0 = LocalDLApplicationID
            int LicenseID = clsLicense.FindByApplicationID(clsLocalDLApplication.Find((int)dgvAllApplications.CurrentRow.Cells[0].Value).ApplicationID).LicenseID;
            frmLicenseInfo frm = new frmLicenseInfo(LicenseID);
            frm.ShowDialog();
            _RefreshApplicationsList();
        }

        private void tsmShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            _ShowPersonLicenseHistory();
        }

        private void _ShowPersonLicenseHistory()
        {
            // 2 = NationalNo.
            int PersonID = clsPerson.Find((string)dgvAllApplications.CurrentRow.Cells[2].Value).ID;
            frmLicenseHistory frm = new frmLicenseHistory(PersonID);
            frm.ShowDialog();
            _RefreshApplicationsList();
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            _EnableContextMenu();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(_enSelectedIndex == encbFilter.LDLAppID)
            {
                // Allow only digits for LDLAppID 
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Ignore the key press
                }
            }

        }
    }
}
