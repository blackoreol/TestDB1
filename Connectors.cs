using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace TestDB1
{
    
    public class Connectors

    {
        public SqlConnection Connector;
        public string ConnetionString;

        public void ConnectToDB()
        {
            ConnetionString = @"Data Source=DKONZERSKY-ASUS;Initial Catalog=TestDB;User ID=sa;Password=Detroit254!";
            Connector = new SqlConnection(ConnetionString);
            Connector.Open();
            
        }

        public void DisconnectFromDB()
        {
            Connector.Close();
        }
    }
}
