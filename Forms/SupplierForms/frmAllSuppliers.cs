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
    public partial class frmAllSuppliers : Form
    {
        public frmAllSuppliers()
        {
            InitializeComponent();
        }

        private void frmAllSuppliers_Load(object sender, EventArgs e)
        {
            RetriveSuppliers(string.Empty);
        }

        private void RetriveSuppliers(string searchvalue)
        {
            dgvAllSupplier.DataSource = null;
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select SupplierID [ID], Name [Supplier], ContactNo [ContactNo], Address [Address], username [Created By], Description [Description] from v_SupplierList";
            }
            else
            {
                query = "select SupplierID [ID], Name [Supplier], ContactNo [ContactNo], Address [Address], username [Created By], Description [Description] from v_SupplierList where Name like '%" + searchvalue.Trim() + "%' ";
            }

            DataTable dt = CosmaticShopApplication.DatabasLayer.DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvAllSupplier.DataSource = dt;
                dgvAllSupplier.Columns[0].Visible = false; // SupplierID
                dgvAllSupplier.Columns[1].Width = 200; // Supplier
                dgvAllSupplier.Columns[2].Width = 150; // ContactNo
                dgvAllSupplier.Columns[3].Width = 250; // Address
                dgvAllSupplier.Columns[4].Width = 130; // username
                dgvAllSupplier.Columns[5].Width = 250; // Description

            }
            else
            {
                dgvAllSupplier.DataSource = null;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveSuppliers(txtSearch.Text.Trim());
        }
    }
}
