using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsDriver
    {
        private enum enMode { AddNew = 0, Update = 1 }

        private enMode Mode;

        public int ID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        private clsDriver(int ID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.ID = ID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;

            this.Mode = enMode.Update;
        }

        public clsDriver()
        {
            this.ID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;

            this.Mode = enMode.AddNew;

        }

        private bool _AddNewDriver()
        {
            this.ID = clsDriverData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);

            return (this.ID != -1);
        }

        private bool _UpdateDriver()
        {
            return clsDriverData.UpdateDriver(this.ID, this.PersonID, this.CreatedByUserID, this.CreatedDate);

        }

        public static clsDriver Find(int ID)
        {
            int PersonID = -1, CreatedByUserID = -1;

            DateTime CreatedDate = DateTime.Now;

            if (clsDriverData.GetDriverInfoByID(ID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(ID, PersonID, CreatedByUserID, CreatedDate);
            }
            else { return null; }
        }
        
        public static clsDriver FindByPersonID(int PersonID)
        {
            DateTime CreatedDate = DateTime.Now;

            int CreatedByUserID = -1, ID = -1;


            if (clsDriverData.GetDriverInfoByPersonID(PersonID, ref ID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(ID, PersonID, CreatedByUserID, CreatedDate);
            }
            else { return null; }
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
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
                        return _UpdateDriver();
                    }

                default:
                    return false;

            }
        }

        public static bool DeleteDriver(int ID)
        {
            return clsDriverData.DeleteDriver(ID);
        }

        public static DataTable GetAllDriversView()
        {
            return clsDriverData.GetAllDrivers_View();
        }

        public static bool isDriverExist(int DriverID)
        {
            return clsDriverData.IsDriverExsist(DriverID);
        }
        
    }
}
