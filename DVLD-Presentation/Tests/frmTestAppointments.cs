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
    public partial class frmTestAppointments: Form
    {

        int _LDLAppID, _LastAppID = -1;
        clsLocalDLApplication _LocalDLApplication;
        clsApplication _AppInfo;

        enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        enTestType _TestType;

        public enum enMode { AddNew = 0, EditNewTest = 1, EditRetakeTest = 2 };
        private enMode _Mode;
        public frmTestAppointments(int ID, short testType)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            Console.WriteLine($"Form Size: {this.Size}, ClientSize: {this.ClientSize}");

            _LDLAppID = ID;
            _TestType = (enTestType)testType;
        }

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            switch (_TestType)
            {
                case enTestType.VisionTest:
                    {
                        this.Text = "Vision Test Appointments";
                        lblMode.Text = "Vision Test Appointments";
                        break;
                    }
                case enTestType.WrittenTest:
                    {
                        this.Text = "Written Test Appointments";
                        lblMode.Text = "Written Test Appointments";
                        break;
                    }
                case enTestType.StreetTest:
                    {
                        this.Text = "Street Test Appointments";
                        lblMode.Text = "Street Test Appointments";
                        break;
                    }
                default:
                    {
                        this.Text = "Test Appointments";
                        lblMode.Text = "Test Appointments";
                        break;
                    }
            }
            _LocalDLApplication = clsLocalDLApplication.Find(_LDLAppID);
            //_AppInfo = clsApplication.Find(_LocalDLApplication.ApplicationID);
            

            ctrlLocalDrivingLicenseInfo1.LoadData(_LDLAppID);

            _RefreshDataGride();
            
        }

        private void _RefreshDataGride()
        {
            dgvAppointments.DataSource = clsTestAppointment.GetAllTestAppointmentsShortDetailes(_LocalDLApplication.LocalDrivingLicenseApplicationID, (short)_TestType);
            clsUtil.ApplyCustomStyle(ref dgvAppointments);
            lblRecords.Text = dgvAppointments.RowCount.ToString();

            if (dgvAppointments.Rows.Count > 0)
            {
                dgvAppointments.Columns[0].HeaderText = "Appointment ID";
                //dgvAppointments.Columns[0].Width = 150;

                dgvAppointments.Columns[1].HeaderText = "Appointment Date";
                //dgvAppointments.Columns[1].Width = 200;

                dgvAppointments.Columns[2].HeaderText = "Paid Fees";
                //dgvAppointments.Columns[2].Width = 150;

                dgvAppointments.Columns[3].HeaderText = "Is Locked";
                //dgvAppointments.Columns[3].Width = 100;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            _AddNewAppointment();
        }

        private void _AddNewAppointment()
        {
            if (_IsHasActiveAppointments())
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;

            }

            if (_IsPassedThisTest())
                MessageBox.Show("This Person Already passed this test before, you can only retake failed test.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //else if (dgvAppointments.Rows.Count > 0)
            //    _ScheduleRetakeTest();
            //else
            //    _ScheduleNewTest();
            else
                _ScheduleTest();

            //else if (dgvAppointments.Rows.Count > 0)
            //{

            //else
            //_ScheduleRetakeTest();

            //return;
            //}
        }

        private void _ScheduleTest()
        {
            //_Mode = enMode.AddNew;
            frmScheduleTest frm = new frmScheduleTest(_LocalDLApplication, (int)_TestType,-1);
            frm.ShowDialog();
            _RefreshDataGride();
        }
        
        //private void _ScheduleNewTest()
        //{
        //    _Mode = enMode.AddNew;
        //    frmScheduleTest frm = new frmScheduleTest(_LocalDLApplication, (int)_TestType,-1);
        //    frm.ShowDialog();
        //    _RefreshDataGride();
        //}
        
        //private void _ScheduleRetakeTest()
        //{
        //    _Mode = enMode.AddNew;
        //    frmScheduleTest frm = new frmScheduleTest(_LocalDLApplication, (int)_TestType, _LastAppID);
        //    frm.ShowDialog();
        //    _RefreshDataGride();
        //}

        private bool _IsHasActiveAppointments()
        {
            return clsTestAppointment.IsHasActiveAppointment(ctrlLocalDrivingLicenseInfo1.GetPersonID(), (short)_TestType);
        }
        
        private bool _IsPassedThisTest()
        {
            return _LocalDLApplication.IsPassedThisTest((short)_TestType);
            //return (ctrlLocalDrivingLicenseInfo1.GetPassedTestsCount() > (short)_TestType);

            //if ((_LastAppID = _GetLastAppointmentID()) != -1)
            //{
            //    if (clsTest.FindByAppointmentID(_LastAppID).TestResult)
            //        return true;
            //    else
            //        return false;
            //    //return clsTestAppointment.IsPassedTheTest(ctrlLocalDrivingLicenseInfo1._PersonID, (short)_TestType);
            //}

            //return false;

        }

        //private int _GetLastAppointmentID()
        //{
        //    if (dgvAppointments.Rows.Count != 0)
        //    {
        //        DataView AppointmentsDataView = _GetDataTable().DefaultView;
        //        AppointmentsDataView.Sort = "TestAppointmentID Desc";
        //        return (int)AppointmentsDataView[0][0];
        //    }

        //    return -1;

        //}

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _EditTest();
        }

        private void _EditTest()
        {
            //if ((bool)dgvAppointments.CurrentRow.Cells[3].Value == false)
            //{
                //_Mode = enMode.EditTest;
                frmScheduleTest frm = new frmScheduleTest(_LocalDLApplication, (int)_TestType, (int)dgvAppointments.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
                _RefreshDataGride();
            //}
            //else
            //{
            //    MessageBox.Show("This Appointment is Locked, you can add new Appointment.",
            //                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _TakeTest();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void lblMode_Click(object sender, EventArgs e)
        {

        }

        private void _TakeTest()
        {
            frmTakeTest frm = new frmTakeTest((int)dgvAppointments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            //_RefreshDataGride();
            _LoadData();

            //// Check if the appointment is locked, 3 : IsLocked column in the DataGridView
            //if ((bool)dgvAppointments.CurrentRow.Cells[3].Value == false)
            //{
            //    frmTakeTest frm = new frmTakeTest((int)dgvAppointments.CurrentRow.Cells[0].Value);
            //    frm.ShowDialog();
            //    //_RefreshDataGride();
            //    _LoadData();
            //}
            //else
            //{
            //    MessageBox.Show("This Appointment is Locked, you can add new Appointment.",
            //                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}
            
        }
    }
}
