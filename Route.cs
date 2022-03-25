using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace Tour
{
    public partial class Route : Form
    {
        TuyenBLL bllTuyen;
        public Route()
        {
            InitializeComponent();
            bllTuyen = new TuyenBLL();
            searchtxb.ForeColor = Color.LightGray;
            searchtxb.Text = "Enter Route Name to search";
            this.searchtxb.Leave += new System.EventHandler(this.textBox1_Leave);
            this.searchtxb.Enter += new System.EventHandler(this.textBox1_Enter);
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (searchtxb.Text == "")
            {
                searchtxb.ForeColor = Color.LightGray;
                searchtxb.Text = "Enter Route Name to search";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (searchtxb.Text == "Enter Route Name to search")
            {
                searchtxb.Text = "";
                searchtxb.ForeColor = Color.Black;
            }
        }
        //Load Tuyến lên datagridview
        public void ShowAllTuyen()
        {
            dataGridView1.DataSource = bllTuyen.getAllTuyen();
        }
        private void TOUR_Load(object sender, EventArgs e)
        {
            rdbNational.Checked = true;
            ShowAllTuyen();
        }

        //Kiểm tra dữ liệu đầu vào
        public bool CheckData()
        {
            //if (string.IsNullOrEmpty(IDtxb.Text))
            //{
            //    MessageBox.Show("Please fill the Route Code box", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    IDtxb.Focus();
            //    return false;
            //}
            if (string.IsNullOrEmpty(tNametxb.Text))
            {
                MessageBox.Show("Please fill the Route Name box", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tNametxb.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(DLtxb.Text))
            {
                MessageBox.Show("Please fill the Departure box", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DLtxb.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(Destxb.Text))
            {
                MessageBox.Show("Please fill the Destination box", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Destxb.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(daytxb.Text))
            {
                MessageBox.Show("Please fill the day box", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                daytxb.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(nighttxb.Text))
            {
                MessageBox.Show("Please fill the night box", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nighttxb.Focus();
                return false;
            }
            return true;
        }
        void Clear()
        {
            nighttxb.Text = daytxb.Text = Destxb.Text = DLtxb.Text = tNametxb.Text = IDtxb.Text = "";
            rdbNational.Checked = true;
            rdbInternational.Checked = false;
        }

        //Thêm một tuyến
        private void addbtn_Click(object sender, EventArgs e)
        {
            if (CheckData() == true)
            {
                tblTuyen route = new tblTuyen();
                route.TenTuyen = tNametxb.Text;
                route.XuatPhat = DLtxb.Text;
                route.DiaDiem = Destxb.Text;
                route.ThoiGianToChuc = daytxb.Text + " Day " + nighttxb.Text + " Night";
                if (rdbNational.Checked == true)
                {
                    route.MaLoaiTuyen = "ROUTE01";
                    route.TenLoaiTuyen = "National";
                }
                else
                {
                    route.MaLoaiTuyen = "ROUTE02";
                    route.TenLoaiTuyen = "International";
                }
                if (bllTuyen.InsertTuyen(route))
                {
                    ShowAllTuyen();
                }
                else
                    MessageBox.Show("Error, Please try again later", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
            }
        }
        public string RouteID,RouteName, Departure, Location, Days, Nights, RouteCode, TypeofRoute;
        public bool addTuyen()
        {
            tblTuyen route = new tblTuyen();
            route.TenTuyen = RouteName;
            route.XuatPhat = Departure;
            route.DiaDiem = Location;
            route.ThoiGianToChuc = Days + " Day " + Nights + " Night";
            route.MaLoaiTuyen = RouteCode;
            route.TenLoaiTuyen = TypeofRoute;
            if (bllTuyen.InsertTuyen(route))
            {
                return true;
            }
            return false;
        }
        public bool deleteTuyen()
        {
            tblTuyen route = new tblTuyen();
            route.MaTuyen = Guid.Parse(RouteID);
            if (bllTuyen.DeleteTuyen(route))
            {
                return true;
            }
            return false;
        }
        public bool updateTuyen()
        {
            tblTuyen route = new tblTuyen();
            route.MaTuyen = Guid.Parse(RouteID);
            route.TenTuyen = RouteName;
            route.XuatPhat = Departure;
            route.DiaDiem = Location;
            route.ThoiGianToChuc = Days + " Day " + Nights + " Night";
            route.MaLoaiTuyen = RouteCode;
            route.TenLoaiTuyen = TypeofRoute;
            if (bllTuyen.UpdateTuyen(route))
            {
                return true;
            }
            return false;
        }
        //Sửa một tuyến
        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (CheckData() == true)
            {
                tblTuyen route = new tblTuyen();
                route.MaTuyen = Guid.Parse(IDtxb.Text);
                route.TenTuyen = tNametxb.Text;
                route.XuatPhat = DLtxb.Text;
                route.DiaDiem = Destxb.Text;
                route.ThoiGianToChuc = daytxb.Text + " Day " + nighttxb.Text + " Night";
                if (rdbNational.Checked == true)
                {
                    route.MaLoaiTuyen = "ROUTE01";
                    route.TenLoaiTuyen = "National";
                }
                else
                {
                    route.MaLoaiTuyen = "ROUTE02";
                    route.TenLoaiTuyen = "International";
                }
                if (bllTuyen.UpdateTuyen(route))
                {
                    ShowAllTuyen();
                }
                else
                    MessageBox.Show("Error, Please try again later", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
            }
        }

        //Xoá một tuyến
        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IDtxb.Text))
                return;
            if (MessageBox.Show("Are you sure to delete this?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblTuyen route = new tblTuyen();
                route.MaTuyen = Guid.Parse(IDtxb.Text);
                if (bllTuyen.DeleteTuyen(route))
                {
                    ShowAllTuyen();
                }
                else
                    MessageBox.Show("Error, Please try again later", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int start = 0, end;
            int index = e.RowIndex;
            string date, temp;
            Guid id;
            if (index >= 0)
            {
                //id = Guid.Parse(dataGridView1.Rows[index].Cells["stt"].Value.ToString());
                IDtxb.Text = dataGridView1.Rows[index].Cells["MaTuyen"].Value.ToString();
                tNametxb.Text = dataGridView1.Rows[index].Cells["TenTuyen"].Value.ToString();
                DLtxb.Text = dataGridView1.Rows[index].Cells["XuatPhat"].Value.ToString();
                Destxb.Text = dataGridView1.Rows[index].Cells["DiaDiem"].Value.ToString();
                date = dataGridView1.Rows[index].Cells["ThoiGianToChuc"].Value.ToString();
                start = date.LastIndexOf("Day");
                daytxb.Text = date.Substring(0, start - 1);
                temp = date.Substring(start + 4);
                end = temp.LastIndexOf(" Night");
                nighttxb.Text = temp.Substring(0, end);
                string kind = dataGridView1.Rows[index].Cells["TenLoaiTuyen"].Value.ToString();
                if (kind == "National")
                {
                    rdbNational.Checked = true;
                }
                else rdbInternational.Checked = true;
            }
        }


        //Tìm tuyến
        private void searchtxb_TextChanged(object sender, EventArgs e)
        {
            string value = searchtxb.Text;
            if (!string.IsNullOrEmpty(value) && value != "Enter Route Name to search")
            {
                dataGridView1.DataSource = bllTuyen.FindTuyen(value);
            }
            else { ShowAllTuyen(); }
        }
        private void GotoTourbtn_Click(object sender, EventArgs e)
        {
            Tour t = new Tour();
            this.Hide();
            t.ShowDialog();
        }

        private void daytxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void nighttxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tNametxb_TextChanged(object sender, EventArgs e)
        {

        }

        private void IDtxb_Enter(object sender, EventArgs e)
        {
            ShowAllTuyen();
        }

        private void DLtxb_Enter(object sender, EventArgs e)
        {
            ShowAllTuyen();
        }

        private void Destxb_Enter(object sender, EventArgs e)
        {
            ShowAllTuyen();
        }

        private void tNametxb_Enter(object sender, EventArgs e)
        {
            ShowAllTuyen();
        }

        private void rdbInternational_Enter(object sender, EventArgs e)
        {
            //ShowAllTuyen();
        }

        private void daytxb_Enter(object sender, EventArgs e)
        {
            ShowAllTuyen();
        }

        private void nighttxb_Enter(object sender, EventArgs e)
        {
            ShowAllTuyen();
        }

        private void rdbNational_Enter(object sender, EventArgs e)
        {
            //ShowAllTuyen();
        }

        private void searchtxb_Leave(object sender, EventArgs e)
        {
            //ShowAllTuyen();
        }

        private void searchtxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
