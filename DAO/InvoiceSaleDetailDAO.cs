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
    public class InvoiceSaleDetailDAO
    {
        //Truy vấn tất cả chi tiết hóa đơn bán
        public static DataTable GetAll()
        {
            string sql = "SELECT * FROM CHITIET_HOADONBAN";
            SqlParameter[] parameters = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(sql, parameters);
        }

        //Tạo chi tiết hóa đơn 
        public static bool Add(InvoiceSaleDetail invoiceDetail)
        {
            string sql = "INSERT INTO CHITIET_HOADONBAN (MAHD, MASACH, SL, GIATIEN) VALUES (@MAHD, @MASACH, @SL, @GIATIEN)";
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@MAHD", invoiceDetail.MAHD);
            parameters[1] = new SqlParameter("@MASACH", invoiceDetail.MASACH);
            parameters[2] = new SqlParameter("@SL", invoiceDetail.SL);
            parameters[3] = new SqlParameter("@GIATIEN", invoiceDetail.GIATIEN);
            return DataProvider.ExecuteNonQuery(sql, parameters) == 1;
        }

        //Truy vấn Chi tiết hóa đơn theo mã hóa đơn
        public static DataRow GetByMAHD(int id)
        {
            string sql = "SELECT * FROM CHITIET_HOADONBAN WHERE Id = @MAHD";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@MAHD", id);
            return DataProvider.ExecuteSelectQuery(sql, par).Rows[0];
        }

        //Chỉnh sửa chi tiết hóa đơn
        public static bool Edit(int id, InvoiceSaleDetail invoice)
        {
            string qr = "UPDATE CHITIET_HOADONBAN SET MAHD = @MAHD, MASACH = @MASACH, SL = @SL, GIATIEN = @GIATIEN WHERE Id = @Id ";
            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@MAHD", invoice.MAHD);
            par[1] = new SqlParameter("@MASACH", invoice.MASACH);
            par[2] = new SqlParameter("@SL", invoice.SL);
            par[3] = new SqlParameter("@GIATIEN", invoice.GIATIEN);
            par[4] = new SqlParameter("@Id", id);
            return DataProvider.ExecuteNonQuery(qr, par) == 1;
        }

        //Xóa chi tiết hóa đơn
        public static bool Del(int id)
        {
            string qr = "DELETE FROM CHITIET_HOADONBAN WHERE Id = @Id";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@Id", id);
            return DataProvider.ExecuteNonQuery(qr, par) == 1;
        }

        //Truy vấn Chi tiết hóa đơn theo mã hóa đơn hoặc mã sách
        public static DataTable GetByName(string name)
        {
            string query = "SELECT * FROM CHITIET_HOADONBAN WHERE MAHD like @Name OR MASACH like @Name";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Name", '%' + name + '%');
            return DataProvider.ExecuteSelectQuery(query, parameters);
        }

        //Đếm chi tiết hóa đơn
        public static int CountProductSale(string ma)
        {
            string qr = "select count(*) from CHITIET_HOADONBAN where MASACH = @Id";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@Id", ma);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(qr, par).Rows[0][0]);
        }

        //Xóa chi tiết hóa đơn theo mã sách
        public static bool DeleteWithMASACH(string ma)
        {
            string qr = "delete from CHITIET_HOADONBAN where MASACH = @Id";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@Id", ma);
            return DataProvider.ExecuteNonQuery(qr, par) > 0;
        }
        public static DataTable GetCHITIETHDNHAP(string ma)
        {
            string sql = @"select CHITIET_HOADONNHAP.*, TENSACH FROM CHITIET_HOADONNHAP JOIN HOADONNHAP on dbo.HOADONNHAP.MAHD = CHITIET_HOADONNHAP.MAHD JOIN SACH on SACH.MASACH = CHITIET_HOADONNHAP.MASACH WHERE CHITIET_HOADONNHAP.MAHD = @ma";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@ma", ma);
            return DataProvider.ExecuteSelectQuery(sql, par);
        }
    }
}
