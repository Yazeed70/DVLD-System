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
    public partial class frmManageDetainReleaseLicenses : Form
    {
        private enum enIsReleased
        {
            NotReleased = 0,
            Released = 1,
            All = 2
        }
        private enum encbFilter
        {
            None,
            DetainID,
            NationalNo,
            ReleaseApplicationID,
            FullName,
            IsReleased
        }

        private encbFilter _enSelectedIndex;
        private enIsReleased _enSelectedActiveIndex;
        int _PersonID = -1;

        DataTable _dtAllLicenses;
        public frmManageDetainReleaseLicenses()
        {
            InitializeComponent();
        }

        private void frmManageDetainReleaseLicenses_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void _LoadData()
        {
            _RefreshList();
            cbFilter.DataSource = Enum.GetValues(typeof(encbFilter));
            cbIsReleased.DataSource = Enum.GetValues(typeof(enIsReleased));
            cbFilter.SelectedIndex = (int)encbFilter.None;
            cbIsReleased.SelectedIndex = (int)enIsReleased.All;
        }

        private void _RefreshList()
        {
            _dtAllLicenses = clsDetainedLicense.GetAllDetainLicensesView();
            dgvAllLicenses.DataSource = _dtAllLicenses;
            _RefreshCountLabel();
            if (dgvAllLicenses.Rows.Count > 0)
            {
                dgvAllLicenses.Columns[0].HeaderText = "D.ID";
                dgvAllLicenses.Columns[1].HeaderText = "L.ID";
                dgvAllLicenses.Columns[2].HeaderText = "D.Date";
                dgvAllLicenses.Columns[3].HeaderText = "Is Released";
                dgvAllLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvAllLicenses.Columns[5].HeaderText = "Release Date";
                dgvAllLicenses.Columns[6].HeaderText = "N.No.";
                dgvAllLicenses.Columns[7].HeaderText = "Full Name";
                dgvAllLicenses.Columns[8].HeaderText = "Rlease App.ID";

            }
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
                    _dtAllLicenses.DefaultView.RowFilter = null;
                    break;

                case encbFilter.DetainID:
                    _dtAllLicenses.DefaultView.RowFilter = $"DetainID = {txtFilter.Text}";
                    break;

                case encbFilter.NationalNo:
                    _dtAllLicenses.DefaultView.RowFilter = $"NationalNo like '{txtFilter.Text}%'";
                    break;

                case encbFilter.FullName:
                    _dtAllLicenses.DefaultView.RowFilter = $"FullName like '{txtFilter.Text}%'";
                    break;

                case encbFilter.ReleaseApplicationID:
                    _dtAllLicenses.DefaultView.RowFilter = $"ReleaseApplicationID = {txtFilter.Text}";
                    break;

                case encbFilter.IsReleased:
                    {
                        //_dtAllLicenses.DefaultView.RowFilter = _FilterStatus();
                        break;
                    }

                default:
                    _dtAllLicenses.DefaultView.RowFilter = null;
                    break;
            }
            _RefreshCountLabel();

        }


        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            _dtAllLicenses.DefaultView.RowFilter = null;
            _RefreshCountLabel();

            if ((encbFilter)cbFilter.SelectedIndex == encbFilter.IsReleased)
            {
                txtFilter.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.SelectedIndex = (int)enIsReleased.All; // Reset to All
                cbIsReleased.Focus();
            }
            else if ((encbFilter)cbFilter.SelectedIndex == encbFilter.None)
            {
                txtFilter.Visible = false;
                cbIsReleased.Visible = false;
            }
            else if (cbFilter.SelectedItem != null)
            {
                _enSelectedIndex = (encbFilter)cbFilter.SelectedItem;
                txtFilter.Text = "";
                cbIsReleased.Visible = false;
                txtFilter.Visible = true;
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

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _RefreshList();
        }

        private void tsmShowPersonDetailes_Click(object sender, EventArgs e)
        {
            _ShowPersonDetailes();
        }

        private void _ShowPersonDetailes()
        {
            // 6 = NationalNo
            _PersonID = clsPerson.Find(dgvAllLicenses.CurrentRow.Cells[6].Value.ToString()).ID;
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
            // 6 = NationalNo
            _PersonID = clsPerson.Find(dgvAllLicenses.CurrentRow.Cells[6].Value.ToString()).ID;
            frmLicenseHistory frm = new frmLicenseHistory(_PersonID);
            frm.ShowDialog();
            _RefreshList();
        }

        private void tsmShowLicenseDetailes_Click(object sender, EventArgs e)
        {
            _ShowLicenseDetailes();
        }
        private void _ShowLicenseDetailes()
        {
            // 1 = LicenseID
            frmLicenseInfo frm = new frmLicenseInfo((int)dgvAllLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            //_RefreshList();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtAllLicenses.DefaultView.RowFilter = null;
            _RefreshCountLabel();

            _FilterIsReleased();
        }

        private void _FilterIsReleased()
        {

            if (cbIsReleased.SelectedItem == null)
            {
                _enSelectedActiveIndex = enIsReleased.All;
            }
            _enSelectedActiveIndex = (enIsReleased)cbIsReleased.SelectedItem;

            switch (_enSelectedActiveIndex)
            {
                case enIsReleased.Released:
                    _dtAllLicenses.DefaultView.RowFilter = "IsReleased = 1";
                    break;

                case enIsReleased.NotReleased:
                    _dtAllLicenses.DefaultView.RowFilter = "IsReleased = 0";
                    break;

                case enIsReleased.All:
                    _dtAllLicenses.DefaultView.RowFilter = null;
                    break;

                default:
                    _dtAllLicenses.DefaultView.RowFilter = null;
                    break;
            }


            _RefreshCountLabel();
        }

        private void tsmReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            _ReleaseDetainedLicense();
        }

        private void _ReleaseDetainedLicense()
        {
            // 1 = LicenseID
            frmReleaseLicense frm = new frmReleaseLicense((int)dgvAllLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            _RefreshList();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
            _RefreshList();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(_enSelectedIndex == encbFilter.DetainID || _enSelectedIndex == encbFilter.ReleaseApplicationID)
            { 
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); 
            }
            
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            tsmReleaseDetainedLicense.Enabled = !(bool)dgvAllLicenses.CurrentRow.Cells[3].Value;
        }
    }
}
