using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//using System.Windows;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmChangePassword: Form
    {

        int _UserID;
        clsUser _User;
        bool _isCurrentPasswordVisible = false;
        bool _isNewPasswordVisible = false;
        bool _isConfirmPasswordVisible = false;
        public frmChangePassword(int ID)
        {
            InitializeComponent();

            _UserID = ID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveData();
        }

        private void _SaveData()
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text) || string.IsNullOrEmpty(txtNewPassword.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please fill all fields.");
                txtCurrentPassword.Focus();
                return;
            }
            if(txtNewPassword.Text == txtCurrentPassword.Text)
            {
                MessageBox.Show("New password cannot be the same as current password.");
                txtNewPassword.Focus();
                return;
            }
            if (txtCurrentPassword.Text == _User.Password && txtNewPassword.Text == txtConfirmPassword.Text)
            {
                _User.Password = txtNewPassword.Text;
                if(_User.Save())
                {
                    MessageBox.Show("Data Saved Successfully.");
                    txtNewPassword.Text = "";
                    txtCurrentPassword.Text = "";
                    txtConfirmPassword.Text = "";
                }
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.");
            }
            else
                MessageBox.Show("Error: Current password is incorrect or new passwords do not match.");

        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            _User = clsUser.Find(_UserID);
            if (_User == null)
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlUserDetails1.LoadData(_UserID);
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            if((Button)sender == btnShowHideCurrentPassword)
            {
                _TogglePasswordVisibility(ref _isCurrentPasswordVisible, txtCurrentPassword, btnShowHideCurrentPassword);
            }
            else if((Button)sender == btnShowHideNewPassword)
            {
                _TogglePasswordVisibility(ref _isNewPasswordVisible, txtNewPassword, btnShowHideNewPassword);
            }
            else if((Button)sender == btnShowHideConfirmPassword)
            {
                _TogglePasswordVisibility(ref _isConfirmPasswordVisible, txtConfirmPassword, btnShowHideConfirmPassword);
            }

        }

        private void _TogglePasswordVisibility(ref bool PasswordVisible, TextBox txtPassword, Button btnShowHidePassword)
        {
            if (PasswordVisible)
            {
                txtPassword.PasswordChar = '*'; // Mask with asterisk
                btnShowHidePassword.BackgroundImage = Properties.Resources.HidePassword_16; // Assuming you have an eye_open image in your resources
            }
            else
            {
                txtPassword.PasswordChar = '\0'; // Show plain text (no masking)
                btnShowHidePassword.BackgroundImage = Properties.Resources.ShowPassword_16; // Assuming you have an eye_closed image in your resources
            }
            PasswordVisible = !PasswordVisible;
        }

        private void txtCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                btnShowHideCurrentPassword.Visible = false;
            }
            else
            {
                btnShowHideCurrentPassword.Visible = true;
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                btnShowHideNewPassword.Visible = false;
            }
            else
            {
                btnShowHideNewPassword.Visible = true;
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

        private void frmChangePassword_Activated(object sender, EventArgs e)
        {
            txtCurrentPassword.Focus();
        }
    }
}
