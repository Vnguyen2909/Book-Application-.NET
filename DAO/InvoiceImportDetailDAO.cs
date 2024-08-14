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
    public class InvoiceImportDetailDAO
    {
        //Truy vấn tất cả các chi tiêt hóa đơn nhập
        public static DataTable GetAll()
        {
            string sql = "SELECT * FROM CHITIET_HOADONNHAP";
            SqlParameter[] parameters = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(sql, parameters);
        }

        //Thêm Chi tiết hóa đơn nhập
        public static bool Add(InvoiceImportDetail invoiceDetail)
        {
            string sql = "INSERT INTO CHITIET_HOADONNHAP (MAHD, MASACH, SL, GIATIEN) VALUES (@MAHD, @MASACH, @SL, @GIATIEN)";
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@MAHD", invoiceDetail.MAHD);
            parameters[1] = new SqlParameter("@MASACH", invoiceDetail.MASACH);
            parameters[2] = new SqlParameter("@SL", invoiceDetail.SL);
            parameters[3] = new SqlParameter("@GIATIEN", invoiceDetail.GIATIEN);
            return DataProvider.ExecuteNonQuery(sql, parameters) == 1;
        }

        //Truy vấn Chi tiết hóa đơn theo mã Hóa đơn
        public static DataRow GetByMAHD(int id)
        {
            string sql = "SELECT * FROM CHITIET_HOADONNHAP WHERE Id = @MAHD";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@MAHD", id);
            return DataProvider.ExecuteSelectQuery(sql, par).Rows[0];
        }

        //Chỉnh sửa chi tiết hóa đơn
        public static bool Edit(int id, InvoiceImportDetail invoice)
        {
            string sql = "UPDATE CHITIET_HOADONNHAP SET MAHD = @MAHD, MASACH = @MASACH, SL = @SL, GIATIEN = @GIATIEN WHERE Id = @Id ";
            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@MAHD", invoice.MAHD);
            par[1] = new SqlParameter("@MASACH", invoice.MASACH);
            par[2] = new SqlParameter("@SL", invoice.SL);
            par[3] = new SqlParameter("@GIATIEN", invoice.GIATIEN);
            par[4] = new SqlParameter("@Id", id);
            return DataProvider.ExecuteNonQuery(sql, par) == 1;
        }

        //Xóa chỉ tiết hóa đơn
        public static bool Del(int id)
        {
            string sql = "DELETE FROM CHITIET_HOADONNHAP WHERE Id = @Id";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@Id", id);
            return DataProvider.ExecuteNonQuery(sql, par) == 1;
        }

        //Truy vấn tên theo mã sách
        public static DataTable GetByName(string name)
        {
            string query = "SELECT * FROM CHITIET_HOADONNHAP WHERE MAHD like @Name OR MASACH like @Name";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Name", '%' + name + '%');
            return DataProvider.ExecuteSelectQuery(query, parameters);
        }

        //Truy vấn giá tiền
        public static decimal GetPrice(string ma)
        {
            string sql = "select GIATIEN from SACH where MASACH = @ma";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@ma", ma);
            return Convert.ToDecimal(DataProvider.ExecuteSelectQuery(sql, par).Rows[0][0]);
        }

        //Truy vấn đếm số sách trong hóa đơn nhập
        public static int CountProductImport(string ma)
        {
            string sql = "select count(*) from CHITIET_HOADONNHAP where MASACH = @Id";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@Id", ma);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(sql, par).Rows[0][0]);
        }

        //Xóa chi tiết hóa đơn theo mã sách
        public static bool DeleteWithMASACH(string ma)
        {
            string sql = "delete from CHITIET_HOADONNHAP where MASACH = @Id";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@Id", ma);
            return DataProvider.ExecuteNonQuery(sql, par) > 0;
        }
    }
}
