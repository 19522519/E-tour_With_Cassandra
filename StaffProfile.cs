using System;
using System.Collections.Generic;
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
using System.Security.Cryptography;
using Cassandra;
using Tour.Model;

namespace Tour
{
    public partial class StaffProfile : Form
    {
        private Func<Row, User> UserSelector;

        public StaffProfile()
        {
            InitializeComponent();
        }

        private void StaffProfile_Load(object sender, EventArgs e)
        {
            UserSelector = delegate (Row r)
            {
                User _user = new User
                {
                    Ho = r.GetValue<string>("ho"),
                    Ten = r.GetValue<string>("ten"),
                    Phone = r.GetValue<string>("sdt")
                };
                return _user;
            };

            if (Properties.Settings.Default.UserName != string.Empty)
            {
                txbGmail.Text = Properties.Settings.Default.UserName;
            }

            string query = "Select Ho,Ten,SDT from User where Email='" + Properties.Settings.Default.UserName + "'";

            //MessageBox.Show(Properties.Settings.Default.UserName + " " + )

            User user = DataConnection.Ins.session.Execute(query)
                .Select(UserSelector).FirstOrDefault();

            txbTen.Text = user.Ten;
            txbHo.Text = user.Ho;
            txbSDT.Text = user.Phone;
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
