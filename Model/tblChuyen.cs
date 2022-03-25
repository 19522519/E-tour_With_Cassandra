using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    class tblChuyen
    {
        public Guid MaTuyen { set; get; }
        public Guid MaChuyen { set; get; }
        public string MaChuyenSearch { set; get; }
        public string TenTuyen { set; get; }
        public string MaLoaiChuyen { set; get; }
        public string TenLoaiChuyen { set; get; }
        public DateTime ThoiGianKhoiHanh { set; get; }
        public string PhuongTien { set; get; }
        public int SoLuongVeMax { set; get; }
        public decimal GiaVe { set; get; }
    }
}
