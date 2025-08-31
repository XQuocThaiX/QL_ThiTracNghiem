using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Windows.Forms;

namespace QLShop
{
    class DBConnect
    {
        public static string stringConnection = @"Data source = .; Initial Catalog = QL_THITRACNGHIEM; INTEGRATED SECURITY= TRUE; Connection Timeout=5";

        public SqlConnection conn = new SqlConnection();

        public DBConnect()
        {
            conn = new SqlConnection(stringConnection);
        }

        public void Open()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public void Close()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public int ExecuteNonQuery(string commandText, Dictionary<string, object> parameters, bool isStoredProcedure = false)
        {
            using (SqlConnection conn = new SqlConnection(stringConnection))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    // Kiểm tra nếu là thủ tục
                    if (isStoredProcedure)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }

                    // Thêm tham số
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ExecuteStoredProcedure(string procedureName, Dictionary<string, object> parameters)
        {
            using (SqlConnection conn = new SqlConnection(stringConnection))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số nếu có
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    // Tạo DataAdapter để điền dữ liệu vào DataTable
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt; // Trả về DataTable chứa kết quả
                    }
                }
            }
        }

        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(stringConnection))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters if provided
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    // Create DataAdapter to fill the DataTable
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public object ExecuteScalar(string commandText, Dictionary<string, object> parameters = null, bool isStoredProcedure = false)
        {
            using (SqlConnection conn = new SqlConnection(stringConnection))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    if (isStoredProcedure)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }

}
