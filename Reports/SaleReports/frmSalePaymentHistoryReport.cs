using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmeticShopApplication.Reports.SaleReports
{
    public partial class frmSalePaymentHistoryReport : Form
    {
        public frmSalePaymentHistoryReport(int SaleID)
        {
            InitializeComponent();
            rptSalePaidList rpt = new rptSalePaidList();
            rpt.SetParameterValue("@SaleID", SaleID);
            crv.ReportSource = rpt;
        }

        private void frmSalePaymentHistoryReport_Load(object sender, EventArgs e)
        {

        }
    }
}
