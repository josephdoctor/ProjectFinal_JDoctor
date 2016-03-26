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

        // global constants for each color
        const int WHITE = 1;
        const int BLUE = 2;
        const int ORANGE = 3;
        const int GREEN = 4;
        const int RED = 5;
        const int YELLOW = 6;

        // global constant for number of stickers
        const int SIZE = 48;

        // global array containing color values for each sticker on cube
        private int[] stickerValues = new int[SIZE] { WHITE, WHITE, WHITE, WHITE, WHITE, WHITE, WHITE, WHITE, BLUE, BLUE, BLUE, BLUE,
                                                      BLUE, BLUE, BLUE, BLUE, ORANGE, ORANGE, ORANGE, ORANGE, ORANGE, ORANGE, ORANGE, ORANGE,
                                                      GREEN, GREEN, GREEN, GREEN, GREEN, GREEN, GREEN, GREEN, RED, RED, RED, RED,
                                                      RED, RED, RED, RED, YELLOW, YELLOW, YELLOW, YELLOW, YELLOW, YELLOW, YELLOW, YELLOW };

        // global array for picturebox controls
        private PictureBox[] stickers;

        public Form1()
        {
            InitializeComponent();
            // stickers array initialized with picturebox controls
            stickers = new PictureBox[] { picW1, picW2, picW3, picW4, picW5, picW6, picW7, picW8, picB1, picB2, picB3, picB4,
                                          picB5, picB6, picB7, picB8, picO1, picO2, picO3, picO4, picO5, picO6, picO7, picO8,
                                          picG1, picG2, picG3, picG4, picG5, picG6, picG7, picG8, picR1, picR2, picR3, picR4,
                                          picR5, picR6, picR7, picR8, picY1, picY2, picY3, picY4, picY5, picY6, picY7, picY8 };
        }


        /////////////////////////////////////////////////////
        ////////////// CUBE MANUEVERS ///////////////////////
        /////////////////////////////////////////////////////

        /// <summary>
        /// Performs a clockwise, single right turn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private void RightTurn(object sender, EventArgs e)
        {
            // creates temp array to store old values of stickerValues
            // adds values in stickerValues to temp array
            int[] temp = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                temp[i] = stickerValues[i];
            }

            // updates stickerValues array with new values resulting from the turn
            stickerValues[2] = temp[10];        stickerValues[20] = temp[17];
            stickerValues[4] = temp[12];        stickerValues[21] = temp[23];
            stickerValues[7] = temp[15];        stickerValues[22] = temp[20];
            stickerValues[10] = temp[45];       stickerValues[23] = temp[18];
            stickerValues[12] = temp[43];       stickerValues[26] = temp[2];
            stickerValues[15] = temp[40];       stickerValues[28] = temp[4];
            stickerValues[16] = temp[21];       stickerValues[31] = temp[7];
            stickerValues[17] = temp[19];       stickerValues[40] = temp[31];
            stickerValues[18] = temp[16];       stickerValues[43] = temp[28];
            stickerValues[19] = temp[22];       stickerValues[45] = temp[26];

            // updates stickers
            UpdateStickers();
        }

        /// <summary>
        /// Performs a counterclockwise, single right turn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private void RightPrimeTurn(object sender, EventArgs e)
        {
            // creates temp array to store old values of stickerValues
            // adds values in stickerValues to temp array
            int[] temp = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                temp[i] = stickerValues[i];
            }

            // updates stickerValues array with new values resulting from the turn
            stickerValues[2] = temp[26]; stickerValues[20] = temp[22];
            stickerValues[4] = temp[28]; stickerValues[21] = temp[16];
            stickerValues[7] = temp[31]; stickerValues[22] = temp[19];
            stickerValues[10] = temp[2]; stickerValues[23] = temp[21];
            stickerValues[12] = temp[4]; stickerValues[26] = temp[45];
            stickerValues[15] = temp[7]; stickerValues[28] = temp[43];
            stickerValues[16] = temp[18]; stickerValues[31] = temp[40];
            stickerValues[17] = temp[20]; stickerValues[40] = temp[15];
            stickerValues[18] = temp[23]; stickerValues[43] = temp[12];
            stickerValues[19] = temp[17]; stickerValues[45] = temp[10];

            // updates stickers
            UpdateStickers();
        }

        /////////////////////////////////////////////////
        ///////////////// OTHER METHODS /////////////////
        /////////////////////////////////////////////////

        /// <summary>
        /// Updates stickerValues global array with number representing color
        /// This method is an opposite of the UpdateStickers() method
        /// </summary>
        private void UpdateStickerValues()
        {
            // loops through stickers PictureBox array and stickerValues int array and
            // assigns stickerValues a value based on the stickers PictureBox backcolor
            for (int i = 0; i < SIZE; i++)
            {
                if (stickers[i].BackColor == Color.White)
                {
                    stickerValues[i] = WHITE;
                }
                else if (stickers[i].BackColor == Color.Blue)
                {
                    stickerValues[i] = BLUE;
                }
                else if (stickers[i].BackColor == Color.Orange)
                {
                    stickerValues[i] = ORANGE;
                }
                else if (stickers[i].BackColor == Color.Green)
                {
                    stickerValues[i] = GREEN;
                }
                else if (stickers[i].BackColor == Color.Red)
                {
                    stickerValues[i] = RED;
                }
                else
                {
                    stickerValues[i] = YELLOW;
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
            // loops through stickers PictureBox array and stickerValues int array and
            // assigns stickers PictureBox backcolor based off of stickerValues int value
            for (int i = 0; i < SIZE; i++)
            {
                if (stickerValues[i] == WHITE)
                {
                    stickers[i].BackColor = Color.White;
                }
                else if (stickerValues[i] == BLUE)
                {
                    stickers[i].BackColor = Color.Blue;
                }
                else if (stickerValues[i] == ORANGE)
                {
                    stickers[i].BackColor = Color.Orange;
                }
                else if (stickerValues[i] == GREEN)
                {
                    stickers[i].BackColor = Color.Green;
                }
                else if (stickerValues[i] == RED)
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
        private void btnClear_Click(object sender, EventArgs e)
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
            // Resets each stickerValue to correct value
            for (int i = 0; i < 8; i++)
            {
                stickers[i].BackColor = Color.White;                stickerValues[i] = WHITE;
                stickers[i + 8].BackColor = Color.Blue;             stickerValues[i + 8] = BLUE;
                stickers[i + 16].BackColor = Color.Orange;          stickerValues[i + 16] = ORANGE;
                stickers[i + 24].BackColor = Color.Green;           stickerValues[i + 24] = GREEN;
                stickers[i + 32].BackColor = Color.Red;             stickerValues[i + 32] = RED;
                stickers[i + 40].BackColor = Color.Yellow;          stickerValues[i + 40] = YELLOW;
            }

            // More housekeeping
            radDisabled.Checked = true;
            radGreen.Checked = true;

        }
        
    }
}
