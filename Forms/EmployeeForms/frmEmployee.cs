using CosmaticShopApplication.DatabasLayer;
using CosmaticShopApplication.SourceCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShopApplication.Forms.EmployeeForms
{
    public partial class frmEmployee : Form
    {
        private string title = "C# dev by TIK";

        public frmEmployee()
        {
            InitializeComponent();

            // Display data to cmbUserType 
            ComboboxHelper.FillUserType(cmbUserType);

            // set value to datagridview
            dgvEmployee.DataSource = null;
            dgvEmployee.ClearSelection();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            // Fill data to datagridview
            FillGrid(string.Empty);
        }


        // Fill data to DataGridView -- START
        private void FillGrid(string searchvalue)
        {
            dgvEmployee.DataSource = null;
            string query = "";
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select [employeeID] [ID], [FullName] [Full Name], [UserTypeID], [ContactNo] [Contact No],[Email] [Email],[CNIC] [CNIC],[Photo],[Address] [Address],[Description] [Description],[username],[password],[isStatus] [Status] from employeeTable";
            }
            else
            {
                query = "select [employeeID] [ID], [FullName] [Full Name], [UserTypeID], [ContactNo] [Contact No],[Email] [Email],[CNIC] [CNIC],[Photo],[Address] [Address],[Description] [Description],[username],[password],[isStatus] [Status] from employeeTable where FullName like '%" + searchvalue + "%' ";
            }

            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvEmployee.DataSource = dt;
                if (dt.Rows.Count > 0)
                {

                    dgvEmployee.Columns[0].Visible = false; // employeeID
                    dgvEmployee.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // FullName
                    dgvEmployee.Columns[2].Visible = false; // userTypeID
                    dgvEmployee.Columns[3].Width = 100; // contactNo
                    dgvEmployee.Columns[4].Width = 150; // Email
                    dgvEmployee.Columns[5].Width = 100; // CNIC
                    dgvEmployee.Columns[6].Visible = false; // Photo
                    dgvEmployee.Columns[7].Width = 150; // Address
                    dgvEmployee.Columns[8].Width = 150; // Description
                    dgvEmployee.Columns[9].Visible = false; // username
                    dgvEmployee.Columns[10].Visible = false; // password
                    dgvEmployee.Columns[11].Width = 50; // isStatus

                }
                else
                {
                    dgvEmployee.DataSource = null;
                }
            }
        }
        // Fill data to DataGridView -- END

        // Add Employee picture -- START
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // open folder to add picture
            ofd_EmployeePIC.Title = "Selct Photo Passport Size Photo";
            ofd_EmployeePIC.Filter = "Image Files (*.bmp; *.jpg; *.jpeg; *.png)|*.BMG; *.JPG; *.JPEG; *.PNG";
            if(ofd_EmployeePIC.ShowDialog() == DialogResult.OK)
            {
                picEMP.ImageLocation = ofd_EmployeePIC.FileName;
            }
        }
        // Add Employee picture -- END


        // Remove Employee picture -- START
        private void btnRemove_Click(object sender, EventArgs e)
        {
            picEMP.Image = null;
        }
        // Remove Employee picture -- END


        // CLearFormData -- START
        private void ClearFormData()
        {
            txtFullName.Clear();
            cmbUserType.SelectedIndex = 0;
            txtContactNo.Clear();
            txtEmail.Clear();
            txtCNIC.Clear();
            txtDescription.Clear();
            txtAddress.Clear();
            picEMP.Image = null;
            txtFullName.Focus();
        }
        // CLearFormData -- END


        // EnableComponents -- START
        private void EnableComponents()
        {
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
            dgvEmployee.Enabled = false;
            lblCancel.Visible = true;
        }
        // EnableComponents -- END

        // ResetComponents -- START
        private void ResetComponents()
        {
            btnSave.Enabled = true;
            btnClear.Enabled = true;
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
            dgvEmployee.Enabled = true;
            lblCancel.Visible = false;
            txtFullName.Focus();
        }
        // ResetComponents -- END



        // CLearFormData -- START
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFormData();
        }
        // CLearFormData -- END



        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetComponents();
        }


        // Save data to Database -- START
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtFullName.Text.Trim().Length == 0)
                {
                    ep.SetError(txtFullName, "Please Enter FullName...");
                    txtFullName.Focus();
                    return;
                }

                if (cmbUserType.SelectedIndex == 0)
                {
                    ep.SetError(cmbUserType, "Please Select Employee Type...");
                    cmbUserType.Focus();
                    return;
                }

                if (txtContactNo.Text.Trim().Length == 0)
                {
                    ep.SetError(txtContactNo, "Please Enter ContactNo...");
                    txtContactNo.Focus();
                    return;
                }

                if (txtEmail.Text.Trim().Length == 0)
                {
                    ep.SetError(txtEmail, "Please Enter Email Address...");
                    txtEmail.Focus();
                    return;
                }

                if (txtAddress.Text.Trim().Length == 0)
                {
                    ep.SetError(txtAddress, "Please Enter Employee Address...");
                    txtAddress.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Retrive(string.Format(@"select * from employeeTable where FullName = '{0}' and ContactNo = '{1}' ", txtFullName.Text.Trim(), txtContactNo.Text.Trim()));
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtFullName, txtFullName.Text + " is Already Registered!");
                        txtFullName.SelectAll();
                        txtFullName.Focus();
                        return;
                    }
                }

                string image64bit = string.Empty;
                if(picEMP.Image != null)
                {
                    image64bit = DatabaseAccess.ImageToBase64(picEMP.Image, System.Drawing.Imaging.ImageFormat.Png); // แปลงรูปเป็น string
                }


                string insertquery = string.Format(@"INSERT INTO [dbo].[employeeTable] ([FullName] ,[UserTypeID] ,[ContactNo] ,[Email] ,[CNIC] ,[Photo] ,[Address] ,[Description] ,[isStatus]) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}') ", 
                    txtFullName.Text.Trim(), cmbUserType.SelectedValue, txtContactNo.Text.Trim(), txtEmail.Text.Trim(), txtCNIC.Text.Trim(), image64bit, txtAddress.Text.Trim(), txtDescription.Text.Trim(), true);


                bool result = DatabaseAccess.Insert(insertquery);
                if (result == true)
                {
                    btnClear_Click(sender, e);
                    ResetComponents();
                    MessageBox.Show("Registered Successfully...", "C# dev by TIK");
                    FillGrid(string.Empty);
                }
                else
                {
                    MessageBox.Show("Registeration Failed, Please try again...", "C# dev by TIK");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Registeration Failed, Please try again...", "C# dev by TIK");
            }
        }
        // Save data to Database -- END

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployee != null)
            {
                if (dgvEmployee.Rows.Count > 0)
                {
                    if (dgvEmployee.SelectedRows.Count == 1)
                    {
                        //dgvEmployee.Columns[0].Visible = false; // employeeID
                        //dgvEmployee.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // FullName
                        //dgvEmployee.Columns[2].Visible = false; // userTypeID
                        //dgvEmployee.Columns[3].Width = 100; // contactNo
                        //dgvEmployee.Columns[4].Width = 150; // Email
                        //dgvEmployee.Columns[5].Width = 100; // CNIC
                        //dgvEmployee.Columns[6].Visible = false; // Photo
                        //dgvEmployee.Columns[7].Width = 150; // Address
                        //dgvEmployee.Columns[8].Width = 150; // Description
                        //dgvEmployee.Columns[9].Visible = false; // username
                        //dgvEmployee.Columns[10].Visible = false; // password
                        //dgvEmployee.Columns[11].Width = 50; // isStatus

                        txtFullName.Text = dgvEmployee.CurrentRow.Cells[1].Value.ToString();
                        cmbUserType.Text = dgvEmployee.CurrentRow.Cells[2].Value.ToString();
                        txtContactNo.Text = dgvEmployee.CurrentRow.Cells[3].Value.ToString();
                        txtEmail.Text = dgvEmployee.CurrentRow.Cells[4].Value.ToString();
                        txtCNIC.Text = dgvEmployee.CurrentRow.Cells[5].Value.ToString();
                        picEMP.Image = DatabaseAccess.Base64ToImage(dgvEmployee.CurrentRow.Cells[6].Value.ToString());// photo
                        txtAddress.Text = dgvEmployee.CurrentRow.Cells[7].Value.ToString();
                        txtDescription.Text = dgvEmployee.CurrentRow.Cells[8].Value.ToString();
                        
                        EnableComponents();
                    }
                    else
                    {
                        MessageBox.Show("Please select one record!", title);
                        ResetComponents();
                    }
                }
            }
        }



        // update data to database -- START
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtFullName.Text.Trim().Length == 0)
                {
                    ep.SetError(txtFullName, "Please Enter FullName...");
                    txtFullName.Focus();
                    return;
                }

                if (cmbUserType.SelectedIndex == 0)
                {
                    ep.SetError(cmbUserType, "Please Select Employee Type...");
                    cmbUserType.Focus();
                    return;
                }

                if (txtContactNo.Text.Trim().Length == 0)
                {
                    ep.SetError(txtContactNo, "Please Enter ContactNo...");
                    txtContactNo.Focus();
                    return;
                }

                if (txtEmail.Text.Trim().Length == 0)
                {
                    ep.SetError(txtEmail, "Please Enter Email Address...");
                    txtEmail.Focus();
                    return;
                }

                if (txtAddress.Text.Trim().Length == 0)
                {
                    ep.SetError(txtAddress, "Please Enter Employee Address...");
                    txtAddress.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Retrive(string.Format(@"select * from employeeTable where FullName = '{0}' and ContactNo = '{1}' and employeeID != '{2}' ", txtFullName.Text.Trim(), txtContactNo.Text.Trim(), dgvEmployee.CurrentRow.Cells[0].Value.ToString()));
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Update Failed, Please try again...", "C# dev by TIK");
                        return;
                    }
                }

                string image64bit = string.Empty;
                if (picEMP.Image != null)
                {
                    image64bit = DatabaseAccess.ImageToBase64(picEMP.Image, System.Drawing.Imaging.ImageFormat.Png); // แปลงรูปเป็น string
                }


                string updatequery = string.Format(@"update [dbo].[employeeTable] set fullname = '{0}', usertypeid = '{1}', contactno = '{2}', email = '{3}',  cnic = '{4}', photo = '{5}', address = '{6}', description = '{7}', isactive = '{8}' where employeeid = '{9}' ",
                    txtFullName.Text.Trim(), cmbUserType.SelectedValue, txtContactNo.Text.Trim(), txtEmail.Text.Trim(), txtCNIC.Text.Trim(), image64bit, txtAddress.Text.Trim(), txtDescription.Text.Trim(), true, dgvEmployee.CurrentRow.Cells[0].Value.ToString());


                bool result = DatabaseAccess.Update(updatequery);
                if (result == true)
                {
                    btnClear_Click(sender, e);
                    ResetComponents();
                    MessageBox.Show("Updated Successfully...", "C# dev by TIK");
                    FillGrid(string.Empty);
                }
                else
                {
                    MessageBox.Show("Update Failed, Please try again...", "C# dev by TIK");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Update Failed, Please try again...", "C# dev by TIK");
            }
        }
        // update data to database -- END


        // Search DGV -- START
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }// Search DGV -- END


        // If DGV has no rows ChangeStatus will not show -- START
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dgvEmployee.Rows.Count > 0)
                {
                    if (dgvEmployee.SelectedRows.Count == 1)
                    {
                        tsmiStatus.Visible = true;
                        bool status = Convert.ToBoolean(dgvEmployee.CurrentRow.Cells[11].Value);
                        if (status == false)
                        {
                            tsmiStatus.Text = "Active";
                        }
                        else
                        {
                            tsmiStatus.Text = "De-Active";
                        }
                    }
                    else
                    {
                        tsmiStatus.Visible = false;
                    }
                }
                else
                {
                    tsmiStatus.Visible = false;
                }
            }
            catch (Exception)
            {
                
            }
        }
        // If DGV has no rows ChangeStatus will not show -- END



        // update Status -- START
        private void tsmiStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployee.Rows.Count > 0)
                {
                    if (dgvEmployee.SelectedRows.Count == 1)
                    {
                        tsmiStatus.Visible = true;
                        bool changeStatus = false;
                        bool status = Convert.ToBoolean(dgvEmployee.CurrentRow.Cells[11].Value);
                        if (tsmiStatus.Text == "Active")
                        {
                            changeStatus = true;
                        }
                        else
                        {
                            changeStatus = false;
                        }

                        string changeStatusquery = string.Format(@"update employeetable set isStatus = '{0}' where employeeid = '{1}' ", changeStatus, dgvEmployee.CurrentRow.Cells[0].Value.ToString());

                        bool result = DatabaseAccess.Update(changeStatusquery);
                        if (result == true)
                        {
                            FillGrid(string.Empty);
                            MessageBox.Show("Status has been Changed!!", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                        else
                        {
                            MessageBox.Show("Please try again..!!", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select one record!!", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
            catch (Exception)
            {
                
            }
                
        }
        // update Status -- END

    }
}
