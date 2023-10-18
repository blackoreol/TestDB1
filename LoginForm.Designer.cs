namespace TestDB1
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.loginForm_textBox1 = new System.Windows.Forms.TextBox();
            this.loginForm_textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Вход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // loginForm_textBox1
            // 
            this.loginForm_textBox1.Location = new System.Drawing.Point(75, 44);
            this.loginForm_textBox1.Name = "loginForm_textBox1";
            this.loginForm_textBox1.Size = new System.Drawing.Size(150, 22);
            this.loginForm_textBox1.TabIndex = 1;
            this.loginForm_textBox1.Text = "Логин";
            // 
            // loginForm_textBox2
            // 
            this.loginForm_textBox2.Location = new System.Drawing.Point(75, 94);
            this.loginForm_textBox2.Name = "loginForm_textBox2";
            this.loginForm_textBox2.PasswordChar = '*';
            this.loginForm_textBox2.Size = new System.Drawing.Size(150, 22);
            this.loginForm_textBox2.TabIndex = 2;
            this.loginForm_textBox2.Text = "пароль";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 233);
            this.Controls.Add(this.loginForm_textBox2);
            this.Controls.Add(this.loginForm_textBox1);
            this.Controls.Add(this.button1);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox loginForm_textBox1;
        private System.Windows.Forms.TextBox loginForm_textBox2;
    }
}