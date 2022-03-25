using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Tour
{
    public partial class ChangePass : Form
    {
        string email = Properties.Settings.Default.UserName;

        public ChangePass()
        {
            InitializeComponent();
        }

        private void Resetbtn_Click(object sender, EventArgs e)
        {
            if (newpasstxb.Text == confirmtxb.Text && newpasstxb.Text != "")
            {
                DataConnection.Ins.session.Execute("UPDATE User SET Password = '" + LoginForm.Encrypt(newpasstxb.Text) + "' WHERE Email = '" + email + "' ");
                MessageBox.Show("Reset password success!!!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Password does not match!!!");
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
