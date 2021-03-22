using CosmaticShopApplication.DatabasLayer;
using CosmaticShopApplication.SourceCode;
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
    public partial class frmSalePayment : Form
    {
        public string SaleID = string.Empty;
        public string TotalAmount = string.Empty;
        frmSalePaymentPending SalePaymentPendingForm;

        public frmSalePayment(string saleid, string RemainingBalance, string totalamount, frmSalePaymentPending FormSalePaymentPending)
        {
            InitializeComponent();
            lblRPB.Text = RemainingBalance;
            txtAmount.Text = RemainingBalance;
            lblRCB.Text = RemainingBalance;
            this.SaleID = saleid;
            this.TotalAmount = totalamount;
            this.SalePaymentPendingForm = FormSalePaymentPending;
        }

        private void frmSalePayment_Load(object sender, EventArgs e)
        {

        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float remainingBalance = 0;
                float.TryParse(lblRPB.Text.Trim(), out remainingBalance);

                float paidamount = 0;
                float.TryParse(txtAmount.Text.Trim(), out paidamount);

                lblRCB.Text = (remainingBalance - paidamount).ToString();
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

            float paidamount = 0;
            float.TryParse(txtAmount.Text.Trim(), out paidamount);

            float remainingCurrentBalance = (remainingBalance - paidamount);

            if (paidamount == 0)
            {
                ep.SetError(txtAmount, "Please Enter Paid Amount!");
                txtAmount.Focus();
                return;
            }

            if (remainingCurrentBalance < 0)
            {
                ep.SetError(txtAmount, "Paid Amount must be equal or less than Remaining Balance Payment!");
                txtAmount.Focus();
                return;
            }

            string paymentquery = string.Format(@"insert into customerPaymentTable (SaleID, EmployeeID, paidDate, TotalAmount, PaidAmount, BalanceAmount) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", SaleID, UserInfo.EmployeeID, DateTime.Now.ToString("yyyy/MM/dd"), TotalAmount, paidamount, remainingCurrentBalance);
            bool result = DatabaseAccess.Insert(paymentquery);
            if (result == true)
            {
                SalePaymentPendingForm.RetriveList(string.Empty);

                string salepaymentid = DatabaseAccess.Retrive("select max(customerPaymentID) from customerPaymentTable").Rows[0][0].ToString();
                frmSalePaymentReport frm = new frmSalePaymentReport(Convert.ToInt32(salepaymentid));
                frm.ShowDialog();

                MessageBox.Show("Amount Paid Succeed!!");
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
