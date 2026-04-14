using DVLD.Classes;
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
    public partial class frmLicenseHistory : Form
    {

        int _PersonID;
        //clsLocalDLApplication _LocalDLApplication;
        public frmLicenseHistory(int PersonID)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;

            _PersonID = PersonID;
            //_LDLAppID = LDLAppID;
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            //_LocalDLApplication = clsLocalDLApplication.Find(_LDLAppID);
            //clsPerson Person = clsPerson.Find(clsApplication.Find(_LocalDLApplication.ApplicationID).ApplicantPersonID);
            clsPerson Person = clsPerson.Find(_PersonID);
            ctrlPersonDetailsWithFilter1._LoadData(Person.ID);

            dgvLocalHistory.DataSource = clsLicense.GetAllLocalLicensesByID(Person.ID);
            dgvInternationalHistory.DataSource = clsInternationalLicense.GetAllInternationalLicensesByID(Person.ID);
            clsUtil.ApplyCustomStyle(ref dgvLocalHistory);
            clsUtil.ApplyCustomStyle(ref dgvInternationalHistory);
            _UpdatelabelRecords();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _UpdatelabelRecords();
        }

        private void _UpdatelabelRecords()
        {
            // 0 = Local History, 1 = International History
            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {
                lblRecords.Text = dgvLocalHistory.RowCount.ToString();
            }
            else if(tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                lblRecords.Text = dgvInternationalHistory.RowCount.ToString();
            }
            else
                lblRecords.Text = "[????]";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void TSMShowLocalLicenseInfo_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo((int)dgvLocalHistory.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void TSMShowInternationalLicenseInfo_Click(object sender, EventArgs e)
        {
            // 2 = IssuedUsingLocalLicenseID
            frmLicenseInfo frm = new frmLicenseInfo((int)dgvInternationalHistory.CurrentRow.Cells[2].Value);
            frm.ShowDialog();
        }
    }
}
