using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Presentation.frmScheduleTest;
using static DVLD_Presentation.frmTakeTest;

namespace DVLD_Presentation
{
    public partial class frmTakeTest: Form
    {

        int _TestAppointmentID;
        clsTestAppointment _TestAppointment;
        clsTest _Test;
        
        enum enMode { AddNew = 0, Update = 1 }

        enMode _Mode;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        enTestType _TestType;
        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;

            _TestAppointmentID = TestAppointmentID;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {

            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
            _TestType = (enTestType)_TestAppointment.TestTypeID;
            _LoadTestTypeImageAndTitle();
            DataRow dt = clsTestAppointment.GetTestAppointmentViewByID(_TestAppointmentID).Rows[0];

            //gbTakeTest.Text = dt["TestTypeTitle"].ToString();
            lblDLAppID.Text = dt["LocalDrivinglicenseApplicationID"].ToString();
            lblDLicense.Text = dt["ClassName"].ToString();
            lblName.Text = dt["FullName"].ToString();
            lblTrial.Text = clsTestAppointment.NumberOfTrials(Convert.ToInt32(dt["LocalDrivinglicenseApplicationID"].ToString()), (short)_TestAppointment.TestTypeID).ToString();
            lblDate.Text = dt["AppointmentDate"].ToString();
            lblFees.Text = dt["PaidFees"].ToString();

            _Test = clsTest.FindByAppointmentID(_TestAppointmentID);
            if (_Test != null)
            {
                _Mode = enMode.Update;
                lblTestID.Text = _Test.ID.ToString();
                if(_Test.TestResult) rbPass.Checked = true; else rbFail.Checked = true;
                rbPass.Enabled = false;
                rbFail.Enabled = false;
                txtNotes.Text = _Test.Notes;
                txtNotes.Enabled = false;
                btnSave.Enabled = false;
                lblMessage.Visible = true;
            }
            else
            {
                _Mode = enMode.AddNew;
                _Test = new clsTest();
            }
            
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {
                case enTestType.VisionTest:
                    {
                        pbTestType.Image = Resources.VisionTest_512;
                        gbTakeTest.Text = "Vision Test";
                        break;
                    }
                case enTestType.WrittenTest:
                    {
                        pbTestType.Image = Resources.WrittenTest_512;
                        gbTakeTest.Text = "Written Test";
                        break;
                    }
                case enTestType.StreetTest:
                    {
                        pbTestType.Image = Resources.StreetTest_512;
                        gbTakeTest.Text = "Street Test";
                        break;
                    }
                default:
                    {
                        //this.Text = "Schedule Test";
                        lblTitle.Text = "Schedule Test";
                        break;
                    }
            }
        }

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
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                return;
            }
            //if (_Mode == enMode.AddNew)
            //    _Test = new clsTest();
            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtNotes.Text;
            _Test.CreatedByUserID = clsGlobal.CurrentUser.ID;
            //_TestAppointment.IsLocked = true;
            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved",
                     MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                _Mode = enMode.Update;
                _LoadData();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

        }
    }
}
