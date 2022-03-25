using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Tour
{
    public partial class forgotpass : Form
    {
        string randomcode;
        public static string to;
        System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
        public forgotpass()
        {
            InitializeComponent();
            emailtxb.ForeColor = Color.LightGray;
            emailtxb.Text = "Enter Your Email";
            this.emailtxb.Leave += new System.EventHandler(this.textBox1_Leave);
            this.emailtxb.Enter += new System.EventHandler(this.textBox1_Enter);
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (emailtxb.Text == "")
            {
                emailtxb.ForeColor = Color.LightGray;
                emailtxb.Text = "Enter Your Email";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (emailtxb.Text == "Enter Your Email")
            {
                emailtxb.Text = "";
                emailtxb.ForeColor = Color.Black;
            }
        }
        private void sendbtn_Click(object sender, EventArgs e)
        {
            string query = "Select * from User Where Email ='" + emailtxb.Text.Trim() + "'";

            Cassandra.RowSet row = DataConnection.Ins.session.Execute(query);

            if (row.FirstOrDefault() != null)
            {
                string from, pass, messageBody;
                Random random = new Random();
                randomcode = (random.Next(100000, 999999)).ToString();
                MailMessage message = new MailMessage();
                to = (emailtxb.Text).ToString();
                from = "PTS.UIT.Group@gmail.com";
                pass = "PTS@uitGroup";
                messageBody = "Your reset account code:" + randomcode;
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = messageBody;
                message.Subject = "Password reseting code";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                try
                {
                    smtp.Send(message);
                    MessageBox.Show("Code send success!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Wrong Gmail.Try Again!!!!");
            }
        }

        private void verifybtn_Click(object sender, EventArgs e)
        {
            if (randomcode == (codetxb.Text).ToString())
            {
                to = emailtxb.Text;
                ChangePass change = new ChangePass();
                this.Close();
                change.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong reset Code!!!!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoginForm change = new LoginForm();
            this.Hide();
            change.ShowDialog();
            this.Show();
        }

        private void emailtxb_Validated(object sender, EventArgs e)
        {
            if (emailtxb.Text.Length > 0)
            {
                if (!rEMail.IsMatch(emailtxb.Text))
                {
                    MessageBox.Show("Invalidate Email", "Error");
                    emailtxb.SelectAll();
                    sendbtn.Enabled = false;
                    //e.Cancel = true;
                }
                else
                {
                    sendbtn.Enabled = true;
                }
            }
        }
    }
}
