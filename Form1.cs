using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestDB1
{


    public partial class Form1 : Form
    {
        Connectors Connector = new Connectors();
        public Form1()
        {
            InitializeComponent();
            Connector.ConnectToDB();


            string query = "SELECT * FROM dbo.Domains ORDER BY domain_name";
            SqlCommand command = new SqlCommand();
            command.Connection = Connector.Connector;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read() == true)
            {

            }
            else
            {
                MessageBox.Show("Неверные логин или пароль");
            }



        }

                        // Тянем методы из класса Connectors

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Connector.ConnectToDB();
        }
    }
}
