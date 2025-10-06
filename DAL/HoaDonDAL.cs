using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using _2001230507_NhanTuManh_B5.Models;

namespace _2001230507_NhanTuManh_B5.DAL
{
    public class HoaDonDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public List<HoaDon> GetHoaDonByKhachHang(int maKH)
        {
            List<HoaDon> dsHD = new List<HoaDon>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT MaHD, MaKH, NgayLap FROM tbl_HoaDon WHERE MaKH = @maKH";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maKH", maKH);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    HoaDon hd = new HoaDon
                    {
                        MaHoaDon = Convert.ToInt32(reader["MaHD"]),
                        MaKH = Convert.ToInt32(reader["MaKH"]),
                        NgayTao = Convert.ToDateTime(reader["NgayLap"]),
                        ChiTietHoaDon = GetChiTietHoaDon(Convert.ToInt32(reader["MaHD"]))
                    };

                    dsHD.Add(hd);
                }
            }

            return dsHD;
        }

        public List<ChiTietHoaDon> GetChiTietHoaDon(int maHD)
        {
            List<ChiTietHoaDon> ds = new List<ChiTietHoaDon>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"SELECT c.MaHD, c.MaSP, c.SoLuong, 
                                      s.TenSP, s.Gia, s.Hinh
                               FROM ChiTietHD c
                               JOIN SanPham s ON c.MaSP = s.MaSanPham
                               WHERE c.MaHD = @maHD";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maHD", maHD);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ChiTietHoaDon ct = new ChiTietHoaDon
                    {
                        MaHD = Convert.ToInt32(reader["MaHD"]),
                        MaSP = Convert.ToInt32(reader["MaSP"]),
                        SoLuong = Convert.ToInt32(reader["SoLuong"]),
                        SanPham = new SanPham
                        {
                            MaSanPham = Convert.ToInt32(reader["MaSP"]),
                            TenSP = reader["TenSP"].ToString(),
                            Gia = Convert.ToDecimal(reader["Gia"]),
                            Hinh = reader["Hinh"].ToString()
                        }
                    };

                    ds.Add(ct);
                }
            }

            return ds;
        }
    }
}
