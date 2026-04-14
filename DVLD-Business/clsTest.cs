using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsTest
    {
        private enum enMode { AddNew = 0, Update = 1 }

        private enMode Mode;

        //public bool _ResultOfLastTest;
        //private bool _TestResult;

        public int ID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        private clsTest(int ID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this.ID = ID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            this.Mode = enMode.Update;
        }

        public clsTest()
        {
            this.ID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.CreatedByUserID = -1;
            this.Notes = "";

            this.Mode = enMode.AddNew;

        }

        private bool _AddNewTest()
        {
            this.ID = clsTestData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);

            return (this.ID != -1);
        }

        private bool _UpdateTest()
        {
            return clsTestData.UpdateTest(this.ID, this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);

        }

        public static clsTest Find(int ID)
        {
            int TestAppointmentID = -1, CreatedByUserID = -1;

            string Notes = "";

            bool TestResult = false;

            if (clsTestData.GetTestInfoByID(ID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTest(ID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            else { return null; }
        }

        public static clsTest FindByAppointmentID(int TestAppointmentID)
        {
            int CreatedByUserID = -1, ID = -1;

            string Notes = "";

            bool TestResult = false;

            if (clsTestData.GetTestInfoByAppointmentID(TestAppointmentID, ref ID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTest(ID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            else { return null; }
        }
        
        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
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
                        return _UpdateTest();
                    }

                default:
                    return false;

            }
        }

        public static bool DeleteTest(int ID)
        {
            return clsTestData.DeleteTest(ID);
        }

        public static DataTable GetAllTests()
        {
            return clsTestData.GetAllTests();
        }

        public static bool isTestExist(int TestID)
        {
            return clsTestData.IsTestExsist(TestID);
        }
    }
}
