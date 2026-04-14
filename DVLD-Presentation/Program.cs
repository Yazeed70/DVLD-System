using DVLD_Business;
//using Syncfusion.Windows.Forms;
//using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD_Presentation
{
    internal static class Program
    {

        //public static clsUser CurrentUser;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzcyMzE1MkAzMjM4MmUzMDJlMzBlK3FnK3pJVEpoMndjbEpJTllvSWYwYWEzczZidlJmMTBiYktaV3k3N3NvPQ==\r\n\r\n");
            //SkinManager.LoadAssembly(typeof(ProjectTheme1).Assembly);
            //SfSkinManager.LoadAssembly(typeof(ProjectTheme1).Assembly);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            //Application.Run(new frmTest());
            //Application.Run(new frmMain());
            //Application.Run(new frmManagePeople());
            //Application.Run(new frmAddNewUser());
            //Application.Run(new frmPersonDetails(1026));
            //Application.Run(new frmManageUsers());
            //Application.Run(new frmLocalD());
        }
    }
    
}
