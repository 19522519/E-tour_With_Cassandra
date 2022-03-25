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
    class typeCustomerDAL
    {
        DataConnection dc;
        SqlCommand cmd;
        //String conStr = "Data Source= DESKTOP-QLEJV95\\SQLEXPRESS; Initial Catalog=TourManagement; Integrated Security=True";
        String conStr = "Data Source= DESKTOP-CI36P6F; Initial Catalog = TourManagement; Integrated Security = True";
        public typeCustomerDAL()
        {
            //dc = new DataConnection();
        }

        public bool Insert(typeCustomer tpcus)
        {
            string sql = "INSERT INTO LoaiKhach(MaLoaiKhach, TenLoaiKhach) VALUES (@MaLoaiKhach, @TenLoaiKhach)";
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MaLoaiKhach", tpcus.MaLoaiKhach);
                cmd.Parameters.AddWithValue("@TenLoaiKhach", tpcus.TenLoaiKhach);
 
                //cmd.Parameters.Add("@MaLoaiKhach", SqlDbType.NVarChar).Value = tpcus.MaLoaiKhach;
                //cmd.Parameters.Add("@TenLoaiKhach", SqlDbType.NVarChar).Value = tpcus.TenLoaiKhach;
                //cmd.Parameters.Add("@CMND_Passport", SqlDbType.NVarChar).Value = tpcus.CMND_Passport;
                //cmd.Parameters.Add("@HanPassport", SqlDbType.Date).Value = tpcus.HanPassport;
                //cmd.Parameters.Add("@HanVisa", SqlDbType.Date).Value = tpcus.HanVisa;
                //cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
