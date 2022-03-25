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
    public partial class Tour : Form
    {
        ChuyenBLL bllChuyen;
        string id;
        public Tour()
        {
            InitializeComponent();
            bllChuyen = new ChuyenBLL();
            tb_search.ForeColor = Color.LightGray;
            tb_search.Text = "Enter Tour ID to search";
            this.tb_search.Leave += new System.EventHandler(this.textBox1_Leave);
            this.tb_search.Enter += new System.EventHandler(this.textBox1_Enter);
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (tb_search.Text == "")
            {
                tb_search.ForeColor = Color.LightGray;
                tb_search.Text = "Enter Tour ID to search";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (tb_search.Text == "Enter Tour ID to search")
            {
                tb_search.Text = "";
                tb_search.ForeColor = Color.Black;
            }
        }
        public void ShowAllChuyen()
        {
            dgv_trip.DataSource = bllChuyen.getAllChuyen();
        }
        private void TRIPManageTour_Load(object sender, EventArgs e)
        {
            ShowAllChuyen();
            bllChuyen.LoadComboBox(idTuyencb);
        }
        public bool CheckData()
        {
            if (string.IsNullOrEmpty(cbHour.Text))
            {
                MessageBox.Show("Please choose the hour", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbHour.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbMinute.Text))
            {
                MessageBox.Show("Please choose the minute", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMinute.Focus();
                return false;
            }
            if (rdbRegular.Checked == false && rdbPromotional.Checked == false)
            {
                MessageBox.Show("Please Check the type of trip box", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(tb_price.Text))
            {
                MessageBox.Show("Please fill the price box", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_price.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbTTransporation.Text))
            {
                MessageBox.Show("Please fill the transportation box", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbTTransporation.Focus();
                return false;
            }
            return true;
        }
        private void update_Click(object sender, EventArgs e)
        {
            if (CheckData() == true)
            {
                tblChuyen route = new tblChuyen();
                int Hour, Minute;
                DateTime temp = new DateTime();
                DateTime date = new DateTime();
                Hour = Int32.Parse(cbHour.Text);
                Minute = Int32.Parse(cbMinute.Text);
                temp = dtpKhoiHanh.Value;
                date = new DateTime(temp.Year, temp.Month, temp.Day, Hour, Minute, 0);
                route.MaTuyen = Guid.Parse(idTuyencb.SelectedValue.ToString());
                route.MaChuyen = Guid.Parse(tb_idtrip.Text);
                route.MaChuyenSearch = route.MaChuyen.ToString();
                route.TenTuyen = idTuyencb.Text;
                route.PhuongTien = cbTTransporation.Text;
                route.ThoiGianKhoiHanh = date;
                route.SoLuongVeMax = Int32.Parse(tbAmount.Text);
                route.GiaVe = Int32.Parse(tb_price.Text);
                if (rdbRegular.Checked == true)
                {
                    route.MaLoaiChuyen = "TOUR01";
                    route.TenLoaiChuyen = "Regular";
                }
                else
                {
                    route.MaLoaiChuyen = "TOUR02";
                    route.TenLoaiChuyen = "Promotional";
                }
                if (bllChuyen.UpdateChuyen(route))
                {
                    ShowAllChuyen();
                }
                else
                    MessageBox.Show("Error, Please try again later", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
            }
        }
        void Clear()
        {
            tb_price.Text = cbTTransporation.Text = cbMinute.Text = cbHour.Text = tb_idtrip.Text = "";
            rdbPromotional.Checked = false;
            rdbRegular.Checked = false;
        }
        private void add_Click(object sender, EventArgs e)
        {
            if (CheckData() == true)
            {
                int Hour, Minute;
                DateTime temp = new DateTime();
                DateTime date = new DateTime();
                tblChuyen route = new tblChuyen();
                Hour = Int32.Parse(cbHour.Text);
                Minute = Int32.Parse(cbMinute.Text);
                temp = dtpKhoiHanh.Value;
                date = new DateTime(temp.Year, temp.Month, temp.Day, Hour, Minute, 0);
                route.MaTuyen = Guid.Parse(idTuyencb.SelectedValue.ToString());
                route.MaChuyen = Guid.NewGuid();
                route.MaChuyenSearch = route.MaChuyen.ToString();
                route.TenTuyen = idTuyencb.Text;
                route.ThoiGianKhoiHanh = date;
                route.PhuongTien = cbTTransporation.Text;
                route.SoLuongVeMax = Int32.Parse(tbAmount.Text);
                route.GiaVe = Int32.Parse(tb_price.Text);
                if (rdbRegular.Checked == true)
                {
                    route.MaLoaiChuyen = "TOUR01";
                    route.TenLoaiChuyen = "Regular";
                }
                else
                { 
                    route.MaLoaiChuyen = "TOUR02";
                    route.TenLoaiChuyen = "Promotional";
                }
                if (bllChuyen.InsertChuyen(route))
                {
                    ShowAllChuyen();
                }
                else
                    MessageBox.Show("Error, Please try again later", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblChuyen route = new tblChuyen();
                route.MaChuyen = Guid.Parse(tb_idtrip.Text);
                if (bllChuyen.DeleteChuyen(route))
                {
                    ShowAllChuyen();
                }
                else
                    MessageBox.Show("Error, Please try again later", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
            }
        }
        public string TourID, TourName , TourCode, TypeofTour,Transport,RouteID;
        public int Hour, Minute, Year, Month, Day, Tickets,Price;
        public bool addChuyen()
        {
            DateTime date ;
            tblChuyen route = new tblChuyen();
            date = new DateTime(Year, Month, Day, Hour, Minute, 0);
            route.MaTuyen = Guid.Parse(RouteID);
            route.MaChuyen = Guid.NewGuid();
            route.TenTuyen = TourName;
            route.ThoiGianKhoiHanh = date;
            route.PhuongTien = Transport;
            route.SoLuongVeMax = Tickets;
            route.GiaVe = Price;
            route.MaLoaiChuyen = TourCode;
            route.TenLoaiChuyen = TypeofTour;
            route.MaChuyenSearch = route.MaChuyen.ToString();
            if (bllChuyen.InsertChuyen(route))
            {
                return true;
            }
            return false;
        }
        public bool deleteChuyen()
        {
            tblChuyen route = new tblChuyen();
            route.MaChuyen = Guid.Parse(TourID);
            if (bllChuyen.DeleteChuyen(route))
            {
                return true;
            }
            return false;
        }
        public bool updateChuyen()
        {
            DateTime date;
            tblChuyen route = new tblChuyen();
            date = new DateTime(Year, Month, Day, Hour, Minute, 0);
            route.MaTuyen =  Guid.Parse(RouteID);
            route.MaChuyen = Guid.Parse(TourID);
            route.TenTuyen = TourName;
            route.ThoiGianKhoiHanh = date;
            route.PhuongTien = Transport;
            route.SoLuongVeMax = Tickets;
            route.GiaVe = Price;
            route.MaLoaiChuyen = TourCode;
            route.TenLoaiChuyen = TypeofTour;
            if (bllChuyen.UpdateChuyen(route))
            {
                return true;
            }
            return false;
        }
        private void dgv_trip_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DateTime Time = new DateTime();
            string kind;
            if (index >= 0)
            {
                id = dgv_trip.Rows[index].Cells["MaTuyen"].Value.ToString();
                idTuyencb.Text = dgv_trip.Rows[index].Cells["TenTuyen"].Value.ToString();
                tb_idtrip.Text = dgv_trip.Rows[index].Cells["MaChuyen"].Value.ToString();
                cbTTransporation.Text = dgv_trip.Rows[index].Cells["PhuongTien"].Value.ToString();
                Time = Convert.ToDateTime(dgv_trip.Rows[index].Cells["ThoiGianKhoiHanh"].Value.ToString());
                cbHour.Text = Time.Hour.ToString();
                cbMinute.Text = Time.Minute.ToString();
                dtpKhoiHanh.Value = Time;
                kind = dgv_trip.Rows[index].Cells["TenLoaiChuyen"].Value.ToString();
                if (kind == "Regular")
                {
                    rdbRegular.Checked = true;
                }
                else rdbPromotional.Checked = true;
                tb_price.Text = dgv_trip.Rows[index].Cells["GiaVe"].Value.ToString();
            }
        }

        private void tb_search_TextChanged_1(object sender, EventArgs e)
        {
            string value = tb_search.Text;
            if (!string.IsNullOrEmpty(value) && value != "Enter Tour ID to search")
            {
                dgv_trip.DataSource = bllChuyen.FindChuyen(value);
            }
            else { ShowAllChuyen(); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTTransporation.Text == "Train")
            {
                tbAmount.Text = "100";
            }
            if (cbTTransporation.Text == "Boat")
            {
                tbAmount.Text = "30";
            }
            if (cbTTransporation.Text == "Passenger Car")
            {
                tbAmount.Text = "50";
            }
            if (cbTTransporation.Text == "Plane")
            {
                tbAmount.Text = "100";
            }
        }

        private void backtoroutebtn_Click(object sender, EventArgs e)
        {
            Route r = new Route();
            this.Hide();
            r.ShowDialog();
        }

        private void gotoregistbtn_Click(object sender, EventArgs e)
        {
            DangKy d = new DangKy();
            this.Hide();
            d.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_price_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbMinute_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void idTuyencb_Enter(object sender, EventArgs e)
        {
            ShowAllChuyen();
        }

        private void tb_idtrip_Enter(object sender, EventArgs e)
        {
            ShowAllChuyen();
        }

        private void rdbRegular_Enter(object sender, EventArgs e)
        {
            //ShowAllChuyen();
        }

        private void rdbPromotional_Enter(object sender, EventArgs e)
        {
            //ShowAllChuyen();
        }

        private void tb_price_Enter(object sender, EventArgs e)
        {
            //ShowAllChuyen();
        }

        private void dtpKhoiHanh_Enter(object sender, EventArgs e)
        {
            ShowAllChuyen();
        }

        private void cbHour_Enter(object sender, EventArgs e)
        {
            ShowAllChuyen();
        }

        private void cbMinute_Enter(object sender, EventArgs e)
        {
            ShowAllChuyen();
        }

        private void cbTTransporation_Enter(object sender, EventArgs e)
        {
            ShowAllChuyen();
        }

        private void tb_search_Leave(object sender, EventArgs e)
        {
            //ShowAllChuyen();
        }

        private void tb_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
