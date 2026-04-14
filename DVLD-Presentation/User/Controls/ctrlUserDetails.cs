using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD_Presentation
{
    public partial class ctrlUserDetails: UserControl
    {
        clsUser _User;
        int _UserID = -1;
        public ctrlUserDetails()
        {
            InitializeComponent();
        }

        public void LoadData(int UserID)
        {
            _User = clsUser.Find(UserID);
            if (_User == null)
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctrlPersonDetails1.LoadData(_User.PersonID);
            lblUserID.Text = _User.ID.ToString();
            lblUsername.Text = _User.UserName;
            lblisActive.Text = _User.IsActive ? "Yes" : "No";

        }

        private void ctrlUserDetails_Load(object sender, EventArgs e)
        {
            
        }
    }
}
