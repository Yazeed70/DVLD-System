using DVLD.Classes;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD_Presentation
{
    public partial class frmManagePeople : Form
    {
        private static DataTable _dtAllPeople = clsPerson.GetAllPersons();

        //only select the columns that you want to show in the grid
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                         "FirstName", "SecondName", "ThirdName", "LastName",
                                                         "GendorCaption", "DateOfBirth", "CountryName",
                                                         "Phone", "Email");

        private enum encbFilter
        {
            None,
            PersonID,
            NationalNo,
            FirstName,
            SecondName,
            ThirdName,
            LastName,
            Gender,
            Email,
            Country,
            Phone
        }

        private encbFilter _enSelectedIndex;

        public frmManagePeople()
        {
            InitializeComponent();

            clsUtil.ApplyCustomStyle(ref dgvAllPeople);
        }

        private void _RefreshPeopleList()
        {
            _dtAllPeople = clsPerson.GetAllPersons();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                         "FirstName", "SecondName", "ThirdName", "LastName",
                                                         "GendorCaption", "DateOfBirth", "CountryName",
                                                         "Phone", "Email");

            dgvAllPeople.DataSource = _dtPeople;
            _RefreshCountLabel();
        }

        private void _RefreshCountLabel()
        {
            lblRecords.Text = dgvAllPeople.Rows.Count.ToString();
            dgvAllPeople.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAllPeople.RowHeadersWidth = 30;
        }

        private void _LoadData()
        {
            dgvAllPeople.DataSource = _dtPeople;

            if (dgvAllPeople.Rows.Count > 0)
            {

                dgvAllPeople.Columns[0].HeaderText = "Person ID";
                dgvAllPeople.Columns[0].Width = 70;

                dgvAllPeople.Columns[1].HeaderText = "National No.";
                dgvAllPeople.Columns[1].Width = 90;


                dgvAllPeople.Columns[2].HeaderText = "First Name";
                dgvAllPeople.Columns[2].Width = 100;

                dgvAllPeople.Columns[3].HeaderText = "Second Name";
                dgvAllPeople.Columns[3].Width = 100;


                dgvAllPeople.Columns[4].HeaderText = "Third Name";
                dgvAllPeople.Columns[4].Width = 100;

                dgvAllPeople.Columns[5].HeaderText = "Last Name";
                dgvAllPeople.Columns[5].Width = 100;

                dgvAllPeople.Columns[6].HeaderText = "Gendor";
                dgvAllPeople.Columns[6].Width = 60;

                dgvAllPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvAllPeople.Columns[7].Width = 100;

                dgvAllPeople.Columns[8].HeaderText = "Nationality";
                dgvAllPeople.Columns[8].Width = 60;


                dgvAllPeople.Columns[9].HeaderText = "Phone";
                dgvAllPeople.Columns[9].Width = 100;


                dgvAllPeople.Columns[10].HeaderText = "Email";
                dgvAllPeople.Columns[10].Width = 100;
            }
            _RefreshCountLabel();
            cbFillter.DataSource = Enum.GetValues(typeof(encbFilter));
            cbFillter.SelectedIndex = 0;
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _AddNewPerson()
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void _FillterData()
        {
            if (_enSelectedIndex == encbFilter.None || txtFilter.Text == "")
            {
                _dtPeople.DefaultView.RowFilter = null;
                _RefreshCountLabel();
                return;
            }

            if (_enSelectedIndex == encbFilter.PersonID)
                _dtPeople.DefaultView.RowFilter = $"PersonID = {txtFilter.Text}";
            else
                _dtPeople.DefaultView.RowFilter = $"{_enSelectedIndex} like '{txtFilter.Text}%'";

            _RefreshCountLabel();
        }


        private void cbFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = cbFillter.SelectedItem != null &&
                                 (encbFilter)cbFillter.SelectedItem != encbFilter.None;

            _enSelectedIndex = (encbFilter)cbFillter.SelectedItem;

            if (txtFilter.Visible)
            {
                txtFilter.Text = "";
                txtFilter.Focus();
            }
            else
            {
                txtFilter.Text = "";
                _dtPeople.DefaultView.RowFilter = null;
                _RefreshCountLabel();
            }


        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _FillterData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmShowDetailes_Click(object sender, EventArgs e)
        {
            _ShowPersonDetailes();
        }

        private void _ShowPersonDetailes()
        {
            frmPersonDetails frm = new frmPersonDetails((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void tsmAddNewPerson_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            _EditPersonInfo();
        }

        private void _EditPersonInfo()
        {
            frmAddEditPerson frm = new frmAddEditPerson((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            _DeletePerson();
        }

        private void _DeletePerson()
        {
            int PersonID = (int)dgvAllPeople.CurrentRow.Cells[0].Value;
            clsPerson Person = clsPerson.Find(PersonID);
            if (MessageBox.Show($"Are you sure you want to delete Person [{PersonID}]", "Confirm Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                string PersonImagePath = Person.ImagePath;
                if (clsPerson.DeletePerson(PersonID))
                {
                    if (PersonImagePath != "" && File.Exists(PersonImagePath))
                    {
                        try
                        {
                            File.Delete(PersonImagePath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting image file: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    MessageBox.Show("Person Deleted Successfully.", "Done",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    _RefreshPeopleList();
                }
                else
                    MessageBox.Show($"Person was not Deleted because it has data linked to it.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_enSelectedIndex == encbFilter.PersonID)
            {
                //allow only numbers
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                //allow all characters
                e.Handled = false;
            }
        }
    }
}

