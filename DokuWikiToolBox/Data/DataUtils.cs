using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Data
{
    public static class DataUtils
    {
        //private static int GetCurrentId()
        //{

        //}

        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            return connection;
        }

        public static int GetProtocol()
        {
            SqlConnection connection = GetConnection();
            connection.Open();

            var command = new SqlCommand("select protocol from Actual", connection);
            int protocol = (int)command.ExecuteScalar();

            connection.Close();
            return protocol;
        }

        public static void SetProtocol(int protocol)
        {
            SqlConnection connection = GetConnection();
            connection.Open();

            string query = "update Actual set protocol = ";
            query += protocol;
            query += " where id = 1";

            var command = new SqlCommand(query, connection);
            command.ExecuteScalar();

            connection.Close();
        }
    }
}
