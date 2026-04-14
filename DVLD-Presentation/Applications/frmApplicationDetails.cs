using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmApplicationDetails : Form
    {
        int _LDLApp;
        clsLocalDLApplication _LDLApplication;
        public frmApplicationDetails(int LDLApp)
        {
            InitializeComponent();

            _LDLApp = LDLApp;
        }

        private void frmApplicationDetails_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            ctrlLocalDrivingLicenseInfo1.LoadData(_LDLApp);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
