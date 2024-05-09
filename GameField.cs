using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace TicTacGame
{
    public partial class GameField : Form
    {
        static public int koef;
        static public int[,] field = { { -1, -1, -1 },
                                       { -1, -1, -1 },
                                       { -1, -1, -1 }  };

        static public bool MovePlayer = true;
        public GameField()
        {
            InitializeComponent();
        }
        private void GameField_Load(object sender, EventArgs e)
        {
            koef = 10; //временно
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            BDConnection.CloseBD();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form MM = new resualtField();
            MM.Show();
            Hide();
        }






        public void MoveBot()
        {
            if (!MovePlayer && CheckWinner() == -1)
            {
                int bestScore = int.MinValue;
                int bestRow = -1;
                int bestCol = -1;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (field[i, j] == -1)
                        {
                            field[i, j] = 1;
                            int score = Minimax(field, false);
                            field[i, j] = -1;

                            if (score > bestScore)
                            {
                                bestScore = score;
                                bestRow = i;
                                bestCol = j;
                            }
                        }
                    }
                }

                field[bestRow, bestCol] = 0;

                switch (bestRow.ToString() + bestCol.ToString())
                {
                    case "00":
                        cell00.BackgroundImage = global::TicTacGame.Properties.Resources.nol;
                        break;
                    case "01":
                        cell01.BackgroundImage = global::TicTacGame.Properties.Resources.nol;
                        break;
                    case "02":
                        cell02.BackgroundImage = global::TicTacGame.Properties.Resources.nol;
                        break;
                    case "10":
                        cell10.BackgroundImage = global::TicTacGame.Properties.Resources.nol;
                        break;
                    case "11":
                        cell11.BackgroundImage = global::TicTacGame.Properties.Resources.nol;
                        break;
                    case "12":
                        cell12.BackgroundImage = global::TicTacGame.Properties.Resources.nol;
                        break;
                    case "20":
                        cell20.BackgroundImage = global::TicTacGame.Properties.Resources.nol;
                        break;
                    case "21":
                        cell21.BackgroundImage = global::TicTacGame.Properties.Resources.nol;
                        break;
                    case "22":
                        cell22.BackgroundImage = global::TicTacGame.Properties.Resources.nol;
                        break;
                }

                MovePlayer = true;
            }
            else
            {
                MessageBox.Show(CheckWinner().ToString(), "Информация о победителе", MessageBoxButtons.OK);
            }
        }

        static private int Minimax(int[,] board, bool isMaximizing)
        {
            int winner = CheckWinner();
            if (winner != -1)
            {
                return winner;
            }

            if (isMaximizing)
            {
                int bestScore = int.MinValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == -1)
                        {
                            board[i, j] = 1;
                            int score = Minimax(board, false);
                            board[i, j] = -1;
                            bestScore = Math.Max(score, bestScore);
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == -1)
                        {
                            board[i, j] = 0;
                            int score = Minimax(board, true);
                            board[i, j] = -1;
                            bestScore = Math.Min(score, bestScore);
                        }
                    }
                }
                return bestScore;
            }
        }

        static private int CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (field[i, 0] != -1 && field[i, 0] == field[i, 1] && field[i, 1] == field[i, 2])
                    return field[i, 0];
                if (field[0, i] != -1 && field[0, i] == field[1, i] && field[1, i] == field[2, i])
                    return field[0, i];
            }

            if (field[0, 0] != -1 && field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2])
                return field[0, 0];
            if (field[0, 2] != -1 && field[0, 2] == field[1, 1] && field[1, 1] == field[2, 0])
                return field[0, 2];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (field[i, j] == -1)
                        return -1;

            return 0;
        }

        public void cell00_Click(object sender, EventArgs e)
        {
            if (MovePlayer && field[0,0] == -1)
            {
                field[0, 0] = 1;
                MovePlayer = false;
                cell00.BackgroundImage = global::TicTacGame.Properties.Resources.krest;
                MoveBot();
            }
        }

        private void cell01_Click(object sender, EventArgs e)
        {
            if (MovePlayer && field[0, 1] == -1)
            {
                field[0, 1] = 1;
                MovePlayer = false;
                cell01.BackgroundImage = global::TicTacGame.Properties.Resources.krest;
                MoveBot();
            }
        }

        private void cell02_Click(object sender, EventArgs e)
        {
            if (MovePlayer && field[0, 2] == -1)
            {
                field[0, 2] = 1;
                MovePlayer = false;
                cell02.BackgroundImage = global::TicTacGame.Properties.Resources.krest;
                MoveBot();
            }
        }

        private void cell10_Click(object sender, EventArgs e)
        {
            if (MovePlayer && field[1, 0] == -1)
            {
                field[1, 0] = 1;
                MovePlayer = false;
                cell10.BackgroundImage = global::TicTacGame.Properties.Resources.krest;
                MoveBot();
            }
        }

        private void cell11_Click(object sender, EventArgs e)
        {
            if (MovePlayer && field[1, 1] == -1)
            {
                field[1, 1] = 1;
                MovePlayer = false;
                cell11.BackgroundImage = global::TicTacGame.Properties.Resources.krest;
                MoveBot();
            }
        }

        private void cell12_Click(object sender, EventArgs e)
        {
            if (MovePlayer && field[1, 2] == -1)
            {
                field[1, 2] = 1;
                MovePlayer = false;
                cell12.BackgroundImage = global::TicTacGame.Properties.Resources.krest;
                MoveBot();
            }
        }

        private void cell20_Click(object sender, EventArgs e)
        {
            if (MovePlayer && field[2, 0] == -1)
            {
                field[2, 0] = 1;
                MovePlayer = false;
                cell20.BackgroundImage = global::TicTacGame.Properties.Resources.krest;
                MoveBot();
            }
        }

        private void cell21_Click(object sender, EventArgs e)
        {
            if (MovePlayer && field[2, 1] == -1)
            {
                field[2, 1] = 1;
                MovePlayer = false;
                cell21.BackgroundImage = global::TicTacGame.Properties.Resources.krest;
                MoveBot();
            }
        }

        private void cell22_Click(object sender, EventArgs e)
        {
            if (MovePlayer && field[2, 2] == -1)
            {
                field[2, 2] = 1;
                MovePlayer = false;
                cell22.BackgroundImage = global::TicTacGame.Properties.Resources.krest;
                MoveBot();
            }
        }
    }
}
