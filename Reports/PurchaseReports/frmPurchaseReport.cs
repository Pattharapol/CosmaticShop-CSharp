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
    public partial class frmPurchaseReport : Form
    {
        public frmPurchaseReport(int purchaseid)
        {
            InitializeComponent();
            rtpPurchaseReport rpt = new rtpPurchaseReport();
            rpt.SetParameterValue("@PurchaseID", purchaseid);
            crv.ReportSource = rpt;
        }

        private void frmPurchaseReport_Load(object sender, EventArgs e)
        {

        }
    }
}
