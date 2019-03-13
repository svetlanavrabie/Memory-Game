﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeuMemoire
{
    

    public partial class Form1 : Form
    {
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"

        };

        Label firstCliked, secondCliked;
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (firstCliked != null && secondCliked != null)
                return;

            Label clickedLabel = sender as Label;
            if (clickedLabel == null)
                return;


            if (clickedLabel.ForeColor == Color.Black)
                return;
            if (firstCliked == null)
            {
                firstCliked = clickedLabel;
                firstCliked.ForeColor = Color.Black;
                return;
            }

            secondCliked = clickedLabel;
            secondCliked.ForeColor = Color.Black;

            CheckForWinner();

            if (firstCliked.Text == secondCliked.Text)
            {
                firstCliked = null;
                secondCliked = null;
            }

            else

                timer1.Start();

        }

        private void CheckForWinner() {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label= tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }

            MessageBox.Show("Felicitacions, vous avez gagne!");
            Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstCliked.ForeColor = firstCliked.BackColor;
            secondCliked.ForeColor = secondCliked.BackColor;
            firstCliked = null;
            secondCliked = null;
        }

        private void AssignIconsToSquares()
        {
            Label label;
            int randomNumber;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    label = (Label)tableLayoutPanel1.Controls[i];
                }
                else continue;

                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];

                icons.RemoveAt(randomNumber);
            }

        }
    }
}
