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


        //Tree values
        enum Tree
        {
            None = 0,
            Alive = 1,
            OnFire = 2
        }

        private Tree[,] forest = new Tree[150, 150];


        public Form1()
        {
            InitializeComponent();

            img_forest.BackColor = Color.Black;
        }


        /// <summary>
        /// Populate the forest array by setting a cell to true if is below the indicated forest population density
        /// </summary>
        private void PopulateForestWithTrees()
        {
            Random random = new Random();

            double forestDensity = Convert.ToDouble(num_forestDensity.Value);

            //populate the forest with trees. a tree bit is set to true if it is less than a random double value
            for (int i = 0; i < forest.GetLength(0); i++)
            {

                for (int j = 0; j < forest.GetLength(1); j++)
                {
                    if (random.NextDouble() < forestDensity)
                    {
                        forest[i, j] = Tree.Alive;
                    }
                }
            }
        }


        /// <summary>
        /// Draw a new bitmap to represent the forest.
        /// </summary>
        private void DrawForest()
        {
            Bitmap newForestImage = new Bitmap(150,150);

            var treeBrush = new SolidBrush(Color.Green);
            var fireBrush = new SolidBrush(Color.Red);
            Graphics graphics;

            graphics = CreateGraphics();


            //graphics = (Graphics)img_forest.Image;
            
            //color pixels green for cells that have trees
            for (int i = 0; i < forest.GetLength(0); i++)
            {

                for (int j = 0; j < forest.GetLength(1); j++)
                {
                    var tree = new Rectangle(i * 4, j * 4, 4, 4);

                    if (forest[0, j] == Tree.Alive)
                    {
                        forest[0, j] = Tree.OnFire;
                        //newForestImage.SetPixel(i, j, Color.Red);
                        graphics.FillRectangle(fireBrush, tree);

                    }


                    if (forest[i, j] == Tree.Alive)
                    {
                        graphics.FillRectangle(treeBrush, tree);
                        //newForestImage.SetPixel(i, j, Color.Green);
                    }
                }

            }

            img_forest.Image = newForestImage;

        }




        /// <summary>
        /// Populate Forest button click event
        /// </summary>
        private void btn_populateForest_Click(object sender, EventArgs e)
        {
            ResetForest();
            PopulateForestWithTrees();
            DrawForest();
        }


        /// <summary>
        /// resets the forest bool array to all false (black)
        /// </summary>
        private void ResetForest()
        {
            for(int i = 0; i < forest.GetLength(0); i++)
            {
                for (int j = 0; j < forest.GetLength(1); j++)
                {
                    forest[i, j] = Tree.None;
                }
            }
        }

        /// <summary>
        /// Start the forest fire - check for adjacent (not diagonal) forest nodes and burn them in each timestep
        /// </summary>
        private void StartForestFire()
        {


        }

    }
}
