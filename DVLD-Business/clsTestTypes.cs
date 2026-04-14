using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestTypes
    {
        public int ID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestFees { get; set; }
        private clsTestTypes(int ID, string TestTypeTitle, string TestTypeDescription, decimal TestFees)
        {
            this.ID = ID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestFees = TestFees;
        }

        public clsTestTypes()
        {
            this.ID = -1;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestFees = -1;
        }

        private bool _UpdateTestType()
        {
            return clsTestTypesData.UpdateTestType(this.ID, this.TestTypeTitle, this.TestTypeDescription, this.TestFees);
        }

        public static clsTestTypes Find(int ID)
        {
            string TestTypeTitle = "";
            string TestTypeDescription = "";
            decimal TestFees = -1;


            if (clsTestTypesData.GetTestTypeInfoByID(ID, ref TestTypeTitle, ref TestTypeDescription, ref TestFees))
            {
                return new clsTestTypes(ID, TestTypeTitle, TestTypeDescription, TestFees);
            }
            else { return null; }
        }

        public bool Save()
        {
            return _UpdateTestType();
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }

        public static bool isTestTypeExist(int TestTypeID)
        {
            return clsTestTypesData.IsTestTypeExsist(TestTypeID);
        }
    }
}
