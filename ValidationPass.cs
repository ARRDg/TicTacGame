﻿using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TicTacGame
{
    public class ValidationPass
    {
        public bool Validation(string password)
        {
            var input = password;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Поле с паролем пустое", "Ошибка");
                return false;
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,45}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?-]");

            if (!hasLowerChar.IsMatch(input))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну строчную букву", "Ошибка");
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну заглавную букву", "Ошибка");
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                MessageBox.Show("Пароль должен быть длиннее 6 символов и не более 45", "Ошибка");
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одно числовое значение", "Ошибка");
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                MessageBox.Show("Пароль должен содержать хотя бы один спец. символ", "Ошибка");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}