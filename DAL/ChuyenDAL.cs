using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Cassandra;

namespace Tour
{   
    class ChuyenDAL
    {
        DataConnection dc;
        SqlCommand cmd;
        SqlDataAdapter da;

        Func<Row, tblChuyen> ChuyenSelector;

        public ChuyenDAL()
        {
            ChuyenSelector = delegate (Row r)
            {
                tblChuyen chuyen = new tblChuyen
                {
                    MaTuyen = r.GetValue<Guid>("matuyen"),
                    MaChuyen = r.GetValue<Guid>("machuyen"),
                    MaChuyenSearch = r.GetValue<string>("machuyensearch"),
                    TenTuyen = r.GetValue<string>("tentuyen"),
                    ThoiGianKhoiHanh = r.GetValue<DateTime>("thoigiankhoihanh"),
                    TenLoaiChuyen = r.GetValue<string>("tenloaichuyen"),
                    PhuongTien = r.GetValue<string>("phuongtien"),
                    SoLuongVeMax = r.GetValue<int>("soluongvemax"),
                    GiaVe = r.GetValue<decimal>("giave"),
                    MaLoaiChuyen = r.GetValue<string>("maloaichuyen"),
                };
                return chuyen;
            };
        }
        public bool LoadComboBox(ComboBox cb)
        {
            Func<Row, tblTuyen> TuyenSelector = delegate (Row r)
            {
                tblTuyen tuyen = new tblTuyen
                {
                    MaTuyen = r.GetValue<Guid>("matuyen"),
                    TenTuyen = r.GetValue<string>("tentuyen")
                };
                return tuyen;
            };

            string query = "Select MaTuyen, TenTuyen From Tuyen";
            var TuyenList = DataConnection.Ins.session.Execute(query)
                .Select(TuyenSelector);

            var MaTuyenList = from c in TuyenList
                              select new
                              {
                                  MaTuyen = c.MaTuyen,
                                  TenTuyen = c.TenTuyen
                              };

            cb.DataSource = MaTuyenList.ToList();
            cb.DisplayMember = "TenTuyen";
            cb.ValueMember = "MaTuyen";
            return true;
        }
        public dynamic getAllChuyen()
        {
            string query = "Select MaTuyen, MaChuyen, MaChuyenSearch, TenTuyen, ThoiGianKhoiHanh, TenLoaiChuyen, PhuongTien, SoLuongVeMax, GiaVe, MaLoaiChuyen FROM ChuyenDuLich ";

            var ChuyenTable = DataConnection.Ins.session.Execute(query)
                .Select(ChuyenSelector);
            return ChuyenTable.ToList();
        }

        public tblChuyen getChuyen(Guid id)
        {
            string query = "Select * FROM ChuyenDuLich WHERE MaChuyen = " + id;

            tblChuyen chuyen = DataConnection.Ins.session.Execute(query)
                .Select(ChuyenSelector)
                .FirstOrDefault();
            return chuyen;
        }

        public bool InsertChuyen(tblChuyen route)
        {
            var ps = DataConnection.Ins.session.Prepare("Insert into ChuyenDuLich(MaTuyen, MaChuyen, MaChuyenSearch, TenTuyen, ThoiGianKhoiHanh, MaLoaiChuyen,PhuongTien,SoLuongVeMax, GiaVe, TenLoaiChuyen) values(?,?,?,?,?,?,?,?,?,?)");
            try
            {
                var query = ps.Bind(route.MaTuyen, route.MaChuyen, route.MaChuyenSearch, route.TenTuyen, route.ThoiGianKhoiHanh, route.MaLoaiChuyen, route.PhuongTien, route.SoLuongVeMax, route.GiaVe, route.TenLoaiChuyen);
                DataConnection.Ins.session.Execute(query);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UpdateChuyen(tblChuyen route)
        {
            var ps = DataConnection.Ins.session.Prepare("Update ChuyenDuLich set MaChuyenSearch=?, MaTuyen=?, TenTuyen=?, ThoiGianKhoiHanh=?, MaLoaiChuyen=?,PhuongTien=?,SoLuongVeMax=?,GiaVe=?, TenLoaiChuyen=? where MaChuyen=?");
            try
            {
                var query = ps.Bind(route.MaChuyenSearch, route.MaTuyen, route.TenTuyen, route.ThoiGianKhoiHanh, route.MaLoaiChuyen, route.PhuongTien, route.SoLuongVeMax, route.GiaVe, route.TenLoaiChuyen, route.MaChuyen);
                DataConnection.Ins.session.Execute(query);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool DeleteChuyen(tblChuyen route)
        {
            string query = "Delete from ChuyenDuLich where MaChuyen=" + route.MaChuyen;
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
        public dynamic FindChuyen(string routeID)
        {
            string query = "Select MaTuyen, MaChuyen, MaChuyenSearch, TenTuyen, ThoiGianKhoiHanh, MaLoaiChuyen, TenLoaiChuyen, PhuongTien, SoLuongVeMax, GiaVe FROM ChuyenDuLich where MaChuyenSearch like '%" + routeID + "%'";

            var ChuyenTable = DataConnection.Ins.session.Execute(query)
                .Select(ChuyenSelector);
            return ChuyenTable.ToList();
        }
    }
}
