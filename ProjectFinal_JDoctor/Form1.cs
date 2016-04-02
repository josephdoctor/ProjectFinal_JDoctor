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
            stickerValues[2] = temp[26];        stickerValues[20] = temp[22];
            stickerValues[4] = temp[28];        stickerValues[21] = temp[16];
            stickerValues[7] = temp[31];        stickerValues[22] = temp[19];
            stickerValues[10] = temp[2];        stickerValues[23] = temp[21];
            stickerValues[12] = temp[4];        stickerValues[26] = temp[45];
            stickerValues[15] = temp[7];        stickerValues[28] = temp[43];
            stickerValues[16] = temp[18];       stickerValues[31] = temp[40];
            stickerValues[17] = temp[20];       stickerValues[40] = temp[15];
            stickerValues[18] = temp[23];       stickerValues[43] = temp[12];
            stickerValues[19] = temp[17];       stickerValues[45] = temp[10];

            // updates stickers
            UpdateStickers();
        }

        /// <summary>
        /// Performs a clockwise, single left turn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private void LeftTurn(object sender, EventArgs e)
        {
            // creates temp array to store old values of stickerValues
            // adds values in stickerValues to temp array
            int[] temp = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                temp[i] = stickerValues[i];
            }

            // updates stickerValues array with new values resulting from the turn
            stickerValues[0] = temp[24];        stickerValues[33] = temp[35];
            stickerValues[3] = temp[27];        stickerValues[34] = temp[32];
            stickerValues[5] = temp[29];        stickerValues[35] = temp[38];
            stickerValues[8] = temp[0];         stickerValues[36] = temp[33];
            stickerValues[11] = temp[3];        stickerValues[37] = temp[39];
            stickerValues[13] = temp[5];        stickerValues[38] = temp[36];
            stickerValues[24] = temp[47];       stickerValues[39] = temp[34];
            stickerValues[27] = temp[44];       stickerValues[42] = temp[13];
            stickerValues[29] = temp[42];       stickerValues[44] = temp[11];
            stickerValues[32] = temp[37];       stickerValues[47] = temp[8];

            // updates stickers
            UpdateStickers();
        }

        /// <summary>
        /// Performs a counterclockwise, single left turn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private void LeftPrimeTurn(object sender, EventArgs e)
        {
            // creates temp array to store old values of stickerValues
            // adds values in stickerValues to temp array
            int[] temp = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                temp[i] = stickerValues[i];
            }

            // updates stickerValues array with new values resulting from the turn
            stickerValues[0] = temp[8];         stickerValues[33] = temp[36];
            stickerValues[3] = temp[11];        stickerValues[34] = temp[39];
            stickerValues[5] = temp[13];        stickerValues[35] = temp[33];
            stickerValues[8] = temp[47];        stickerValues[36] = temp[38];
            stickerValues[11] = temp[44];       stickerValues[37] = temp[32];
            stickerValues[13] = temp[42];       stickerValues[38] = temp[35];
            stickerValues[24] = temp[0];        stickerValues[39] = temp[37];
            stickerValues[27] = temp[3];        stickerValues[42] = temp[29];
            stickerValues[29] = temp[5];        stickerValues[44] = temp[27];
            stickerValues[32] = temp[34];       stickerValues[47] = temp[24];

            // updates stickers
            UpdateStickers();
        }

        /// <summary>
        /// Performs a clockwise, single upward turn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private void UpTurn(object sender, EventArgs e)
        {
            // creates temp array to store old values of stickerValues
            // adds values in stickerValues to temp array
            int[] temp = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                temp[i] = stickerValues[i];
            }

            // updates stickerValues array with new values resulting from the turn
            stickerValues[0] = temp[5];         stickerValues[10] = temp[16];
            stickerValues[1] = temp[3];         stickerValues[16] = temp[29];
            stickerValues[2] = temp[0];         stickerValues[19] = temp[30];
            stickerValues[3] = temp[6];         stickerValues[21] = temp[31];
            stickerValues[4] = temp[1];         stickerValues[29] = temp[39];
            stickerValues[5] = temp[7];         stickerValues[30] = temp[36];
            stickerValues[6] = temp[4];         stickerValues[31] = temp[34];
            stickerValues[7] = temp[2];         stickerValues[34] = temp[8];
            stickerValues[8] = temp[21];        stickerValues[36] = temp[9];
            stickerValues[9] = temp[19];        stickerValues[39] = temp[10];

            // updates stickers
            UpdateStickers();
        }

        /// <summary>
        /// Performs a counterclockwise, single upward turn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private void UpPrimeTurn(object sender, EventArgs e)
        {
            // creates temp array to store old values of stickerValues
            // adds values in stickerValues to temp array
            int[] temp = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                temp[i] = stickerValues[i];
            }

            // updates stickerValues array with new values resulting from the turn
            stickerValues[0] = temp[2];         stickerValues[10] = temp[39];
            stickerValues[1] = temp[4];         stickerValues[16] = temp[10];
            stickerValues[2] = temp[7];         stickerValues[19] = temp[9];
            stickerValues[3] = temp[1];         stickerValues[21] = temp[8];
            stickerValues[4] = temp[6];         stickerValues[29] = temp[16];
            stickerValues[5] = temp[0];         stickerValues[30] = temp[19];
            stickerValues[6] = temp[3];         stickerValues[31] = temp[21];
            stickerValues[7] = temp[5];         stickerValues[34] = temp[31];
            stickerValues[8] = temp[34];        stickerValues[36] = temp[30];
            stickerValues[9] = temp[36];        stickerValues[39] = temp[29];

            // updates stickers
            UpdateStickers();
        }

        /// <summary>
        /// Performs a clockwise, single downward turn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private void DownTurn(object sender, EventArgs e)
        {
            // creates temp array to store old values of stickerValues
            // adds values in stickerValues to temp array
            int[] temp = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                temp[i] = stickerValues[i];
            }

            // updates stickerValues array with new values resulting from the turn
            stickerValues[13] = temp[32];       stickerValues[35] = temp[25];
            stickerValues[14] = temp[35];       stickerValues[37] = temp[24];
            stickerValues[15] = temp[37];       stickerValues[40] = temp[45];
            stickerValues[18] = temp[15];       stickerValues[41] = temp[43];
            stickerValues[20] = temp[14];       stickerValues[42] = temp[40];
            stickerValues[23] = temp[13];       stickerValues[43] = temp[46];
            stickerValues[24] = temp[18];       stickerValues[44] = temp[41];
            stickerValues[25] = temp[20];       stickerValues[45] = temp[47];
            stickerValues[26] = temp[23];       stickerValues[46] = temp[44];
            stickerValues[32] = temp[26];       stickerValues[47] = temp[42];

            // updates stickers
            UpdateStickers();
        }

        /// <summary>
        /// Performs a counterclockwise, single downward turn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private void DownPrimeTurn(object sender, EventArgs e)
        {
            // creates temp array to store old values of stickerValues
            // adds values in stickerValues to temp array
            int[] temp = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                temp[i] = stickerValues[i];
            }

            // updates stickerValues array with new values resulting from the turn
            stickerValues[13] = temp[23];       stickerValues[35] = temp[14];
            stickerValues[14] = temp[20];       stickerValues[37] = temp[15];
            stickerValues[15] = temp[18];       stickerValues[40] = temp[42];
            stickerValues[18] = temp[24];       stickerValues[41] = temp[44];
            stickerValues[20] = temp[25];       stickerValues[42] = temp[47];
            stickerValues[23] = temp[26];       stickerValues[43] = temp[41];
            stickerValues[24] = temp[37];       stickerValues[44] = temp[46];
            stickerValues[25] = temp[35];       stickerValues[45] = temp[40];
            stickerValues[26] = temp[32];       stickerValues[46] = temp[43];
            stickerValues[32] = temp[13];       stickerValues[47] = temp[45];

            // updates stickers
            UpdateStickers();
        }

        /// <summary>
        /// Performs a clockwise, single front turn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private void FrontTurn(object sender, EventArgs e)
        {
            // creates temp array to store old values of stickerValues
            // adds values in stickerValues to temp array
            int[] temp = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                temp[i] = stickerValues[i];
            }

            // updates stickerValues array with new values resulting from the turn
            stickerValues[5] = temp[37];        stickerValues[15] = temp[10];
            stickerValues[6] = temp[38];        stickerValues[21] = temp[5];
            stickerValues[7] = temp[39];        stickerValues[22] = temp[6];
            stickerValues[8] = temp[13];        stickerValues[23] = temp[7];
            stickerValues[9] = temp[11];        stickerValues[37] = temp[45];
            stickerValues[10] = temp[8];        stickerValues[38] = temp[46];
            stickerValues[11] = temp[14];       stickerValues[39] = temp[47];
            stickerValues[12] = temp[9];        stickerValues[45] = temp[21];
            stickerValues[13] = temp[15];       stickerValues[46] = temp[22];
            stickerValues[14] = temp[12];       stickerValues[47] = temp[23];

            // updates stickers
            UpdateStickers();
        }

        /// <summary>
        /// Performs a counterclockwise, single front turn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private void FrontPrimeTurn(object sender, EventArgs e)
        {
            // creates temp array to store old values of stickerValues
            // adds values in stickerValues to temp array
            int[] temp = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                temp[i] = stickerValues[i];
            }

            // updates stickerValues array with new values resulting from the turn
            stickerValues[5] = temp[21];        stickerValues[15] = temp[13];
            stickerValues[6] = temp[22];        stickerValues[21] = temp[45];
            stickerValues[7] = temp[23];        stickerValues[22] = temp[46];
            stickerValues[8] = temp[10];        stickerValues[23] = temp[47];
            stickerValues[9] = temp[12];        stickerValues[37] = temp[5];
            stickerValues[10] = temp[15];       stickerValues[38] = temp[6];
            stickerValues[11] = temp[9];        stickerValues[39] = temp[7];
            stickerValues[12] = temp[14];       stickerValues[45] = temp[37];
            stickerValues[13] = temp[8];        stickerValues[46] = temp[38];
            stickerValues[14] = temp[11];       stickerValues[47] = temp[39];

            // updates stickers
            UpdateStickers();
        }

        /// <summary>
        /// Performs a clockwise, single back turn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private void BackTurn(object sender, EventArgs e)
        {
            // creates temp array to store old values of stickerValues
            // adds values in stickerValues to temp array
            int[] temp = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                temp[i] = stickerValues[i];
            }

            // updates stickerValues array with new values resulting from the turn
            stickerValues[0] = temp[16];        stickerValues[28] = temp[25];
            stickerValues[1] = temp[17];        stickerValues[29] = temp[31];
            stickerValues[2] = temp[18];        stickerValues[30] = temp[28];
            stickerValues[16] = temp[40];       stickerValues[31] = temp[26];
            stickerValues[17] = temp[41];       stickerValues[32] = temp[0];
            stickerValues[18] = temp[42];       stickerValues[33] = temp[1];
            stickerValues[24] = temp[29];       stickerValues[34] = temp[2];
            stickerValues[25] = temp[27];       stickerValues[40] = temp[32];
            stickerValues[26] = temp[24];       stickerValues[41] = temp[33];
            stickerValues[27] = temp[30];       stickerValues[42] = temp[34];

            // updates stickers
            UpdateStickers();
        }

        /// <summary>
        /// Performs a counterclockwise, single back turn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private void BackPrimeTurn(object sender, EventArgs e)
        {
            // creates temp array to store old values of stickerValues
            // adds values in stickerValues to temp array
            int[] temp = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                temp[i] = stickerValues[i];
            }

            // updates stickerValues array with new values resulting from the turn
            stickerValues[0] = temp[32];        stickerValues[28] = temp[30];
            stickerValues[1] = temp[33];        stickerValues[29] = temp[24];
            stickerValues[2] = temp[34];        stickerValues[30] = temp[27];
            stickerValues[16] = temp[0];        stickerValues[31] = temp[29];
            stickerValues[17] = temp[1];        stickerValues[32] = temp[40];
            stickerValues[18] = temp[2];        stickerValues[33] = temp[41];
            stickerValues[24] = temp[26];       stickerValues[34] = temp[42];
            stickerValues[25] = temp[28];       stickerValues[40] = temp[16];
            stickerValues[26] = temp[31];       stickerValues[41] = temp[17];
            stickerValues[27] = temp[25];       stickerValues[42] = temp[18];

            // updates stickers
            UpdateStickers();
        }

        /////////////////////////////////////////////////
        ///////////////// OTHER METHODS /////////////////
        /////////////////////////////////////////////////

        private void Scramble()
        {

        }

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
                difficulty = 3;
            }
            else if (radHard.Checked)
            {
                difficulty = 4;
            }
            else
            {
                difficulty = 5;
            }

            for (int i = 0; i < difficulty; i++)
            {
                // figures out which turn to call
                turn = rand.Next(1, 13);

                // calls selected turn
                switch (turn)
                {
                    case 1:
                        RightTurn(sender, e);
                        break;
                    case 2:
                        RightPrimeTurn(sender, e);
                        break;
                    case 3:
                        LeftTurn(sender, e);
                        break;
                    case 4:
                        LeftPrimeTurn(sender, e);
                        break;
                    case 5:
                        UpTurn(sender, e);
                        break;
                    case 6:
                        UpPrimeTurn(sender, e);
                        break;
                    case 7:
                        DownTurn(sender, e);
                        break;
                    case 8:
                        DownPrimeTurn(sender, e);
                        break;
                    case 9:
                        FrontTurn(sender, e);
                        break;
                    case 10:
                        FrontPrimeTurn(sender, e);
                        break;
                    case 11:
                        BackTurn(sender, e);
                        break;
                    case 12:
                        BackPrimeTurn(sender, e);
                        break;
                }
            }

        }
    }
}
