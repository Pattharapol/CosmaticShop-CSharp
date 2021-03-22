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
    public partial class frmPurchasePaymentHistoryReport : Form
    {
        public frmPurchasePaymentHistoryReport(int PurchaseID)
        {
            InitializeComponent();
            rptPurchasesPaymentList rpt = new rptPurchasesPaymentList();
            rpt.SetParameterValue("@PurchaseID", PurchaseID);
            crv.ReportSource = rpt;
        }

        private void frmPurchasePaymentHistoryReport_Load(object sender, EventArgs e)
        {

        }
    }
}
