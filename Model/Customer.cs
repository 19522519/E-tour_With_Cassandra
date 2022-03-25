using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    class Customer
    {
        public Guid MaDuKhach { set; get; }
        public string HoTen { set; get; }
        public string DiaChi { set; get; }
        public string SDT { set; get; }
        public string MaLoaiKhach { set; get; }
        public string GioiTinh { set; get; }
        public string CMND_Passport { set; get; }
        public DateTime HanPassport { set; get; }
        public DateTime HanVisa { set; get; }

    }
}
