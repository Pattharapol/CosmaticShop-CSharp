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
    public partial class frmAllPurchasePaymentHistory : Form
    {
        public frmAllPurchasePaymentHistory()
        {
            InitializeComponent();
            rptSupplierPurchaseWisePaymentReport rpt = new rptSupplierPurchaseWisePaymentReport();
            crv.ReportSource = rpt;
        }

        private void frmAllPurchasePaymentHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
