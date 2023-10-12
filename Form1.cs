using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace TestDB1
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectToDB();
            MessageBox.Show("Connection Open  !");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisconnectFromDB();
            MessageBox.Show("Connection Close  !");
        } 
    }
}
