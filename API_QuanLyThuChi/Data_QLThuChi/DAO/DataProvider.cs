using Data_QLThuChi.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_QLThuChi.DAO
{
    public class DataProvider
    {
        public static string ConnectString = @"Data Source=tuan-pc;Initial Catalog=QLThuChi;Integrated Security=True";
        /// <summary>
        /// Thực thi thủ tục sql, dùng cho lúc chỉ cần thực thi thủ tục, không cần return trả về
        /// </summary>
        /// <param name="proc">tên thủ tục</param>
        /// <param name="para">parameter truyền vào</param>
        public void ExecuteNonqueryProc(string proc, SqlParameter[] para)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(proc, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (para != null)
                    cmd.Parameters.AddRange(para);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                
            }
        }

        /// <summary>
        /// Thực thi thủ tục sql, thích hợp dùng cho thao tác thêm sửa xóa bằng thủ tục
        /// </summary>
        /// <param name="proc">tên thủ tục</param>
        /// <param name="para">parameter truyền vào</param>
        /// <returns>Trả về ExecuteNonQuery: số dòng dữ liệu bị thay đổi</returns>
        public int returnExecuteNonqueryProc(string proc, SqlParameter[] para)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(proc, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (para != null)
                    cmd.Parameters.AddRange(para);
                int temp = cmd.ExecuteNonQuery();
                conn.Close();
                return temp;
            }
            catch (Exception ex)
            {       
                return 0;
            }
            finally
            {

            }
        }

        /// <summary>
        /// Thực thi câu lệnh sql thông thường, dùng cho truy vấn đơn giản
        /// </summary>
        /// <param name="sql">câu lệnh sql truyền vào</param>
        /// <returns>trả về ExecuteNonQuery: số dòng dữ liệu bị thay đổi</returns>
        public int returnExecuteNonquerySQL(string sql)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int temp = cmd.ExecuteNonQuery();
                conn.Close();
                return temp;
            }
            catch (Exception ex)
            {             
                return 0;
            }
        }


        /// <summary>
        /// Thực thi thủ tục sql, dùng trong trường hợp thủ tục trả về một giá trị đơn
        /// </summary>
        /// <param name="proc">tên thủ tục</param>
        /// <param name="para">parameter truyền vào</param>
        /// <returns>Trả về ô dữ liệu đầu tại vị trí [0][0] của kết quả</returns>
        public int returnScarlar(string proc, SqlParameter[] para)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(proc, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (para != null)
                    cmd.Parameters.AddRange(para);
                int temp = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                return temp;
            }
            catch (Exception ex)
            {
               
                return 0;
            }
        }


        /// <summary>
        /// Thực thi câu lệnh sql, dùng cho truy vấn đơn giản bằng câu lệnh sql
        /// </summary>
        /// <param name="sql">Câu lệnh sql</param>
        /// <returns>Trả về dữ liệu dạng bảng là dataTable: </returns>
        /// Các dùng vd: DAL_Handle hd = new DAL_Handle();
        ///              DataTable dt = hd.GetData(câu lệnh sql);
        public DataTable GetData(string sql)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }

        /// <summary>
        /// Thực thi thủ tục sql, dùng cho truy vấn bằng thủ tục
        /// </summary>
        /// <param name="proc">tên thủ tục</param>
        /// <param name="para">parameter truyền vào</param>
        /// <returns>Trả về dữ liệu dạng bảng DataTable</returns>
        public DataTable GetDataProc(string proc, SqlParameter[] para)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(ConnectString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(proc, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (para != null)
                    cmd.Parameters.AddRange(para);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {   
                return dt;
            }
        }

        static SqlConnection OpenConnection()
        {
            if (string.IsNullOrEmpty(ConnectString))
            {
                throw new Exception("Connection string can't be null or empty");
            }
            var _connection = new SqlConnection(ConnectString);
            _connection.Open();
            return _connection;
        }

        public static SqlCommand CreateSqlCommand(string query, List<SqlParameter> parameters, CommandType commandType)
        {
            if (commandType != CommandType.StoredProcedure)
            {
                throw new Exception("This command type is not supported in SBV Project");
            }
            var _command = new SqlCommand()
            {
                Connection = OpenConnection(),
                CommandText = query,
                CommandType = commandType
            };

            if (parameters != null)
            {
                foreach (var para in parameters)
                {
                    _command.Parameters.Add(para);
                }
            }
            return _command;
        }

        public static IDataReader ExecuteReader(string query, List<SqlParameter> parameters) //
        {
            var _command = CreateSqlCommand(query, parameters, CommandType.StoredProcedure);
            return _command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static int ExecuteNonQuery(string query, List<SqlParameter> parameters)
        {
            var _command = CreateSqlCommand(query, parameters, CommandType.StoredProcedure);
            int rowAffected = _command.ExecuteNonQuery();
            _command.Connection.Close();
            _command.Connection.Dispose();
            _command.Dispose();
            return rowAffected;
        }

    }
}
