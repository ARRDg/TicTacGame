﻿using System;
using System.Globalization;
using System.Windows.Forms;

namespace TicTacGame
{
    public partial class MainMenu : Form
    {
        static public int id, win, lose, draw, matches;
        static public string date;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            id = UpdateStats.GetPlayerID(Form1.currentLogin);
            GetDataPlayer();
            SetDataPlayer();
        }
        private void guna2TabControl1_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                if (guna2TabControl1.SelectedIndex == 1)
                {
                    GetDataPlayer();
                    SetDataPlayer();
                }
            }
            else
            {
                MessageBox.Show("Было полученно некорректное ID игрока", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            BDConnection.CloseBD();
            Application.Exit();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Form MM = new GameField();
            MM.Show();
            Hide();
        }

        public static string ConvertDate(string dateString)
        {
            DateTime date = DateTime.ParseExact(dateString, "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture);

            CultureInfo russianCulture = new CultureInfo("ru-RU");
            string formattedDate = date.ToString("d MMMM", russianCulture);

            return formattedDate;
        }

        private void GetDataPlayer()
        {
            date = UpdateStats.GetPlayerDate(id);
            win = UpdateStats.GetPlayerWin(id);
            lose = UpdateStats.GetPlayerLose(id);
            draw = UpdateStats.GetPlayerDraw(id);
            matches = UpdateStats.GetPlayerMatches(id);

            date = ConvertDate(date);
        }
        private void SetDataPlayer()
        {
            label3.Text = date;
            label6.Text = win.ToString();
            label8.Text = lose.ToString();
            label10.Text = draw.ToString();
            label5.Text = matches.ToString();
        }
    }
}
