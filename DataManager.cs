using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace TestDB1
{

    public class DatabaseManager
    {
        
        public string connectionString = @"Data Source=DKONZERSKY-ASUS;Initial Catalog=TestDB;User ID=sa;Password=Detroit254!";

        public SqlConnection Connection { get; set; }

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
        private DatabaseManager DBManager { get; set; }

        public DataManager()
        {
            DBManager = new DatabaseManager();
        }

        public List<string[]> GetDataFromDatabase()
        {
            string query = "SELECT * FROM dbo.Domains ORDER BY days_left";
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


}
