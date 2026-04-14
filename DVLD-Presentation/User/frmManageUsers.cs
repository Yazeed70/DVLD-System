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
    public partial class frmManageUsers: Form
    {

        private enum enIsActive
        {
            All = 2,
            Yes = 1,
            No = 0
        }

        private enum encbFilter
        {
            None,
            UserID,
            PersonID,
            FullName,
            UserName,
            IsActive
        }

        private encbFilter _enSelectedIndex;
        private enIsActive _enSelectedActiveIndex;

        private static DataTable _dtAllUsers;


        public frmManageUsers()
        {
            InitializeComponent();
            //clsUtil.ApplyCustomStyle(ref dgvAllUsers);
        }

        private void _RefreshUsersList()
        {
            _dtAllUsers = clsUser.GetAllUsersWithFullName();
            dgvAllUsers.DataSource = _dtAllUsers;
            clsUtil.ApplyCustomStyle(ref dgvAllUsers);
            _RefreshCountLabel();
        }

        private void _LoadData()
        {
            _RefreshUsersList();
            cbFillter.DataSource = Enum.GetValues(typeof(encbFilter));
            cbIsActive.DataSource = Enum.GetValues(typeof(enIsActive));
            cbFillter.SelectedIndex = 0; // Set to "None" by default
            cbIsActive.SelectedIndex = 2; // Set to "All" by default
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _FilterIsActive()
        {

            if (cbIsActive.SelectedItem != null)
            {
                _enSelectedActiveIndex = (enIsActive)cbIsActive.SelectedItem;

                switch (_enSelectedActiveIndex)
                {
                    case enIsActive.Yes:
                        _dtAllUsers.DefaultView.RowFilter = "IsActive = 1";
                        break;

                    case enIsActive.No:
                        _dtAllUsers.DefaultView.RowFilter = "IsActive = 0";
                        break;

                    case enIsActive.All:
                        _dtAllUsers.DefaultView.RowFilter = null;
                        break;

                    default:
                        _dtAllUsers.DefaultView.RowFilter = null;
                        break;
                } 
            }
            _RefreshCountLabel();

        }

        private void _FillterData()
        {

            switch (_enSelectedIndex)
            {
                case encbFilter.None:
                    txtFilter.Visible = false;
                    _dtAllUsers.DefaultView.RowFilter = null;
                    break;

                case encbFilter.UserID:
                    _dtAllUsers.DefaultView.RowFilter = $"UserID = {txtFilter.Text}";
                    break;

                case encbFilter.PersonID:
                    _dtAllUsers.DefaultView.RowFilter = $"PersonID = {txtFilter.Text}";
                    break;

                case encbFilter.FullName:
                    _dtAllUsers.DefaultView.RowFilter = $"[Full Name] like '{txtFilter.Text}%'";
                    break;

                case encbFilter.UserName:
                    _dtAllUsers.DefaultView.RowFilter = $"UserName like '{txtFilter.Text}%'";
                    break;
                
                case encbFilter.IsActive:
                    {
                        //dataView.RowFilter = _FilterIsActive();
                        break;
                    }

                default:
                    _dtAllUsers.DefaultView.RowFilter = null;
                    break;
            }
            _RefreshCountLabel();

        }


        private void cbFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshUsersList();
            txtFilter.Text = "";
            _dtAllUsers.DefaultView.RowFilter = null;
            
            //txtFilter.Visible = false;
            //cbIsActive.Visible = false;
            if ((encbFilter)cbFillter.SelectedIndex == encbFilter.IsActive)
            {
                txtFilter.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.SelectedIndex = 2; // Set to "All" by default
                cbIsActive.Focus();
            }
            else if ((encbFilter)cbFillter.SelectedIndex == encbFilter.None)
            {
                txtFilter.Visible = false;
                cbIsActive.Visible = false;
            }
            else 
            {
                _enSelectedIndex = (encbFilter)cbFillter.SelectedItem;
                txtFilter.Visible = true;
                cbIsActive.Visible = false;
                txtFilter.Text = "";
                txtFilter.Focus();
            }
      
        }

        private void _RefreshCountLabel()
        {
            lblRecords.Text = dgvAllUsers.RowCount.ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (txtFilter.Text != "")
                _FillterData();
            else
                _RefreshUsersList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbIsActive.SelectedItem != null)
            {
                _FilterIsActive();
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            _AddNewUser();
        }

        private void _AddNewUser()
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();
            //frmManageUsers_Load(null, null); // you can call this to refresh the data
            _RefreshUsersList();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmShowUserDetailes_Click(object sender, EventArgs e)
        {
            _ShowUserDetailes();
        }

        private void _ShowUserDetailes()
        {
            frmUserInfo frm = new frmUserInfo((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void tsmAddNewUser_Click(object sender, EventArgs e)
        {
            _AddNewUser();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            _EditUserInfo();
        }

        private void _EditUserInfo()
        {
            frmAddEditUser frm = new frmAddEditUser((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void tsmSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsmChangePassword_Click(object sender, EventArgs e)
        {
            _ChangePassword();
        }

        private void _ChangePassword()
        {
            frmChangePassword frm = new frmChangePassword((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            _DeleteUser();
        }

        private void _DeleteUser()
        {
            int UserID = (int)dgvAllUsers.CurrentRow.Cells[0].Value;
            if (MessageBox.Show($"Are you sure you want to delete User [{UserID}]", "Confirm Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                if (clsUser.DeleteUser(UserID))
                {
                    MessageBox.Show("User Deleted Successfully.", "Done",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    _RefreshUsersList();
                }
                else
                    MessageBox.Show($"User was not Deleted because it has data linked to it.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_enSelectedIndex == encbFilter.UserID || _enSelectedIndex == encbFilter.PersonID)
            {
                // Allow only numbers for UserID and PersonID filters
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Prevent non-numeric input
                }
            }
        }

        private void tsmPhoneCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
