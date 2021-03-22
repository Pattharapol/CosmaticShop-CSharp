using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShopApplication.Forms.ExpenseForms
{
    public partial class frmAllExpense : Form
    {
        public frmAllExpense()
        {
            InitializeComponent();
        }

        private void frmAllExpense_Load(object sender, EventArgs e)
        {
            RetriveAllExpense(string.Empty);
        }


        private void RetriveAllExpense(string searchvalue)
        {
            dgvAllExpense.DataSource = null;
            string query = string.Empty;
            string totalcostquery = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select expenseID [ID], title [Expenses], expCategoryID, Name [Category], ExpDate [Date], totalCost [Cost], reason, comments, username [Created By] from v_AllExpenses where ExpDate > DATEADD(day, -1, '"+dtpFromDate.Value.ToString("yyyy/MM/dd")+ " 23:59') and ExpDate < DATEADD(day, 1, '" + dtpToDate.Value.ToString("yyyy/MM/dd")+ " 23:59') ";
                totalcostquery = "select  SUM(totalCost) from v_AllExpenses where ExpDate > DATEADD(day, -1, '" + dtpFromDate.Value.ToString("yyyy/MM/dd") + " 23:59') and ExpDate < DATEADD(day, 1, '" + dtpToDate.Value.ToString("yyyy/MM/dd") + " 23:59') ";
            }
            else
            {
                query = "select expenseID [ID], title [Expenses], expCategoryID, Name [Category], ExpDate [Date], totalCost [Cost], reason, comments, username [Created By] from v_AllExpenses where title like '%" + searchvalue + "%' or Name like '%" + searchvalue + "%' or username like '%" + searchvalue + "%' and ExpDate > DATEADD(day, -1, '" + dtpFromDate.Value.ToString("yyyy/MM/dd") + " 23:59') and ExpDate < DATEADD(day, 1, '" + dtpToDate.Value.ToString("yyyy/MM/dd") + " 23:59') ";
                totalcostquery = "select  SUM(totalCost) from v_AllExpenses where title like '%" + searchvalue + "%' or Name like '%" + searchvalue + "%' or username like '%" + searchvalue + "%' and ExpDate > DATEADD(day, -1, '" + dtpFromDate.Value.ToString("yyyy/MM/dd") + " 23:59') and ExpDate < DATEADD(day, 1, '" + dtpToDate.Value.ToString("yyyy/MM/dd") + " 23:59') ";

            }

            DataTable dt = DatabasLayer.DatabaseAccess.Retrive(query);
            DataTable totalcostdt = DatabasLayer.DatabaseAccess.Retrive(totalcostquery);
            if (dt != null)
            {
                dgvAllExpense.DataSource = dt;
                dgvAllExpense.Columns[0].Visible = false; // expenseID
                dgvAllExpense.Columns[1].Width = 150; // title Expenses
                dgvAllExpense.Columns[2].Visible = false; // expCategoryID
                dgvAllExpense.Columns[3].Width = 150; // Category
                dgvAllExpense.Columns[4].Width = 150; // date
                dgvAllExpense.Columns[5].Width = 80; // totalcost
                dgvAllExpense.Columns[6].Width = 200; // reason
                dgvAllExpense.Columns[7].Width = 200; // comments
                dgvAllExpense.Columns[8].Width = 130; // username
            }
            else
            {
                dgvAllExpense.DataSource = null;
            }

            double totalcost = 0;
            if (totalcostdt != null)
            {
                double.TryParse(totalcostdt.Rows[0][0].ToString(), out totalcost);
                lblTotalCost.Text = totalcost == 0 ? "0.00 Bath" : totalcost.ToString("0.00") + " Bath";
            }
            else
            {
                lblTotalCost.Text = "0.00 Bath";
            }
            

            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveAllExpense(txtSearch.Text.Trim());
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            RetriveAllExpense(txtSearch.Text.Trim());
        }
    }
}
