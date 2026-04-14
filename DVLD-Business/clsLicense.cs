using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicense
    {
        private enum enMode { AddNew = 0, Update = 1 }

        private enMode Mode;

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate,
            DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.Mode = enMode.Update;
        }

        public clsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = -1;
            this.IsActive = false;
            this.IssueReason = 1;
            this.CreatedByUserID = -1;

            this.Mode = enMode.AddNew;

        }

        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass,
                this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass,
                this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);

        }

        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = -1, LicenseClass = -1, CreatedByUserID = -1, DriverID = -1;

            DateTime IssueDate = DateTime.Now , ExpirationDate = DateTime.Now;

            decimal PaidFees = -1;

            string Notes = "";

            bool IsActive = false;

            byte IssueReason = 1;


            if (clsLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID,
                ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive,
                ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate,
                    ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            else { return null; }
        }

        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            int LicenseID = -1, LicenseClass = -1, CreatedByUserID = -1, DriverID = -1;

            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;

            decimal PaidFees = -1;

            string Notes = "";

            bool IsActive = false;

            byte IssueReason = 1;


            if (clsLicenseData.GetLicenseInfoByApplicationID(ApplicationID, ref LicenseID, ref DriverID,
                ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive,
                ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate,
                    ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            else { return null; }
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
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
                        return _UpdateLicense();
                    }

                default:
                    return false;

            }
        }

        public static bool DeleteLicense(int LicenseID)
        {
            return clsLicenseData.DeleteLicense(LicenseID);
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicenseData.GetAllLicenses();
        }

        public static bool isLicenseExist(int LicenseID)
        {
            return clsLicenseData.IsLicenseExsist(LicenseID);
        }

        public string GetIssueReason()
        {
            //IssueReason: 1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.

            switch (this.IssueReason)
            {
                case 1:
                    {
                        return "First Time";
                    }
                case 2:
                    {
                        return "Renew";
                    }
                case 3:
                    {
                        return "Replacement for Damaged";
                    }
                case 4:
                    {
                        return "Replacement for Lost";
                    }
                default:
                    {
                        return "First Time";
                    }
            }
        }

        public static DataTable GetAllLocalLicensesByID(int PersonID)
        {
            return clsLicenseData.GetAllLocalLicensesByPersonID(PersonID);
        }
    }
}
