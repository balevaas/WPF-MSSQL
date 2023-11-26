using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes
{
    /*
     ,ProductCategory
      ,ProductPhoto
      ,ProductManufacturer
      ,ProductCost
      ProductDiscountAmount
      ,ProductQuantityInStock
    */
    public class DataBase
    {
        public static string connectionString = @"Data Source=Anastasia-ПК; Initial Catalog=Trade; Integrated Security=True;";
        private readonly SqlConnection connection = new SqlConnection(connectionString);

        public DataTable SqlSelect(string cmd)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();            
            SqlCommand command = new SqlCommand(cmd, conn);
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Метод для открытия соединения с БД
        /// </summary>
        public void OpenConnection()
        {
            // Если состояние строки закрыто, открываем
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        /// <summary>
        /// Метод для закрытия соединения с БД
        /// </summary>
        public void CloseConnection()
        {
            // Если состояние строки открыто, закрываем
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Метод для возвращения строки подключения
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
