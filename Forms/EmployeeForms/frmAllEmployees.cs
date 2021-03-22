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

namespace CosmeticShopApplication.Forms.EmployeeForms
{
    public partial class frmAllEmployees : Form
    {
        public frmAllEmployees()
        {
            InitializeComponent();
        }

        private void frmAllEmployees_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        // Fill data to DataGridView -- START
        private void FillGrid(string searchvalue)
        {
            dgvEmployee.DataSource = null;
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
                dgvEmployee.DataSource = dt;
                if (dt.Rows.Count > 0)
                {

                    dgvEmployee.Columns[0].Visible = false; // employeeID
                    dgvEmployee.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // FullName
                    dgvEmployee.Columns[2].Visible = false; // userTypeID
                    dgvEmployee.Columns[3].Width = 100; // contactNo
                    dgvEmployee.Columns[4].Width = 150; // Email
                    dgvEmployee.Columns[5].Width = 100; // CNIC
                    dgvEmployee.Columns[6].Visible = false; // Photo
                    dgvEmployee.Columns[7].Width = 150; // Address
                    dgvEmployee.Columns[8].Width = 150; // Description
                    dgvEmployee.Columns[9].Visible = false; // username
                    dgvEmployee.Columns[10].Visible = false; // password
                    dgvEmployee.Columns[11].Width = 50; // isStatus

                }
                else
                {
                    dgvEmployee.DataSource = null;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }
        // Fill data to DataGridView -- END
    }
}
