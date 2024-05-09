using System;
using System.Windows.Forms;

namespace TicTacGame
{
    internal class Registration
    {
        static public bool CheckAccountExistence(string log)
        {
            try
            {
                BDConnection.msCommand.CommandText = "SELECT COUNT(*) FROM users WHERE login = '" + log + "'";
                object result = BDConnection.msCommand.ExecuteScalar();
                int count = Convert.ToInt32(result);

                return count > 0;
            }
            catch
            {
                MessageBox.Show("Ошибка при проверке аккаунта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static public void RegistrationAccount(string log, string pass)
        {
            try
            {
                BDConnection.msCommand.CommandText = @"INSERT INTO users (login, pass) VALUES ('" + log + "', '" + pass + "');";
                BDConnection.msCommand.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("Ошибка при регистрации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
