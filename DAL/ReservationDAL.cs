using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    class ReservationDAL
    {
        public bool Insert(Reservation res)
        {
            var ps = DataConnection.Ins.session.Prepare("INSERT INTO PhieuDatCho(MaPhieu, MaChuyen) VALUES (?, ?)");
            try
            {
                var query = ps.Bind(res.MaPhieu, res.MaChuyen);
                DataConnection.Ins.session.Execute(query);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        

        public bool Delete(Reservation res)
        {
            string query = "DELETE from PhieuDatCho WHERE MaPhieu = " + res.MaPhieu + " and MaChuyen = " + res.MaChuyen;
            try
            {
                DataConnection.Ins.session.Execute(query);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
