using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TicTacGame
{
    public class ValidationLogin
    {
        public bool Validation(string login)
        {
            var input = login;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Поле с логином пустое", "Ошибка");
                return false;
            }

            var hasMiniMaxChars = new Regex(@".{6,24}");

            if (!hasMiniMaxChars.IsMatch(input))
            {
                MessageBox.Show("Логин должен быть длиннее 6 символов и не более 24 символов", "Ошибка");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}