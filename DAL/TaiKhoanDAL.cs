using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001230507_NhanTuManh_B5.DAL
{
    public class TaiKhoanDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @ten AND MatKhau = @matkhau";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", tenDangNhap);
                cmd.Parameters.AddWithValue("@matkhau", matKhau);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}