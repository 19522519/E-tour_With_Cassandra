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
using System.Threading;
namespace Tour
{
    public partial class LoginForm : Form
    {

        System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
        public LoginForm()
        {
            InitializeComponent();
            emailtxb.ForeColor = Color.LightGray;
            emailtxb.Text = "Email";
            this.emailtxb.Leave += new System.EventHandler(this.textBox1_Leave);
            this.emailtxb.Enter += new System.EventHandler(this.textBox1_Enter);
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (emailtxb.Text == "")
            {
                emailtxb.ForeColor = Color.LightGray;
                emailtxb.Text = "Email";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (emailtxb.Text == "Email")
            {
                emailtxb.Text = "";
                emailtxb.ForeColor = Color.Black;
            }
        }
        public static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the program?", "Nofitication", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }  
        }
        public void loginbtn_Click(object sender, EventArgs e)
        {
            if (cbghinho.Checked == true)
            {
                Properties.Settings.Default.Email = emailtxb.Text;
                Properties.Settings.Default.Password = passwordtxb.Text;
                Properties.Settings.Default.Save();
            }
            if (cbghinho.Checked == false)
            {
                Properties.Settings.Default.Email = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }

            string query = "Select * from User Where Email ='" + emailtxb.Text.Trim() + "' and Password = '" + Encrypt(passwordtxb.Text.Trim()) + "'  ALLOW FILTERING";

            Cassandra.RowSet row = DataConnection.Ins.session.Execute(query);

            if (row.FirstOrDefault() != null)
            {
                Properties.Settings.Default.UserName = emailtxb.Text;
                Properties.Settings.Default.Password = passwordtxb.Text;
                Properties.Settings.Default.Save();
                SelectForm menuF = new SelectForm();
                this.Hide();
                menuF.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Wrong email or password!!!!");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Email != string.Empty)
            {
                emailtxb.Text = Properties.Settings.Default.Email;
                passwordtxb.Text = Properties.Settings.Default.Password;
                cbghinho.Checked = true;
                emailtxb.ForeColor = Color.Black;
            }
        }

        private void forgetlb_Click(object sender, EventArgs e)
        {
            forgotpass forgotpass = new forgotpass();
            this.Hide();
            forgotpass.ShowDialog();

            if (!this.IsDisposed)
                this.Show();
        }

        private void emailtxb_Validating(object sender, CancelEventArgs e)
        {
            if (emailtxb.Text.Length > 0)
            {
                if (!rEMail.IsMatch(emailtxb.Text))
                {
                    MessageBox.Show("Invalidate Email", "Error");
                    emailtxb.SelectAll();
                    loginbtn.Enabled = false;
                    //e.Cancel = true;
                }
                else
                {
                    loginbtn.Enabled = true;
                }
            }
        }

        private void registaccountlb_Click(object sender, EventArgs e)
        {
            RegisterAccount ra = new RegisterAccount();
            this.Hide();
            ra.ShowDialog();
            this.Show();
        }
        public string password, email;
        public bool Login()
        {
            password = Encrypt(password);
            string query = "Select * from User Where Email ='" + email + "' and Password = '" + password + "'  ALLOW FILTERING";
            Cassandra.RowSet row = DataConnection.Ins.session.Execute(query);

            if (row.FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
    }
}
