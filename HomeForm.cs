using CosmaticShopApplication.Forms;
using CosmaticShopApplication.Forms.EmployeeForms;
using CosmaticShopApplication.Forms.ExpenseForms;
using CosmaticShopApplication.Forms.StockForms;
using CosmaticShopApplication.Forms.UserForms;
using CosmeticShopApplication.Forms.StockForms;
using CosmeticShopApplication.Forms.SupplierForm;
using CosmeticShopApplication.Forms.CustomerForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CosmeticShopApplication.Forms.SupplierForms;
using CosmeticShopApplication.Forms.EmployeeForms;
using CosmeticShopApplication.Forms.PurchaseForms;
using CosmeticShopApplication.Forms.SaleForms;
using CosmeticShopApplication.Reports.PurchaseReports;

namespace CosmaticShopApplication
{
    public partial class HomeForm : Form
    {
        public StartUpForm StartUp;
        public frmExpense ExpenseForm;
        public HomeForm()
        {
            InitializeComponent();

            tChangeTime.Start();
            StartUp = new StartUpForm();
            StartUp.TopLevel = false;
            StartUp.Dock = DockStyle.Fill;
            panelParent.Controls.Add(StartUp);
            StartUp.Show();
            panelParent.AutoScroll = true;
        }

        public void Logout()
        {
            msHomeForm.Enabled = false;
            tsbtnAllExpense.Enabled = false;
            tsbtnNewExpense.Enabled = false;
            tsbtnNewPurchase.Enabled = false;
            tsbtnNewSale.Enabled = false;
            tsbtnOurchasePayment.Enabled = false;
            tsbtnReports.Enabled = false;
            tsbtnSalePayment.Enabled = false;
            tsbtnStock.Enabled = false;
            tsbtnLogin.Visible = true;
            tsbtnLogin.Enabled = true;
            tsbtnLogout.Enabled = false;
            tsbtnLogout.Visible = false;
        }

        public void Login()
        {
            msHomeForm.Enabled = true;
            tsbtnAllExpense.Enabled = true;
            tsbtnNewExpense.Enabled = true;
            tsbtnNewPurchase.Enabled = true;
            tsbtnNewSale.Enabled = true;
            tsbtnOurchasePayment.Enabled = true;
            tsbtnReports.Enabled = true;
            tsbtnSalePayment.Enabled = true;
            tsbtnStock.Enabled = true;
            tsbtnLogin.Visible = false;
            tsbtnLogin.Enabled = false;
            tsbtnLogout.Enabled = true;
            tsbtnLogout.Visible = true;
        }


        private void HomeForm_Load(object sender, EventArgs e)
        {
            Logout();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout();
            Application.Restart();
        }


        // Call frmUsertype
        private void userTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserType frm = new frmUserType();
            frm.ShowDialog();
        }

        private void employeeRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            //frm.ShowDialog();
            frm.TopLevel = false;
            panelParent.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreateUser user = new frmCreateUser();
            user.ShowDialog();
        }

        private void allUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllUser frm = new frmAllUser();
            frm.ShowDialog();
        }

        private void tChangeTime_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString("dd MMMM yyyy : hh:mm:ss tt");
        }

        private void tsbtnLogin_Click(object sender, EventArgs e)
        {
            frmUserLogin f = new frmUserLogin(this);
            f.ShowDialog();
        }

        private void tsmibtnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Logout();
        }

        private void tsmibtnChangePassword_Click(object sender, EventArgs e)
        {
            frmPasswordChange frm = new frmPasswordChange();
            frm.ShowDialog();
        }

        private void newCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory();
            frm.TopLevel = false;
            panelParent.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStock frm = new frmStock();
            frm.TopLevel = false;
            panelParent.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
            
        }

        private void expenseCategoryToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmExpenseCategory frm = new frmExpenseCategory();
            frm.ShowDialog();
        }

        private void newExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ExpenseForm == null)
            {
                ExpenseForm = new frmExpense();
            }
            ExpenseForm.TopLevel = false;
            panelParent.Controls.Add(ExpenseForm);
            ExpenseForm.BringToFront();
            ExpenseForm.Show();
        }

        private void allExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllExpense frm = new frmAllExpense();
            frm.TopLevel = false;
            panelParent.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void allStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllStock frm = new frmAllStock();
            frm.TopLevel = false;
            panelParent.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void newSupplierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSupplier frm = new frmSupplier();
            frm.TopLevel = false;
            panelParent.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CosmeticShopApplication.Forms.CustomerForms.Customers frm = new Customers();
            frm.TopLevel = false;
            panelParent.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void allSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllSuppliers frm = new frmAllSuppliers();
            frm.TopLevel = false;
            panelParent.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void allCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllCustomers frm = new frmAllCustomers();
            frm.TopLevel = false;
            panelParent.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void allEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllEmployees frm = new frmAllEmployees();
            frm.TopLevel = false;
            panelParent.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void newPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewPurchase frm = new frmNewPurchase();
            frm.TopLevel = false;
            panelParent.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void newSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewSale frm = new frmNewSale();
            frm.TopLevel = false;
            panelParent.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void allSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchasesPaymentPending frm = new frmPurchasesPaymentPending();
            frm.ShowDialog();
        }

        private void salePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalePaymentPending frm = new frmSalePaymentPending();
            frm.ShowDialog();
        }

        private void paymentHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllPurchasePaymentHistory frm = new frmAllPurchasePaymentHistory();
            frm.ShowDialog();
        }

        private void newSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllPurchases frm = new frmAllPurchases();
            frm.ShowDialog();
        }
    }
}
