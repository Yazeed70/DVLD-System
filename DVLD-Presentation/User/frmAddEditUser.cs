using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmAddEditUser: Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _UserID, _PersonID;
        
        //clsPerson _Person;
        clsUser _User;

        bool _isPasswordVisible = false;
        bool _isConfirmPasswordVisible = false;
        public frmAddEditUser(int ID)
        {
            InitializeComponent();

            _UserID = ID;
            _Mode = enMode.Update;
        }
        public frmAddEditUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
            
        }
        private void _SaveUser()
        {
            if(clsPerson.isPersonHasAUser(_PersonID))
            {
                MessageBox.Show("Selected Person already has a user, choose another one!");
                return;
            }

            if (clsPerson.isPersonExist(_PersonID))
            {
                string _Username = txtUsername.Text.Trim();
                if(clsUser.isUsernameExist(_Username) && _Mode == enMode.AddNew)
                {
                    MessageBox.Show("This Username already exists, please choose another one.");
                    return;
                }
                if (txtUsername.Text != "" && txtPassword.Text!=""&&txtConfirmPassword.Text==txtPassword.Text)
                {
                    _User.PersonID = _PersonID;
                    _User.UserName = _Username;
                    _User.Password = txtPassword.Text.Trim();
                    _User.IsActive = ckbIsActive.Checked;
                    if (_User.Save())
                    {
                        MessageBox.Show("Data Saved Successfully.");
                        lblUserID.Text = _User.ID.ToString();
                        tbLoginInfo.Enabled = false;
                        btnSave.Enabled = false;

                        _Mode = enMode.Update;
                        lblMode.Text = $"Edit User ID =  {_User.ID}";
                    }
                }
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }
            
        }

        private void _GoTotbLoginInfo()
        {
            if(_Mode == enMode.Update)
            {
                tbLoginInfo.Enabled = true;
                btnSave.Enabled = true;
                tabControl1.SelectTab(1);
                txtUsername.Focus();
                return;
            }

            _PersonID = ctrlPersonDetailsWithFilter1.PersonID;
            if (_PersonID != -1)
            {
                if (!clsPerson.isPersonHasAUser(_PersonID))
                {
                    tbLoginInfo.Enabled = true;
                    btnSave.Enabled = true;
                    tabControl1.SelectTab(1);
                    txtUsername.Focus();
                }
                else
                {
                    MessageBox.Show("Selected Person already has a user, choose another one!");
                    tbLoginInfo.Enabled = false;
                    btnSave.Enabled = false;
                    tabControl1.SelectTab(0);
                }
            }
            else
            {
                MessageBox.Show($"Please Enter correct Info", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectTab(0);
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            _GoTotbLoginInfo();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text != "" && txtPassword.Text != "" && txtConfirmPassword.Text == txtPassword.Text && lblUserID.Text =="[????]")
                _SaveUser();
            else
                MessageBox.Show($"Please Enter correct Info", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbLoginInfo_Click(object sender, EventArgs e)
        {
            _GoTotbLoginInfo();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(e.TabPage == tbLoginInfo)
            {
                _GoTotbLoginInfo();
            }
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            _LoadData();
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tbLoginInfo)
            {
                btnRight.Enabled = false;
                btnLeft.Enabled = true;
            }
            else if (tabControl1.SelectedTab == tbPersonalInfo)
            {
                btnLeft.Enabled = false;
                btnRight.Enabled = true;
            }
        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            if (_isPasswordVisible)
            {
                txtPassword.PasswordChar = '*'; // Mask with asterisk
                btnShowHidePassword.BackgroundImage = Properties.Resources.HidePassword_16; // Assuming you have an eye_open image in your resources
            }
            else
            {
                txtPassword.PasswordChar = '\0'; // Show plain text (no masking)
                btnShowHidePassword.BackgroundImage = Properties.Resources.ShowPassword_16; // Assuming you have an eye_closed image in your resources
            }
            _isPasswordVisible = !_isPasswordVisible;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                btnShowHidePassword.Visible = false;
            }
            else
            {
                btnShowHidePassword.Visible = true;
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                btnShowHideConfirmPassword.Visible = false;
            }
            else
            {
                btnShowHideConfirmPassword.Visible = true;
            }
        }

        private void btnConfirmPassword_Click(object sender, EventArgs e)
        {
            if (_isConfirmPasswordVisible)
            {
                txtConfirmPassword.PasswordChar = '*'; // Mask with asterisk
                btnShowHidePassword.BackgroundImage = Properties.Resources.HidePassword_16; // Assuming you have an eye_open image in your resources
            }
            else
            {
                txtConfirmPassword.PasswordChar = '\0'; // Show plain text (no masking)
                btnShowHidePassword.BackgroundImage = Properties.Resources.ShowPassword_16; // Assuming you have an eye_closed image in your resources
            }
            _isConfirmPasswordVisible = !_isConfirmPasswordVisible;
        }

        private void frmAddEditUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonDetailsWithFilter1.FilterFocus();
        }

        private void _LoadData()
        {
            btnLeft.Enabled = false;
            if (_Mode == enMode.AddNew)
            {
                tbLoginInfo.Enabled = false;
                ctrlPersonDetailsWithFilter1.FilterFocus();
                lblMode.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUser();
                return;
            }
            tbLoginInfo.Enabled = true;
            lblMode.Text = "Update User";
            this.Text = "Update User";
            btnSave.Enabled = true;

            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("This form will be closed because No User with ID = " + _UserID);
                this.Close();

                return;
            }

            ctrlPersonDetailsWithFilter1._LoadData(_User.PersonID);
            ctrlPersonDetailsWithFilter1.EnableFilter = false;
            lblUserID.Text = _User.ID.ToString();
            txtUsername.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            ckbIsActive.Checked = _User.IsActive;

        }

    }
}
