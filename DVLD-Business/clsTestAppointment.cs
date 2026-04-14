using DVLD_DataAccess;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestAppointment
    {
        private enum enMode { AddNew = 0, Update = 1 }

        private enMode Mode;

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        private clsTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
            decimal PaidFees, int CreatedByUserID, bool IsLocked, int retakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = retakeTestApplicationID;

            this.Mode = enMode.Update;
        }

        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;

            this.Mode = enMode.AddNew;

        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked,this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(this.TestAppointmentID, this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked,this.RetakeTestApplicationID);

        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID = -1, LocalDrivingLicenseApplicationID = -1, CreatedByUserID = -1,
            RetakeTestApplicationID =-1;

            DateTime AppointmentDate = DateTime.Now;

            decimal PaidFees = -1;

            bool IsLocked = false; 

            if (clsTestAppointmentData.GetTestAppointmentInfoByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
                AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }
            else { return null; }
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    {
                        return _UpdateTestAppointment();
                    }

                default:
                    return false;

            }
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointmentData.DeleteTestAppointment(TestAppointmentID);
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentData.GetAllTestAppointments();
        }
        
        public static DataTable GetAllTestAppointmentsShortDetailes(int LDLAppID, short TestTypeID)
        {
            return clsTestAppointmentData.GetAllTestAppointmentsByPersonID(LDLAppID, TestTypeID);
        }

        public static bool isTestAppointmentExist(int TestAppointmentID)
        {
            return clsTestAppointmentData.IsTestAppointmentExsist(TestAppointmentID);
        }
        
        public static bool IsHasActiveAppointment(int PersonID, short TestTypeID)
        {
            return clsTestAppointmentData.IsHasActiveAppointment(PersonID, TestTypeID);
        }
        public static int NumberOfTrials(int LDLAppID, short TestTypeID)
        {
            return clsTestAppointmentData.NumberOfTrials(LDLAppID, TestTypeID);
        }

        public static DataTable GetTestAppointmentViewByID(int TestAppointmentID)
        {
            return clsTestAppointmentData.GetTestAppointmentViewByID(TestAppointmentID);
        }
        
        public static DataTable GetTestAppointmentsView(int TestAppointmentID)
        {
            return clsTestAppointmentData.GetTestAppointmentsView(TestAppointmentID);
        }
    }
}
