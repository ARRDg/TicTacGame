using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacGame
{
    public partial class GameField : Form
    {
        static public int botDifficulty, scorePlayer, scoreBot, currentRound;
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
            scorePlayer = scoreBot = currentRound = 0;

            label6.Text = scorePlayer.ToString();
            label7.Text = scoreBot.ToString();
            label5.Text = $"Раунд {currentRound}/3";
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            BDConnection.CloseBD();
            Application.Exit();
        }

        private async void MoveBot()
        {
            Random random = new Random();
            int randomValue = random.Next(1, 101);

            await Task.Delay(600);
            if (botDifficulty >= randomValue)
            {
                int bestScore = int.MinValue;
                int bestRow = -1;
                int bestCol = -1;

                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (field[row, col] == -1)
                        {
                            field[row, col] = 0;
                            int score = Minimax(field, 0, false);
                            field[row, col] = -1;

                            if (score > bestScore)
                            {
                                bestScore = score;
                                bestRow = row;
                                bestCol = col;
                            }
                        }
                    }
                }

                if (bestRow != -1 && bestCol != -1)
                {
                    field[bestRow, bestCol] = 0;
                    UpdateCellImage(bestRow, bestCol, global::TicTacGame.Properties.Resources.nol);
                }
            }
            else
            {
                int row, col;
                do
                {
                    row = random.Next(0, 3);
                    col = random.Next(0, 3);
                } while (field[row, col] != -1);

                field[row, col] = 0;
                UpdateCellImage(row, col, global::TicTacGame.Properties.Resources.nol);
            }

            MovePlayer = true;
            int winner = CheckWinner();
            if (winner != -2)
            {
                HandleEndGame(winner);
                MovePlayer = false;
            }
        }


        private int Minimax(int[,] board, int depth, bool isMaximizing)
        {
            int result = CheckWinner();
            if (result != -2)
            {
                if (result == 0)
                    return 10 - depth;
                else if (result == 1)
                    return depth - 10;
                else
                    return 0;
            }

            if (isMaximizing)
            {
                int bestScore = int.MinValue;
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (board[row, col] == -1)
                        {
                            board[row, col] = 0;
                            int score = Minimax(board, depth + 1, false);
                            board[row, col] = -1;
                            bestScore = Math.Max(score, bestScore);
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (board[row, col] == -1)
                        {
                            board[row, col] = 1;
                            int score = Minimax(board, depth + 1, true);
                            board[row, col] = -1;
                            bestScore = Math.Min(score, bestScore);
                        }
                    }
                }
                return bestScore;
            }
        }







        static int CheckWinner()
        {
            for (int row = 0; row < 3; row++)
            {
                if (field[row, 0] == field[row, 1] && field[row, 1] == field[row, 2])
                {
                    if (field[row, 0] != -1)
                        return field[row, 0];
                }
            }

            for (int col = 0; col < 3; col++)
            {
                if (field[0, col] == field[1, col] && field[1, col] == field[2, col])
                {
                    if (field[0, col] != -1)
                        return field[0, col];
                }
            }

            if (field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2])
            {
                if (field[0, 0] != -1)
                    return field[0, 0];
            }

            if (field[0, 2] == field[1, 1] && field[1, 1] == field[2, 0])
            {
                if (field[0, 2] != -1)
                    return field[0, 2];
            }

            bool isDraw = true;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (field[row, col] == -1)
                    {
                        isDraw = false;
                        break;
                    }
                }
            }
            if (isDraw)
                return -1;

            return -2;
        }
        private void HandleCellClick(int row, int col)
        {
            if (MovePlayer && field[row, col] == -1)
            {
                field[row, col] = 1;
                MovePlayer = false;
                UpdateCellImage(row, col, global::TicTacGame.Properties.Resources.krest);

                int winner = CheckWinner();
                if (winner != -2)
                {
                    HandleEndGame(winner);
                }
                else
                {
                    MoveBot();
                    winner = CheckWinner();
                    if (winner != -2)
                    {
                        HandleEndGame(winner);
                    }
                }
            }
        }
        private async void ClearField()
        {
            await Task.Delay(1000);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    field[i, j] = -1;
                }
            }

            cell00.BackgroundImage = cell01.BackgroundImage = cell02.BackgroundImage =
            cell10.BackgroundImage = cell11.BackgroundImage = cell12.BackgroundImage =
            cell20.BackgroundImage = cell21.BackgroundImage = cell22.BackgroundImage = null;
            MovePlayer = true;
        }
        private void HandleEndGame(int winner)
        {
            if (winner == 0)
            {
                scoreBot++;
            }
            else if (winner == 1)
            {
                scorePlayer++;
            }

            currentRound++;

            label6.Text = scorePlayer.ToString();
            label7.Text = scoreBot.ToString();
            label5.Text = $"Раунд {currentRound}/3";

            if (currentRound < 3)
            {
                ClearField();
            }
            else
            {
                Form MM = new resualtField();
                MM.Show();
                ClearField();
                Close();
            }
        }
        private void UpdateCellImage(int row, int col, System.Drawing.Image image)
        {
            switch (row.ToString() + col.ToString())
            {
                case "00": cell00.BackgroundImage = image; break;
                case "01": cell01.BackgroundImage = image; break;
                case "02": cell02.BackgroundImage = image; break;
                case "10": cell10.BackgroundImage = image; break;
                case "11": cell11.BackgroundImage = image; break;
                case "12": cell12.BackgroundImage = image; break;
                case "20": cell20.BackgroundImage = image; break;
                case "21": cell21.BackgroundImage = image; break;
                case "22": cell22.BackgroundImage = image; break;
                default: break;
            }
        }

        private void cell00_Click(object sender, EventArgs e)
        {
            HandleCellClick(0, 0);
        }

        private void cell01_Click(object sender, EventArgs e)
        {
            HandleCellClick(0, 1);
        }

        private void cell02_Click(object sender, EventArgs e)
        {
            HandleCellClick(0, 2);
        }

        private void cell10_Click(object sender, EventArgs e)
        {
            HandleCellClick(1, 0);
        }

        private void cell11_Click(object sender, EventArgs e)
        {
            HandleCellClick(1, 1);
        }

        private void cell12_Click(object sender, EventArgs e)
        {
            HandleCellClick(1, 2);
        }

        private void cell20_Click(object sender, EventArgs e)
        {
            HandleCellClick(2, 0);
        }

        private void cell21_Click(object sender, EventArgs e)
        {
            HandleCellClick(2, 1);
        }

        private void cell22_Click(object sender, EventArgs e)
        {
            HandleCellClick(2, 2);
        }
    }
}
