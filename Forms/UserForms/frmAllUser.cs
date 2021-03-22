using CosmaticShopApplication.DatabasLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShopApplication.Forms.UserForms
{
    public partial class frmAllUser : Form
    {
        public frmAllUser()
        {
            InitializeComponent();
        }

        private void frmAllUser_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
            dgvAllUser.Columns[1].HeaderText = "FullName";
        }


        // Fill data to DataGridView -- START
        private void FillGrid(string searchvalue)
        {
            dgvAllUser.DataSource = null;
            string query = "";
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select [employeeID] [ID], [FullName] [Full Name], [UserTypeID], [ContactNo] [Contact No],[Email] [Email],[CNIC] [CNIC],[Photo],[Address] [Address],[Description] [Description],[username],[password],[isStatus] [Status] from employeeTable where username is not null";
            }
            else
            {
                query = "select [employeeID] [ID], [FullName] [Full Name], [UserTypeID], [ContactNo] [Contact No],[Email] [Email],[CNIC] [CNIC],[Photo],[Address] [Address],[Description] [Description],[username],[password],[isStatus] [Status] from employeeTable where FullName like '%" + searchvalue + "%' and username is not null ";
            }

            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvAllUser.DataSource = dt;
                dgvAllUser.Columns[0].HeaderText = "ID";
                if (dt.Rows.Count > 0)
                {
                    dgvAllUser.Columns[0].Visible = false; // employeeID
                    dgvAllUser.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // FullName
                    dgvAllUser.Columns[2].Visible = false; // userTypeID
                    dgvAllUser.Columns[3].Width = 100; // contactNo
                    dgvAllUser.Columns[4].Width = 150; // Email
                    dgvAllUser.Columns[5].Width = 100; // CNIC
                    dgvAllUser.Columns[6].Visible = false; // Photo
                    dgvAllUser.Columns[7].Width = 150; // Address
                    dgvAllUser.Columns[8].Width = 150; // Description
                    dgvAllUser.Columns[9].Visible = false; // username
                    dgvAllUser.Columns[10].Visible = false; // password
                    dgvAllUser.Columns[11].Width = 50; // isStatus
                }
                else
                {
                    dgvAllUser.DataSource = null;
                }
            }
        }
        // Fill data to DataGridView -- END


        private void btnFind_Click(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }
        



        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveUser();
        }



        public void RemoveUser()
        {
            if(dgvAllUser != null)
            {
                if(dgvAllUser.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show("Confrim Remove?", "C# dev by TIK", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        int employeeid = Convert.ToInt32(dgvAllUser.CurrentRow.Cells[0].Value);
                        int usertypeid = Convert.ToInt32(dgvAllUser.CurrentRow.Cells[2].Value); // เช็คว่าเป็น admin หรือไม่
                        if(usertypeid != 1)
                        {
                            string removequery = string.Format(@"update employeeTable set Username = NULL where EmployeeID = '{0}' ", employeeid);
                            bool result = DatabaseAccess.Update(removequery);
                            if (result == true)
                            {
                                MessageBox.Show("User Removed Successfully...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                FillGrid(txtSearch.Text.Trim());
                                txtSearch.Clear();
                                txtSearch.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot Remove Administrator Type...!", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            txtSearch.Clear();
                            txtSearch.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Select One Row..", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Select One Row..", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
    }
}
