using CosmaticShopApplication.DatabasLayer;
using CosmaticShopApplication.SourceCode;
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
    public partial class frmPurchasePayment : Form
    {
        public string PurchaseID = string.Empty;
        public string TotalAmount = string.Empty;
        frmPurchasesPaymentPending PurchasePaymentPendingForm;

        public frmPurchasePayment(string purchaseid, string RemainingBalance, string totalamount, frmPurchasesPaymentPending FormPurchasePaymentPending)
        {
            InitializeComponent();
            lblRPB.Text = RemainingBalance;
            txtPayment.Text = RemainingBalance;
            lblRCB.Text = RemainingBalance;
            this.PurchaseID = purchaseid;
            this.TotalAmount = totalamount;
            this.PurchasePaymentPendingForm = FormPurchasePaymentPending;
        }

        private void frmPurchasePayment_Load(object sender, EventArgs e)
        {

        }

        private void txtPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float remainingBalance = 0;
                float.TryParse(lblRPB.Text.Trim(), out remainingBalance);

                float payment = 0;
                float.TryParse(txtPayment.Text.Trim(), out payment);

                lblRCB.Text = (remainingBalance - payment).ToString();
            }
            catch (Exception ex)
            {
                lblRCB.Text = "0";
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            ep.Clear();

            float remainingBalance = 0;
            float.TryParse(lblRPB.Text.Trim(), out remainingBalance);

            float payment = 0;
            float.TryParse(txtPayment.Text.Trim(), out payment);

            float remainingCurrentBalance = (remainingBalance - payment);

            if(payment == 0)
            {
                ep.SetError(txtPayment, "Please Enter Payment Amount!");
                txtPayment.Focus();
                return;
            }

            if (remainingCurrentBalance < 0)
            {
                ep.SetError(txtPayment, "Payment Amount must be equal or less than Remaining Balance Payment!");
                txtPayment.Focus();
                return;
            }

            string paymentquery = string.Format(@"insert into SupplierPaymentTable (PurchaseID, EmployeeID, PaymentDate, TotalAmount, PaidAmount, BalanceAmount) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", PurchaseID, UserInfo.EmployeeID, DateTime.Now.ToString("yyyy/MM/dd"), TotalAmount, payment, remainingCurrentBalance);
            bool result = DatabaseAccess.Insert(paymentquery);
            if (result == true)
            {
                PurchasePaymentPendingForm.RetriveList(string.Empty);

                string purchasepaymentid = DatabaseAccess.Retrive("select max(supplierPaymentID) from supplierPaymentTable").Rows[0][0].ToString();
                frmPurchasePaymentReport frm = new frmPurchasePaymentReport(Convert.ToInt32(purchasepaymentid));
                frm.ShowDialog();

                MessageBox.Show("Payment Succeed!!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Provide Correct Details and Try Again!!!");
                return;
            }
        }
    }
}
