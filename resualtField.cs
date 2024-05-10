using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacGame
{
    public partial class resualtField : Form
    {
        static public int id, win, lose, draw, matches, scoreBot, scorePlayer, winner;
        public resualtField()
        {
            InitializeComponent();
        }

        private void resualtField_Load(object sender, EventArgs e)
        {
            id = UpdateStats.GetPlayerID(Form1.currentLogin);
            scoreBot = GameField.scoreBot;
            scorePlayer = GameField.scorePlayer;
            UpdateUI();
        }

        public void UpdateUI()
        {
            if (scoreBot > scorePlayer)
            {
                label1.Text = "Вы проиграли";
                winner = 0;
            }
            else if (scorePlayer > scoreBot)
            {
                label1.Text = "Вы победили";
                winner = 1;
            }
            else
            {
                label1.Text = "Ничья";
                winner = -1;
            }

            label2.Text = $"{scorePlayer}:{scoreBot}";
            GetDatePlayer();
            Timer();
        }

        public void GetDatePlayer()
        {
            win = UpdateStats.GetPlayerWin(id);
            lose = UpdateStats.GetPlayerLose(id);
            draw = UpdateStats.GetPlayerDraw(id);
            matches = UpdateStats.GetPlayerMatches(id);

            if (winner == 1)
            {
                win++;
            }
            else if(winner == 0)
            {
                lose++;
            }
            else if(winner == -1)
            {
                draw++;
            }

            matches++;
            SaveDatePlayer();
        }

        private void SaveDatePlayer()
        {
            try
            {
                BDConnection.msCommand.CommandText = "UPDATE users SET win = '" + win + "', lose = '" + lose + "', draw = '" + draw + "', matches = '" + matches + "' WHERE id = '" + id + "'";
                BDConnection.msCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранение данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Timer()
        {
            for (int i = 3; i > 0; i--)
            {
                label3.Text = i.ToString();
                await Task.Delay(1000);
            }

            Form MM = new MainMenu();
            MM.Show();
            Close();
        }
    }
}
