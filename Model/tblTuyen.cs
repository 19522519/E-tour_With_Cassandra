using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    class tblTuyen
    {
        public Guid MaTuyen { set; get; }
        public string TenTuyen { set; get; }
        public string XuatPhat { set; get; }
        public string DiaDiem { set; get; }

        public string ThoiGianToChuc { set; get; }
        public string MaLoaiTuyen { set; get; }
        public string TenLoaiTuyen { set; get; }
    }
}
