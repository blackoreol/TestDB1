using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB1
{
    public class updatesql
    {
        public SqlConnection Connect;
        public string ConnetionString;


        public void Update()
        {
        Connectors Connection = new Connectors();
        Connection.ConnectToDB();
        string query = "SELECT * FROM dbo.Domains ORDER BY days_left";
        SqlCommand command = new SqlCommand();
        command.Connection = Connection.Connector;
        command.CommandType = CommandType.Text;
        command.CommandText = query;
        SqlDataReader reader = command.ExecuteReader();
        List<string[]> data = new List<string[]>();

        }





        
    }
}
