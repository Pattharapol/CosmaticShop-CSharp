using CosmeticShopApplication.Forms.PurchaseForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmeticShopApplication.Forms.SupplierForms
{
    public partial class frmSearchSupplier : Form
    {
        frmNewPurchase NewPurchaseForm;
        public frmSearchSupplier(string value, frmNewPurchase NewPurchase)
        {
            InitializeComponent();
            NewPurchaseForm = NewPurchase;
            txtSearch.Text = value;
            
        }

        private void frmSearchSupplier_Load(object sender, EventArgs e)
        {
            RetriveSuppliers(txtSearch.Text.Trim());
        }

        private void RetriveSuppliers(string searchvalue)
        {
            dgvSupplier.DataSource = null;
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select SupplierID [ID], Name [Supplier], ContactNo [ContactNo], Address [Address], username [Created By], Description [Description] from v_SupplierList";
            }
            else
            {
                query = "select SupplierID [ID], Name [Supplier], ContactNo [ContactNo], Address [Address], username [Created By], Description [Description] from v_SupplierList where Name like '%" + searchvalue.Trim() + "%' or ContactNo like '%" + searchvalue.Trim() + "%' or Address like '%" + searchvalue.Trim() + "%' or username like '%" + searchvalue.Trim() + "%' ";
            }

            DataTable dt = CosmaticShopApplication.DatabasLayer.DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvSupplier.DataSource = dt;
                dgvSupplier.Columns[0].Visible = false; // SupplierID
                dgvSupplier.Columns[1].Width = 200; // SupplierName
                dgvSupplier.Columns[2].Width = 150; // ContactNo
                dgvSupplier.Columns[3].Width = 250; // Address
                dgvSupplier.Columns[4].Width = 130; // username
                dgvSupplier.Columns[5].Width = 250; // Description

            }
            else
            {
                dgvSupplier.DataSource = null;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveSuppliers(txtSearch.Text.Trim());
        }

        private void frmSearchSupplier_Activated(object sender, EventArgs e)
        {
            dgvSupplier.Focus();
        }

        private void dgvSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(dgvSupplier.Rows.Count > 0)
                {
                    if(dgvSupplier.SelectedRows.Count == 1)
                    {
                        SelectSupplier();
                    }
                    else
                    {
                        dgvSupplier.Rows[0].Selected = true;
                        SelectSupplier();
                    }
                }
            }
        }

        private void SelectSupplier()
        {
            if (NewPurchaseForm != null)
            {
                NewPurchaseForm.SupplierID = dgvSupplier.CurrentRow.Cells[0].Value.ToString();
                NewPurchaseForm.lblSupplierName.Text = dgvSupplier.CurrentRow.Cells[1].Value.ToString();
                NewPurchaseForm.lblContactNo.Text = dgvSupplier.CurrentRow.Cells[2].Value.ToString();
                this.Close();
            }
        }
    }
}
