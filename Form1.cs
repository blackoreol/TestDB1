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
        Connectors Connector = new Connectors();

        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Connector.ConnectToDB();
            MessageBox.Show("Connection Open  !");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connector.DisconnectFromDB();
            MessageBox.Show("Connection Close  !");
        } 
    }
}
