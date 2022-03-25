using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    class tblTicket
    {
        public Guid MaVe { set; get; }
        public Guid MaPhieu { set; get; }
        public Guid MaDuKhach { set; get; }
        public Guid MaChuyen { set; get; }
        public string MaChuyenSearch { set; get; }

        public Decimal GiaVe { set; get; }
        public Decimal TienHoanTra { set; get; }
        public int LePhiHoanTra { set; get; }
        public string HoTen { set; get; }
        public string DiaChi { set; get; }
        public string SDT { set; get; }
        public string GioiTinh { set; get; }
        public string CMND_Passport { set; get; }
        public string TenLoaiKhach { set; get; }
        public string TenLoaiTuyen { set; get; }
        public string TenLoaiChuyen { set; get; }
        public DateTime HanPassport { set; get; }
        public DateTime HanVisa { set; get; }
    }
}
