using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    internal class clsDataAccessSettings
    {
        // Use this connection string if you are using SQL Server Authentication:
        public static string connectionString = "Server=.;Database=DVLD;User Id=Write_Your_ID_Here;Password=Write_Your_Password_Here;";

        // OR use this connection string if you are using Windows Authentication (Integrated Security):
        // public static string connectionString = "Server=.;Database=DVLD;Integrated Security=True;";
    }
}
