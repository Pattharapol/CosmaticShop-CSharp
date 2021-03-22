using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmeticShopApplication.Forms.StockForms
{
    public partial class frmAllStock : Form
    {
        public frmAllStock()
        {
            InitializeComponent();
        }

        private void frmAllStock_Load(object sender, EventArgs e)
        {
            RetriveList(string.Empty);
        }


        private void RetriveList(string searchvalue)
        {
            dgvAllStock.DataSource = null;
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select itemID [ID], IsActive [Status], Name [Product], CategoryID, Category, Qty, CurrentPurchasePrice [Purchase Unit Price], SaleUnitPrice [Sale Unit Price], manuDate [Manu Date], expDate [Exp Date ], username [Created By] from v_StockList";
            }
            else
            {
                query = "select itemID [ID], IsActive [Status], Name [Product], CategoryID, Category, Qty, CurrentPurchasePrice [Purchase Unit Price], SaleUnitPrice [Sale Unit Price], manuDate [Manu Date], expDate [Exp Date ], username [Created By] from v_StockList where Name like '%" + searchvalue.Trim() + "%' ";
            }

            DataTable dt = CosmaticShopApplication.DatabasLayer.DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvAllStock.DataSource = dt;
                dgvAllStock.Columns[0].Visible = false; // itemID
                dgvAllStock.Columns[1].Width = 60; // IsActive
                dgvAllStock.Columns[2].Width = 150; // Name
                dgvAllStock.Columns[3].Visible = false; // CategoryID
                dgvAllStock.Columns[4].Width = 100; // Category
                dgvAllStock.Columns[5].Width = 80; // Qty
                dgvAllStock.Columns[6].Width = 130; // CurrentPurchasePrice
                dgvAllStock.Columns[7].Width = 130; // SaleUnitPrice
                dgvAllStock.Columns[8].Width = 120; // manuDate
                dgvAllStock.Columns[9].Width = 120; // expDate
                dgvAllStock.Columns[10].Width = 120; // username
            }
            else
            {
                dgvAllStock.DataSource = null;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
        }
    }
}
