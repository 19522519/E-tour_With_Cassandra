using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    class ticketDAL
    {
        public bool Insert(tblTicket tk)
        {
            var ps = DataConnection.Ins.session.Prepare("INSERT INTO Ve (MaVe, MaPhieu, GiaVe, MaDuKhach, HoTen, DiaChi, SDT, GioiTinh, CMND_Passport, TenLoaiKhach, HanPassport, HanVisa, MaChuyen, TenLoaiTuyen, TenLoaiChuyen, LePhiHoanTra, TienHoanTra, MaChuyenSearch) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?, ?)");
            try
            {
                var query = ps.Bind(tk.MaVe, tk.MaPhieu, tk.GiaVe, tk.MaDuKhach, tk.HoTen, tk.DiaChi, tk.SDT, tk.GioiTinh, tk.CMND_Passport, tk.TenLoaiKhach, tk.HanPassport, tk.HanVisa, tk.MaChuyen, tk.TenLoaiTuyen, tk.TenLoaiChuyen, tk.LePhiHoanTra, tk.TienHoanTra, tk.MaChuyenSearch);
                DataConnection.Ins.session.Execute(query);
            }
            catch (Exception e)
            {
                return false;
            } 
            return true;
        }
        public bool Update(tblTicket tk)
        {
            var ps = DataConnection.Ins.session.Prepare("UPDATE Ve SET GiaVe=?, HoTen=?, DiaChi=?, SDT=?, GioiTinh=?, CMND_Passport=?, TenLoaiKhach=?, HanPassport=?, HanVisa=?, MaChuyen=?, MaChuyenSearch=?, TenLoaiTuyen=?, TenLoaiChuyen=?, LePhiHoanTra=?, TienHoanTra=? WHERE MaVe=? and MaPhieu=? and MaDuKhach=?");
            try
            {
                var query = ps.Bind(tk.GiaVe, tk.HoTen, tk.DiaChi, tk.SDT, tk.GioiTinh, tk.CMND_Passport, tk.TenLoaiKhach, tk.HanPassport, tk.HanVisa, tk.MaChuyen, tk.MaChuyenSearch, tk.TenLoaiTuyen, tk.TenLoaiChuyen, tk.LePhiHoanTra, tk.TienHoanTra, tk.MaVe, tk.MaPhieu, tk.MaDuKhach);
                DataConnection.Ins.session.Execute(query);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool UpdateCustomerInTicket(Customer cus, Guid MaVe, Guid MaPhieu)
        {
            var ps = DataConnection.Ins.session.Prepare("UPDATE Ve SET HoTen=?, DiaChi=?, SDT=?, GioiTinh=?, CMND_Passport=?, HanPassport=?, HanVisa=? WHERE MaVe=? and MaPhieu=? and MaDuKhach=?");
            try
            {
                var query = ps.Bind(cus.HoTen, cus.DiaChi, cus.SDT, cus.GioiTinh, cus.CMND_Passport, cus.HanPassport, cus.HanVisa, MaVe, MaPhieu, cus.MaDuKhach);
                DataConnection.Ins.session.Execute(query);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Delete(tblTicket tk)
        {
            var ps = DataConnection.Ins.session.Prepare("DELETE from Ve WHERE MaVe=? and MaPhieu=? and MaDuKhach=?");
            try
            {
                var query = ps.Bind(tk.MaVe, tk.MaPhieu, tk.MaDuKhach);
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
