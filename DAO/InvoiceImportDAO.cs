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
    public class InvoiceImportDAO
    {
        //Truy vấn tất cả các Hóa đơn nhập
        public static DataTable GetAll()
        {
            string sql = "SELECT * FROM HOADONNHAP";
            SqlParameter[] parameters = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(sql, parameters);
        }

        //Truy vấn Hóa đơn nhập theo Mã Hóa Đơn
        public static DataRow GetByMAHD(string ma)
        {
            string sql = "SELECT * FROM HOADONNHAP WHERE MAHD = @MAHD";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@MAHD", ma);
            return DataProvider.ExecuteSelectQuery(sql, parameters).Rows[0];
        }

        //Thêm Hóa đơn nhập
        public static bool Add(InvoiceImport invoice)
        {
            string sql = "INSERT INTO HOADONNHAP (MAHD, MANV, THOIGIAN, TONGTIEN, TRANGTHAI) VALUES (@MAHD, @MANV, @THOIGIAN, @TONGTIEN, @TRANGTHAI)";
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@MAHD", invoice.MAHD);
            parameters[1] = new SqlParameter("@MANV", invoice.MANV);
            parameters[2] = new SqlParameter("@THOIGIAN", invoice.THOIGIAN);
            parameters[3] = new SqlParameter("@TONGTIEN", invoice.TONGTIEN);
            parameters[4] = new SqlParameter("@TRANGTHAI", invoice.TRANGTHAI);
            return DataProvider.ExecuteNonQuery(sql, parameters) == 1;
        }

        //Chỉnh sửa hóa đơn nhập
        public static bool Edit(InvoiceImport invoice)
        {
            string sql = "UPDATE HOADONNHAP SET MANV = @MANV, THOIGIAN = @THOIGIAN, TONGTIEN = @TONGTIEN, TRANGTHAI = @TRANGTHAI WHERE MAHD = @MAHD ";
            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@MAHD", invoice.MAHD);
            par[1] = new SqlParameter("@MANV", invoice.MANV);
            par[2] = new SqlParameter("@THOIGIAN", invoice.THOIGIAN);
            par[3] = new SqlParameter("@TONGTIEN", invoice.TONGTIEN);
            par[4] = new SqlParameter("@TRANGTHAI", invoice.TRANGTHAI);
            return DataProvider.ExecuteNonQuery(sql, par) == 1;
        }

        //Xóa hóa đơn nhập
        public static bool Del(string id)
        {
            string sql = "DELETE FROM HOADONNHAP WHERE MAHD = @Id";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@Id", id);
            return DataProvider.ExecuteNonQuery(sql, par) == 1;
        }

        //Truy vấn theo mã hóa đơn 
        public static DataTable GetByName(string name)
        {
            string sql = "SELECT * FROM HOADONNHAP WHERE MAHD like @Name";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Name", '%' + name + '%');
            return DataProvider.ExecuteSelectQuery(sql, parameters);
        }
    }
}
