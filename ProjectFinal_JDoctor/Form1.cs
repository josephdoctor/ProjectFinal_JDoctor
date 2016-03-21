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
        // change each picturebox array to be like whitePic
        // change intitialize component as well
        PictureBox[] whitePic = new PictureBox[9];
        PictureBox[] bluePic = { picB0, picB1, picB2, picB3, picB4, picB5, picB6, picB7, picB8 };
        PictureBox[] orangePic = { picO0, picO1, picO2, picO3, picO4, picO5, picO6, picO7, picO8 };
        PictureBox[] greenPic = { picG0, picG1, picG2, picG3, picG4, picG5, picG6, picG7, picG8 };
        PictureBox[] redPic = { picR0, picR1, picR2, picR3, picR4, picR5, picR6, picR7, picR8 };
        PictureBox[] yellowPic = { picY0, picY1, picY2, picY3, picY4, picY5, picY6, picY7, picY8 }

        // global constants for each color
        const int SILVER = 0;
        const int WHITE = 1;
        const int BLUE = 2;
        const int ORANGE = 3;
        const int GREEN = 4;
        const int RED = 5;
        const int YELLOW = 6;
        const int SIZE = 9;
        const int TOTAL_SIZE = 54;

        // global arrays for each face
        int[] white = new int[SIZE];
        int[] blue = new int[SIZE];
        int[] orange = new int[SIZE];
        int[] green = new int[SIZE];
        int[] red = new int[SIZE];
        int[] yellow = new int[SIZE];
        int[] all = new int[TOTAL_SIZE];

        public Form1()
        {
            InitializeComponent();
            whitePic[0] = picW0;
        }

        //////////////////////////////////////////////////////
        ////////////// CUBE OUTPUT //////////////////////////
        ////////////////////////////////////////////////////

        /*private void UpdateCube(int[] all)
        {
            for (int i = 0; i < SIZE; i++)
            {
                switch (all[i])
                {
                    case WHITE:
                        // CREATE LIST OF ALL PICTURE BOXES.BackColor = Color.White;
                }
            }
        }*/

        //////////////////////////////////////////////////////
        ////////////// CUBE MANUEVERS ///////////////////////
        /////////////////////////////////////////////////////

        /// <summary>
        /// Performs a clockwise, single right turn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int[] RightTurn(int[] input)
        {
            // this is unnecessary; should just change individual picturebox background color and then call
            // AssignAll method to update all array
            int[] output = input;
            output[20] = input[18];
            output[23] = input[19];
            output[26] = input[20];
            output[19] = input[21];
            output[25] = input[23];
            output[18] = input[24];
            output[21] = input[25];
            output[24] = input[26];
            output[2] = input[11];
            output[5] = input[14];
            output[8] = input[17];
            output[29] = input[2];
            output[32] = input[5];
            output[35] = input[8];
            output[45] = input[35];
            output[48] = input[32];
            output[51] = input[29];
            output[11] = input[51];
            output[14] = input[48];
            output[17] = input[45];

            return output;

            // the end of this method should call the AssignAll method to update values
        }

          /////////////////////////////////////////////////
         /////////// RECEIVES INPUT FROM USER ////////////
        /////////////////////////////////////////////////

        /// <summary>
        /// Receives arrays of each side and combines them into one array.
        /// </summary>
        /// <param name="white"></param>
        /// <param name="blue"></param>
        /// <param name="orange"></param>
        /// <param name="green"></param>
        /// <param name="red"></param>
        /// <param name="yellow"></param>
        /// <returns></returns>
        private int[] AssignAll(int[] white, int[] blue, int[] orange, int[] green, int[] red, int[] yellow)
        {
            int[] all = new int[TOTAL_SIZE];

            // SHOULD GET RID OF ALL COLORASSIGN METHODS AND COMBINE THEM INTO ASSIGNALL
            // would turn 7 methods into 1

            for (int i = 0; i < SIZE; i++)
            {
                all[i] = white[i];
                all[i + 9] = blue[i];
                all[i + 18] = orange[i];
                all[i + 27] = green[i];
                all[i + 36] = red[i];
                all[i + 45] = yellow[i];
            }
            return all;
        }

        /// <summary>
        /// Updates white array with user input
        /// </summary>
        /// <param name="white"></param>
        private void AssignWhite(ref int[] white)
        {
            PictureBox[] whitePic = { picW0, picW1, picW2, picW3, picW4, picW5, picW6, picW7, picW8 };
            
            for (int i = 0; i < SIZE; i++)
            {
                if (whitePic[i].BackColor == Color.White)
                {
                    white[i] = WHITE;
                }
                else if (whitePic[i].BackColor == Color.Blue)
                {
                    white[i] = BLUE;
                }
                else if (whitePic[i].BackColor == Color.Orange)
                {
                    white[i] = ORANGE;
                }
                else if (whitePic[i].BackColor == Color.Green)
                {
                    white[i] = GREEN;
                }
                else if (whitePic[i].BackColor == Color.Red)
                {
                    white[i] = RED;
                }
                else if (whitePic[i].BackColor == Color.Yellow)
                {
                    white[i] = YELLOW;
                }
                else
                {
                    white[i] = SILVER;
                }
            }
        }

        /// <summary>
        /// Updates blue array with user input
        /// </summary>
        /// <param name="blue"></param>
        private void AssignBlue(ref int[] blue)
        {
            PictureBox[] bluePic = { picB0, picB1, picB2, picB3, picB4, picB5, picB6, picB7, picB8 };
            //CHANGE TO blue[i]
            for (int i = 0; i < SIZE; i++)
            {
                if (bluePic[i].BackColor == Color.White)
                {
                    white[i] = WHITE;
                }
                else if (bluePic[i].BackColor == Color.Blue)
                {
                    white[i] = BLUE;
                }
                else if (bluePic[i].BackColor == Color.Orange)
                {
                    white[i] = ORANGE;
                }
                else if (bluePic[i].BackColor == Color.Green)
                {
                    white[i] = GREEN;
                }
                else if (bluePic[i].BackColor == Color.Red)
                {
                    white[i] = RED;
                }
                else if (bluePic[i].BackColor == Color.Yellow)
                {
                    white[i] = YELLOW;
                }
                else
                {
                    white[i] = SILVER;
                }
            }
        }

        /// <summary>
        /// Updates orange array with user input
        /// </summary>
        /// <param name="orange"></param>
        private void AssignOrange(ref int[] orange)
        {
            PictureBox[] orangePic = { picO0, picO1, picO2, picO3, picO4, picO5, picO6, picO7, picO8 };

            for (int i = 0; i < SIZE; i++)
            {
                if (orangePic[i].BackColor == Color.White)
                {
                    orange[i] = WHITE;
                }
                else if (orangePic[i].BackColor == Color.Blue)
                {
                    orange[i] = BLUE;
                }
                else if (orangePic[i].BackColor == Color.Orange)
                {
                    orange[i] = ORANGE;
                }
                else if (orangePic[i].BackColor == Color.Green)
                {
                    orange[i] = GREEN;
                }
                else if (orangePic[i].BackColor == Color.Red)
                {
                    orange[i] = RED;
                }
                else if (orangePic[i].BackColor == Color.Yellow)
                {
                    orange[i] = YELLOW;
                }
                else
                {
                    orange[i] = SILVER;
                }
            }
        }

        /// <summary>
        /// Updates green array with user input
        /// </summary>
        /// <param name="green"></param>
        private void AssignGreen(ref int[] green)
        {
            PictureBox[] greenPic = { picG0, picG1, picG2, picG3, picG4, picG5, picG6, picG7, picG8 };
            //change to green[i]
            for (int i = 0; i < SIZE; i++)
            {
                if (greenPic[i].BackColor == Color.White)
                {
                    white[i] = WHITE;
                }
                else if (greenPic[i].BackColor == Color.Blue)
                {
                    white[i] = BLUE;
                }
                else if (greenPic[i].BackColor == Color.Orange)
                {
                    white[i] = ORANGE;
                }
                else if (greenPic[i].BackColor == Color.Green)
                {
                    white[i] = GREEN;
                }
                else if (greenPic[i].BackColor == Color.Red)
                {
                    white[i] = RED;
                }
                else if (greenPic[i].BackColor == Color.Yellow)
                {
                    white[i] = YELLOW;
                }
                else
                {
                    white[i] = SILVER;
                }
            }
        }

        /// <summary>
        /// Updates red array with user input
        /// </summary>
        /// <param name="red"></param>
        private void AssignRed(ref int[] red)
        {
            PictureBox[] redPic = { picR0, picR1, picR2, picR3, picR4, picR5, picR6, picR7, picR8 };
            //change to red[i]
            for (int i = 0; i < SIZE; i++)
            {
                if (redPic[i].BackColor == Color.White)
                {
                    white[i] = WHITE;
                }
                else if (redPic[i].BackColor == Color.Blue)
                {
                    white[i] = BLUE;
                }
                else if (redPic[i].BackColor == Color.Orange)
                {
                    white[i] = ORANGE;
                }
                else if (redPic[i].BackColor == Color.Green)
                {
                    white[i] = GREEN;
                }
                else if (redPic[i].BackColor == Color.Red)
                {
                    white[i] = RED;
                }
                else if (redPic[i].BackColor == Color.Yellow)
                {
                    white[i] = YELLOW;
                }
                else
                {
                    white[i] = SILVER;
                }
            }
        }

        /// <summary>
        /// Updates yellow array with user input
        /// </summary>
        /// <param name="yellow"></param>
        private void AssignYellow(ref int[] yellow)
        {
            PictureBox[] yellowPic = { picY0, picY1, picY2, picY3, picY4, picY5, picY6, picY7, picY8 };
            //change to yellow[i]
            for (int i = 0; i < SIZE; i++)
            {
                if (yellowPic[i].BackColor == Color.White)
                {
                    white[i] = WHITE;
                }
                else if (yellowPic[i].BackColor == Color.Blue)
                {
                    white[i] = BLUE;
                }
                else if (yellowPic[i].BackColor == Color.Orange)
                {
                    white[i] = ORANGE;
                }
                else if (yellowPic[i].BackColor == Color.Green)
                {
                    white[i] = GREEN;
                }
                else if (yellowPic[i].BackColor == Color.Red)
                {
                    white[i] = RED;
                }
                else if (yellowPic[i].BackColor == Color.Yellow)
                {
                    white[i] = YELLOW;
                }
                else
                {
                    white[i] = SILVER;
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
            }
        }

        /// <summary>
        /// Changes background color of button based on which colored radio button is checked.
        /// </summary>
        private void ChangeColor(object sender)
        {
            PictureBox pic = sender as PictureBox;

            if (radDisabled.Checked)
            {
                // do nothing
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
        /// Determines button clicked and sends to ChangeColor method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClicked(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

          //////////////////////////////////////////////////////
         /////////// RESETS FORM TO ORIGINAL STATE ////////////
        //////////////////////////////////////////////////////

        /// <summary>
        /// Resets form back to original state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
           

            foreach (PictureBox p in Controls)
            {
                if (p.GetType() == typeof(PictureBox))
                {
                    p.BackColor = Color.Silver;
                }
            }

            // Resets panel picture boxes to silver
            for (int i = 0; i < SIZE; i++)
            {
                whitePic[i].BackColor = Color.Silver;
                bluePic[i].BackColor = Color.Silver;
                orangePic[i].BackColor = Color.Silver;
                greenPic[i].BackColor = Color.Silver;
                redPic[i].BackColor = Color.Silver;
                yellowPic[i].BackColor = Color.Silver;
            }

            // More housekeeping
            radDisabled.Checked = true;
            radGreen.Checked = true;

        }
    }
}
