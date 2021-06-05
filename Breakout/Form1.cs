using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
    public partial class Form1 : Form
    {

        bool goLeft;
        bool goRight;
        bool gameIsOver;

        int score;
        int ballx;
        int bally;
        int playerSpeed;

        Random rnd = new Random();

        
        public Form1()
        {
            InitializeComponent();

            gameSetup();
        }


        private void gameSetup()
        {
            score = 0;
            ballx = 5;
            bally = 5;
            playerSpeed = 12;
            txtScore.Text = "Score" + score;

            gameTimer.Start();

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "blocks")
                {

                    x.BackColor = Color.FromArgb(rnd.Next(256),rnd.Next(256),rnd.Next(256));
                }
            }

        }




        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            if(goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;

            }
            if (goRight == true && player.Left < 700)
            {
                player.Left += playerSpeed;

            }
            ball.Left += ballx;
            ball.Top += bally;

            if(ball.Left < 0 || ball.Left > 700)
            {
                ballx = -bally;
            }
            if(ball.Top < 0)
            {
                bally = -bally;
            }

            if(ball.Bounds.IntersectsWith(player.Bounds))
            {
                bally = rnd.Next(5, 12) * -1;
            }

        }
        

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;

            }
            if (e.KeyCode == Keys.Right)
                goRight = true;

            }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;

        }
    }
    }

}
