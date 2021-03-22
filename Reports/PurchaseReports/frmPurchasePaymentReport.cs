using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmeticShopApplication.Reports.PurchaseReports
{
    public partial class frmPurchasePaymentReport : Form
    {
        public frmPurchasePaymentReport(int SupplierPaymentID)
        {
            InitializeComponent();
            rptPurchasePayment rpt = new rptPurchasePayment();
            rpt.SetParameterValue("@SupplierPaymentID", SupplierPaymentID);
            crv.ReportSource = rpt;
        }

        private void frmPurchasePaymentReport_Load(object sender, EventArgs e)
        {

        }
    }
}
