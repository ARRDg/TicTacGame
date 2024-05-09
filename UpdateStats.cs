using System;
using System.Windows.Forms;

namespace TicTacGame
{
    internal class UpdateStats
    {
        static public int GetPlayerID(string log)
        {
            try
            {
                BDConnection.msCommand.CommandText = "SELECT id FROM users WHERE login = '" + log + "'";
                object result = BDConnection.msCommand.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return -1;
                }

            }
            catch
            {
                MessageBox.Show("Ошибка при получении ID", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        static public string GetPlayerDate(int id)
        {
            try
            {
                BDConnection.msCommand.CommandText = "SELECT date FROM users WHERE id = '" + id + "'";
                object result = BDConnection.msCommand.ExecuteScalar();

                if (result != null)
                {
                    return result.ToString();
                }
                else
                {
                    return "-1";
                }

            }
            catch
            {
                MessageBox.Show("Ошибка при получении даты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "-1";
            }
        }

        static public int GetPlayerWin(int id)
        {
            try
            {
                BDConnection.msCommand.CommandText = "SELECT win FROM users WHERE id = '" + id + "'";
                object result = BDConnection.msCommand.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return -1;
                }

            }
            catch
            {
                MessageBox.Show("Ошибка при получении количества побед", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        static public int GetPlayerLose(int id)
        {
            try
            {
                BDConnection.msCommand.CommandText = "SELECT lose FROM users WHERE id = '" + id + "'";
                object result = BDConnection.msCommand.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return -1;
                }

            }
            catch
            {
                MessageBox.Show("Ошибка при получении количества проигрышей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        static public int GetPlayerDraw(int id)
        {
            try
            {
                BDConnection.msCommand.CommandText = "SELECT draw FROM users WHERE id = '" + id + "'";
                object result = BDConnection.msCommand.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return -1;
                }

            }
            catch
            {
                MessageBox.Show("Ошибка при получении количества ничьих", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        static public int GetPlayerMatches(int id)
        {
            try
            {
                BDConnection.msCommand.CommandText = "SELECT matches FROM users WHERE id = '" + id + "'";
                object result = BDConnection.msCommand.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return -1;
                }

            }
            catch
            {
                MessageBox.Show("Ошибка при получении количества матчей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
    }
}
