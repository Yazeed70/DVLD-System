using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsPerson
    {
        private enum enMode { AddNew = 0, Update = 1 }

        private enMode Mode;

        public int ID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gendor {  get; set; } 
        public string ImagePath { get; set; }
        public int NationalityCountryID { get; set; }
        private clsPerson(int ID, string NationalNumber, string FirstName, string SecondName,
            string ThirdName, string LastName, string Email, string Phone, string Address, short Gendor,
            DateTime DateOfBirth, int NationalityCountryID, string ImagePath)
        {
            this.ID = ID;
            this.NationalNo = NationalNumber;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.Gendor = Gendor;
            this.DateOfBirth = DateOfBirth;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            this.Mode = enMode.Update;
        }

        public clsPerson()
        {
            this.ID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.Gendor = -1;
            this.DateOfBirth = DateTime.Now;
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            this.Mode = enMode.AddNew;

        }

        private bool _AddNewPerson()
        {
            this.ID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
            this.LastName, this.Email, this.Phone, this.Address, this.Gendor,
            this.DateOfBirth, this.NationalityCountryID, this.ImagePath);

            return (this.ID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.ID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
            this.LastName, this.Email, this.Phone, this.Address, this.Gendor,
            this.DateOfBirth, this.NationalityCountryID, this.ImagePath);

        }

        public static clsPerson Find(int ID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "",
                Address = "", ImagePath = "";

            DateTime DateOfBirth = DateTime.Now;

            int NationalityCountryID = -1;
            short Gendor = -1;


            if (clsPersonData.GetPersonInfoByID(ID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref NationalNo, ref Gendor, ref Email, ref Phone, ref Address, ref DateOfBirth, 
                ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, Email,
                    Phone, Address, Gendor, DateOfBirth, NationalityCountryID, ImagePath);
            }
            else { return null; }
        }
        
        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "",
                Address = "", ImagePath = "";

            DateTime DateOfBirth = DateTime.Now;

            int NationalityCountryID = -1, ID = -1;
            short Gendor = -1;


            if (clsPersonData.GetPersonInfoByNationalNo(NationalNo, ref ID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref Gendor, ref Email, ref Phone, ref Address, ref DateOfBirth, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, Email,
                    Phone, Address, Gendor, DateOfBirth, NationalityCountryID, ImagePath);
            }
            else { return null; }
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
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
                        return _UpdatePerson();
                    }

                default:
                    return false;

            }
        }

        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }

        public static DataTable GetAllPersons()
        {
            return clsPersonData.GetAllPeople();
        }
        
        public static DataTable GetAllPersonsWithFilter()
        {
            return clsPersonData.GetAllPeopleWithJoin();
        }


        public static bool isPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExsist(PersonID);
        }
        
        public static bool isPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExsist(NationalNo);
        }
        
        public static bool isPersonHasAUser(int PersonID)
        {
            return clsPersonData.IsPersonHasAUser(PersonID);
        }

    }
}
