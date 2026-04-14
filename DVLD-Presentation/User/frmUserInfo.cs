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
    public partial class frmUserInfo: Form
    {
        int _UserID;
        public frmUserInfo(int ID)
        {
            InitializeComponent();

            _UserID = ID;
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserDetails1.LoadData(_UserID);
        }
    }
}
