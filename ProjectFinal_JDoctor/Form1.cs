using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFinal_JDoctor
{
    public partial class Form1 : Form
    {
        // constructs a cube object
        Cube myCube = new Cube();

        // global variables
        private PictureBox[] stickers;
        const int WHITE = 1;
        const int BLUE = 2;
        const int ORANGE = 3;
        const int GREEN = 4;
        const int RED = 5;
        const int YELLOW = 6;
        const int SIZE = 48;

        public Form1()
        {
            InitializeComponent();
            // stickers array initialized with picturebox controls
            stickers = new PictureBox[] { picW1, picW2, picW3, picW4, picW5, picW6, picW7, picW8, picB1, picB2, picB3, picB4,
                                          picB5, picB6, picB7, picB8, picO1, picO2, picO3, picO4, picO5, picO6, picO7, picO8,
                                          picG1, picG2, picG3, picG4, picG5, picG6, picG7, picG8, picR1, picR2, picR3, picR4,
                                          picR5, picR6, picR7, picR8, picY1, picY2, picY3, picY4, picY5, picY6, picY7, picY8 };
        }

        /// <summary>
        /// Updates Stickers property of Cube object with array of numbers representing colors
        /// This method is an opposite of the UpdateStickers() method
        /// </summary>
        private void UpdateStickerValues()
        {
            // loops through stickers PictureBox array and Stickers property of Cube object and
            // assigns temp a value based on the stickers PictureBox backcolor
            for (int i = 0; i < SIZE; i++)
            {
                if (stickers[i].BackColor == Color.White)
                {
                    myCube.Stickers[i] = WHITE;
                }
                else if (stickers[i].BackColor == Color.Blue)
                {
                    myCube.Stickers[i] = BLUE;
                }
                else if (stickers[i].BackColor == Color.Orange)
                {
                    myCube.Stickers[i] = ORANGE;
                }
                else if (stickers[i].BackColor == Color.Green)
                {
                    myCube.Stickers[i] = GREEN;
                }
                else if (stickers[i].BackColor == Color.Red)
                {
                    myCube.Stickers[i] = RED;
                }
                else
                {
                    myCube.Stickers[i] = YELLOW;
                }
            }
        }

        /// <summary>
        /// Enables color selection when radDisabled is unchecked.
        /// Disables color selection and picture box clicking when radDisabled is checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radDisabled_CheckedChanged(object sender, EventArgs e)
        {
            if (radEnabled.Checked)
            {
                grpColors.Enabled = true;
            }
            else
            {
                grpColors.Enabled = false;
                UpdateStickerValues();
            }
        }

        /// <summary>
        /// Updates stickers global array with backcolor representing number
        /// This method is an opposite of the UpdateStickerValues() method
        /// </summary>
        private void UpdateStickers()
        {
            // loops through stickers PictureBox array and Stickers property of Cube object and
            // assigns stickers PictureBox backcolor based off of Stickers value
            for (int i = 0; i < SIZE; i++)
            {
                if (myCube.Stickers[i] == WHITE)
                {
                    stickers[i].BackColor = Color.White;
                }
                else if (myCube.Stickers[i] == BLUE)
                {
                    stickers[i].BackColor = Color.Blue;
                }
                else if (myCube.Stickers[i] == ORANGE)
                {
                    stickers[i].BackColor = Color.Orange;
                }
                else if (myCube.Stickers[i] == GREEN)
                {
                    stickers[i].BackColor = Color.Green;
                }
                else if (myCube.Stickers[i] == RED)
                {
                    stickers[i].BackColor = Color.Red;
                }
                else
                {
                    stickers[i].BackColor = Color.Yellow;
                }
            }
        }

        /// <summary>
        /// Changes background color of button clicked based on which colored radio button is checked.
        /// </summary>
        private void ChangeColor(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;

            if (radDisabled.Checked)
            {
                return;
            }
            else if (radGreen.Checked)
            {
                pic.BackColor = Color.Green;
            }
            else if (radBlue.Checked)
            {
                pic.BackColor = Color.Blue;
            }
            else if (radWhite.Checked)
            {
                pic.BackColor = Color.White;
            }
            else if (radYellow.Checked)
            {
                pic.BackColor = Color.Yellow;
            }
            else if (radOrange.Checked)
            {
                pic.BackColor = Color.Orange;
            }
            else
            {
                pic.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// Resets form back to original state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            /*
            foreach (PictureBox p in Controls)
            {
                if (p.GetType() == typeof(PictureBox))
                {
                    p.BackColor = Color.Silver;
                }
            }
            */

            // Resets each picture box to correct color
            // Resets each Stickers value to correct value
            for (int i = 0; i < 8; i++)
            {
                stickers[i].BackColor = Color.White;        myCube.Stickers[i] = WHITE;
                stickers[i + 8].BackColor = Color.Blue;     myCube.Stickers[i + 8] = BLUE;
                stickers[i + 16].BackColor = Color.Orange;  myCube.Stickers[i + 16] = ORANGE;
                stickers[i + 24].BackColor = Color.Green;   myCube.Stickers[i + 24] = GREEN;
                stickers[i + 32].BackColor = Color.Red;     myCube.Stickers[i + 32] = RED;
                stickers[i + 40].BackColor = Color.Yellow;  myCube.Stickers[i + 40] = YELLOW;
            }

            // More housekeeping
            radDisabled.Checked = true;
            radGreen.Checked = true;
            radEasy.Checked = true;

        }

        /// <summary>
        /// Randomly scrambles cube into one of four difficulties.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScramble_Click(object sender, EventArgs e)
        {
            int difficulty;                 // number of random turns
            int turn;                       // represents turn, which is selected randomly
            Random rand = new Random();     // Random object, used to determine which turns to call

            // determines difficulty level
            if (radEasy.Checked)
            {
                difficulty = 2;
            }
            else if (radNormal.Checked)
            {
                difficulty = 4;
            }
            else if (radHard.Checked)
            {
                difficulty = 8;
            }
            else
            {
                difficulty = 16;
            }

            for (int i = 0; i < difficulty; i++)
            {
                // figures out which turn to call
                turn = rand.Next(1, 13);

                // calls selected turn
                switch (turn)
                {
                    case 1:
                        myCube.RightTurn();
                        break;
                    case 2:
                        myCube.RightPrimeTurn();
                        break;
                    case 3:
                        myCube.LeftTurn();
                        break;
                    case 4:
                        myCube.LeftPrimeTurn();
                        break;
                    case 5:
                        myCube.UpTurn();
                        break;
                    case 6:
                        myCube.UpPrimeTurn();
                        break;
                    case 7:
                        myCube.DownTurn();
                        break;
                    case 8:
                        myCube.DownPrimeTurn();
                        break;
                    case 9:
                        myCube.FrontTurn();
                        break;
                    case 10:
                        myCube.FrontPrimeTurn();
                        break;
                    case 11:
                        myCube.BackTurn();
                        break;
                    case 12:
                        myCube.BackPrimeTurn();
                        break;
                }
            }

            UpdateStickers();

        }

        /// <summary>
        /// Makes a counterclockwise, left turn.
        /// Updates stickers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeftPrime_Click(object sender, EventArgs e)
        {
            myCube.LeftPrimeTurn();
            UpdateStickers();
        }

        /// <summary>
        /// Makes a clockwise, right turn.
        /// Updates stickers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            myCube.RightTurn();
            UpdateStickers();
        }

        /// <summary>
        /// Makes a clockwise, upward turn.
        /// Updates stickers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            myCube.UpTurn();
            UpdateStickers();
        }

        /// <summary>
        /// Makes a counterclockwise, backward turn. Updates stickers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackPrime_Click(object sender, EventArgs e)
        {
            myCube.BackPrimeTurn();
            UpdateStickers();
        }

        /// <summary>
        /// Makes a clockwise, front turn. Updates stickers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFront_Click(object sender, EventArgs e)
        {
            myCube.FrontTurn();
            UpdateStickers();
        }

        /// <summary>
        /// Makes a counterclockwise, downward turn.
        /// Updates stickers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownPrime_Click(object sender, EventArgs e)
        {
            myCube.DownPrimeTurn();
            UpdateStickers();
        }

        /// <summary>
        /// Makes a clockwise, downward turn.
        /// Updates stickers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            myCube.DownTurn();
            UpdateStickers();
        }

        /// <summary>
        /// Makes a counterclockwise, right turn.
        /// Updates stickers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRightPrime_Click(object sender, EventArgs e)
        {
            myCube.RightTurn();
            UpdateStickers();
        }

        /// <summary>
        /// Makes a clockwise, left turn.
        /// Updates stickers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            myCube.LeftTurn();
            UpdateStickers();
        }

        /// <summary>
        /// Makes a counterclockwise, upward turn.
        /// Updates stickers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpPrime_Click(object sender, EventArgs e)
        {
            myCube.UpPrimeTurn();
            UpdateStickers();
        }

        /// <summary>
        /// Makes a counterclockwise, front turn.
        /// Updates stickers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFrontPrime_Click(object sender, EventArgs e)
        {
            myCube.FrontPrimeTurn();
            UpdateStickers();
        }

        /// <summary>
        /// Makes a clockwise, backward turn.
        /// Updates stickers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            myCube.BackTurn();
            UpdateStickers();
        }
    }
}
