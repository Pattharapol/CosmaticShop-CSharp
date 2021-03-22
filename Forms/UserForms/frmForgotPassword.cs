using System;
using System.Data;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace CosmaticShopApplication.Forms.UserForms
{
    public partial class frmForgotPassword : Form
    {
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if(txtEmailAddress.Text.Trim().Length == 0)
            {
                ep.SetError(txtEmailAddress, "Required missing field...");
                txtEmailAddress.Focus();
                return;
            }
            string message = ForgotPassword(txtEmailAddress.Text.Trim());
            MessageBox.Show("Email has been send successfully, Please Check Your Email...", "C# dev by tik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private string ForgotPassword(string email)
        {
            string message = string.Empty;
            try
            {
                DataTable dt = DatabasLayer.DatabaseAccess.Retrive(string.Format(@"select top 1 UserName, Password from employeetable where Email = '{0}' ", email.Trim()));
                if (dt != null)
                {
                    string receiver = email;
                    string subject = "Password Recovery, C# dev by TIK";

                    var senderEmail = new MailAddress("std.61322420115@ubru.ac.th", "Cosmatic Shop Recovery Password");
                    var receiverEmail = new MailAddress(receiver, "User");
                    var password = "1320700050600";
                    var sub = dt.Rows[0][0].ToString() + " Login Details, C# dev by tik";
                    var body = "Here's your Details..."+Environment.NewLine+"User Name : " + dt.Rows[0][0].ToString() + " \n Password : " + dt.Rows[0][1].ToString() + " \n This is Auto Send Email Testing Only" + Environment.NewLine +
                        "For Recovery UserName and Password" + Environment.NewLine +
                        "Thank you for your supported";
                    var smtp = new SmtpClient   // Allow user to send email using simple mail transfer protocol (SMTP)
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,   // secure socket layer to encrypts
                        DeliveryMethod = SmtpDeliveryMethod.Network,  // this email send through network 
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };

                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    };

                    message = "Login Details Send Successfully, Please Check Your Email..!";
                    
                }
                else
                {
                    message = "Please Enter Valid Email Address..!!";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //message = "Please Check Internet Connection, Please Try Again..!!";
            }
            return message;
        }

        private void txtEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSendEmail_Click(sender, e);
            }
        }
    }
}
