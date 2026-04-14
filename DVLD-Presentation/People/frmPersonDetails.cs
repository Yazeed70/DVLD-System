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
    public partial class frmPersonDetails: Form
    {
        int _PersonID;
        clsPerson _Person;
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void _LoadData()
        {
            //_Person = clsPerson.Find(_PersonID);

            if (_PersonID == -1)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID);
                this.Close();

                return;
            }

            ctrlPersonDetails1.LoadData(_PersonID);
            
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
