using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestDB1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void ConnectToDB()
        {
            string ConnetionString;
            SqlConnection Connector;
            ConnetionString = @"Data Source=DKONZERSKY-ASUS;Initial Catalog=TestDB;User ID=sa;Password=Detroit254!";
            Connector = new SqlConnection(ConnetionString);
            Connector.Open();
            MessageBox.Show("Connection Open  !");
            Connector.Close();
        }
        public void CloseConnectToDB()
        {
            string ConnetionString;
        }

        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ConnectToDB();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
