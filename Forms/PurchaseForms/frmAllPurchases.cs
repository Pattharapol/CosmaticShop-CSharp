using CosmeticShopApplication.Reports.PurchaseReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmeticShopApplication.Forms.PurchaseForms
{
    public partial class frmAllPurchases : Form
    {
        public frmAllPurchases()
        {
            InitializeComponent();
        }

        private void frmAllPurchases_Load(object sender, EventArgs e)
        {
            RetriveList(dtpFromDate.Value.ToString("yyyy/MM/dd"), dtpToDate.Value.ToString("yyyy/MM/dd"));
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            RetriveList(dtpFromDate.Value.ToString("yyyy-MM-dd"), dtpToDate.Value.ToString("yyyy-MM-dd"));
        }

        public void RetriveList(string fromDate, string toDate)
        {
            dgvAllPurchase.DataSource = null;
            string query = string.Format(@"SELECT [purchaseID] [ID],[supplierID] ,[Name] [Supplier],[ContactNo] [Contact No],[purchaseDate] [Purchase Date],[totalAmount] [Total Amount],[comments] ,[FullName] [Created by] FROM [dbo].[v_AllPurchases] WHERE purchaseDate > DATEADD(DAY, -1, '"+fromDate+"') AND purchaseDate < DATEADD(DAY, 1, '"+toDate+"') ");
            
            
            DataTable dt = CosmaticShopApplication.DatabasLayer.DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvAllPurchase.DataSource = dt;
                dgvAllPurchase.Columns[0].Width = 80; // purchaseid
                dgvAllPurchase.Columns[1].Visible = false; // supplierid
                dgvAllPurchase.Columns[2].Width = 150; // supplier
                dgvAllPurchase.Columns[3].Width = 80; // contactno
                dgvAllPurchase.Columns[4].Width = 100; // purchasedate
                dgvAllPurchase.Columns[5].Width = 120; // totalamount
                dgvAllPurchase.Columns[6].Width = 120; // Comments
                dgvAllPurchase.Columns[7].Width = 120; // Created By

            }
            else
            {
                dgvAllPurchase.DataSource = null;
            }
            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
            float totalamount = 0;
            if (dgvAllPurchase != null)
            {
                if (dgvAllPurchase.Rows.Count > 0)
                {
                    foreach (DataGridViewRow item in dgvAllPurchase.Rows)
                    {
                        float remainingBalance = 0;
                        float.TryParse(item.Cells[5].Value.ToString(), out remainingBalance);


                        totalamount = totalamount + remainingBalance;
                    }
                }
            }
            lblTotalAmount.Text = totalamount.ToString("0.00");
        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int purchaseid = 0;
                int.TryParse(dgvAllPurchase.CurrentRow.Cells[0].Value.ToString(), out purchaseid);
                frmPurchaseReport frm = new frmPurchaseReport(Convert.ToInt32(purchaseid));
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void purchaseReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                int purchaseid = 0;
                int.TryParse(dgvAllPurchase.CurrentRow.Cells[0].Value.ToString(), out purchaseid);
                frmPurchaseReport frm = new frmPurchaseReport(Convert.ToInt32(purchaseid));
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void paymentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllPurchase != null)
            {
                if (dgvAllPurchase.Rows.Count > 0)
                {
                    if (dgvAllPurchase.SelectedRows.Count == 1)
                    {
                        frmPurchasePaymentHistoryReport frm = new frmPurchasePaymentHistoryReport(Convert.ToInt32(dgvAllPurchase.CurrentRow.Cells[0].Value));
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please select one record!");
                    }
                }
                else
                {
                    MessageBox.Show("List is empty!");
                }
            }
        }
    }
}
