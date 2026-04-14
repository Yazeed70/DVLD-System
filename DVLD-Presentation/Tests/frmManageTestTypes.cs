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
    public partial class frmManageTestTypes: Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
            clsUtil.ApplyCustomStyle(ref dgvTestTypes);
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            dgvTestTypes.DataSource = clsTestTypes.GetAllTestTypes();
            lblRecords.Text = dgvTestTypes.RowCount.ToString();

            if (dgvTestTypes.RowCount > 0)
            {
                dgvTestTypes.Columns[0].HeaderText = "Test Type ID";
                dgvTestTypes.Columns[1].HeaderText = "Title";
                dgvTestTypes.Columns[2].HeaderText = "Description";
                dgvTestTypes.Columns[3].HeaderText = "Fees";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _EditTestType();
        }

        private void _EditTestType()
        {
            frmUpdateTestTypes frm = new frmUpdateTestTypes((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadData();
        }
    }
}
