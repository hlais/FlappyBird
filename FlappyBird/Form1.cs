﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        bool jumping = false;
        int pipeSpeed = 5;
        int gravity = 5;
        int Inscore = 0;

        Random ran = new Random();

        public Form1()
        {
            InitializeComponent();
            endText1.Text = "Game Over!";
            endText2.Text = "Your final score is: " + Inscore;
            gameDesigner.Text = "Game Designed by Halim Lais";
            endText1.Visible = false;
            endText2.Visible = false;
            gameDesigner.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            flappyBird.Top += gravity;
            checkingCollision();
            scoreText.Text = $"Scored: {Inscore}";

            if (pipeBottom.Left < -80)
            {
                Inscore += 1;
                pipeBottom.Left = 1000;
                pipeTop.Top = ran.Next(-200, -50);
               
            }
            else if (pipeTop.Left < -95)
            {   
                pipeTop.Left = 1100;
                Inscore += 1;
            }

                
           
        }
        private void checkingCollision()
        {
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds))
            {
                endGame();
            }
            if (flappyBird.Bounds.IntersectsWith(pipeTop.Bounds))
            {
                endGame();
            }
            else if (flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }
        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = false;
                gravity = 5;
            }
            
        }
        private void endGame()
        {
            gameTimer.Stop();
            endText1.Visible = true;
            endText2.Visible = true;
            gameDesigner.Visible = true;
        }

        private void GameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = true;
                gravity = -5;
               
            }

        }
    }
}
