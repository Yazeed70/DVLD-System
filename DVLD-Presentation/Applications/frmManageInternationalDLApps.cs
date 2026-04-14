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
    public partial class frmManageInternationalDLApps : Form
    {
        private enum enIsActive
        {
            NotActive = 0,
            Active = 1,
            All = 2
            
        }
        private enum encbFilter
        {
            None,
            IntLicenseID,
            ApplicationID,
            DriverID,
            LocalLicenseID,
            IsActive
        }

        private encbFilter _enSelectedIndex;
        private enIsActive _enSelectedActiveIndex;
        int _PersonID = -1;
        DataTable _dtInternationalLicenses;
        public frmManageInternationalDLApps()
        {
            InitializeComponent();
        }

        private void frmManageInternationalDLApps_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            _RefreshList();
            cbFilter.DataSource = Enum.GetValues(typeof(encbFilter));
            cbIsActive.DataSource = Enum.GetValues(typeof(enIsActive));
            cbFilter.SelectedIndex = (int)encbFilter.None;
            cbIsActive.SelectedIndex = (int)enIsActive.All;
        }

        private void _RefreshList()
        {
            _dtInternationalLicenses = clsInternationalLicense.GetAllInternationalLicensesView(); ;
            dgvAllLicenses.DataSource = _dtInternationalLicenses;
            _RefreshCountLabel();
            clsUtil.ApplyCustomStyle(ref dgvAllLicenses);
        }

        private void _RefreshCountLabel()
        {
            lblRecords.Text = dgvAllLicenses.RowCount.ToString();
        }

        private void _FilterData()
        {

            switch (_enSelectedIndex)
            {
                case encbFilter.None:
                    txtFilter.Visible = false;
                    _dtInternationalLicenses.DefaultView.RowFilter = null;
                    break;

                case encbFilter.IntLicenseID:
                    _dtInternationalLicenses.DefaultView.RowFilter = $"[Int.License ID] = {txtFilter.Text}";
                    break;

                case encbFilter.ApplicationID:
                    _dtInternationalLicenses.DefaultView.RowFilter = $"[Application ID] = {txtFilter.Text}";
                    break;

                case encbFilter.DriverID:
                    _dtInternationalLicenses.DefaultView.RowFilter = $"[Driver ID] = {txtFilter.Text}";
                    break;

                case encbFilter.LocalLicenseID:
                    _dtInternationalLicenses.DefaultView.RowFilter = $"[L.License ID] = {txtFilter.Text}";
                    break;

                case encbFilter.IsActive:
                    {
                        //_dtInternationalLicenses.DefaultView.RowFilter = _FilterStatus();
                        break;
                    }

                default:
                    _dtInternationalLicenses.DefaultView.RowFilter = null;
                    break;
            }
            _RefreshCountLabel();

        }


        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshList();
            txtFilter.Text = "";
            _dtInternationalLicenses.DefaultView.RowFilter = null;

            if ((encbFilter)cbFilter.SelectedIndex == encbFilter.IsActive)
            {
                txtFilter.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.SelectedIndex = 2; // Set to "All" by default
                cbIsActive.Focus();
            }
            else if ((encbFilter)cbFilter.SelectedIndex == encbFilter.None)
            {
                txtFilter.Visible = false;
                cbIsActive.Visible = false;
            }
            else
            {
                _enSelectedIndex = (encbFilter)cbFilter.SelectedItem;
                txtFilter.Visible = true;
                cbIsActive.Visible = false;
                txtFilter.Text = "";
                txtFilter.Focus();
            }


        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (txtFilter.Text != "")
                _FilterData();
            else
                _RefreshList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmInternationalDLApplication frm = new frmInternationalDLApplication();
            frm.ShowDialog();
            _RefreshList();
        }

        private void tsmShowPersonDetailes_Click(object sender, EventArgs e)
        {
            _ShowPersonDetailes();
        }

        private void _ShowPersonDetailes()
        {
            _PersonID = clsApplication.Find((int)dgvAllLicenses.CurrentRow.Cells[1].Value).ApplicantPersonID;
            frmPersonDetails frm = new frmPersonDetails(_PersonID);
            frm.ShowDialog();
            _RefreshList();
        }

        private void tsmShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            _ShowPersonLicenseHistory();
        }

        private void _ShowPersonLicenseHistory()
        {
            _PersonID = clsApplication.Find((int)dgvAllLicenses.CurrentRow.Cells[1].Value).ApplicantPersonID;
            frmLicenseHistory frm = new frmLicenseHistory(_PersonID);
            frm.ShowDialog();
        }

        private void tsmShowLicenseDetailes_Click(object sender, EventArgs e)
        {
            _ShowLicenseDetailes();
        }
        private void _ShowLicenseDetailes()
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo((int)dgvAllLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshList();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterIsActive();
        }

        private void _FilterIsActive()
        {

            if (cbIsActive.SelectedItem == null)
            {
                _enSelectedActiveIndex = enIsActive.All;
            }
            _enSelectedActiveIndex = (enIsActive)cbIsActive.SelectedItem;

            switch (_enSelectedActiveIndex)
            {
                case enIsActive.Active:
                    _dtInternationalLicenses.DefaultView.RowFilter = "[Is Active] = 1";
                    break;

                case enIsActive.NotActive:
                    _dtInternationalLicenses.DefaultView.RowFilter = "[Is Active] = 0";
                    break;

                case enIsActive.All:
                    _dtInternationalLicenses.DefaultView.RowFilter = null;
                    break;

                default:
                    _dtInternationalLicenses.DefaultView.RowFilter = null;
                    break;
            }

            _RefreshCountLabel();
        }

        private void btnAddNewIntLicense_Click(object sender, EventArgs e)
        {
            frmInternationalDLApplication frm = new frmInternationalDLApplication();
            frm.ShowDialog();
            _RefreshList();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
