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
        SolidBrush noTreeBrush = new SolidBrush(Color.PaleGoldenrod);
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
            timer_burn.Enabled = false;
            //MessageBox.Show("Creating a new forest");
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

                    //initially all trees on the left side are "on fire" - so if the tree is alive, now its onfire.
                    if (forest[0, j] == Tree.Alive)
                    {
                        forest[0, j] = Tree.OnFire;
                        e.Graphics.FillRectangle(onFireTreeBrush, tree);
                    }

                    if (forest[i, j] == Tree.Alive)
                    {
                        e.Graphics.FillRectangle(aliveTreeBrush, tree);
                    }
                    else if (forest[i, j] == Tree.None)
                    {
                        e.Graphics.FillRectangle(noTreeBrush, tree);
                    }
                    else if (forest[i, j] == Tree.OnFire)
                    {
                        e.Graphics.FillRectangle(burntTreeBrush, tree);
                    }



                }

            }
        }

        /// <summary>
        /// Starts the forest burning and is used by the timer to control the forest burning time increments
        /// </summary>
        /// <returns>false if forest still has burnable trees.
        /// true if forest is done burning</returns>
        private bool IsForestBurning()
        {
            #warning maybe just make this return void
            bool canBurn = false;

            for (int i = 0; i < forest.GetLength(0); i++)
            {
                for (int j = 0; j < forest.GetLength(1); j++)
                {
                    if(forest[i,j] == Tree.OnFire)
                    {
                        canBurn = true;
                        
                        //burn up
                        if(j > 0)
                        {
                            if(forest[i, j - 1] == Tree.Alive)
                            {
                                forest[i, j - 1] = Tree.OnFire;
                            }
                        }

                        // burn right
                        if (i < (forest.GetLength(0)-1))
                        {
                            if(forest[i + 1, j] == Tree.Alive)
                            {
                                forest[i + 1, j] = Tree.OnFire;
                            }
                        }

                        //burn down
                        if (j < (forest.GetLength(1)-1))
                        {
                            if (forest[i, j + 1] == Tree.Alive)
                            {
                                forest[i, j + 1] = Tree.OnFire;
                            }
                        }


                        //burn left
                        if (i > 0) //dont array out of bounds
                        {
                            if (forest[i - 1, j] == Tree.Alive)
                            {
                                forest[i - 1, j] = Tree.OnFire;
                            }
                        }

                        //Wind check
                        if(chkbx_wind.Checked)
                        {
                            //see the next array element/cell
                            if(i < forest.GetLength(0) - 2)
                            {
                                var windSetOnFire = new Random();

                                if(windSetOnFire.NextDouble() < 0.5)
                                {
                                    if(forest[i+2, j] == Tree.Alive)
                                    {
                                        forest[i + 2, j] = Tree.OnFire;
                                    }
                                }

                            }

                            //see the next->next array element cell (+ 1 + 1 + 1)
                            if(i < forest.GetLength(1) - 3)
                            {
                                var windSetOnFire = new Random();

                                if(windSetOnFire.NextDouble() < 0.25)
                                {
                                    if (forest[i + 3, j] == Tree.Alive)
                                    {
                                        forest[i + 3, j] = Tree.OnFire;
                                    }
                                }
                            }
                        }



                    }

                }
            }

            if(!canBurn)
            {
                return false;
            }
            else
            {
                return true;

            }


        }

        /// <summary>
        /// 
        /// </summary>
        private void btn_startFire_Click(object sender, EventArgs e)
        {
            //trigger redraw
            //img_forest.Invalidate();
            //timer_burn.Interval = (int) numeric_timeToBurn.Value;
            timer_burn.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void timer_burn_Tick(object sender, EventArgs e)
        {
            bool isForestBurning = IsForestBurning();

            img_forest.Invalidate();

            //turn off timer when forest is done burning
            if(!isForestBurning)
            {
                MessageBox.Show("Burn complete!");
                timer_burn.Enabled = false;
            }
        }
    }
}
