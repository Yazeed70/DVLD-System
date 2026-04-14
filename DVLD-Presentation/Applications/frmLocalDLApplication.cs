using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmLocalDrivingLicenseApplication : Form
    {
        int _LDLAppID;
        clsApplication _Application;
        clsLocalDLApplication _LocalDivingLecinseApplication = new clsLocalDLApplication();
        clsApplicationTypes _LocalDivingLecinse = new clsApplicationTypes();

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        public frmLocalDrivingLicenseApplication()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }
        public frmLocalDrivingLicenseApplication(int LDLAppID)
        {
            InitializeComponent();

            _LDLAppID = LDLAppID;

            _Mode = enMode.Update;
            
        }

        private void frmLocalD_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            _FillComboBoxWithData();
            if(_Mode == enMode.AddNew)
            {
                lblMode.Text = "New Local Driving License Application";
                _LocalDivingLecinse = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.NewLocalDrivingLicenseService); // 1 = Local Driving License
                cbLicenseClass.SelectedIndex = 2;
                lblApplicationDate.Text = DateTime.Now.ToShortDateString().ToString();
                lblApplicationFees.Text = ((int)_LocalDivingLecinse.ApplicationFees).ToString() + " $";
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
                ctrlPersonDetailsWithFilter1.FilterFocus();
                btnSave.Enabled = false;
                return;
            }
            lblMode.Text = $"Update Local Driving License Application With ID = {_LDLAppID}";
            btnSave.Enabled = true;
            _LocalDivingLecinseApplication = clsLocalDLApplication.Find(_LDLAppID);
            _Application = clsApplication.Find(_LocalDivingLecinseApplication.ApplicationID);
            ctrlPersonDetailsWithFilter1._LoadData(_Application.ApplicantPersonID);
            ctrlPersonDetailsWithFilter1.EnableFilter = false;
            lblLocalDLApplicationID.Text = _LocalDivingLecinseApplication.ApplicationID.ToString();
            cbLicenseClass.SelectedIndex = _LocalDivingLecinseApplication.LicenseClassID - 1;
            lblApplicationDate.Text = _Application.ApplicationDate.ToShortDateString();
            lblApplicationFees.Text = clsApplicationTypes.Find(_Application.ApplicationTypeID).ApplicationFees.ToString() + " $";
            lblCreatedBy.Text = clsUser.Find(_Application.CreatedByUserID).UserName;
        }

        private void _FillComboBoxWithData()
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClasses();
            List<string> LicenseClass = new List<string>();

            foreach (DataRow row in dt.Rows)
            {

                LicenseClass.Add((string)row["ClassName"]);

            }
            cbLicenseClass.DataSource = LicenseClass;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void _Save()
        {

            int LicenseClassID = cbLicenseClass.SelectedIndex + 1;
            if(_Mode == enMode.Update)
            {
                _LocalDivingLecinseApplication.LicenseClassID = LicenseClassID;
                if (_LocalDivingLecinseApplication.Save())
                {
                    MessageBox.Show($"Data Saved Successfuly!");
                    //this.Close();
                    return;
                }
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
           
            int PersonID = ctrlPersonDetailsWithFilter1.PersonID;
            int ApplicationID = _LocalDivingLecinseApplication.IsAllowedToAddNew(PersonID, LicenseClassID);

            if (ApplicationID == -1)
            {
                _Application = new clsApplication();
                _Application.ApplicantPersonID = PersonID;
                _Application.ApplicationDate = DateTime.Now;
                _Application.ApplicationTypeID = (int) clsApplicationTypes.enApplicationType.NewLocalDrivingLicenseService; // 1
                _Application.ApplicationStatus = (int) clsApplication.enApplicationStatus.New; // 1
                _Application.LastStatusDate = DateTime.Now;
                _Application.PaidFees = _LocalDivingLecinse.ApplicationFees;
                _Application.CreatedByUserID = clsGlobal.CurrentUser.ID;
                if(_Application.Save())
                {
                    _LocalDivingLecinseApplication.ApplicationID = _Application.ApplicationID;
                    _LocalDivingLecinseApplication.LicenseClassID = LicenseClassID;
                    if(_LocalDivingLecinseApplication.Save())
                    {
                        MessageBox.Show($"Data Saved Successfuly!");
                        _LDLAppID = _LocalDivingLecinseApplication.LocalDrivingLicenseApplicationID;
                        _Mode = enMode.Update;
                        _LoadData();
                    }
                }
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
            else
            {
                MessageBox.Show($"Choose another License Class, the selected Person " +
                    $"already have an active application for the selected class with id = {ApplicationID}"
                    ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);

            }
        }

        private void ctrlPersonDetailsWithFilter1_OnPersonSelected(int obj)
        {
            btnSave.Enabled = true;
        }

        private void frmLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonDetailsWithFilter1.FilterFocus();
        }
    }
}
