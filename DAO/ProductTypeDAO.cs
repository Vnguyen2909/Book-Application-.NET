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
    public class ProductTypeDAO
    {
        
        public static DataRow Get(int masach)
        {
            string sql = "SELECT * FROM LOAISACH WHERE MALOAISACH = @MALOAISACH";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@MALOAISACH", masach);
            return DataProvider.ExecuteSelectQuery(sql, par).Rows[0];
        }

        //LAY TOAN BO MALOAISACH DA TON TAI
        public static DataTable GetProductType()
        {
            string sql = "SELECT * FROM LOAISACH";
            SqlParameter[] par = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(sql, par);
        }

        //THEM LOAI SACH
        public static bool AddProductType(ProductType pt)
        {
            string sql = "INSERT INTO LOAISACH (MALOAISACH, LOAISACH) VALUES (@MALOAISACH, @LOAISACH)";
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@MALOAISACH", pt.MALOAISACH);
            par[1] = new SqlParameter("@LOAISACH", pt.LOAISACH);
            return DataProvider.ExecuteNonQuery(sql, par) == 1;
        }

        public static bool CheckExist(int maloaisach)
        {
            string query = "SELECT COUNT(*) FROM LOAISACH WHERE MALOAISACH = @MALOAISACH";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@MALOAISACH", maloaisach);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, parameters).Rows[0][0]) == 1;
        }

        public static bool CheckName(string loaisach)
        {
            string query = "SELECT COUNT(*) FROM LOAISACH WHERE LOAISACH = @LOAISACH";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@LOAISACH", loaisach);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, parameters).Rows[0][0]) == 1;
        }

        public static bool Del(int masach)
        {
            string sql = "DELETE FROM LOAISACH WHERE MALOAISACH = @MASACH";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@MASACH", masach);
            return DataProvider.ExecuteNonQuery(sql, par) == 1;
        }

        public static bool Edit(ProductType pt)
        {
            string sql = "UPDATE LOAISACH SET LOAISACH = @LOAISACH WHERE MALOAISACH = @MALOAISACH";
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@MALOAISACH", pt.MALOAISACH);
            par[1] = new SqlParameter("@LOAISACH", pt.LOAISACH);
            return DataProvider.ExecuteNonQuery(sql, par) == 1;
        }
        public static DataTable GetByName(string name)
        {
            string sql = "SELECT * FROM LOAISACH WHERE LOAISACH like @Name";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Name", '%' + name + '%');
            return DataProvider.ExecuteSelectQuery(sql, parameters);
        }
    }
}
