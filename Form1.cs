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


        //Tree "datatype"
        enum Tree
        {
            None = 0,
            Alive = 1,
            OnFire = 2,
            Burnt = 3
        }

        private Tree[,] forest = new Tree[150, 150];

        //brushes to color the trees (rectangles)
        SolidBrush burntTreeBrush = new SolidBrush(Color.Black);
        SolidBrush aliveTreeBrush = new SolidBrush(Color.Green);
        SolidBrush onFireTreeBrush = new SolidBrush(Color.Red);

        bool hasBeenSetup = false; //

        public Form1()
        {
            InitializeComponent();

            //set the number control to a default value
            num_forestDensity.Value = (decimal)0.5;

        }


        /// <summary>
        /// Populate the forest array by setting a cell to true if is below the indicated forest population density
        /// </summary>
        private void PopulateForestWithTrees()
        {
            var random = new Random();

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
        /// Populate Forest button click event
        /// </summary>
        private void btn_populateForest_Click(object sender, EventArgs e)
        {
            ResetForest();
            PopulateForestWithTrees();

            // pictureBox Invalidate() triggers the paint method
            img_forest.Invalidate();
        }


        /// <summary>
        /// resets the forest Tree array to be all no trees (black)
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
            for (int i = 0; i < forest.GetLength(0); i++)
            {
                for (int j = 0; j < forest.GetLength(1); j++)
                {
                    forest[i, j] = Tree.None;
                }
            }

        }

        /// <summary>
        /// On an Invalidate event - triggers the repaint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void img_forest_Paint(object sender, PaintEventArgs e)
        {
            //graphics = (Graphics)img_forest.Image;

            //color pixels green for cells that have trees
            for (int i = 0; i < forest.GetLength(0); i++)
            {

                for (int j = 0; j < forest.GetLength(1); j++)
                {
                    var tree = new Rectangle(i * 4, j * 4, 4, 4);

                    if (forest[i, j] == Tree.OnFire)
                    {
                        //make current tree burnt
                        e.Graphics.FillRectangle(burntTreeBrush, tree);
                        
                        //adjacent trees need to be set on fire
                        //burn right tree
                        if(i < 149 && j < 149)
                        {
                            //burn right
                            if (forest[i + 1, j] == Tree.Alive)
                            {
                                forest[i + 1, j] = Tree.OnFire;

                            }

                            //burn down
                            if (forest[i, j + 1] == Tree.Alive)
                            {
                                forest[i, j + 1] = Tree.OnFire;
                            }

                        }

                    }
                    //initially all trees on the left side are "on fire" - so if the tree is alive, now its onfire.
                    else if (forest[0, j] == Tree.Alive)
                    {
                        forest[0, j] = Tree.OnFire;
                        e.Graphics.FillRectangle(onFireTreeBrush, tree);
                    }
                    else if (forest[i, j] == Tree.Alive)
                    {
                        e.Graphics.FillRectangle(aliveTreeBrush, tree);
                    }



                }

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_startFire_Click(object sender, EventArgs e)
        {
            img_forest.Invalidate();
        }
    }
}
