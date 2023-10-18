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
            loginForm_textBox1.Clear();
            loginForm_textBox2.Clear();
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            DatabaseManager dbManager = new DatabaseManager();
            dbManager.OpenConnection();
            string query = "Select * from dbo.Users Where login = @login and password = @password";
            SqlCommand command = new SqlCommand
            {
                Connection = dbManager.Connection,
                CommandType = CommandType.Text,
                CommandText = query
            };
            command.Parameters.AddWithValue("@login", loginForm_textBox1.Text);
            command.Parameters.AddWithValue("@password", loginForm_textBox1.Text);

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
    }
}
