using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using _2001230507_NhanTuManh_B5.Models;

namespace _2001230507_NhanTuManh_B5.DAL
{
    public class LoaiDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public List<Loai> GetAllLoai()
        {
            List<Loai> ds = new List<Loai>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT MaLoai, TenLoai FROM tbl_Loai";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ds.Add(new Loai
                    {
                        MaLoai = Convert.ToInt32(reader["MaLoai"]),
                        TenLoai = reader["TenLoai"].ToString()
                    });
                }
            }
            return ds;
        }
    }
}
