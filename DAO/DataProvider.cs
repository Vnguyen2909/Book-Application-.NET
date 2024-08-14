using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DataProvider
    {
        private static SqlDataAdapter adapter = new SqlDataAdapter();
        private static SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-3JB6IQD2;Initial Catalog=DBQL_NhaSach_FN;Integrated Security=True");

        private static SqlConnection OpenConnection()
        {
            if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.Open();
            }
            return con;
        }

        /// <summary>
        /// Phương thức ExecuteSelectQuery() giúp thực thi câu truy vấn SELECT
        /// </summary>
        /// <param name="query">Câu truy vấn, có thể kèm theo tham số (string)</param>
        /// <param name="parameters">Danh sách tham số (SqlParatemer[])</param>
        /// <returns>Bảng kết quả truy vấn (DataTable)</returns>
        public static DataTable ExecuteSelectQuery(string query, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable result = new DataTable();
            try
            {
                cmd.Connection = OpenConnection();
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameters);
                adapter.SelectCommand = cmd;
                adapter.Fill(result);
                con.Close();
            }
            catch
            {
                return null;
            }
            return result;
        }

        /// <summary>
        /// Phương thức ExecuteNonQuery() giúp thực thi câu truy vấn INSERT, UPDATE, DELETE
        /// </summary>
        /// <param name="query">Câu truy vấn, có thể kèm theo tham số (string)</param>
        /// <param name="parameters">Danh sách tham số (SqlParatemer[])</param>
        /// <returns>Số dòng bị ảnh hưởng bởi câu truy vấn này (int)</returns>
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            int rowsAffected;                           //Dòng thực thi 
            try
            {
                cmd.Connection = OpenConnection();
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameters);
                rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                return 0;
            }
            return rowsAffected;
        }
        public static object getScalar(string sql, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            object rowsAffected;                           //Dòng thực thi 
            try
            {
                cmd.Connection = OpenConnection();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
                rowsAffected = cmd.ExecuteScalar();
                con.Close();
            }
            catch
            {
                return 0;
            }
            return rowsAffected;

        }
    }
}
