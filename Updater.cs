using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB1
{
    public class Updater
    {
        Connectors Connector = new Connectors();
        public void Update()
        {
            Connector.ConnectToDB();
            string query = "SELECT * FROM dbo.Domains ORDER BY days_left";
            SqlCommand command = new SqlCommand();
            command.Connection = Connector.Connector;
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[3]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
            }
            reader.Close();


        }
    }
}
