using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProjectFinal_JDoctor
{
    public partial class WelcomeForm : Form
    {
        // fields
        MainForm mainForm;
        HelpForm helpForm;

        public WelcomeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens a new instance of the mainform.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            // creates instance of mainform
            mainForm = new MainForm();

            // displays the form
            mainForm.Show();
        }

        /// <summary>
        /// Allows user to open a previous instance of the main form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContinue_Click(object sender, EventArgs e)
        {
            // local list variable
            List<int> fileList = new List<int>();

            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // stores FileName property of openFileDialog control in string
                    string path = openFileDialog.FileName;

                    // constructs StreamReader object, inFile
                    StreamReader inFile = File.OpenText(path);

                    // loops through file and counts number of values
                    int size = 0;
                    while (!inFile.EndOfStream)
                    {
                        fileList.Add(int.Parse(inFile.ReadLine()));
                        size++;
                    }

                    // closes flie
                    inFile.Close();

                    // initializes int[] temp array with size of file
                    int[] temp = new int[size];

                    // copies values from fileList to temp array
                    for (int i = 0; i < size; i++)
                    {
                        temp[i] = fileList[i];
                    }

                    // opens and displays new mainform with temp array as argument
                    mainForm = new MainForm(temp, path);
                    mainForm.Show();
                    
                }
            }
            catch
            {
                MessageBox.Show("Save file corrupted!\nCube failed to load.", "Error Opening File");
            }
        }

        /// <summary>
        /// Opens a new instance of the help form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            // creates instance of helpform
            helpForm = new HelpForm();

            // displays the form
            helpForm.Show();
        }
    }
}
