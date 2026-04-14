using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsUser
    {
        private enum enMode { AddNew = 0, Update = 1 }

        private enMode Mode;

        public int ID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        private clsUser(int ID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.ID = ID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            this.Mode = enMode.Update;
        }

        public clsUser()
        {
            this.ID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            this.PersonID = -1;

            this.Mode = enMode.AddNew;

        }

        private bool _AddNewUser()
        {
            this.ID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.ID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.ID, this.PersonID, this.UserName, this.Password, this.IsActive);

        }

        public static clsUser Find(int ID)
        {
            string UserName = "", Password = "";

            int PersonID = -1;
            bool IsActive = false;


            if (clsUserData.GetUserInfoByID(ID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(ID, PersonID, UserName, Password, IsActive);
            }
            else { return null; }
        }
        
        public static clsUser FindByUsernameAndPassword(string Username,string Password)
        {
            //string UserName = "", Password = "";

            int PersonID = -1, ID = -1;
            bool IsActive = false;


            if (clsUserData.GetUserInfoByUsernameAndPassword(Username, Password, ref ID, ref PersonID, ref IsActive))
            {
                return new clsUser(ID, PersonID, Username, Password, IsActive);
            }
            else { return null; }
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
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
                        return _UpdateUser();
                    }

                default:
                    return false;

            }
        }

        public static bool DeleteUser(int ID)
        {
            return clsUserData.DeleteUser(ID);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
        
        public static DataTable GetAllUsersWithFullName()
        {
            return clsUserData.GetAllUsersWithFullName();
        }


        public static bool isUserExist(int UserID)
        {
            return clsUserData.IsUserExsist(UserID);
        }
        
        public static bool isUserActive(int UserID)
        {
            return clsUserData.IsUserActive(UserID);
        }
    }
}
