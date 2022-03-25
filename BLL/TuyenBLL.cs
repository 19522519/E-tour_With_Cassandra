using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    class TuyenBLL
    {
        TuyenDAL dalTuyen;
        public TuyenBLL()
        {
            dalTuyen = new TuyenDAL();
        }
        public dynamic getAllTuyen()
        {
            return dalTuyen.getAllTuyen();
        }
        public dynamic FindTuyen(string route)
        {
            return dalTuyen.FindTuyen(route);
        }
        public bool InsertTuyen(tblTuyen route)
        {
            return dalTuyen.InsertTuyen(route);
        }
        public bool UpdateTuyen(tblTuyen route)
        {
            return dalTuyen.UpdateTuyen(route);
        }
        public bool DeleteTuyen(tblTuyen route)
        {
            return dalTuyen.DeleteTuyen(route);
        }
    }
}
