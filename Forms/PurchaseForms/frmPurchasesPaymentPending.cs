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
    public partial class frmPurchasesPaymentPending : Form
    {
        public frmPurchasesPaymentPending()
        {
            InitializeComponent();
        }

        private void frmPurchasesPaymentPending_Load(object sender, EventArgs e)
        {
            RetriveList(string.Empty);
        }

        public void RetriveList(string searchvalue)
        {
            dgvSupplier.DataSource = null;
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select pt.purchaseid [ID], pt.supplierid, st.name [Supplier], st.contactno [Contact No], pt.purchasedate [Purchase Date], pt.totalamount [Total Amount], ISNULL(spt.[PaidAmount],0) [PaidAmount], (pt.totalamount - ISNULL(spt.[PaidAmount],0)) [Remaining Balance] from purchaseTable pt inner join SupplierTable st on pt.supplierid = st.supplierid left outer join (select purchaseid, sum(paidamount) [PaidAmount] from supplierPaymentTable group by PurchaseID) spt on pt.purchaseid = spt.purchaseid where pt.totalamount > ISNULL(spt.[PaidAmount],0)";
            }
            else
            {
                query = "select pt.purchaseid [ID], pt.supplierid, st.name [Supplier], st.contactno [Contact No], pt.purchasedate [Purchase Date], pt.totalamount [Total Amount], ISNULL(spt.[PaidAmount],0) [PaidAmount], (pt.totalamount - ISNULL(spt.[PaidAmount],0)) [Remaining Balance] from purchaseTable pt inner join SupplierTable st on pt.supplierid = st.supplierid left outer join (select purchaseid, sum(paidamount) [PaidAmount] from supplierPaymentTable group by PurchaseID) spt on pt.purchaseid = spt.purchaseid where pt.totalamount > ISNULL(spt.[PaidAmount],0) and (st.name + ' ' + st.contactno) like '%" + searchvalue.Trim()+"%' ";
            }

            DataTable dt = CosmaticShopApplication.DatabasLayer.DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvSupplier.DataSource = dt;
                dgvSupplier.Columns[0].Width = 80; // purchaseid
                dgvSupplier.Columns[1].Visible = false; // supplierid
                dgvSupplier.Columns[2].Width = 150; // supplier
                dgvSupplier.Columns[3].Width = 80; // contactno
                dgvSupplier.Columns[4].Width = 100; // purchasedate
                dgvSupplier.Columns[5].Width = 120; // totalamount
                dgvSupplier.Columns[6].Width = 120; // PaidAmount
                dgvSupplier.Columns[7].Width = 120; // Remain Balance

            }
            else
            {
                dgvSupplier.DataSource = null;
            }
            CalculateTotalAmount();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
        }

        private void CalculateTotalAmount()
        {
            float totalamount = 0;
            if(dgvSupplier != null)
            {
                if(dgvSupplier.Rows.Count > 0)
                {
                    foreach (DataGridViewRow item in dgvSupplier.Rows)
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
            if (dgvSupplier != null)
            {
                if (dgvSupplier.Rows.Count > 0)
                {
                    if(dgvSupplier.SelectedRows.Count == 1)
                    {
                        frmPurchasePayment frm = new frmPurchasePayment(
                            dgvSupplier.CurrentRow.Cells[0].Value.ToString(), dgvSupplier.CurrentRow.Cells[7].Value.ToString(), dgvSupplier.CurrentRow.Cells[5].Value.ToString(), this);
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
            if (dgvSupplier != null)
            {
                if (dgvSupplier.Rows.Count > 0)
                {
                    if (dgvSupplier.SelectedRows.Count == 1)
                    {
                        frmPurchasePaymentHistoryReport frm = new frmPurchasePaymentHistoryReport(Convert.ToInt32(dgvSupplier.CurrentRow.Cells[0].Value));
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
