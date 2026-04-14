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
    public partial class frmManageApplicationTypes: Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
            clsUtil.ApplyCustomStyle(ref dgvApplicationTypes);
        }
        private void _LoadData()
        {
            dgvApplicationTypes.DataSource = clsApplicationTypes.GetAllApplicationTypes();
            lblRecords.Text = dgvApplicationTypes.RowCount.ToString();

            if (dgvApplicationTypes.RowCount > 0)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "Application ID";
                dgvApplicationTypes.Columns[1].HeaderText = "Title";
                dgvApplicationTypes.Columns[2].HeaderText = "Fees";
            }
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _EditApplicationType();
        }

        private void _EditApplicationType()
        {
            frmUpdateApplicationType frm = new frmUpdateApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadData();
        }
    }
}
