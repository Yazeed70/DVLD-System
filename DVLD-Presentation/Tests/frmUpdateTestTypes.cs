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
    public partial class frmUpdateTestTypes: Form
    {

        private int _TestID;
        private clsTestTypes _TestType;
        public frmUpdateTestTypes(int ID)
        {
            InitializeComponent();

            _TestID = ID;
            //_TestID = 1;
        }

        private void frmUpdateTestTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            if (_TestID == -1)
                this.Close();

            _TestType = clsTestTypes.Find(_TestID);
            if(_TestType != null)
            {
                lblTestTypeID.Text = _TestType.ID.ToString();
                txtTestTypeTitle.Text = _TestType.TestTypeTitle;
                txtTestTypeDescription.Text = _TestType.TestTypeDescription;
                txtTestFees.Text = _TestType.TestFees.ToString();
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void _Save()
        {
            if (txtTestFees.Text != "" && txtTestTypeTitle.Text != "")
            {
                //_TestType = clsTestTypes.Find(_TestID);
                _TestType.TestTypeTitle = txtTestTypeTitle.Text;
                _TestType.TestTypeDescription = txtTestTypeDescription.Text;
                _TestType.TestFees = Convert.ToDecimal(txtTestFees.Text);
                if (_TestType.Save())
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
