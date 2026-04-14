using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmMain: Form
    {
        private bool sidePanelExpanded = false;
        private bool ApplicationExpanded = false;
        private bool _DLServicesCMS = false;
        private bool _ManageAppCMS = false;
        private bool _DetainLicensesCMS = false;
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        private Color ThemeColor = Color.FromArgb(0, 174, 239); // Default theme color

        frmLogin _LoginForm;

        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _LoginForm = frm;
            random = new Random();
            //btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;
            //If correction factor is less than 0, darken color.
            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            //If correction factor is greater than zero, lighten color.
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }
            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    //DisableButton();
                    Color color = ThemeColor;
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblTitle.BackColor = color;
                    //lblSecondTitle.BackColor = ChangeColorBrightness(color, -0.3);
                    //ThemeColor.PrimaryColor = color;
                    //ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //btnCloseChildForm.Visible = true;
                }
            }
        }
        //private void DisableButton()
        //{
        //    foreach (Control previousBtn in pnlLeftSide.Controls)
        //    {
        //        if (previousBtn.GetType() == typeof(Button))
        //        {
        //            previousBtn.BackColor = Color.FromArgb(37, 41, 76);
        //            previousBtn.ForeColor = Color.Gainsboro;
        //            previousBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        }
        //    }
        //}
        //private void OpenChildForm(Form childForm, object btnSender)
        //{
        //    if (activeForm != null)
        //        activeForm.Close();
        //    ActivateButton(btnSender);
        //    activeForm = childForm;
        //    childForm.TopLevel = false;
        //    childForm.FormBorderStyle = FormBorderStyle.None;
        //    childForm.Dock = DockStyle.Fill;
        //    this.panelDesktopPane.Controls.Add(childForm);
        //    this.panelDesktopPane.Tag = childForm;
        //    childForm.BringToFront();
        //    childForm.Show();
        //    lblTitle.Text = childForm.Text;
        //}

        

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
            
        //}

        //private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{

        //}

        //private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        //{

        //}

        private void signOut_Click(object sender, EventArgs e)
        {
            this.Close();
            clsGlobal.CurrentUser = null;
            _LoginForm.Show();
            //Application.Exit();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.ID);
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDLApplications frm = new frmManageLocalDLApplications();
            frm.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            frmManageDrivers frm = new frmManageDrivers();
            frm.ShowDialog();
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmLocalD frm = new frmLocalD(-1);
            //frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUsername.Text = clsGlobal.CurrentUser.UserName;
            lblUserEmail.Text = clsGlobal.CurrentUser.PersonInfo.Email;
            if (!string.IsNullOrEmpty(clsGlobal.CurrentUser.PersonInfo.ImagePath))
                pbUserProfile.ImageLocation = clsGlobal.CurrentUser.PersonInfo.ImagePath;
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
            UserCMS.Show(lblUsername, new Point(135, lblUsername.Height - 30));
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(sidePanelExpanded)
            {
                flowLayoutPanel1.Width -= 10;
                if(flowLayoutPanel1.Width == flowLayoutPanel1.MinimumSize.Width)
                {
                    sidePanelExpanded = false;
                    LeftSideTimer.Stop();
                }
            }
            else
            {
                flowLayoutPanel1.Width += 10;
                if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
                {
                    sidePanelExpanded = true;
                    LeftSideTimer.Stop();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LeftSideTimer.Start();
        }

        private void ApplicationsTimer_Tick(object sender, EventArgs e)
        {
            if (ApplicationExpanded)
            {
                pnlApplications2.Height -= 10;
                pnlSpace.Height += 10;
                if (pnlApplications2.Height == pnlApplications2.MinimumSize.Height)
                {
                    ApplicationExpanded = false;
                    ApplicationsTimer.Stop();
                }
            }
            else
            {
                pnlApplications2.Height += 10;
                pnlSpace.Height -= 10;
                if (pnlApplications2.Height == pnlApplications2.MaximumSize.Height)
                {
                    ApplicationExpanded = true;
                    ApplicationsTimer.Stop();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ApplicationsTimer.Start();
        }

        private void ShowDLServicesCMS()
        {
            if (!_DLServicesCMS)
            {
                DLServicesCMS.Show(button17, new Point(200, button17.Height - 40));
                _DLServicesCMS = true;
            }
        }

        private void HideDLServicesCMS()
        {
            if (_DLServicesCMS)
            {
                DLServicesCMS.Close();
                _DLServicesCMS = false;
            }
        }
        private void ShowManageAppCMS()
        {
            if (!_ManageAppCMS)
            {
                ManageAppCMS.Show(button19, new Point(200, button19.Height - 40));
                _ManageAppCMS = true;
            }
        }

        private void HideManageAppCMS()
        {
            if (_ManageAppCMS)
            {
                ManageAppCMS.Close();
                _ManageAppCMS = false;
            }
        }
        private void ShowDetainLicensesCMS()
        {
            if (!_DetainLicensesCMS)
            {
                DetainLicensesCMS.Show(button21, new Point(200, button21.Height - 40));
                _DetainLicensesCMS = true;
            }
        }

        private void HideDetainLicensesCMS()
        {
            if (_DetainLicensesCMS)
            {
                DetainLicensesCMS.Close();
                _DetainLicensesCMS = false;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if(!_DetainLicensesCMS)
            {
                ShowDetainLicensesCMS();
            }
            else
            {
                HideDetainLicensesCMS();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if(!_DLServicesCMS)
            {
                ShowDLServicesCMS();
            }
            else
            {
                HideDLServicesCMS();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (!_ManageAppCMS)
            {
                ShowManageAppCMS();
            }
            else
            {
                HideManageAppCMS();
            }
        }

        private void pbUserProfile_Click(object sender, EventArgs e)
        {
            if(sidePanelExpanded)
            {
                UserCMS.Show(pbUserProfile, new Point(45, pbUserProfile.Height- 100));
            }
            else
            {
                UserCMS.Show(pbUserProfile, new Point(45, pbUserProfile.Height - 100));
            }
            
        }

        private void NewLocalLicenseTSM_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplication frm = new frmLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void newInternationalLicenseTSM_Click(object sender, EventArgs e)
        {
            frmInternationalDLApplication frm = new frmInternationalDLApplication();
            frm.ShowDialog();
        }

        private void renewDrivingLicensesTSM_Click(object sender, EventArgs e)
        {
            frmRenewLocalDL frm = new frmRenewLocalDL();
            frm.ShowDialog();
        }

        private void replacementLicensesTSM_Click(object sender, EventArgs e)
        {
            frmReplacementLicense frm = new frmReplacementLicense();
            frm.ShowDialog();
        }

        private void releaseDetainLicenseTSM_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
        }

        private void retakeTestTSM_Click(object sender, EventArgs e)
        {
            frmManageLocalDLApplications frm = new frmManageLocalDLApplications();
            frm.ShowDialog();
        }

        private void LocalDLAppTSM_Click(object sender, EventArgs e)
        {
            frmManageLocalDLApplications frm = new frmManageLocalDLApplications();
            frm.ShowDialog();
        }

        private void InternationalDLAppTSM_Click(object sender, EventArgs e)
        {
            frmManageInternationalDLApps frm = new frmManageInternationalDLApps();
            frm.ShowDialog();
        }

        private void ManageDetainLicenseTSM_Click(object sender, EventArgs e)
        {
            frmManageDetainReleaseLicenses frm = new frmManageDetainReleaseLicenses();
            frm.ShowDialog();
        }

        private void DetainLicenseTSM_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void ReleaseDetainLicenseTSM2_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
        }

        private void btnManageAppType_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void btnManageTestTypes_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm = new frmManageTestTypes();
            frm.ShowDialog();
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {

        }

        private void userInfo_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.ID);
            frm.ShowDialog();
        }

        private void changePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.ID);
            frm.ShowDialog();
        }
    }
}
