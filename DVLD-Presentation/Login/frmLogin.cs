using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.Login;
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
    public partial class frmLogin : Form
    {

        short FaildLoginCount = 1;
        bool _isPasswordVisible= false;
        sbyte _LockedTime = 30; // seconds

        public frmLogin()
        {
            InitializeComponent();
        }

        private void ClearAllText()
        {
            txtbUsername.Text = "";
            txtbPassword.Text = "";
            txtbUsername.Focus();
        }

        private void bntLogIn_Click(object sender, EventArgs e)
        {
            _Login();
        }

        private void _Login()
        {
            string Username = txtbUsername.Text.Trim();
            string Password = txtbPassword.Text.Trim();
            clsUser User;
            if ((User = clsUser.FindByUsernameAndPassword(Username,Password)) != null)
            {
                if (!User.IsActive)
                {
                    MessageBox.Show("This user is not active, please contact the administrator.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    ClearAllText();
                    return;
                }
                clsGlobal.CurrentUser = User;
                clsAppLogger.LogInfo($"User {User.UserName} logged in successfully.");
                if (chkRememberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(User.UserName, User.Password);
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");
                }
                frmMain frm = new frmMain(this);
                this.Hide();
                frm.Show();
                //this.Close();
                return;
            }
            else
            {
                MessageBox.Show($"Invlaid Username/Password!\nYou have {3 - FaildLoginCount} Trial(s) to login.", "Error",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                ClearAllText();
                clsAppLogger.LogWarning("User failed to login with invalid credentials.");
                FaildLoginCount++;
            }
            if (FaildLoginCount > 3)
            {
                if (MessageBox.Show("You are Locked after 3 failed trials.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    //this.Close();
                    ClearAllText();
                    EnabledAll(false);
                    lblLockedMessage.Visible = true;
                    LockedTimer.Start();
                    clsAppLogger.LogError("User is locked after 3 failed login attempts.");
                }

            }
        }

        private void EnabledAll(bool Enable)
        {
            txtbUsername.Enabled = Enable;
            txtbPassword.Enabled = Enable;
            bntLogIn.Enabled = Enable;
            btnShowHidePassword.Enabled = Enable;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;

            string Username = "", Password = "";
            chkRememberMe.Checked = clsGlobal.GetStoredCredential(ref Username, ref Password);
            txtbUsername.Text = Username;
            txtbPassword.Text = Password;
            //lnkClearAll.Visible = false;
            if (txtbUsername.Text != "" || txtbPassword.Text != "")
                lnkClearAll.Visible = true;
            
            txtbUsername.Focus();
        }

        private void txtbPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtbUsername.Text != "" || txtbPassword.Text != "")
                lnkClearAll.Visible = true;
            else
                lnkClearAll.Visible = false;

            if (string.IsNullOrEmpty(txtbPassword.Text))
            {
                btnShowHidePassword.Visible = false;
            }
            else
            {
                btnShowHidePassword.Visible = true;
            }

        }

        private void txtbUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtbUsername.Text != "" || txtbPassword.Text != "")
                lnkClearAll.Visible = true;
            else
                lnkClearAll.Visible = false;
        }

        private void lnkClearAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAllText();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            if (_isPasswordVisible)
            {
                txtbPassword.PasswordChar = '*'; // Mask with asterisk
                btnShowHidePassword.BackgroundImage = Properties.Resources.HidePassword_16; // Assuming you have an eye_open image in your resources
            }
            else
            {
                txtbPassword.PasswordChar = '\0'; // Show plain text (no masking)
                btnShowHidePassword.BackgroundImage = Properties.Resources.ShowPassword_16; // Assuming you have an eye_closed image in your resources
            }
            _isPasswordVisible = !_isPasswordVisible;
        }

        private void LockedTimer_Tick(object sender, EventArgs e)
        {
            lblLockedMessage.Text = $"You are locked , you can try again after {_LockedTime} Seconds.";
            
            _LockedTime--;
            if (_LockedTime < 0)
            {
                EnabledAll(true);
                LockedTimer.Stop();
                lblLockedMessage.Visible = false;
                FaildLoginCount = 1;
                _LockedTime = 30; // Reset the locked time
            }
        }

        private void lnkResetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
