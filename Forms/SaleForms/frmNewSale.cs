using CosmaticShopApplication.DatabasLayer;
using CosmaticShopApplication.SourceCode;
using CosmeticShopApplication.Forms.CustomerForms;
using CosmeticShopApplication.Reports.PurchaseReports;
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
    public partial class frmNewSale : Form
    {

        public string CustomerID = string.Empty;
        private string title = "C# dev by tik";

        public frmNewSale()
        {
            InitializeComponent();
        }

        private void frmNewSale_Load(object sender, EventArgs e)
        {
            ComboboxHelper.FillCategories(cmbCategory);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxHelper.FillProducts(cmbProduct, Convert.ToString(cmbCategory.SelectedValue));
        }

        private void GetProductDetails(string productid)
        {
            try
            {
                string query = string.Format(@"select qty, SaleUnitPrice, currentPurchasePrice from StockTable where ItemID = '" + productid.Trim() + "' ");
                DataTable dt = DatabaseAccess.Retrive(query);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        lblCurrentQty.Text = dt.Rows[0][0].ToString();
                        lblCurrentSaleUnitPrice.Text = dt.Rows[0][1].ToString();
                        txtSaleUnitPrice.Text = dt.Rows[0][1].ToString();
                        
                    }
                    else
                    {
                        lblCurrentQty.Text = "0";
                        lblCurrentSaleUnitPrice.Text = "0";
                        txtSaleUnitPrice.Text = "0";
                        
                    }
                }
            }
            catch (Exception ex)
            {
                lblCurrentQty.Text = "0";
                lblCurrentSaleUnitPrice.Text = "0";
                txtSaleUnitPrice.Text = "0";
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProductDetails(Convert.ToString(cmbProduct.SelectedValue));
        }

        private void btnSaleConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (string.IsNullOrEmpty(CustomerID))
                {
                    ep.SetError(txtSearch, "Please Search Customer");
                    txtSearch.Focus();
                    return;
                }

                int customerid = 0;
                int.TryParse(CustomerID, out customerid);
                if (customerid == 0)
                {
                    ep.SetError(txtSearch, "Please Search Customer");
                    txtSearch.Focus();
                    return;
                }

                if (lblCustomerName.Text.Trim().Length == 0)
                {
                    ep.SetError(lblCustomerName, "Please Search Customer");
                    lblCustomerName.Focus();
                    return;
                }

                if (dgvSaleCart == null)
                {
                    ep.SetError(btnADD, "Please Sale Some Products");
                    cmbProduct.Focus();
                    return;
                }

                if (dgvSaleCart.Rows.Count < 1)
                {
                    ep.SetError(btnADD, "Please Customer Some Products");
                    cmbProduct.Focus();
                    return;
                }

                if (dgvSaleCart.Rows.Count > 0)
                {
                    CalculateTotalAmount();
                    float totalamount = 0;
                    float.TryParse(lblTotalCost.Text.Trim(), out totalamount);
                    if (totalamount == 0)
                    {
                        ep.SetError(btnADD, "Please Purchase Some Products");
                        cmbProduct.Focus();
                        return;
                    }
                    string saleHeaderquery = string.Format(@"insert into saleTable (customerID, EmployeeID, saleDate, TotalAmount, Comments) values ('{0}', '{1}', '{2}', '{3}', '{4}')", customerid, UserInfo.EmployeeID, DateTime.Now.ToString("yyyy/MM/dd"), totalamount, txtComments.Text.Trim());
                    bool saleHeaderresult = DatabaseAccess.Insert(saleHeaderquery);
                    string saleid = string.Empty;
                    if (saleHeaderresult == true)
                    {
                        saleid = DatabaseAccess.Retrive("select max(saleID) from saleTable").Rows[0][0].ToString();
                        foreach (DataGridViewRow product in dgvSaleCart.Rows)
                        {
                            string productquery = string.Format(@"insert into saleDetailTable (saleID, itemID, Qty, unitPrice) values ('{0}', '{1}', '{2}', '{3}')", saleid, Convert.ToString(product.Cells[0].Value), Convert.ToString(product.Cells[4].Value), Convert.ToString(product.Cells[5].Value));
                            try
                            {
                                bool saledetailresult = DatabaseAccess.Insert(productquery);
                                if (saledetailresult == false)
                                {
                                    DeleteSale(saleid);
                                    MessageBox.Show("Un-Expected Issue is Occur Please Try-Again!!!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                string stockupdatequery = string.Format(@"update StockTable set Qty = Qty - '{0}', SaleUnitPrice = '{1}' where itemID = '{2}' ", Convert.ToString(product.Cells[3].Value), Convert.ToString(product.Cells[4].Value), Convert.ToString(product.Cells[0].Value));
                                DatabaseAccess.Update(stockupdatequery);
                            }
                            catch (Exception ex)
                            {
                                DeleteSale(saleid);
                                MessageBox.Show("Un-Expected Issue is Occur Please Try-Again!!!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        string message = "Sale is Confirmed...";
                        if (chkIsPaymentSucceed.Checked == true)
                        {
                            string paymentquery = string.Format(@"insert into customerPaymentTable (saleID, EmployeeID, paidDate, totalAmount, PaidAmount, BalanceAmount) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", saleid, UserInfo.EmployeeID, DateTime.Now.ToString("yyyy/MM/dd"), totalamount, totalamount, "0");
                            bool result = DatabaseAccess.Insert(paymentquery);
                            if (result == true)
                            {
                                message = message + " with Payment!";
                            }
                        }

                        frmSaleReport frm = new frmSaleReport(Convert.ToInt32(saleid));
                        frm.ShowDialog();
                        ResetForm();
                        CalculateTotalAmount();
                        txtComments.Text = "";
                        lblTotalCost.Text = "";
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Please Provide Sale Correct Details/ Re-Login!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                }
                else
                {
                    ep.SetError(btnADD, "Please Sale Some Products");
                    cmbProduct.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void CalculateItemCost()
        {
            try
            {
                int qty = 0;
                int.TryParse(txtSaleQty.Text.Trim(), out qty);

                float saleunitprice = 0;
                float.TryParse(txtSaleUnitPrice.Text.Trim(), out saleunitprice);

                lblItemCost.Text = (qty * saleunitprice).ToString();
            }
            catch (Exception)
            {
                lblItemCost.Text = "0";
            }
        }

        private void ClearProductGroup()
        {
            cmbProduct.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            txtSaleUnitPrice.Text = "0";
            lblCurrentSaleUnitPrice.Text = "0";
            lblCurrentQty.Text = "0";
        }

        private void EnableProductComponents()
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnADD.Visible = false;
            btnClear.Visible = false;
            dgvSaleCart.Enabled = false;
        }

        private void DisableProductComponents()
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnADD.Visible = true;
            btnClear.Visible = true;
            dgvSaleCart.Enabled = true;
            ClearProductGroup();
            GetProductDetails(Convert.ToString(cmbProduct.SelectedValue));
            CalculateTotalAmount();
        }

        private void ResetForm()
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnADD.Visible = true;
            btnClear.Visible = true;
            dgvSaleCart.Enabled = true;
            CustomerID = string.Empty;
            lblCustomerName.Text = "";
            lblContactNo.Text = "";
            chkIsPaymentSucceed.Checked = true;
            ClearProductGroup();
            GetProductDetails(Convert.ToString(cmbProduct.SelectedValue));
            CalculateTotalAmount();
            ClearProductGroup();
            dgvSaleCart.Rows.Clear();
        }

        private void CalculateTotalAmount()
        {
            try
            {
                if (dgvSaleCart != null)
                {
                    if (dgvSaleCart.Rows.Count > 0)
                    {
                        float totalamount = 0;
                        foreach (DataGridViewRow item in dgvSaleCart.Rows)
                        {
                            float amount = 0;
                            float.TryParse(item.Cells[6].Value.ToString(), out amount);
                            totalamount = totalamount + amount;
                        }

                        lblTotalCost.Text = totalamount.ToString();
                    }
                    else
                    {
                        lblTotalCost.Text = "0.00";
                    }
                }
                else
                {
                    lblTotalCost.Text = "0.00";
                }
            }
            catch
            {
                lblTotalCost.Text = "Error!";
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                frmSearchCustomer frm = new frmSearchCustomer(txtSearch.Text.Trim(), this);
                frm.ShowDialog();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            ep.Clear();

            if (cmbCategory.SelectedIndex == 0)
            {
                ep.SetError(cmbCategory, "Required missing field...");
                cmbCategory.Focus();
                return;
            }

            if (cmbProduct.SelectedIndex == 0)
            {
                ep.SetError(cmbProduct, "Required missing field...");
                cmbProduct.Focus();
                return;
            }

            string categoryid = (cmbCategory.SelectedValue).ToString();
            string categoryname = cmbCategory.Text;

            string productid = (cmbProduct.SelectedValue).ToString();
            string productname = cmbProduct.Text;

            int qty = 0;
            int.TryParse(txtSaleQty.Text.Trim(), out qty);
            
            float saleunitprice = 0;
            float.TryParse(txtSaleUnitPrice.Text.Trim(), out saleunitprice);

            float itemcost = 0;
            float.TryParse(lblItemCost.Text.Trim(), out itemcost);


            if (qty == 0)
            {
                ep.SetError(txtSaleQty, "Required missing field...");
                txtSaleQty.Focus();
                txtSaleQty.SelectAll();
                return;
            }
            

            if (saleunitprice == 0)
            {
                ep.SetError(txtSaleUnitPrice, "Required missing field...");
                txtSaleUnitPrice.Focus();
                txtSaleUnitPrice.SelectAll();
                return;
            }

            try
            {
                foreach (DataGridViewRow checkitem in dgvSaleCart.Rows)
                {
                    if (Convert.ToInt32(checkitem.Cells[0].Value.ToString()) == Convert.ToInt32(productid) &&
                        Convert.ToInt32(checkitem.Cells[2].Value.ToString()) == Convert.ToInt32(categoryid))
                    {
                        ep.SetError(cmbProduct, "Product Already in Purchase Cart!");
                        cmbProduct.Focus();
                        dgvSaleCart.ClearSelection();
                        checkitem.Selected = true;
                        return;
                    }
                }
            }
            catch (Exception)
            {

            }

            // Add data to DGV
            DataGridViewRow additem = new DataGridViewRow();
            additem.CreateCells(dgvSaleCart);
            additem.Cells[0].Value = productid;
            additem.Cells[1].Value = productname;
            additem.Cells[2].Value = categoryid;
            additem.Cells[3].Value = categoryname;
            additem.Cells[4].Value = qty;
            additem.Cells[5].Value = saleunitprice;
            additem.Cells[6].Value = lblItemCost.Text;
            dgvSaleCart.Rows.Add(additem);
            DisableProductComponents();
            txtSaleQty.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ep.Clear();

            if (cmbCategory.SelectedIndex == 0)
            {
                ep.SetError(cmbCategory, "Required missing field...");
                cmbCategory.Focus();
                return;
            }

            if (cmbProduct.SelectedIndex == 0)
            {
                ep.SetError(cmbProduct, "Required missing field...");
                cmbProduct.Focus();
                return;
            }

            string categoryid = (cmbCategory.SelectedValue).ToString();
            string categoryname = cmbCategory.Text;

            string productid = (cmbProduct.SelectedValue).ToString();
            string productname = cmbProduct.Text;

            int qty = 0;
            int.TryParse(txtSaleQty.Text.Trim(), out qty);

            float saleunitprice = 0;
            float.TryParse(txtSaleUnitPrice.Text.Trim(), out saleunitprice);

            float itemcost = 0;
            float.TryParse(lblItemCost.Text.Trim(), out itemcost);


            if (qty == 0)
            {
                ep.SetError(txtSaleQty, "Required missing field...");
                txtSaleQty.Focus();
                txtSaleQty.SelectAll();
                return;
            }

            if (saleunitprice == 0)
            {
                ep.SetError(txtSaleUnitPrice, "Required missing field...");
                txtSaleUnitPrice.Focus();
                txtSaleUnitPrice.SelectAll();
                return;
            }

            try
            {

            }
            catch (Exception)
            {

            }

            // Add data to DGV

            dgvSaleCart.CurrentRow.Cells[0].Value = productid;
            dgvSaleCart.CurrentRow.Cells[1].Value = productname;
            dgvSaleCart.CurrentRow.Cells[2].Value = categoryid;
            dgvSaleCart.CurrentRow.Cells[3].Value = categoryname;
            dgvSaleCart.CurrentRow.Cells[4].Value = qty;
            dgvSaleCart.CurrentRow.Cells[5].Value = saleunitprice;
            dgvSaleCart.CurrentRow.Cells[6].Value = lblItemCost.Text;
            DisableProductComponents();
        }

        private void DeleteSale(string saleid)
        {
            DataTable dt = DatabaseAccess.Retrive("select itemID, Qty from saleDetailTable where saleID = '" + saleid + "' ");
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    string stockupdatequery = string.Format(@"update StockTable set Qty = Qty + '{0}' where itemID = '{1}' ",
                        Convert.ToString(item[1]), Convert.ToString(item[0]));
                    DatabaseAccess.Update(stockupdatequery);
                }
            }

            string saledetailquery = string.Format(@"delete from saleDetailTable where saleID = '" + saleid + "' ");
            DatabaseAccess.Delete(saledetailquery);

            string purchaseheaderquery = string.Format(@"delete from saleTable where saleID = '" + saleid + "' ");
            DatabaseAccess.Delete(saledetailquery);

        }

        private void txtSaleQty_TextChanged(object sender, EventArgs e)
        {
            CalculateItemCost();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSaleCart != null)
                {
                    if (dgvSaleCart.Rows.Count > 0)
                    {
                        if (dgvSaleCart.SelectedRows.Count == 1)
                        {
                            DataGridViewRow currentrow = dgvSaleCart.CurrentRow;

                            cmbCategory.SelectedValue = Convert.ToInt32(currentrow.Cells[2].Value);
                            cmbProduct.SelectedValue = Convert.ToInt32(currentrow.Cells[0].Value);
                            txtSaleQty.Text = currentrow.Cells[4].Value.ToString();
                            txtSaleUnitPrice.Text = currentrow.Cells[5].Value.ToString();
                            lblItemCost.Text = currentrow.Cells[6].Value.ToString();
                            EnableProductComponents();
                        }
                        else
                        {
                            MessageBox.Show("Please select one record...", title);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Purchase Cart is Empty!!", title);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please try again...", title);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSaleCart != null)
                {
                    if (dgvSaleCart.Rows.Count > 0)
                    {
                        if (dgvSaleCart.SelectedRows.Count == 1)
                        {
                            if (MessageBox.Show("Are you sure You want to delete this?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                dgvSaleCart.Rows.Remove(dgvSaleCart.SelectedRows[0]);
                                CalculateTotalAmount();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select one record...", title);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Purchase Cart is Empty!!", title);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please try again...", title);
            }
        }
    }
}
