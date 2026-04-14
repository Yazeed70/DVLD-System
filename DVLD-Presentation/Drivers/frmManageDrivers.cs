using DVLD.Classes;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmManageDrivers : Form
    {

        private enum encbFilter
        {
            None,
            DriverID,
            PersonID,
            NationalNo,
            FullName,
            ActiveLicenses
        }

        private encbFilter _enSelectedIndex;

        DataTable _dtAllDrivers;
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            _dtAllDrivers = clsDriver.GetAllDriversView();
            dgvAllDrivers.DataSource = _dtAllDrivers;
            clsUtil.ApplyCustomStyle(ref dgvAllDrivers);
            _RefreshCountLabel();
            if (dgvAllDrivers.RowCount > 0)
            {
                dgvAllDrivers.Columns[0].HeaderText = "Driver ID";
                dgvAllDrivers.Columns[1].HeaderText = "Person ID";
                dgvAllDrivers.Columns[2].HeaderText = "National No.";
                dgvAllDrivers.Columns[3].HeaderText = "Full Name";
                dgvAllDrivers.Columns[4].HeaderText = "Date";
                dgvAllDrivers.Columns[5].HeaderText = "Active Licenses";
            }

            cbFilter.DataSource = Enum.GetValues(typeof(encbFilter));
            cbFilter.SelectedIndex = (int)encbFilter.None;
            txtFilter.Visible = false;


        }

        private void _FilterData()
        {

            switch (_enSelectedIndex)
            {
                case encbFilter.None:
                    {
                        txtFilter.Visible = false;
                        _dtAllDrivers.DefaultView.RowFilter = null;
                        break;
                    }

                case encbFilter.DriverID:
                    {
                        _dtAllDrivers.DefaultView.RowFilter = $"DriverID = {txtFilter.Text}";
                        break;
                    }
                    
                case encbFilter.PersonID:
                    {
                        _dtAllDrivers.DefaultView.RowFilter = $"PersonID = {txtFilter.Text}";
                        break;
                    }
                
                case encbFilter.NationalNo:
                    {
                        _dtAllDrivers.DefaultView.RowFilter = $"NationalNo like '{txtFilter.Text}%'";
                        break;
                    }

                case encbFilter.FullName:
                    {
                        _dtAllDrivers.DefaultView.RowFilter = $"FullName like '{txtFilter.Text}%'";
                        break;
                    }

                case encbFilter.ActiveLicenses:
                    {
                        _dtAllDrivers.DefaultView.RowFilter = $"NumberOfActiveLicenses = {txtFilter.Text}";
                        break;
                    }

                default:
                    {
                        _dtAllDrivers.DefaultView.RowFilter = null;
                        break;
                    }
            }
            _RefreshCountLabel();
        }

        private void _RefreshCountLabel()
        {
            lblRecords.Text = dgvAllDrivers.RowCount.ToString();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtAllDrivers.DefaultView.RowFilter = null;
            _RefreshCountLabel();
            if ((encbFilter)cbFilter.SelectedIndex != encbFilter.None)
            { 
                _enSelectedIndex = (encbFilter)cbFilter.SelectedItem;
                txtFilter.Visible = true;
                txtFilter.Text = "";
                txtFilter.Focus();
            }
            else 
                txtFilter.Visible = false;
            
            
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cell 1 : PersonID
            frmPersonDetails frm = new frmPersonDetails((int)dgvAllDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            _LoadData();
        }

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((int)dgvAllDrivers.CurrentRow.Cells[5].Value == 0)
            {
                MessageBox.Show("This driver does not have an active license,\n you cannot issue an international license.", "Error", MessageBoxButtons.OK);
                return;
            }

            frmInternationalDLApplication frm = new frmInternationalDLApplication();
            frm.ShowDialog();
            _LoadData();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cell 1 : PersonID
            frmLicenseHistory frm = new frmLicenseHistory((int)dgvAllDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            _LoadData();
        }
    }
}
