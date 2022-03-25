using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using Cassandra;

namespace Tour
{
    class TuyenDAL
    {
        Func<Row, tblTuyen> TuyenSelector;

        public TuyenDAL()
        {
            TuyenSelector = delegate (Row r)
            {
                tblTuyen tuyen = new tblTuyen
                {
                    MaTuyen = r.GetValue<Guid>("matuyen"),
                    DiaDiem = r.GetValue<string>("diadiem"),
                    XuatPhat = r.GetValue<string>("xuatphat"),
                    TenTuyen = r.GetValue<string>("tentuyen"),
                    MaLoaiTuyen = r.GetValue<string>("maloaituyen"),
                    TenLoaiTuyen = r.GetValue<string>("tenloaituyen"),
                    ThoiGianToChuc = r.GetValue<string>("thoigiantochuc")
                };

                return tuyen;
            };
        }
        public dynamic getAllTuyen()
        {
            string query = "Select MaTuyen, TenTuyen, XuatPhat, DiaDiem, ThoiGianToChuc, TenLoaiTuyen, MaLoaiTuyen from Tuyen";
            var TuyenTable = DataConnection.Ins.session
                .Execute(query)
                .Select(TuyenSelector);
            return TuyenTable.ToList();
        }
        public bool InsertTuyen(tblTuyen route)
        {
            var query = DataConnection.Ins.session.Prepare("Insert into Tuyen (MaTuyen, TenTuyen, XuatPhat, DiaDiem, ThoiGianToChuc, MaLoaiTuyen, TenLoaiTuyen) values (?,?,?,?,?,?,?)");
            try
            {
                Guid guid = Guid.NewGuid();
                var ps = query.Bind(guid, route.TenTuyen, route.XuatPhat, route.DiaDiem, route.ThoiGianToChuc, route.MaLoaiTuyen, route.TenTuyen);
                DataConnection.Ins.session.Execute(ps);
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UpdateTuyen(tblTuyen route)
        {
            var query = DataConnection.Ins.session.Prepare("Update Tuyen set TenTuyen=?, XuatPhat=?, DiaDiem=?, MaLoaiTuyen=?, ThoiGianToChuc=?, TenLoaiTuyen=? where MaTuyen=?");
            try
            {
                var ps = query.Bind(route.TenTuyen, route.XuatPhat, route.DiaDiem, route.MaLoaiTuyen, route.ThoiGianToChuc, route.TenLoaiTuyen, route.MaTuyen);
                DataConnection.Ins.session.Execute(ps);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool DeleteTuyen(tblTuyen route)
        {
            string query = "Delete from Tuyen where MaTuyen = " + route.MaTuyen;
            //DataConnection.Ins.session.Execute(query);
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
        public dynamic FindTuyen(string route)
        {
            string query = "Select MaTuyen, TenTuyen, XuatPhat, DiaDiem, ThoiGianToChuc, TenLoaiTuyen, MaLoaiTuyen from Tuyen where TenTuyen like '%" + route + "%'";

            var TuyenTable = DataConnection.Ins.session
                .Execute(query)
                .Select(TuyenSelector);
            return TuyenTable.ToList();
        }
    }
}
