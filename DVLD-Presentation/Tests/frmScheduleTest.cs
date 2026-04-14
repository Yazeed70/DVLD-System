using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.Properties;
//using Syncfusion.Windows.Forms.Tools;
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
    public partial class frmScheduleTest: Form
    {
        int _TestAppointmentID;
        clsTestAppointment _TestAppointment;
        clsLocalDLApplication _LocalDLApplication;
        clsApplication _RetakeApp;
        clsLocalDLApplication.stDrivingLicenseApplicationView stDLAppView;
        //clsTest _Test;
        int _NumberOfTrials;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        enTestType _TestType;

        public enum enMode { AddNew = 0, AddNewRetakeTest = 1, EditNewTest = 2, EditRetakeTest = 3 };
        private enMode _Mode;
        public frmScheduleTest(clsLocalDLApplication LDLApp, int TestType, int TestAppointmentID)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;

            _LocalDLApplication = LDLApp;
            _TestType = (enTestType)TestType;
            _TestAppointmentID = TestAppointmentID;
            //_Mode = (enMode)Mode;

            if (TestAppointmentID != -1)
            {
                _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
                if(_TestAppointment.RetakeTestApplicationID != -1)
                {
                    _Mode = enMode.EditRetakeTest;
                }
                else
                    _Mode = enMode.EditNewTest;
            }
            else
                _Mode = enMode.AddNew;

        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {
                case enTestType.VisionTest:
                    {
                        pbTestType.Image = Resources.VisionTest_512;
                        gbScheduleTest.Text = "Vision Test";
                        break;
                    }
                case enTestType.WrittenTest:
                    {
                        pbTestType.Image = Resources.WrittenTest_512;
                        gbScheduleTest.Text = "Written Test";
                        break;
                    }
                case enTestType.StreetTest:
                    {
                        pbTestType.Image = Resources.StreetTest_512;
                        gbScheduleTest.Text = "Street Test";
                        break;
                    }
                default:
                    {
                        //this.Text = "Schedule Test";
                        lblMode.Text = "Schedule Test";
                        break;
                    }
            }
        }

        private void _LoadData()
        {
            _LoadTestTypeImageAndTitle();
            stDLAppView = clsLocalDLApplication.FindFromVeiw(_LocalDLApplication.LocalDrivingLicenseApplicationID);

            lblDLAppID.Text = _LocalDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDLicense.Text = stDLAppView.ClassName;
            lblName.Text = stDLAppView.FullName;
            _NumberOfTrials = clsTestAppointment.NumberOfTrials(_LocalDLApplication.LocalDrivingLicenseApplicationID, ((short)_TestType));
            lblTrial.Text = _NumberOfTrials.ToString();
            dtpDate.Value = DateTime.Now;
            dtpDate.MinDate = DateTime.Now;
            int Fees = (int)clsTestTypes.Find((short) _TestType).TestFees;
            lblFees.Text = Fees.ToString();
            int RetakeTestFees = Convert.ToInt16(lblRetakeAppFees.Text);
            lblTotalFees.Text = (Fees + RetakeTestFees).ToString();

            if (_NumberOfTrials > 0 && _Mode == enMode.AddNew)
                _Mode = enMode.AddNewRetakeTest;

            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        _TestAppointment = new clsTestAppointment();
                        //return;
                        break;
                    }
                case enMode.AddNewRetakeTest:
                    {
                        _TestAppointment = new clsTestAppointment();
                        gbRetakeTest.Enabled = true;
                        lblMode.Text = "Schedule Retake Test";
                        RetakeTestFees = (int)clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.RetakeTest).ApplicationFees;
                        lblRetakeAppFees.Text = RetakeTestFees.ToString();
                        lblTotalFees.Text = (Fees + RetakeTestFees).ToString();
                        lblRetakeTestAppID.Text = "N/A";
                        break;
                    }
                case enMode.EditNewTest:
                    {
                        _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
                        _UpdateDate();
                        //dtpDate.Value = _TestAppointment.AppointmentDate;
                        break;
                    }
                case enMode.EditRetakeTest:
                    {
                        _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
                        _UpdateDate();
                        //dtpDate.Value = _TestAppointment.AppointmentDate;
                        gbRetakeTest.Enabled = true;
                        lblMode.Text = "Schedule Retake Test";
                        RetakeTestFees = (int)clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.RetakeTest).ApplicationFees;
                        lblRetakeAppFees.Text = RetakeTestFees.ToString();
                        lblTotalFees.Text = (Fees + RetakeTestFees).ToString();
                        lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            if((_Mode == enMode.EditNewTest || _Mode == enMode.EditRetakeTest) && _TestAppointment.IsLocked == true)
            {
                lblNote.Visible = true;
                dtpDate.Enabled = false;
                btnSave.Enabled = false;
            }
            //if (_Mode == enMode.AddNew || _Mode == enMode.AddNewRetakeTest)
            //{
            //    _TestAppointment = new clsTestAppointment();
            //    //return;
            //}
            //else if()

            //    dtpDate.Value = _TestAppointment.AppointmentDate;

            //if (_Mode == enMode.EditRetakeTest)
            //{
            //    gbRetakeTest.Enabled = true;
            //    lblMode.Text = "Schedule Retake Test";
            //    RetakeTestFees = (int)clsApplicationTypes.Find(7).ApplicationFees;
            //    lblRetakeAppFees.Text = RetakeTestFees.ToString();
            //    lblTotalFees.Text = (Fees + RetakeTestFees).ToString();
            //    lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
                
            //}
            
            
            //if (_Mode == enMode.EditNewTest)
            //{
            //    lblRetakeTestAppID.Text = "N/A";

            //}

            //if (_ResultOfLastTest())
            //{
            //    lblNote.Visible = true;
            //    dtpDate.Enabled = false;
            //    btnSave.Enabled = false;

            //}

        }

        private void _UpdateDate()
        {
            //we compare the current date with the appointment date to set the min date.
            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpDate.MinDate = DateTime.Now;
            else
                dtpDate.MinDate = _TestAppointment.AppointmentDate;

            dtpDate.Value = _TestAppointment.AppointmentDate;
        }

        //private bool _ResultOfLastTest()
        //{
        //    return _TestAppointment.;
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void _Save()
        {
            _TestAppointment.AppointmentDate = dtpDate.Value;
            if(_Mode == enMode.AddNew || _Mode == enMode.AddNewRetakeTest)
                _FillData();

            if (_Mode == enMode.AddNewRetakeTest)
            {
                if (_RetakeApp.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = _RetakeApp.ApplicationID;
                    lblRetakeTestAppID.Text = _RetakeApp.ApplicationID.ToString();
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    //this.Close();
                    return;
                }
            }

            if (_TestAppointment.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                //this.Close();
            }
        }

        private void _FillData()
        {
            _TestAppointment.TestTypeID = (int)_TestType;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDLApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.PaidFees = Convert.ToDecimal(lblFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.ID;
            _TestAppointment.IsLocked = false;

            if(_Mode == enMode.AddNewRetakeTest)
            {
                _RetakeApp = new clsApplication();
                _RetakeApp.ApplicationTypeID = (int)clsApplicationTypes.enApplicationType.RetakeTest; // 7 : Retake Test
                clsApplication App = clsApplication.Find(_LocalDLApplication.ApplicationID);
                _RetakeApp.ApplicantPersonID = App.ApplicantPersonID;
                _RetakeApp.PaidFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.RetakeTest).ApplicationFees;
                _RetakeApp.CreatedByUserID = clsGlobal.CurrentUser.ID;
            }
        }

        private void gbScheduleTest_Enter(object sender, EventArgs e)
        {

        }
    }
}

