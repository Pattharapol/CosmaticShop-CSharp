using CosmeticShopApplication.Forms.SaleForms;
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
    public partial class frmSearchCustomer : Form
    {
        public frmNewSale NewSaleForm;
        public frmSearchCustomer(string searchvalue, frmNewSale FormNewSale)
        {
            InitializeComponent();
            NewSaleForm = FormNewSale;
            txtSearch.Text = searchvalue;
            RetriveCustomers(searchvalue);
        }

        private void frmSearchCustomer_Load(object sender, EventArgs e)
        {

        }

        private void RetriveCustomers(string searchvalue)
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
            RetriveCustomers(txtSearch.Text.Trim());
        }

        private void SelectCustomer()
        {
            if (NewSaleForm != null)
            {
                NewSaleForm.CustomerID = dgvCustomer.CurrentRow.Cells[0].Value.ToString();
                NewSaleForm.lblCustomerName.Text = dgvCustomer.CurrentRow.Cells[1].Value.ToString();
                NewSaleForm.lblContactNo.Text = dgvCustomer.CurrentRow.Cells[2].Value.ToString();
                this.Close();
            }
        }

        private void dgvCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvCustomer.Rows.Count > 0)
                {
                    if (dgvCustomer.SelectedRows.Count == 1)
                    {
                        SelectCustomer();
                    }
                    else
                    {
                        dgvCustomer.Rows[0].Selected = true;
                        SelectCustomer();
                    }
                }
            }
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCustomer != null)
            {
                if (dgvCustomer.Rows.Count > 0)
                {
                    if (dgvCustomer.SelectedRows.Count == 1)
                    {
                        SelectCustomer();
                    }
                    else
                    {
                        dgvCustomer.Rows[0].Selected = true;
                        SelectCustomer();
                    }
                }
            }
        }

        private void frmSearchCustomer_Activated(object sender, EventArgs e)
        {
            dgvCustomer.Focus();
        }
    }
}
