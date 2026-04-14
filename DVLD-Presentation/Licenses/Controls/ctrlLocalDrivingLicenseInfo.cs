using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD_Presentation
{
    public partial class ctrlLocalDrivingLicenseInfo: UserControl
    {
        private int _PersonID = -1;
        //private int _TestTypeID = -1;
        private int _PassedTests = -1;
        clsApplication AppInfo;
        int _LocalDLAppID;
        clsLocalDLApplication _LocalDLApp;


        public ctrlLocalDrivingLicenseInfo()
        {
            InitializeComponent();
        }

        public int GetPassedTestsCount()
        {
            return _PassedTests;
        }
        
        public int GetPersonID()
        {
            return _PersonID;
        }
        
        //public int GetTestTypeID()
        //{
        //    return _TestTypeID;
        //}

        public void LoadData(int LocalDLAppID)
        {
            _LocalDLAppID = LocalDLAppID;
            _LocalDLApp = clsLocalDLApplication.Find(_LocalDLAppID);
            if (_LocalDLApp == null)
            {
                MessageBox.Show("No Local Driving License Application found with the given ID.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            clsLocalDLApplication.stDrivingLicenseApplicationView stDLAppView = 
                clsLocalDLApplication.FindFromVeiw(_LocalDLApp.LocalDrivingLicenseApplicationID);

            AppInfo = clsApplication.Find(_LocalDLApp.ApplicationID);
            if (AppInfo != null && !stDLAppView.isNull)
            {
                _PersonID = AppInfo.ApplicantPersonID;

                lblDLAppID.Text = _LocalDLApp.LocalDrivingLicenseApplicationID.ToString();
                lblAppliedForLicense.Text = stDLAppView.ClassName;
                _PassedTests = stDLAppView.PassesTests;
                lblPassedTests.Text = $"{_PassedTests.ToString()}/3";

                lblID.Text = AppInfo.ApplicationID.ToString();
                //lblStatus.Text = AppInfo.ApplicationStatus.ToString();
                lblFees.Text = AppInfo.PaidFees.ToString();
                lblType.Text = clsApplicationTypes.Find(AppInfo.ApplicationTypeID).ApplicationTypeTitle;
                lblApplicant.Text = stDLAppView.FullName;
                lblDate.Text = AppInfo.ApplicationDate.ToShortDateString();
                lblStatusDate.Text = AppInfo.LastStatusDate.ToShortDateString();
                lblCreatedBy.Text = clsUser.Find(AppInfo.CreatedByUserID).UserName;

                switch(AppInfo.ApplicationStatus)
                {
                    case 1:
                        {
                            lblStatus.Text = "New";
                            break;
                        }
                    
                    case 2:
                        {
                            lblStatus.Text = "Cancelled";
                            break;
                        }
                    
                    case 3:
                        {
                            lblStatus.Text = "Completed";
                            break;
                        }
                    default:
                        {
                            lblStatus.Text = "Unkown";
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Something went wrong", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }    
            
        }

        private void ctrlLocalDrivingLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewPersonInfo();
        }

        private void ViewPersonInfo()
        {
            frmPersonDetails frm = new frmPersonDetails(_PersonID);
            frm.ShowDialog();
            LoadData(_LocalDLAppID);
        }

        private void lnkViewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewLicenseInfo();
        }

        private void ViewLicenseInfo()
        {
            clsLicense License = clsLicense.FindByApplicationID(AppInfo.ApplicationID);
            if (License != null)
            {
                frmLicenseInfo frm = new frmLicenseInfo(License.LicenseID);
                frm.ShowDialog();
                LoadData(_LocalDLAppID);
            }
            else
            {
                MessageBox.Show("No License found for this Application!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            
        }
    }
}
