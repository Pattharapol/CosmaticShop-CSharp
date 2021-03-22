using CosmaticShopApplication.DatabasLayer;
using CosmaticShopApplication.Forms.UserForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShopApplication.Forms.EmployeeForms
{
    public partial class frmSearchEmployee : Form
    {
        private frmCreateUser CreateUser { get; set; }

        public frmSearchEmployee(string searchvalue, frmCreateUser createUser)
        {
            InitializeComponent();
            CreateUser = createUser;
            FillGrid(searchvalue);
        }

        private void frmSearchEmployee_Load(object sender, EventArgs e)
        {

        }


        // Fill data to DataGridView -- START
        private void FillGrid(string searchvalue)
        {
            dgvSearchEmployee.DataSource = null;
            string query = "";
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select [employeeID] [ID], [FullName] [Full Name], [UserTypeID], [ContactNo] [Contact No],[Email] [Email],[CNIC] [CNIC],[Photo],[Address] [Address],[Description] [Description],[username],[password],[isStatus] [Status] from employeeTable";
            }
            else
            {
                query = "select [employeeID] [ID], [FullName] [Full Name], [UserTypeID], [ContactNo] [Contact No],[Email] [Email],[CNIC] [CNIC],[Photo],[Address] [Address],[Description] [Description],[username],[password],[isStatus] [Status] from employeeTable where FullName like '%" + searchvalue + "%' ";
            }

            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvSearchEmployee.DataSource = dt;
                if (dt.Rows.Count > 0)
                {

                    dgvSearchEmployee.Columns[0].Visible = false; // employeeID
                    dgvSearchEmployee.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // FullName
                    dgvSearchEmployee.Columns[2].Visible = false; // userTypeID
                    dgvSearchEmployee.Columns[3].Width = 100; // contactNo
                    dgvSearchEmployee.Columns[4].Width = 150; // Email
                    dgvSearchEmployee.Columns[5].Width = 100; // CNIC
                    dgvSearchEmployee.Columns[6].Visible = false; // Photo
                    dgvSearchEmployee.Columns[7].Width = 150; // Address
                    dgvSearchEmployee.Columns[8].Width = 150; // Description
                    dgvSearchEmployee.Columns[9].Visible = false; // username
                    dgvSearchEmployee.Columns[10].Visible = false; // password
                    dgvSearchEmployee.Columns[11].Width = 50; // isStatus

                }
                else
                {
                    dgvSearchEmployee.DataSource = null;
                }
            }
        }
        // Fill data to DataGridView -- END


        
        private void btnFind_Click(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }



        public void SelectEmployee()
        {
            if(dgvSearchEmployee != null)
            {
                if(dgvSearchEmployee.Rows.Count > 0)
                {
                    if(dgvSearchEmployee.SelectedRows.Count == 1)
                    {
                        if(CreateUser != null)
                        {
                            CreateUser.EmployeeID = Convert.ToInt32(dgvSearchEmployee.CurrentRow.Cells[0].Value); // employeeID
                            CreateUser.lblFullName.Text = Convert.ToString(dgvSearchEmployee.CurrentRow.Cells[1].Value); // FullName
                            CreateUser.lblContactNo.Text = Convert.ToString(dgvSearchEmployee.CurrentRow.Cells[3].Value); // contactNo
                            CreateUser.lblCNIC.Text = Convert.ToString(dgvSearchEmployee.CurrentRow.Cells[5].Value); // CNIC

                           string value = dgvSearchEmployee.CurrentRow.Cells[6].Value != DBNull.Value ? Convert.ToString(dgvSearchEmployee.CurrentRow.Cells[6].Value) : string.Empty ; // Photo
                            if (!string.IsNullOrEmpty(value))
                            {
                                CreateUser.picEMP.Image = DatabaseAccess.Base64ToImage(value);
                            }
                            else
                            {
                                CreateUser.picEMP.Image = null;
                            }

                            CreateUser.txtUserName.Text = Convert.ToString(dgvSearchEmployee.CurrentRow.Cells[9].Value); // username
                            CreateUser.txtPassword.Text = Convert.ToString(dgvSearchEmployee.CurrentRow.Cells[10].Value); // password
                            CreateUser.txtConfirmPassword.Text = Convert.ToString(dgvSearchEmployee.CurrentRow.Cells[10].Value); // password
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Record!!", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("List is Empty!!", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("List is Empty!!", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // pick from DGVSearchEmployee to show data to CreateUser -- START
        private void dgvSearchEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectEmployee();
        }
        // pick from DGVSearchEmployee to show data to CreateUser -- END

        // pick from DGVSearchEmployee to show data to CreateUser -- START
        private void dgvSearchEmployee_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectEmployee();
        }
        // pick from DGVSearchEmployee to show data to CreateUser -- END

        // pick from DGVSearchEmployee to show data to CreateUser -- START
        private void dgvSearchEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SelectEmployee();
            }
        }
        // pick from DGVSearchEmployee to show data to CreateUser -- END


        // pick from DGVSearchEmployee to show data to CreateUser -- START
        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectEmployee();
        }
        // pick from DGVSearchEmployee to show data to CreateUser -- END
    }
}
