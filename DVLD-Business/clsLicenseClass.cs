using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicenseClass
    {
        public int ID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }
        private clsLicenseClass(int ID, string ClassName, string ClassDescription, byte MinimumAllowedAge,
            byte DefaultValidityLength, decimal ClassFees)
        {
            this.ID = ID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }

        public clsLicenseClass()
        {
            this.ID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 18;
            this.DefaultValidityLength = 1;
            this.ClassFees = -1;
        }

        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassData.UpdateLicenseClass(this.ID, this.ClassName, this.ClassDescription,
                this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
        }

        public static clsLicenseClass Find(int ID)
        {
            string ClassName = "", ClassDescription="";
            byte MinimumAllowedAge = 18, DefaultValidityLength = 1;
            decimal ClassFees = -1;


            if (clsLicenseClassData.GetLicenseClassInfoByID(ID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge,
                ref DefaultValidityLength, ref ClassFees)) 
            {
                return new clsLicenseClass(ID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else { return null; }
        }

        public bool Save()
        {
            return _UpdateLicenseClass();
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }

        public static bool isLicenseClassExist(int LicenseClassID)
        {
            return clsLicenseClassData.IsLicenseClassExsist(LicenseClassID);
        }
    }
}
