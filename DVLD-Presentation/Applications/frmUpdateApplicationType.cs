using DVLD_Business;
//using Syncfusion.Windows.Forms.Tools;
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
    public partial class frmUpdateApplicationType: Form
    {

        private int _ApplicationID = -1;
        private clsApplicationTypes _ApplicationType;
        public frmUpdateApplicationType(int ID)
        {
            InitializeComponent();

            _ApplicationID = ID;
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            if (_ApplicationID == -1)
                this.Close();

            _ApplicationType = clsApplicationTypes.Find(_ApplicationID);
            if (_ApplicationType != null)
            {
                lblApplicationTypeID.Text = _ApplicationType.ID.ToString();
                txtApplicationTypeTitle.Text = _ApplicationType.ApplicationTypeTitle;
                txtApplicationFees.Text = _ApplicationType.ApplicationFees.ToString();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void _Save()
        {
            if (txtApplicationFees.Text != "" && txtApplicationTypeTitle.Text != "")
            {
                _ApplicationType.ApplicationTypeTitle = txtApplicationTypeTitle.Text.Trim();
                _ApplicationType.ApplicationFees = Convert.ToDecimal(txtApplicationFees.Text.Trim());

                if (_ApplicationType.Save())
                    MessageBox.Show("Data Saved Successfully.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
                MessageBox.Show($"Please Enter correct Info", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
