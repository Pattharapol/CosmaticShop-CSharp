using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmeticShopApplication.Forms.CustomerForms
{
    public partial class frmAllCustomers : Form
    {
        public frmAllCustomers()
        {
            InitializeComponent();
        }

        private void frmAllCustomers_Load(object sender, EventArgs e)
        {
            RetriveAllCustomers(string.Empty);
        }

        private void RetriveAllCustomers(string searchvalue)
        {
            dgvCustomer.DataSource = null;
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select CustomerID [ID], Name [Customer], ContactNo [Contact], Address [Address], username [Created By], Description [Description] from v_CustomerList";
            }
            else
            {
                query = "select CustomerID [ID], Name [Customer], ContactNo [Contact], Address [Address], username [Created By], Description [Description] from v_CustomerList where Name like '%" + searchvalue.Trim() + "%' ";
            }

            DataTable dt = CosmaticShopApplication.DatabasLayer.DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvCustomer.DataSource = dt;
                dgvCustomer.Columns[0].Visible = false; // CustomerID
                dgvCustomer.Columns[1].Width = 200; // Name
                dgvCustomer.Columns[2].Width = 150; // ContactNo
                dgvCustomer.Columns[3].Width = 250; // Address
                dgvCustomer.Columns[4].Width = 130; // username
                dgvCustomer.Columns[5].Width = 250; // Description

            }
            else
            {
                dgvCustomer.DataSource = null;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveAllCustomers(txtSearch.Text.Trim());
        }
    }
}
