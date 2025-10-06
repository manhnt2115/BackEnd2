using System.Configuration;
using _2001230507_NhanTuManh_B5.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001230507_NhanTuManh_B5.DAL
{
    public class SanPhamDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public List<SanPham> GetAllSanPham()
        {
            List<SanPham> list = new List<SanPham>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM tbl_SanPham";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    SanPham sp = new SanPham()
                    {
                        MaSanPham = Convert.ToInt32(row["MaSanPham"]),
                        TenSP = row["TenSP"].ToString(),
                        MaLoai = Convert.ToInt32(row["MaLoai"]),
                        MaNSX = Convert.ToInt32(row["MaNSX"]),
                        Gia = Convert.ToDecimal(row["Gia"]),
                        GhiChu = row["GhiChu"].ToString(),
                        Hinh = row["Hinh"].ToString()
                    };
                    list.Add(sp);
                }
            }

            return list;
        }

        public SanPham GetSanPhamById(int id)
        {
            SanPham sp = null;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM tbl_SanPham WHERE MaSanPham = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    sp = new SanPham()
                    {
                        MaSanPham = Convert.ToInt32(reader["MaSanPham"]),
                        TenSP = reader["TenSP"].ToString(),
                        MaLoai = Convert.ToInt32(reader["MaLoai"]),
                        MaNSX = Convert.ToInt32(reader["MaNSX"]),
                        Gia = Convert.ToDecimal(reader["Gia"]),
                        GhiChu = reader["GhiChu"].ToString(),
                        Hinh = reader["Hinh"].ToString()
                    };
                }
            }

            return sp;
        }

        public List<SanPham> TimKiemSanPham(int? maLoai, int? giaTu, int? giaDen)
        {
            List<SanPham> ds = new List<SanPham>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM tbl_SanPham WHERE 1=1";
                SqlCommand cmd = new SqlCommand();

                if (maLoai.HasValue)
                {
                    sql += " AND MaLoai = @maLoai";
                    cmd.Parameters.AddWithValue("@maLoai", maLoai.Value);
                }

                if (giaTu.HasValue)
                {
                    sql += " AND Gia >= @giaTu";
                    cmd.Parameters.AddWithValue("@giaTu", giaTu.Value);
                }

                if (giaDen.HasValue)
                {
                    sql += " AND Gia <= @giaDen";
                    cmd.Parameters.AddWithValue("@giaDen", giaDen.Value);
                }

                cmd.CommandText = sql;
                cmd.Connection = conn;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ds.Add(new SanPham
                    {
                        MaSanPham = Convert.ToInt32(reader["MaSanPham"]),
                        TenSP = reader["TenSP"].ToString(),
                        MaLoai = Convert.ToInt32(reader["MaLoai"]),
                        MaNSX = Convert.ToInt32(reader["MaNSX"]),
                        Gia = Convert.ToDecimal(reader["Gia"]),
                        GhiChu = reader["GhiChu"].ToString(),
                        Hinh = reader["Hinh"].ToString()
                    });
                }
            }

            return ds;
        }


    }

}