using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class ProductDAO
    {
        //TRUY VẤN LẤY MÃ SÁCH
        public static DataRow Get(string ma)
        {
            string sql = "SELECT * FROM SACH WHERE MASACH = @MASACH";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@MASACH", ma);
            return DataProvider.ExecuteSelectQuery(sql, par).Rows[0];
        }

        //Lấy 2 bảng ghép LOAI SACH VA SACH
        public static DataTable GetProduct()
        {
            string sql = "select *, LOAISACH.LOAISACH as THELOAI from SACH join LOAISACH on SACH.MALOAISACH = LOAISACH.MALOAISACH";
            SqlParameter[] parameters = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(sql, parameters);
        }
        public static DataTable GetProductNhaSanXuat()
        {
            string sql = "select *, NHAXUATBAN.TENNXB as NHAXUATBAN from SACH join NHAXUATBAN on SACH.MANXB = NHAXUATBAN.MANXB";
            SqlParameter[] parameters = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(sql, parameters);
        }

        public static DataTable GetProductTacGia()
        {
            string sql = "select *, TACGIA.TENTG as TACGIA from SACH join TACGIA on SACH.MATG = TACGIA.MATG";
            SqlParameter[] parameters = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(sql, parameters);
        }

        //Lây thông tin của từng mã sách
        public static DataTable GetMaSach()
        {
            string sql = "select ANH, MASACH as TONTAI, GIATIEN from SACH";
            SqlParameter[] parameters = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(sql, parameters);
        }

        //Lấy thông tin sách theo tên
        public static DataTable GetByName(string name)
        {
            string sql = "SELECT p.*, pt.LOAISACH AS THELOAI FROM SACH p JOIN LOAISACH pt ON p.MALOAISACH = pt.MALOAISACH WHERE p.TENSACH like @Name";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Name", '%' + name + '%');
            return DataProvider.ExecuteSelectQuery(sql, parameters);
        }

        //Thêm sách
        public static bool AddProducts(Product p)
        {
            string sql = "INSERT INTO SACH (MASACH, MALOAISACH, TENSACH, TENTACGIA, NHAXUATBAN, GIATIEN, SLTK, ANH) VALUES (@MASACH, @MALOAISACH, @TENSACH, @TENTACGIA, @NHAXUATBAN, @GIATIEN, @SLKT, @ANH)";
            SqlParameter[] par = new SqlParameter[8];
            par[0] = new SqlParameter("@MASACH", p.MASACH);
            par[1] = new SqlParameter("@MALOAISACH", p.MALOAISACH);
            par[2] = new SqlParameter("@TENSACH", p.TENSACH);
            par[3] = new SqlParameter("@TENTACGIA", p.MATACGIA);
            par[4] = new SqlParameter("@NHAXUATBAN", p.MANHAXUATBAN);
            par[5] = new SqlParameter("@GIATIEN", p.GIATIEN);
            par[6] = new SqlParameter("@SLKT", p.SLTK);
            par[7] = new SqlParameter("@ANH", p.ANH);
            return DataProvider.ExecuteNonQuery(sql, par) == 1;
        }

        //Sửa sách
        public static bool Edit(Product product)
        {
            string sql = "UPDATE SACH SET MALOAISACH = @MALOAISACH, TENSACH = @TENSACH, TENTACGIA = @TENTACGIA, NHAXUATBAN = @NHAXUATBAN, GIATIEN = @GIATIEN, SLTK = @SLTK, ANH = @ANH WHERE MASACH = @MASACH";
            SqlParameter[] par = new SqlParameter[8];
            par[0] = new SqlParameter("@MALOAISACH", product.MALOAISACH);
            par[1] = new SqlParameter("@TENSACH", product.TENSACH);
            par[2] = new SqlParameter("@TENTACGIA", product.MATACGIA);
            par[3] = new SqlParameter("@NHAXUATBAN", product.MANHAXUATBAN);
            par[4] = new SqlParameter("@GIATIEN", product.GIATIEN);
            par[5] = new SqlParameter("@SLTK", product.SLTK);
            par[6] = new SqlParameter("@ANH", product.ANH);
            par[7] = new SqlParameter("@MASACH", product.MASACH);
            return DataProvider.ExecuteNonQuery(sql, par) == 1;
        }

        //Check tồn tại có bao nhiêu sách theo mã sách
        public static bool CheckExist(string masach)
        {
            string sql = "SELECT COUNT(*) FROM SACH WHERE MASACH = @MASACH";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@MASACH", masach);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(sql, parameters).Rows[0][0]) == 1;
        }

       
        //Xóa theo mã sách
        public static bool Del(string masach)
        {
            string sql = "DELETE FROM SACH WHERE MASACH = @MASACH";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@MASACH", masach);
            return DataProvider.ExecuteNonQuery(sql, par) == 1;
        }

        public static DataTable TOP10()
        {
            string sql = "SELECT TOP 10 (SACH.MASACH), SACH.ANH, SACH.TENSACH, SACH.TENTACGIA, SACH.NHAXUATBAN, SUM(CHITIET_HOADONBAN.SL) as TONGLUOTMUA FROM CHITIET_HOADONBAN join SACH on CHITIET_HOADONBAN.MASACH = SACH.MASACH GROUP BY SACH.MASACH, SACH.ANH, SACH.TENSACH, SACH.TENTACGIA, SACH.NHAXUATBAN ORDER BY TONGLUOTMUA DESC";
            SqlParameter[] parameters = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(sql, parameters);
        }
        public static bool SubtrackStock(string MASACH, int qty)
        {
            string qr = "UPDATE SACH SET SLTK = SLTK - @Qty WHERE MASACH = @Masach";
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@Masach", MASACH);
            par[1] = new SqlParameter("@Qty", qty);
            return DataProvider.ExecuteNonQuery(qr, par) == 1;
        }

        public static bool PlusStock(string MASACH, int qty)
        {
            string qr = "UPDATE SACH SET SLTK = SLTK + @Qty WHERE MASACH = @Masach";
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@Masach", MASACH);
            par[1] = new SqlParameter("@Qty", qty);
            return DataProvider.ExecuteNonQuery(qr, par) == 1;
        }
    }
}
