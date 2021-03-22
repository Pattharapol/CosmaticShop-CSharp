using CosmaticShopApplication.DatabasLayer;
using CosmaticShopApplication.SourceCode;
using CosmeticShopApplication.Forms.SupplierForms;
using CosmeticShopApplication.Reports.PurchaseReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmeticShopApplication.Forms.PurchaseForms
{
    public partial class frmNewPurchase : Form
    {
        public string SupplierID = string.Empty;
        private string title = "C# dev by tik";
        public frmNewPurchase()
        {
            InitializeComponent();
        }

        private void frmNewPurchase_Load(object sender, EventArgs e)
        {
            ComboboxHelper.FillCategories(cmbCategory);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                frmSearchSupplier searchsupplier = new frmSearchSupplier(txtSearch.Text.Trim(), this);
                searchsupplier.ShowDialog();
            }
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
                        lblCurrentPurchaseUnitPrice.Text = dt.Rows[0][2].ToString();

                        txtSaleUnitPrice.Text = dt.Rows[0][1].ToString();
                        txtPurchaseUnitPrice.Text = dt.Rows[0][2].ToString();
                    }
                    else
                    {
                        lblCurrentQty.Text = "0";
                        lblCurrentSaleUnitPrice.Text = "0";
                        lblCurrentPurchaseUnitPrice.Text = "0";

                        txtSaleUnitPrice.Text = "0";
                        txtPurchaseUnitPrice.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                lblCurrentQty.Text = "0";
                lblCurrentSaleUnitPrice.Text = "0";
                lblCurrentPurchaseUnitPrice.Text = "0";

                txtSaleUnitPrice.Text = "0";
                txtPurchaseUnitPrice.Text = "0";
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProductDetails(Convert.ToString(cmbProduct.SelectedValue));
        }

        private void txtPurchaseQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPurchaseUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSaleUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CalculateItemCost()
        {
            try
            {
                int qty = 0;
                int.TryParse(txtPurchaseQty.Text.Trim(), out qty);

                float saleunitprice = 0;
                float.TryParse(txtPurchaseUnitPrice.Text.Trim(), out saleunitprice);

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
            txtPurchaseQty.Clear();
            txtPurchaseUnitPrice.Text = "0";
            txtSaleUnitPrice.Text = "0";
            lblCurrentPurchaseUnitPrice.Text = "0";
            lblCurrentSaleUnitPrice.Text = "0";
            lblCurrentQty.Text = "0";
        }

        private void EnableProductComponents()
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnADD.Visible = false;
            btnClear.Visible = false;
            dgvPurchaseCart.Enabled = false;
        }

        private void DisableProductComponents()
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnADD.Visible = true;
            btnClear.Visible = true;
            dgvPurchaseCart.Enabled = true;
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
            dgvPurchaseCart.Enabled = true;
            SupplierID = string.Empty;
            lblSupplierName.Text = "";
            lblContactNo.Text = "";
            chkIsPaymentSucceed.Checked = true;
            ClearProductGroup();
            GetProductDetails(Convert.ToString(cmbProduct.SelectedValue));
            CalculateTotalAmount();
            ClearProductGroup();
            dgvPurchaseCart.Rows.Clear();
        }

        private void txtPurchaseQty_TextChanged(object sender, EventArgs e)
        {
            CalculateItemCost();
        }

        private void txtPurchaseUnitPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateItemCost();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearProductGroup();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableProductComponents();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPurchaseCart != null)
                {
                    if (dgvPurchaseCart.Rows.Count > 0)
                    {
                        if (dgvPurchaseCart.SelectedRows.Count == 1)
                        {
                            if (MessageBox.Show("Are you sure You want to delete this?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                dgvPurchaseCart.Rows.Remove(dgvPurchaseCart.SelectedRows[0]);
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

        private void btnADD_Click(object sender, EventArgs e)
        {
            ep.Clear();

            if(cmbCategory.SelectedIndex == 0)
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
            int.TryParse(txtPurchaseQty.Text.Trim(), out qty);

            float purchasesunitprice = 0;
            float.TryParse(txtPurchaseUnitPrice.Text.Trim(), out purchasesunitprice);

            float saleunitprice = 0;
            float.TryParse(txtSaleUnitPrice.Text.Trim(), out saleunitprice);

            float itemcost = 0;
            float.TryParse(lblItemCost.Text.Trim(), out itemcost);


            if (qty == 0)
            {
                ep.SetError(txtPurchaseQty, "Required missing field...");
                txtPurchaseQty.Focus();
                txtPurchaseQty.SelectAll();
                return;
            }

            if (purchasesunitprice == 0)
            {
                ep.SetError(txtPurchaseUnitPrice, "Required missing field...");
                txtPurchaseUnitPrice.Focus();
                txtPurchaseUnitPrice.SelectAll();
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
                foreach (DataGridViewRow checkitem in dgvPurchaseCart.Rows)
                {
                    if (Convert.ToInt32(checkitem.Cells[0].Value.ToString()) == Convert.ToInt32(productid) &&
                        Convert.ToInt32(checkitem.Cells[2].Value.ToString()) == Convert.ToInt32(categoryid))
                    {
                        ep.SetError(cmbProduct, "Product Already in Purchase Cart!");
                        cmbProduct.Focus();
                        dgvPurchaseCart.ClearSelection();
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
            additem.CreateCells(dgvPurchaseCart);
            additem.Cells[0].Value = productid;
            additem.Cells[1].Value = productname;
            additem.Cells[2].Value = categoryid;
            additem.Cells[3].Value = categoryname;
            additem.Cells[4].Value = qty;
            additem.Cells[5].Value = purchasesunitprice;
            additem.Cells[6].Value = saleunitprice;
            additem.Cells[7].Value = lblItemCost.Text;
            dgvPurchaseCart.Rows.Add(additem);
            DisableProductComponents();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPurchaseCart != null)
                {
                    if (dgvPurchaseCart.Rows.Count > 0)
                    {
                        if (dgvPurchaseCart.SelectedRows.Count == 1)
                        {
                            DataGridViewRow currentrow = dgvPurchaseCart.CurrentRow;

                            cmbCategory.SelectedValue = Convert.ToInt32(currentrow.Cells[2].Value);
                            cmbProduct.SelectedValue = Convert.ToInt32(currentrow.Cells[0].Value);
                            txtPurchaseQty.Text = currentrow.Cells[4].Value.ToString();
                            txtPurchaseUnitPrice.Text = currentrow.Cells[5].Value.ToString();
                            txtSaleUnitPrice.Text = currentrow.Cells[6].Value.ToString();
                            lblItemCost.Text = currentrow.Cells[7].Value.ToString();
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

        private void CalculateTotalAmount()
        {
            try
            {
                if(dgvPurchaseCart != null)
                {
                    if (dgvPurchaseCart.Rows.Count > 0)
                    {
                        float totalamount = 0;
                        foreach(DataGridViewRow item in dgvPurchaseCart.Rows)
                        {
                            float amount = 0;
                            float.TryParse(item.Cells[7].Value.ToString(), out amount);
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
            int.TryParse(txtPurchaseQty.Text.Trim(), out qty);

            float purchasesunitprice = 0;
            float.TryParse(txtPurchaseUnitPrice.Text.Trim(), out purchasesunitprice);

            float saleunitprice = 0;
            float.TryParse(txtSaleUnitPrice.Text.Trim(), out saleunitprice);

            float itemcost = 0;
            float.TryParse(lblItemCost.Text.Trim(), out itemcost);


            if (qty == 0)
            {
                ep.SetError(txtPurchaseQty, "Required missing field...");
                txtPurchaseQty.Focus();
                txtPurchaseQty.SelectAll();
                return;
            }

            if (purchasesunitprice == 0)
            {
                ep.SetError(txtPurchaseUnitPrice, "Required missing field...");
                txtPurchaseUnitPrice.Focus();
                txtPurchaseUnitPrice.SelectAll();
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
            
            dgvPurchaseCart.CurrentRow.Cells[0].Value = productid;
            dgvPurchaseCart.CurrentRow.Cells[1].Value = productname;
            dgvPurchaseCart.CurrentRow.Cells[2].Value = categoryid;
            dgvPurchaseCart.CurrentRow.Cells[3].Value = categoryname;
            dgvPurchaseCart.CurrentRow.Cells[4].Value = qty;
            dgvPurchaseCart.CurrentRow.Cells[5].Value = purchasesunitprice;
            dgvPurchaseCart.CurrentRow.Cells[6].Value = saleunitprice;
            dgvPurchaseCart.CurrentRow.Cells[7].Value = lblItemCost.Text;
            DisableProductComponents();
        }

        private void btnPurchaseCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnPurchaseConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (string.IsNullOrEmpty(SupplierID))
                {
                    ep.SetError(txtSearch, "Please Search Supplier");
                    txtSearch.Focus();
                    return;
                }

                int supplierid = 0;
                int.TryParse(SupplierID, out supplierid);
                if (supplierid == 0)
                {
                    ep.SetError(txtSearch, "Please Search Supplier");
                    txtSearch.Focus();
                    return;
                }

                if (lblSupplierName.Text.Trim().Length == 0)
                {
                    ep.SetError(lblSupplierName, "Please Search Supplier");
                    lblSupplierName.Focus();
                    return;
                }

                if(dgvPurchaseCart == null)
                {
                    ep.SetError(btnADD, "Please Purchase Some Products");
                    cmbProduct.Focus();
                    return;
                }

                if (dgvPurchaseCart.Rows.Count < 1)
                {
                    ep.SetError(btnADD, "Please Purchase Some Products");
                    cmbProduct.Focus();
                    return;
                }

                if (dgvPurchaseCart.Rows.Count > 0)
                {
                    CalculateTotalAmount();
                    float totalamount = 0;
                    float.TryParse(lblTotalCost.Text.Trim(), out totalamount);
                    if(totalamount == 0)
                    {
                        ep.SetError(btnADD, "Please Purchase Some Products");
                        cmbProduct.Focus();
                        return;
                    }
                    string purchaseheaderquery = string.Format(@"insert into PurchaseTable (EmployeeID, SupplierID, PurchaseDate, TotalAmount, Comments) values ('{0}', '{1}', '{2}', '{3}', '{4}')", UserInfo.EmployeeID, supplierid, DateTime.Now.ToString("yyyy/MM/dd"), totalamount, txtComments.Text.Trim());
                    bool purchaseheaderresult = DatabaseAccess.Insert(purchaseheaderquery);
                    string purchaseid = string.Empty;
                    if(purchaseheaderresult == true)
                    {
                        purchaseid = DatabaseAccess.Retrive("select max(purchaseID) from PurchaseTable").Rows[0][0].ToString();
                        foreach(DataGridViewRow product in dgvPurchaseCart.Rows)
                        {
                            string productquery = string.Format(@"insert into purchaseDetailTable (purchaseID, itemID, Qty, unitPrice) values ('{0}', '{1}', '{2}', '{3}')", purchaseid, Convert.ToString(product.Cells[0].Value), Convert.ToString(product.Cells[4].Value), Convert.ToString(product.Cells[5].Value));
                            try
                            {
                                bool purchasedetailresult = DatabaseAccess.Insert(productquery);
                                if(purchasedetailresult == false)
                                {
                                    DeletePurchase(purchaseid);
                                    MessageBox.Show("Un-Expected Issue is Occur Please Try-Again!!!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                string stockupdatequery = string.Format(@"update StockTable set currentPurchasePrice = '{0}', Qty = Qty + '{1}', SaleUnitPrice = '{2}' where itemID = '{3}' ", Convert.ToString(product.Cells[5].Value), Convert.ToString(product.Cells[4].Value), Convert.ToString(product.Cells[6].Value), Convert.ToString(product.Cells[0].Value));
                                DatabaseAccess.Update(stockupdatequery);
                            }
                            catch(Exception ex)
                            {
                                DeletePurchase(purchaseid);
                                MessageBox.Show("Un-Expected Issue is Occur Please Try-Again!!!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        string message = "Purchase is Confirmed...";
                        if (chkIsPaymentSucceed.Checked == true)
                        {
                            string paymentquery = string.Format(@"insert into SupplierPaymentTable (PurchaseID, EmployeeID, PaymentDate, TotalAmount, PaidAmount, BalanceAmount) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", purchaseid, UserInfo.EmployeeID, DateTime.Now.ToString("yyyy/MM/dd"), totalamount, totalamount, "0");
                            bool result = DatabaseAccess.Insert(paymentquery);
                            if(result == true)
                            {
                                message = message + " with Payment!";
                            }
                        }

                        frmPurchaseReport frm = new frmPurchaseReport(Convert.ToInt32(purchaseid));
                        frm.ShowDialog();
                        ResetForm();
                        CalculateTotalAmount();
                        txtComments.Text = "";
                        lblTotalCost.Text = "";
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Please Provide Purchase Correct Details/ Re-Login!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                }
                else
                {
                    ep.SetError(btnADD, "Please Purchase Some Products");
                    cmbProduct.Focus();
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeletePurchase(string purchaseid)
        {
            DataTable dt = DatabaseAccess.Retrive("select itemID, Qty from purchaseDetailTable where purchaseID = '" + purchaseid + "' ");
            if(dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    string stockupdatequery = string.Format(@"update StockTable set Qty = Qty - '{0}' where itemID = '{1}' ", 
                        Convert.ToString(item[1]), Convert.ToString(item[0]));
                    DatabaseAccess.Update(stockupdatequery);
                }
            }

            string purchasedetailquery = string.Format(@"delete from purchaseDetailTable where purchaseID = '"+purchaseid+"' ");
            DatabaseAccess.Delete(purchasedetailquery);
            
            string purchaseheaderquery = string.Format(@"delete from PurchaseTable where purchaseID = '" + purchaseid + "' ");
            DatabaseAccess.Delete(purchasedetailquery);

        }
    }
}
