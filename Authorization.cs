using System;
using System.Windows.Forms;

namespace TicTacGame
{
    internal class Authorization
    {
        static public bool AuthorizationAccount(string log, string pass)
        {
            try
            {
                BDConnection.msCommand.CommandText = "SELECT COUNT(*) FROM users WHERE login = '" + log + "' and pass = '" + pass + "'";
                object result = BDConnection.msCommand.ExecuteScalar();

                int count = Convert.ToInt32(result);
                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
