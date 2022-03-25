using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;

namespace Tour
{
    public partial class RegisterAccount : Form
    {
        string randomcode;
        public static string to;
        System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
        public RegisterAccount()
        {
            InitializeComponent();
        }

        bool CheckDuplicateEmail(string email)
        {
            string query = "select * from User where Email='" + email + "'";
            Cassandra.RowSet row = DataConnection.Ins.session.Execute(query);

            if (row.FirstOrDefault() != null)
                return false;
            return true;
        }

        private void SignUpbtn_Click(object sender, EventArgs e)
        {
            var sql = DataConnection.Ins.session.Prepare("Insert into User(Ho,Ten,SDT,Email,Password) values(?,?,?,?,?)");
            
            if (CheckDuplicateEmail(txbGmail.Text) == false)
            {
                MessageBox.Show("Your Email is already in use");
            }
            else if (txbGmail.Text == "" || txbHo.Text == "" || txbTen.Text == "" || txbSDT.Text == "" )
            {
                MessageBox.Show("Please enter FULL INFORMATION!!!");
            }
            else if (txbPass.Text == "")
                MessageBox.Show("Please Enter Password!!!");
            else if (txbConfirm.Text != txbPass.Text)
                MessageBox.Show("Password not match!!!");
            else if (randomcode != txbCode.Text.ToString() || txbGmail.Text.ToString() != email)
            {
                MessageBox.Show("Code Box is wrong or empty!!!");
            }
            else
            {
                var query = sql.Bind(txbHo.Text.Trim(), txbTen.Text.Trim(), txbSDT.Text.Trim(), email, LoginForm.Encrypt(txbPass.Text.Trim()));
                DataConnection.Ins.session.Execute(query);

                label12.Text = "Checked";
                label12.ForeColor = Color.Green;
                SignUpbtn.Enabled = true;

                MessageBox.Show("SignUp success!!!");
                Clear();
            }
        }
        void Clear()
        {
            txbHo.Text = txbTen.Text = txbSDT.Text = txbGmail.Text = txbPass.Text = txbConfirm.Text = "";
        }

        private void txbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        string email;
        private void txbGmail_Validating(object sender, CancelEventArgs e)
        {
            if (txbGmail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txbGmail.Text))
                {
                    MessageBox.Show("Invalidate Email", "Error");
                    txbGmail.SelectAll();
                    SignUpbtn.Enabled = false;
                    //e.Cancel = true;
                }
                else
                {
                    SignUpbtn.Enabled = true;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txbGmail.Text.Length > 0)
            {
                if (rEMail.IsMatch(txbGmail.Text))
                {
                    email = txbGmail.Text.ToString();
                    string from, pass, messageBody;
                    Random random = new Random();
                    randomcode = (random.Next(100000, 999999)).ToString();
                    MailMessage message = new MailMessage();
                    to = (txbGmail.Text).ToString();
                    from = "PTS.UIT.Group@gmail.com";
                    pass = "PTS@uitGroup";
                    messageBody = "Verification code exists for your email :" + randomcode;
                    message.To.Add(to);
                    message.From = new MailAddress(from);
                    message.Body = messageBody;
                    message.Subject = "Confirm Email Code";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    try
                    {
                        smtp.Send(message);
                        MessageBox.Show("Code send success!!!");
                        label12.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void txbGmail_TextChanged(object sender, EventArgs e)
        {
            txbCode.Text = "";
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
