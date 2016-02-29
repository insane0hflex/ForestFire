using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForestFire
{
    public partial class Form1 : Form
    {

        //2D array of trees in the forest
        private bool[,] forest = new bool[150, 150];


        public Form1()
        {
            InitializeComponent();

            img_forest.Image = new Bitmap(150, 150);
            img_forest.BackColor = Color.Black;
        }



        private void PopulateForestWithTrees()
        {
            Random random = new Random();

            // do a regex test for valid input in the textbox here before the covert to double
            double forestDensity = Convert.ToDouble(0.25);

            //populate the forest with trees. a tree bit is set to true if it is less than a random double value
            for (int i = 0; i < forest.GetLength(0); i++)
            {

                for (int j = 0; j < forest.GetLength(1); j++)
                {
                    if (random.NextDouble() < forestDensity)
                    {
                        forest[i, j] = true;
                    }
                }

            }

        }


        private void DrawForestImage()
        {
            Bitmap newForestImage = new Bitmap(150,150);


            //color pixels green for cells that have trees
            for (int i = 0; i < forest.GetLength(0); i++)
            {

                for (int j = 0; j < forest.GetLength(1); j++)
                {
                    if (forest[i, j])
                    {
                        newForestImage.SetPixel(i, j, Color.Green);
                    }
                }

            }

            img_forest.Image = newForestImage;

        }

        private void btn_populateForest_Click(object sender, EventArgs e)
        {
            ResetForest();
            PopulateForestWithTrees();
            DrawForestImage();
        }


        private void ResetForest()
        {
            for(int i = 0; i < forest.GetLength(0); i++)
            {
                for (int j = 0; j < forest.GetLength(1); j++)
                {
                    forest[i, j] = false;
                }
            }
        }

    }
}
