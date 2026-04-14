using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplicationTypes
    {
        public int ID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }
        private clsApplicationTypes(int ID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            this.ID = ID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;
        }

        public clsApplicationTypes()
        {
            this.ID = -1;
            this.ApplicationTypeTitle = "";
            this.ApplicationFees = -1;
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypesData.UpdateApplicationType(this.ID, this.ApplicationTypeTitle, this.ApplicationFees);
        }

        public static clsApplicationTypes Find(int ID)
        {
            string ApplicationTypeTitle = "";
            decimal ApplicationFees = -1;


            if (clsApplicationTypesData.GetApplicationTypeInfoByID(ID, ref ApplicationTypeTitle, ref ApplicationFees))
            {
                return new clsApplicationTypes(ID, ApplicationTypeTitle, ApplicationFees);
            }
            else { return null; }
        }

        public bool Save()
        {
            return _UpdateApplicationType();
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }

        public static bool isApplicationTypeExist(int ApplicationTypeID)
        {
            return clsApplicationTypesData.IsApplicationTypeExsist(ApplicationTypeID);
        }
    }
}
