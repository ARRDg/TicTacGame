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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Form MM = new GameField();
            MM.Show();
            Hide();
        }
    }
}
