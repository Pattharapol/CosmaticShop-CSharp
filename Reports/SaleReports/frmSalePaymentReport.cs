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
    public partial class frmSalePaymentReport : Form
    {
        public frmSalePaymentReport(int CustomerPaymentID)
        {
            InitializeComponent();
            rptSalePayment rpt = new rptSalePayment();
            rpt.SetParameterValue("@CustomerPaymentID", CustomerPaymentID);
            crv.ReportSource = rpt;
        }

        private void frmSalePaymentReport_Load(object sender, EventArgs e)
        {

        }
    }
}
