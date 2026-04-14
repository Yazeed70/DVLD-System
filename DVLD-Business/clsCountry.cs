using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;


namespace DVLD_Business
{
    public class clsCountry
    {

        public int CountryID { get; set; }
        public string CountryName { get; set; }

        private clsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            
        }

        public clsCountry()
        {
            this.CountryID = -1;
            this.CountryName = "";
        }

        

        public static clsCountry Find(int CountryID)
        {
            string CountryName = "", Code = "", PhoneCode = "";

            if (clsCountryData.GetCountryInfoByCountryID(CountryID, ref CountryName))
            {
                return new clsCountry(CountryID, CountryName);
            }
            else { return null; }
        }

        public static clsCountry Find(string CountryName)
        {
            int CountryID = -1;
            string Code = "", PhoneCode = "";

            if (clsCountryData.GetCountryInfoByCountryName(ref CountryID, CountryName))
            {
                return new clsCountry(CountryID, CountryName);
            }
            else { return null; }
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }


        public static bool isCountryExist(int CountryID)
        {
            return clsCountryData.IsCountryExsist(CountryID);
        }

        public static bool isCountryExist(string CountryName)
        {
            return clsCountryData.IsCountryExsist(CountryName);
        }
    }
}
