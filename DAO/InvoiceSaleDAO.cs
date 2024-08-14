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
    public class InvoiceSaleDAO
    {
        //Truy vấn tất cả hóa đơn bán
        public static DataTable GetAll()
        {
            string sql = "SELECT * FROM HOADONBAN";
            SqlParameter[] parameters = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(sql, parameters);
        }

        //Truy vấn Hóa đơn bán theo má hóa đơn
        public static DataRow GetByMAHD(string ma)
        {
            string sql = "SELECT * FROM HOADONBAN WHERE MAHD = @MAHD";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@MAHD", ma);
            return DataProvider.ExecuteSelectQuery(sql, parameters).Rows[0];
        }

        //Thêm hóa đơn bán 
        public static bool Add(InvoiceSale invoice)
        {
            string sql = "INSERT INTO HOADONBAN (MAHD, MANV, THOIGIAN, TONGTIEN, TRANGTHAI) VALUES (@MAHD, @MANV, @THOIGIAN, @TONGTIEN, @TRANGTHAI)";
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@MAHD", invoice.MAHD);
            parameters[1] = new SqlParameter("@MANV", invoice.MANV);
            parameters[2] = new SqlParameter("@THOIGIAN", invoice.THOIGIAN);
            parameters[3] = new SqlParameter("@TONGTIEN", invoice.TONGTIEN);
            parameters[4] = new SqlParameter("@TRANGTHAI", invoice.TRANGTHAI);
            return DataProvider.ExecuteNonQuery(sql, parameters) == 1;
        }

        //Chỉnh sửa hóa đơn bán
        public static bool Edit(InvoiceSale invoice)
        {
            string sql = "UPDATE HOADONBAN SET MANV = @MANV, THOIGIAN = @THOIGIAN, TONGTIEN = @TONGTIEN, TRANGTHAI = @TRANGTHAI WHERE MAHD = @MAHD ";
            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@MAHD", invoice.MAHD);
            par[1] = new SqlParameter("@MANV", invoice.MANV);
            par[2] = new SqlParameter("@THOIGIAN", invoice.THOIGIAN);
            par[3] = new SqlParameter("@TONGTIEN", invoice.TONGTIEN);
            par[4] = new SqlParameter("@TRANGTHAI", invoice.TRANGTHAI);
            return DataProvider.ExecuteNonQuery(sql, par) == 1;
        }

        //Xóa hóa đơn bán
        public static bool Del(string id)
        {
            string sql = "DELETE FROM HOADONBAN WHERE MAHD = @Id";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@Id", id);
            return DataProvider.ExecuteNonQuery(sql, par) == 1;
        }

        //Truy vấn Hóa đơn bán theo mã hóa đơn
        public static DataTable GetByName(string name)
        {
            string sql = "SELECT * FROM HOADONBAN WHERE MAHD like @Name";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Name", '%' + name + '%');
            return DataProvider.ExecuteSelectQuery(sql, parameters);
        }

        public static DataTable GetStat()
        {
            string sql = "select HOADONBAN.THOIGIAN, SUM (CHITIET_HOADONBAN.GIATIEN * CHITIET_HOADONBAN.SL) as DOANHTHU from CHITIET_HOADONBAN join HOADONBAN on CHITIET_HOADONBAN.MAHD = HOADONBAN.MAHD group by HOADONBAN.THOIGIAN";
            SqlParameter[] par = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(sql, par);
        }

        // lấy ra danh sách hóa đơn bán theo ngày
        public static DataTable GetByDayEnH(string day, string month, string year)
        {
            string sql = "SELECT * FROM GetDay(@day, @month, @year)";
            SqlParameter[] par = new SqlParameter[3];
            par[0] = new SqlParameter("@day", day);
            par[1] = new SqlParameter("@month", month);
            par[2] = new SqlParameter("@year", year);
            return DataProvider.ExecuteSelectQuery(sql, par);
        }
        public static DataTable GetDayToDay(DateTime dt1, DateTime dt2)
        {
            string sql = "Select * from GetDayToDay(@dt1, @dt2)";
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@dt1", dt1);
            par[1] = new SqlParameter("@dt2", dt2);
            return DataProvider.ExecuteSelectQuery(sql, par);
        }
        public static DataTable GetDay(DateTime dt1)
        {
            string sql = "Select * from GetDay(@dt1)";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@dt1", dt1);
            return DataProvider.ExecuteSelectQuery(sql, par);
        }
        public static DataTable GetByMonthEnH(string month, string year)
        {
            string sql = "SELECT * FROM GetMonth(@month, @year)";
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@month", month);
            par[1] = new SqlParameter("@year", year);
            return DataProvider.ExecuteSelectQuery(sql, par);
        }
        public static DataTable GetByYearEnH(string year)
        {
            string sql = "SELECT * FROM GetYear(@year)";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@year", year);
            return DataProvider.ExecuteSelectQuery(sql, par);
        }
        public static object GetDoanhThuDayToDay(DateTime dt1, DateTime dt2)
        {
            string sql = "select sum(DOANHTHU) as TONGDOANHTHU from GetDayToDay(@dt1, @dt2)";
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@dt1", dt1);
            par[1] = new SqlParameter("@dt2", dt2);
            return DataProvider.getScalar(sql, par);
        }
        public static DataTable GetDoanhThuMonth(string month, string year)
        {
            string sql = "select sum(DOANHTHU) as TONGDOANHTHU from GetMonth(@month,@year)";
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@month", month);
            par[1] = new SqlParameter("@year", year);
            return DataProvider.ExecuteSelectQuery(sql, par);
        }
        public static DataTable GetDoanhThuYear(string year)
        {
            string sql = "select sum(DOANHTHU) as TONGDOANHTHU from GetYear(@year)";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@year", year);
            return DataProvider.ExecuteSelectQuery(sql, par);
        }
        public static DataTable GetByDayTotalEnH(string d, string m, string y)
        {
            string sql = @"exec GetDayTotal @day = @d, @month = @m, @year = @y";
            SqlParameter[] par = new SqlParameter[3];
            par[0] = new SqlParameter("@d", d);
            par[1] = new SqlParameter("@m", m);
            par[2] = new SqlParameter("@y", y);
            return DataProvider.ExecuteSelectQuery(sql, par);
        }

        public static DataTable GetByMonthTotalEnH(string m, string y)
        {
            string sql = @"exec GetMonthTotal @month = @m, @year = @y";
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@m", m);
            par[1] = new SqlParameter("@y", y);
            return DataProvider.ExecuteSelectQuery(sql, par);
        }

        public static DataTable GetByYearTotalEnH(string y)
        {
            string sql = @"exec GetYearTotal @year = @y";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@y", y);
            return DataProvider.ExecuteSelectQuery(sql, par);
        }

        public static DataTable GetCHITIETHD(string ma)
        {
            string sql = @"select CHITIET_HOADONBAN.*, TENSACH from CHITIET_HOADONBAN join HOADONBAN on HOADONBAN.MAHD = CHITIET_HOADONBAN.MAHD join SACH on SACH.MASACH = CHITIET_HOADONBAN.MASACH where CHITIET_HOADONBAN.MAHD = @ma";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@ma", ma);
            return DataProvider.ExecuteSelectQuery(sql, par);
        }
    }
}
