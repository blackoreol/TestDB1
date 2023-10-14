using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestDB1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            DatabaseManager dbManager = new DatabaseManager();
            dbManager.OpenConnection();
            string query = "Select * from dbo.Users Where login = @login and password = @password";
            SqlCommand command = new SqlCommand();
            command.Connection = dbManager.Connection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            command.Parameters.AddWithValue("@login", textBox1.Text);
            command.Parameters.AddWithValue("@password", textBox1.Text);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read() == true)
            {
                this.Hide();
                ProgramFormOpen();                          
            }
            else
            {
                MessageBox.Show("Неверные логин или пароль");
            }
        }

        public void ProgramFormOpen()
        {
            DomainForm form1 = new DomainForm();
            form1.ShowDialog();
        }

        private void textBox1_Click(object sender, System.EventArgs e)
        {
            textBox1.Clear();
        }
        private void textBox2_Click(object sender, System.EventArgs e)
        {
            textBox2.Clear();
        }
    }
}
