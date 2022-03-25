using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tour
{
    class CustomerDAL
    {
        public bool InsertForeign(Customer cus)
        {
            var ps = DataConnection.Ins.session.Prepare("INSERT INTO DuKhach(MaDuKhach, HoTen, DiaChi, SDT, MaLoaiKhach, GioiTinh, CMND_Passport, HanPassport, HanVisa ) VALUES (?,?,?,?,?,?,?,?,?)");
            try
            {
                var query = ps.Bind(cus.MaDuKhach, cus.HoTen, cus.DiaChi, cus.SDT, cus.MaLoaiKhach, cus.GioiTinh, cus.CMND_Passport, cus.HanPassport, cus.HanVisa);
                DataConnection.Ins.session.Execute(query);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool InsertDomestic(Customer cus)
        {
            var ps = DataConnection.Ins.session.Prepare("INSERT INTO DuKhach(MaDuKhach, HoTen, DiaChi, SDT, MaLoaiKhach, GioiTinh, CMND_Passport) VALUES (?,?,?,?,?,?,?)");
            try
            {
                var query = ps.Bind(cus.MaDuKhach, cus.HoTen, cus.DiaChi, cus.SDT, cus.MaLoaiKhach, cus.GioiTinh, cus.CMND_Passport);
                DataConnection.Ins.session.Execute(query);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Update(Customer cus)
        {

            var ps = DataConnection.Ins.session.Prepare("UPDATE DuKhach SET  HoTen = ?, DiaChi = ?, SDT = ?, MaLoaiKhach = ?, GioiTinh = ?, CMND_Passport = ?, HanVisa = ?, HanPassport = ? WHERE MaDuKhach = ?");
            try
            {
                var query = ps.Bind(cus.HoTen, cus.DiaChi, cus.SDT, cus.MaLoaiKhach, cus.GioiTinh, cus.CMND_Passport, cus.HanVisa, cus.HanPassport, cus.MaDuKhach);
                DataConnection.Ins.session.Execute(query);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool Delete(Customer cus)
        {
            string query = "DELETE from DuKhach WHERE MaDuKhach = " + cus.MaDuKhach;
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
