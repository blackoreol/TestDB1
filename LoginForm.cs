using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestDB1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public string login;
        public string password;
        public void button1_Click(object sender, EventArgs e)
        {
            login = textBox1.Text;
            password = textBox2.Text;
            if (login == "1" && password =="2")
            {
                ProgramFormOpen();
                this.Close();
            }
        }

        public void ProgramFormOpen()
        {
            Form1 form1 = new Form1();
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
