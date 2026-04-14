using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLocalDLApplication
    {
        private enum enMode { AddNew = 0, Update = 1 }

        private enMode Mode;

        public struct stDrivingLicenseApplicationView
        {
            public int LocalDrivingLicenseAppID;
            public int PassesTests;
            public string NationalNo, ClassName, FullName, Status;
            public DateTime ApplicationDate;
            public bool isNull;

            public stDrivingLicenseApplicationView (int LocalDrivingLicenseAppID, string ClassName,
              string NationalNo, string FullName, DateTime ApplicationDate, int PassesTests,
              string Status, bool isNull)
            {
                this.LocalDrivingLicenseAppID = LocalDrivingLicenseAppID;
                this.ClassName = ClassName;
                this.NationalNo = NationalNo;
                this.FullName = FullName;
                this.ApplicationDate = ApplicationDate;
                this.PassesTests = PassesTests;
                this.Status = Status;

                this.isNull = isNull;
            }
            
            public stDrivingLicenseApplicationView (bool isNull)
            {
                this.isNull = isNull;
                this.LocalDrivingLicenseAppID = -1;
                this.ClassName = "";
                this.NationalNo = "";
                this.FullName = "";
                this.ApplicationDate = DateTime.Now;
                this.PassesTests = -1;
                this.Status = "";
            }
        }

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        private clsLocalDLApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;

            this.Mode = enMode.Update;
        }

        public clsLocalDLApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;

            this.Mode = enMode.AddNew;

        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            //if(IsAllowedToAddNew())
            this.LocalDrivingLicenseApplicationID = clsLocalDLApplicationData.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        public int IsAllowedToAddNew(int PersonID, int LicenseClassID)
        {
            return clsLocalDLApplicationData.IsAllowedToAddNew(PersonID, LicenseClassID);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDLApplicationData.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);

        }

        public static clsLocalDLApplication Find(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            if (clsLocalDLApplicationData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))
            {
                return new clsLocalDLApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
            }
            else { return null; }
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
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
                        return _UpdateLocalDrivingLicenseApplication();
                    }

                default:
                    return false;

            }
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDLApplicationData.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDLApplicationData.GetAllLocalDrivingLicenseApplications();
        }

        public static bool isLocalDrivingLicenseApplicationExist(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDLApplicationData.IsLocalDrivingLicenseApplicationExsist(LocalDrivingLicenseApplicationID);
        }

        public static DataTable GetAllLocalDrivingLicenseApplicationsView()
        {
            return clsLocalDLApplicationData.GetLocalDrivingLicenseApplicationsView();
        }

        public static stDrivingLicenseApplicationView FindFromVeiw(int LocalDrivingLicenseApplicationID)
        {
            int PassesTests = -1;
            string NationalNo = "", ClassName = "", FullName ="", Status = "";
            DateTime ApplicationDate = DateTime.Now;

            if (clsLocalDLApplicationData.GetLocalDrivingLicenseApplicationViewByID(LocalDrivingLicenseApplicationID,
                ref NationalNo, ref ClassName, ref FullName, ref ApplicationDate, ref PassesTests, ref Status))
            {
                return new stDrivingLicenseApplicationView(LocalDrivingLicenseApplicationID, ClassName, NationalNo, FullName, ApplicationDate, PassesTests, Status, false);
            }
            else { return new stDrivingLicenseApplicationView(true); }
        }

        
    }
}
