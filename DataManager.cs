using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDB1
{

    public class DatabaseManager
    {
        
        public string connectionString = @"Data Source=DKONZERSKY-ASUS;Initial Catalog=TestDB;User ID=sa;Password=Detroit254!";
        public SqlConnection Connection;
        public DatabaseManager()
        {
            Connection = new SqlConnection(connectionString); // СЮДА КИДАЮТСЯ ПАРАМЕТРЫ СОЕДИНЕНИЯ 
        }
        public void OpenConnection()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
        }
        public void CloseConnection()
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }
        public SqlDataReader ExecuteQuery(string query)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand(query, Connection);
            return command.ExecuteReader();
        }
    }
    public class DataManager
    {
        private readonly DatabaseManager DBManager;

        public DataManager()
        {
            DBManager = new DatabaseManager();
        }
        public List<string[]> GetDataFromDatabase()
        {
            string query = "SELECT domain_name, expire_date, days_left FROM dbo.Domains ORDER BY days_left";
            SqlDataReader reader = DBManager.ExecuteQuery(query);
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                string[] row = new string[3];
                row[0] = reader[0].ToString();

                // Получаем дату из базы данных (например, "2024-02-01")
                string dbDate = reader[1].ToString();

                // Преобразуем дату из строки в объект DateTime
                DateTime dateValue;
                if (DateTime.TryParse(dbDate, out dateValue))
                {
                    // Форматируем дату в строку "dd.MM.yyyy" (например, "01.02.2024")
                    row[1] = dateValue.ToString("dd.MM.yyyy");

                    // Вычисляем разницу между этой датой и текущей датой
                    TimeSpan difference = dateValue - DateTime.Now;
                    // Записываем разницу в днях в row[2]
                    row[2] = Convert.ToInt32(difference.TotalDays).ToString();
                }
                else
                {
                    // Если формат даты некорректен, оставляем значение как есть
                    row[1] = dbDate;
                    row[2] = "Некорректная дата";
                }

                data.Add(row);
            }

            reader.Close();
            DBManager.CloseConnection();
            return data;
        }
    }
    public class DataChecker
    {
        public string connectionString = @"Data Source=DKONZERSKY-ASUS;Initial Catalog=TestDB;User ID=sa;Password=Detroit254!";
        public bool CheckValueInDatabase(string tableName, string columnName, string valueToCheck)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = $"SELECT 1 FROM {tableName} WHERE {columnName} = @ValueToCheck";
                    command.Parameters.AddWithValue("@ValueToCheck", valueToCheck);
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return true; // Значение найдено
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ошибка SQL: " + ex.Message);
                    }
                }
            }
            return false; // Значение не найдено
        }
    }


}
