using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes
{    
    public class DataBase
    {
        // Строка подключения к БД, чтобы соединиться с вашей базой: 
        // Data Source = "{Название вашего сервера}",
        // InitialCatalog = "{Название вашей БД}" 
        private static string connectionString = @"Data Source=Anastasia-ПК; Initial Catalog=Trade; Integrated Security=True;";
        public SqlConnection connection = new SqlConnection(connectionString); // создаем соединение, передав в SqlConnection
                                                                        // строку подключения
       // Метод, который позволяет выполнять запросы типа Select
       // Существенно облегчает разработку приложения, так как избавляет от дублирования кода 
       // В качестве параметра передается строка запроса
        public DataTable SqlSelect(string cmd)
        {                       
            connection.Open();                                    // открываем соединение с БД          
            SqlCommand command = new SqlCommand(cmd, connection); // Формируем команду для MS SQL
            command.ExecuteNonQuery();                            // Выполняем запрос
            SqlDataAdapter adapter = new SqlDataAdapter(command); // Затем, полученные данные необходимо адаптировать под VS
            DataTable dt = new DataTable();                       // Создаем "виртуальную" таблицу, в которой сначала сформируется результат запроса
            adapter.Fill(dt);                                     // Заполняем ее через адаптер
            return dt;                                            // Возвращаем результат                
        }

        // Метод закрывающий соединение с БД
        public void CloseConnection()
        {
            // Если состояние строки открыто, закрываем
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Метод возвращающий строку подключения
        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
