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
            //string query2 = "SELECT * FROM dbo.Domains ORDER BY days_left";
            string query = "SELECT domain_name, LEFT(expire_date, LEN(expire_date) - 8) AS expire_date, days_left FROM dbo.Domains ORDER BY days_left";
            SqlDataReader reader = DBManager.ExecuteQuery(query);
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                string[] row = new string[3];
                row[0] = reader[0].ToString();
                row[1] = reader[1].ToString();
                row[2] = reader[2].ToString();
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

        //public DataChecker()
        //{
            //this.connectionString = connectionString;
        //}

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
