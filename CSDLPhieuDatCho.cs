using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cassandra;

namespace Tour
{
    public partial class CSDLPhieuDatCho : Form
    {

        ticketDAL tkDAL = new ticketDAL();
        CustomerDAL cusDAL = new CustomerDAL();
        ReservationDAL resDAL = new ReservationDAL();
        DataConnection dc;
        SqlDataAdapter adapter;

        Func<Row, tblTicket> TicketSelector;
        Func<Row, tblTicket> TicketSelectorV2;

        void Clear()
        {
            tbName.Text=tbAddress.Text = tbID.Text = tbICN.Text = tbphone.Text = tbAddress.Text = "";
            rdbDomestic.Checked = rdbFemale.Checked = rdbMale.Checked = rdbForeign.Checked = false;
        }
        public CSDLPhieuDatCho()
        {
            TicketSelector = delegate (Row r)
            {
                tblTicket ticket = new tblTicket
                {
                    MaDuKhach = r.GetValue<Guid>("madukhach"),
                    HanPassport = r.GetValue<DateTime>("hanpassport"),
                    HanVisa = r.GetValue<DateTime>("hanvisa"),
                    MaChuyen = r.GetValue<Guid>("machuyen"),
                    TenLoaiTuyen = r.GetValue<string>("tenloaituyen"),
                    TenLoaiChuyen = r.GetValue<string>("tenloaichuyen"),
                    LePhiHoanTra = r.GetValue<int>("lephihoantra"),
                    TienHoanTra = r.GetValue<decimal>("tienhoantra"),
                    MaVe = r.GetValue<Guid>("mave"),
                    MaPhieu = r.GetValue<Guid>("maphieu"),
                    HoTen = r.GetValue<string>("hoten"),
                    DiaChi = r.GetValue<string>("diachi"),
                    SDT = r.GetValue<string>("sdt"),
                    GioiTinh = r.GetValue<string>("gioitinh"),
                    TenLoaiKhach = r.GetValue<string>("tenloaikhach"),
                    CMND_Passport = r.GetValue<string>("cmnd_passport"),
                    GiaVe = r.GetValue<decimal>("giave")
                };
                return ticket;
            };

            TicketSelectorV2 = delegate (Row r)
            {
                tblTicket ticket = new tblTicket
                {
                    MaPhieu = r.GetValue<Guid>("maphieu"),
                    HoTen = r.GetValue<string>("hoten"),
                };
                return ticket;
            };

            InitializeComponent();
            tkDAL = new ticketDAL();
            tbSearchTicket.ForeColor = Color.LightGray;
            tbSearchTicket.Text = "Enter Tour ID to search";
            this.tbSearchTicket.Leave += new System.EventHandler(this.textBox1_Leave);
            this.tbSearchTicket.Enter += new System.EventHandler(this.textBox1_Enter);
            tbSearchResID.ForeColor = Color.LightGray;
            tbSearchResID.Text = "Enter Tour ID to search";
            this.tbSearchResID.Leave += new System.EventHandler(this.textBox2_Leave);
            this.tbSearchResID.Enter += new System.EventHandler(this.textBox2_Enter);
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (tbSearchTicket.Text == "")
            {
                tbSearchTicket.ForeColor = Color.LightGray;
                tbSearchTicket.Text = "Enter Tour ID to search";
                ShowTicket();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (tbSearchTicket.Text == "Enter Tour ID to search")
            {
                tbSearchTicket.Text = "";
                tbSearchTicket.ForeColor = Color.Black;
                ShowTicket();
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (tbSearchResID.Text == "")
            {
                tbSearchResID.ForeColor = Color.LightGray;
                tbSearchResID.Text = "Enter Tour ID to search";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (tbSearchResID.Text == "Enter Tour ID to search")
            {
                tbSearchResID.Text = "";
                tbSearchResID.ForeColor = Color.Black;
            }
        }
        public void ShowTicket()
        {
            string query = "SELECT MaDuKhach, HanPassport, HanVisa, MaChuyen, TenLoaiTuyen, TenLoaiChuyen, LePhiHoanTra, TienHoanTra, MaVe, MaPhieu, HoTen, DiaChi, SDT, GioiTinh, TenLoaiKhach, CMND_Passport, GiaVe FROM Ve";

            var TicketTable = DataConnection.Ins.session.Execute(query)
                .Select(TicketSelector);

            dgvQuanLy.DataSource = TicketTable.ToList();
        }

        public void ShowTicketv2()
        {
            
            string query = "Select MaPhieu, HoTen from ve";

            var TicketTable = DataConnection.Ins.session.Execute(query)
                .Select(TicketSelectorV2);

            dgvDatCho.DataSource = TicketTable.ToList();
        }


        Guid TicketID, CustomerID, ReservationID, TourID;
        decimal CostTicket;
        string NameOfRouteType, NameOfTourType;

        private void dgvQuanLy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            String gender, tourist;
            if (index >= 0)
            {
                CustomerID = Guid.Parse(dgvQuanLy.Rows[index].Cells["MaDuKhach"].Value.ToString());
                TicketID = Guid.Parse(dgvQuanLy.Rows[index].Cells["MaVe"].Value.ToString());
                ReservationID = Guid.Parse(dgvQuanLy.Rows[index].Cells["MaPhieuDatCho"].Value.ToString());
                TourID = Guid.Parse(dgvQuanLy.Rows[index].Cells["MaChuyen"].Value.ToString());
                NameOfTourType = dgvQuanLy.Rows[index].Cells["TenLoaiChuyen"].Value.ToString();
                NameOfRouteType = dgvQuanLy.Rows[index].Cells["TenloaiTuyen"].Value.ToString();
                CostTicket = decimal.Parse(dgvQuanLy.Rows[index].Cells["GiaVe"].Value.ToString());

                tbID.Text = dgvQuanLy.Rows[index].Cells["MaChuyen"].Value.ToString();
                tbName.Text = dgvQuanLy.Rows[index].Cells["HoTen"].Value.ToString();
                tbAddress.Text = dgvQuanLy.Rows[index].Cells["DiaChi"].Value.ToString();
                tbphone.Text = dgvQuanLy.Rows[index].Cells["SDT"].Value.ToString();
                tbICN.Text = dgvQuanLy.Rows[index].Cells["CMND_Passport"].Value.ToString();

                dtpVisa.Value = DateTime.Parse(dgvQuanLy.Rows[index].Cells["HanVisa"].Value.ToString());
                dtpPassport.Value = DateTime.Parse(dgvQuanLy.Rows[index].Cells["HanPassport"].Value.ToString());

                gender = dgvQuanLy.Rows[index].Cells["GioiTinh"].Value.ToString();
                if (gender == "Male")
                {
                    rdbMale.Checked = true;
                }
                else if (gender == "Female")
                {
                    rdbFemale.Checked = true;
                }
                tourist = dgvQuanLy.Rows[index].Cells["TenLoaiKhach"].Value.ToString();
                if (tourist == "Foreign")
                {
                    rdbForeign.Checked = true;
                }
                else if (tourist == "Domestic")
                {
                    rdbDomestic.Checked = true;
                }
            }
        }
        private void CSDLPhieuDatCho_Load(object sender, EventArgs e)
        {
            ShowTicket();
            tientong();
        }
        void tientong()
        {
            int sum = 0;
            for (int i = 0; i < dgvQuanLy.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvQuanLy.Rows[i].Cells["GiaVe"].Value);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                Customer cus = new Customer();

                cus.MaDuKhach = CustomerID;
                cus.HoTen = tbName.Text;
                cus.DiaChi = tbAddress.Text;
                cus.SDT = tbphone.Text;

                cus.GioiTinh = "Male";
                if (rdbFemale.Checked == true)
                {
                    cus.GioiTinh = "Female";
                }

                if (rdbDomestic.Checked == true)
                {
                    cus.MaLoaiKhach = "CUS001";
                }
                else cus.MaLoaiKhach = "CUS002";

                cus.CMND_Passport = tbICN.Text;
                cus.HanPassport = dtpPassport.Value;
                cus.HanVisa = dtpVisa.Value;

                if (cusDAL.Update(cus) && tkDAL.UpdateCustomerInTicket(cus, TicketID, ReservationID))
                {
                    ShowTicket();
                    MessageBox.Show("Cập nhật thông tin hoàn tất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                //Clear();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = tbSearchTicket.Text;
            if (!string.IsNullOrEmpty(value) && value != "Enter Tour ID to search")
            {
                string query = "SELECT MaDuKhach, HanPassport, HanVisa, MaChuyen, TenLoaiTuyen, TenLoaiChuyen, LePhiHoanTra, TienHoanTra, MaVe, MaPhieu, HoTen, DiaChi, SDT, GioiTinh, TenLoaiKhach, CMND_Passport, GiaVe FROM Ve where MaChuyenSearch like '%" + value + "%'";
                var VeTable = DataConnection.Ins.session.Execute(query)
                .Select(TicketSelector);
                dgvQuanLy.DataSource = VeTable.ToList();
            }
            else { ShowTicket(); }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string value = tbSearchResID.Text;
            if (!string.IsNullOrEmpty(value) && value != "Enter Tour ID to search")
            {
                string query = "Select MaChuyen, MaPhieu, HoTen from Ve where MaChuyenSearch like '%" + value + "%'";
                var ChuyenTable = DataConnection.Ins.session.Execute(query)
                .Select(TicketSelectorV2);
                dgvDatCho.DataSource = ChuyenTable.ToList();
            }
            else { ShowTicketv2(); }
        }

        public bool CheckData()
        {
            DateTime date = GetTime(TourID);

            if (String.IsNullOrEmpty(tbName.Text) || String.IsNullOrEmpty(tbphone.Text) || String.IsNullOrEmpty(tbAddress.Text))
            {
                MessageBox.Show("Please fill in all the information", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (rdbForeign.Checked == true && dtpPassport.Value.Date <= date.Date)
            {
                MessageBox.Show("Passport expire error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (rdbForeign.Checked == true && dtpVisa.Value.Date <= date.Date)
            {
                MessageBox.Show("Visa expire error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void tbphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void rdbForeign_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDomestic.Checked)
            {
                panelTime.Visible = false;
            }
            else
            {
                panelTime.Visible = true;
            }
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbSearchResID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbSearchTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbName_Enter(object sender, EventArgs e)
        {
            ShowTicket();
        }

        private void tbAddress_Enter(object sender, EventArgs e)
        {
            ShowTicket();
        }

        private void tbphone_Enter(object sender, EventArgs e)
        {
            ShowTicket();
        }

        private void btnTraVe_Click(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now;
            DateTime date = GetTime(TourID);
            TimeSpan interval = date - current;
            tblTicket tk = new tblTicket();
            tk.MaVe = TicketID;
            tk.MaPhieu = ReservationID;
            tk.MaDuKhach = CustomerID;

            Customer cus = new Customer();
            cus.MaDuKhach = CustomerID;

            Reservation res = new Reservation();
            res.MaPhieu = ReservationID;
            res.MaChuyen = TourID;


            decimal result;
            decimal costA = 1;
            int costB = 0;

            tblTicket ticket = DataConnection.Ins.session
                .Execute("Select * from Ve where MaVe = " + TicketID + " and MaPhieu = " + res.MaPhieu + " and MaDuKhach = " + cus.MaDuKhach)
                .Select(TicketSelector)
                .FirstOrDefault();

            if (ticket == null)
                return;

            costA = ticket.TienHoanTra;
            costB = ticket.LePhiHoanTra;

            result = (CostTicket * costA) - costB;
            if (result > 0)
            {
                MessageBox.Show("You get paid " + result + " for ticket refund ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result < 0)
            {
                MessageBox.Show("You have to pay extra " + result * (-1) + " for ticket refund ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Clear();

            if (tkDAL.Delete(tk) && cusDAL.Delete(cus) && resDAL.Delete(res))
            {
                ShowTicket();
                ShowTicketv2();
            }
            else MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public string mave,maphieu,madukhach,tourID;
        public bool XoaKhach()
        {
            tblTicket tk = new tblTicket();
            tk.MaVe = Guid.Parse(mave);
            tk.MaPhieu =Guid.Parse(maphieu);
            tk.MaDuKhach = Guid.Parse(madukhach);
            Customer cus = new Customer();
            cus.MaDuKhach= Guid.Parse(madukhach);
            Reservation res = new Reservation();
            res.MaPhieu = Guid.Parse(maphieu);
            res.MaChuyen = Guid.Parse(tourID);
            if (tkDAL.Delete(tk) && cusDAL.Delete(cus) && resDAL.Delete(res))
            {
                return true;
            }           
            tientong();
            return false;
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblTicket tk = new tblTicket();
                tk.MaVe = TicketID;
                tk.MaPhieu = ReservationID;
                tk.MaDuKhach = CustomerID;

                Customer cus = new Customer();
                cus.MaDuKhach = CustomerID;

                Reservation res = new Reservation();
                res.MaPhieu = ReservationID;
                res.MaChuyen = TourID;

                if (tkDAL.Delete(tk) && cusDAL.Delete(cus) && resDAL.Delete(res))
                {
                    ShowTicket();
                    ShowTicketv2();
                }
                else MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tientong();
                Clear();
            }
        }
        public float getTienHoantra(string TenLoaiChuyen)
        {
            float cost = 0;
            string sql = "SELECT TienHoanTra FROM LoaiChuyen WHERE TenLoaiChuyen = @TenLoaiChuyen";
            SqlConnection con = null; // dc.getConnect();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("@TenLoaiChuyen", TenLoaiChuyen);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                cost = float.Parse(da.GetValue(0).ToString());
            }
            return cost;
        }

        public int getLePhiHoanTra(string TenLoaiTuyen)
        {
            int cost = 0;
            string sql = "SELECT LePhiHoanTra FROM LoaiTuyen WHERE TenLoaiTuyen = @TenLoaiTuyen";
            SqlConnection con = null; // dc.getConnect();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("@TenLoaiTuyen", TenLoaiTuyen);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                cost = Int32.Parse( da.GetValue(0).ToString());             
            }
            return cost;
        }

        public DateTime GetTime(Guid MaChuyen)
        {
            DateTime date = new DateTime();
            Func<Row, DateTime> DateSelector = delegate (Row r)
            {
                return r.GetValue<DateTime>("thoigiankhoihanh");
            };
            
            try
            {
                date = DataConnection.Ins.session.Execute("SELECT ThoiGianKhoiHanh FROM ChuyenDuLich WHERE MaChuyen =" + MaChuyen)
                .Select(DateSelector)
                .FirstOrDefault();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error, Please try again later", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return date;
        }
    }
}