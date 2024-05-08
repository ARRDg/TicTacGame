using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

namespace TicTacGame
{
    public partial class Form1 : Form
    {
        static public string currentLogin, currentPassword;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BDConnection.ConnectoinBD();
            CheckChanger();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            BDConnection.CloseBD();
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (ChechPasswordAnsLogin() == false)
                return;

            currentLogin = guna2TextBox1.Text;
            currentPassword = guna2TextBox2.Text;

            if (!Registration.CheckAccountExistence(currentLogin))
            {
                Registration.RegistrationAccount(currentLogin, currentPassword);
                Form MM = new MainMenu();
                MM.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Аккаунт с таким логином уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ChechPasswordAnsLogin()
        {
            ValidationLogin validLogin = new ValidationLogin();

            if (validLogin.Validation(guna2TextBox1.Text) == false)
                return false;

            if (guna2TextBox3.Text == guna2TextBox1.Text)
            {
                MessageBox.Show("Пороль и логин не должны совпадать.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ValidationPass validPass = new ValidationPass();
            if (validPass.Validation(guna2TextBox2.Text) == false)
                return false;

            if (guna2TextBox3.Text != guna2TextBox2.Text)
            {
                MessageBox.Show("Пороли не совпадают.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            currentLogin = guna2TextBox6.Text;
            currentPassword = guna2TextBox4.Text;

            if (string.IsNullOrWhiteSpace(currentLogin))
            {
                MessageBox.Show("Поле с логином пустое", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(currentPassword))
            {
                MessageBox.Show("Поле с паролем пустое", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool resualt = Authorization.AuthorizationAccount(currentLogin, currentPassword);
            if (resualt)
            {
                Registration.RegistrationAccount(currentLogin, currentPassword);
                Form MM = new MainMenu();
                MM.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Логин или пароль неверны либо аккаунта не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckChanger();
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckChanger();
        }

        private void CheckChanger()
        {
            if (!guna2CheckBox1.Checked)
            {
                guna2TextBox3.UseSystemPasswordChar = true;
                guna2TextBox2.UseSystemPasswordChar = true;
            }
            else if (guna2CheckBox1.Checked)
            {
                guna2TextBox3.UseSystemPasswordChar = false;
                guna2TextBox2.UseSystemPasswordChar = false;
            }

            if (!guna2CheckBox2.Checked)
            {
                guna2TextBox4.UseSystemPasswordChar = true;
            }
            else if (guna2CheckBox2.Checked)
            {
                guna2TextBox4.UseSystemPasswordChar = false;
            }
        }
    }
}
