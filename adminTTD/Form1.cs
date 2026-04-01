using System;
using System.Drawing;
using System.Windows.Forms;

namespace adminTTD
{
    public partial class Form1 : Form
    {
        TextBox txtUsername;
        TextBox txtPassword;
        Button btnLogin;
        Label lblError;

        public Form1()
        {
            // Form
            this.Text = "Admin Login";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Label Username
            Label lblUser = new Label();
            lblUser.Text = "Username";
            lblUser.Location = new Point(50, 50);

            // TextBox Username
            txtUsername = new TextBox();
            txtUsername.Location = new Point(50, 70);
            txtUsername.Width = 250;

            // Label Password
            Label lblPass = new Label();
            lblPass.Text = "Password";
            lblPass.Location = new Point(50, 110);

            // TextBox Password
            txtPassword = new TextBox();
            txtPassword.Location = new Point(50, 130);
            txtPassword.Width = 250;
            txtPassword.UseSystemPasswordChar = true;

            // Button Login
            btnLogin = new Button();
            btnLogin.Text = "Đăng nhập";
            btnLogin.Location = new Point(50, 180);
            btnLogin.Width = 250;
            btnLogin.BackColor = Color.LightBlue;

            // Label Error
            lblError = new Label();
            lblError.Location = new Point(50, 220);
            lblError.ForeColor = Color.Red;
            lblError.AutoSize = true;

            // Event
            btnLogin.Click += BtnLogin_Click;

            // Add vào form
            this.Controls.Add(lblUser);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPass);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(lblError);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "123")
            {
                MessageBox.Show("Đăng nhập thành công!");

                FormMain f = new FormMain();
                f.Show();

                this.Hide();
            }
            else
            {
                lblError.Text = "Sai tài khoản hoặc mật khẩu!";
            }
        }
    }
}