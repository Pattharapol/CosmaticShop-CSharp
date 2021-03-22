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
    public partial class frmSaleReport : Form
    {
        public frmSaleReport(int saleid)
        {
            InitializeComponent();
            rptSaleReport rpt = new rptSaleReport();
            rpt.SetParameterValue("@SaleID", saleid);
            crv.ReportSource = rpt;
        }

        private void frmSaleReport_Load(object sender, EventArgs e)
        {

        }
    }
}
