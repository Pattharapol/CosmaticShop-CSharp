using CosmeticShopApplication.Forms.PurchaseForms;
using CosmeticShopApplication.Reports.SaleReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmeticShopApplication.Forms.SaleForms
{
    public partial class frmSalePaymentPending : Form
    {
        public frmSalePaymentPending()
        {
            InitializeComponent();
        }

        private void frmSalePaymentPending_Load(object sender, EventArgs e)
        {
            RetriveList(string.Empty);
        }

        public void RetriveList(string searchvalue)
        {
            dgvSales.DataSource = null;
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select ST.saleID [ID], ST.CustomerID, CT.name [Customer], CT.contactno [Contact No], ST.saleDate [Sale Date], ST.totalamount [Total Amount], ISNULL(CPT.[PaidAmount],0) [PaidAmount], (ST.totalamount - ISNULL(CPT.[PaidAmount],0)) [Remaining Balance] from saleTable ST inner join customerTable CT on ST.CustomerID = CT.CustomerID left outer join (select saleID, sum(paidamount) [PaidAmount] from customerPaymentTable group by saleID) CPT on ST.saleID = CPT.saleID where ST.totalamount > ISNULL(CPT.[PaidAmount],0)";
            }
            else
            {
                query = "select ST.saleID [ID], ST.CustomerID, CT.name [Customer], CT.contactno [Contact No], ST.saleDate [Sale Date], ST.totalamount [Total Amount], ISNULL(CPT.[PaidAmount],0) [PaidAmount], (ST.totalamount - ISNULL(CPT.[PaidAmount],0)) [Remaining Balance] from saleTable ST inner join customerTable CT on ST.CustomerID = CT.CustomerID left outer join (select saleID, sum(paidamount) [PaidAmount] from customerPaymentTable group by saleID) CPT on ST.saleID = CPT.saleID where ST.totalamount > ISNULL(CPT.[PaidAmount],0) and (CT.name + ' ' + CT.contactno) like '%" + searchvalue.Trim() + "%' ";
            }

            DataTable dt = CosmaticShopApplication.DatabasLayer.DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvSales.DataSource = dt;
                dgvSales.Columns[0].Width = 80; // SaleID
                dgvSales.Columns[1].Visible = false; // CustomerID
                dgvSales.Columns[2].Width = 150; // Customer
                dgvSales.Columns[3].Width = 80; // contactno
                dgvSales.Columns[4].Width = 100; // SaleDate
                dgvSales.Columns[5].Width = 120; // totalamount
                dgvSales.Columns[6].Width = 120; // PaidAmount
                dgvSales.Columns[7].Width = 120; // Remain Balance

            }
            else
            {
                dgvSales.DataSource = null;
            }

            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
            float totalamount = 0;
            if (dgvSales != null)
            {
                if (dgvSales.Rows.Count > 0)
                {
                    foreach (DataGridViewRow item in dgvSales.Rows)
                    {
                        float remainingBalance = 0;
                        float.TryParse(item.Cells[7].Value.ToString(), out remainingBalance);

                        totalamount = totalamount + remainingBalance;
                    }
                }
            }
            lblTotalAmount.Text = totalamount.ToString();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSales != null)
            {
                if (dgvSales.Rows.Count > 0)
                {
                    if (dgvSales.SelectedRows.Count == 1)
                    {
                        frmSalePayment frm = new frmSalePayment(
                            dgvSales.CurrentRow.Cells[0].Value.ToString(), dgvSales.CurrentRow.Cells[7].Value.ToString(), dgvSales.CurrentRow.Cells[5].Value.ToString(), this);
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

        private void paymentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSales != null)
            {
                if (dgvSales.Rows.Count > 0)
                {
                    if (dgvSales.SelectedRows.Count == 1)
                    {
                        frmSalePaymentHistoryReport frm = new frmSalePaymentHistoryReport(Convert.ToInt32(dgvSales.CurrentRow.Cells[0].Value));
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
        }

        private void dgvSales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 7 || e.ColumnIndex == 5)
            {
                e.CellStyle.Format = "0.00";
            }
        }
    }
}
