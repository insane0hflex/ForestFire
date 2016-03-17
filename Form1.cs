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
        public enum Tree
        {
            None = 0,
            Alive,
            ToBurn,
            OnFire,
            Burnt 
        }

        private Tree[,] forest = new Tree[150, 150];

        //brushes to color the trees (rectangles)
        SolidBrush noTreeBrush = new SolidBrush(Color.LightGoldenrodYellow);
        SolidBrush burntTreeBrush = new SolidBrush(Color.Black);
        SolidBrush aliveTreeBrush = new SolidBrush(Color.Green);
        SolidBrush onFireTreeBrush = new SolidBrush(Color.Red);

        //if greater than 1 - sets the far left to burnt
        private int timerIntervalCheck = 0;

        public Form1()
        {
            InitializeComponent();

            //set some controls to a default value
            num_forestDensity.Value = Convert.ToDecimal(0.5);
            numeric_timeToBurn.Value = 20; //20ms default
            numeric_windPercentage.Value = Convert.ToDecimal(0.25);

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
            timerIntervalCheck = 0;

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

                    //initially all trees on the left side are "on fire" - so if the tree is on the left and is alive, set it onfire.
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
                    else if (forest[i,j] == Tree.ToBurn)
                    {
                        e.Graphics.FillRectangle(onFireTreeBrush, tree);
                        forest[i, j] = Tree.OnFire;
                    }
                    else if (forest[i, j] == Tree.OnFire)
                    {
                        //e.Graphics.FillRectangle(burntTreeBrush, tree);
                        e.Graphics.FillRectangle(onFireTreeBrush, tree);
                        //forest[i, j] = Tree.Burnt;

                        //TODO: left side still remains as "burning"
                        //maybe make a bool or timer.interval > 1 or something to set these left column trees to burnt

                        //If the tree was on fire - set it to "Tree.Burnt" so that the tree is burnt and colored black next timestep
                        if (i > 0)
                        {
                            forest[i, j] = Tree.Burnt;
                        }
                        else if (i == 0 && timerIntervalCheck > 1)
                        {
                            forest[0, j] = Tree.Burnt;
                        }
                    }
                    else if (forest[i,j] == Tree.Burnt)
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
        private void StartForestFire()
        {
            for (int i = 0; i < forest.GetLength(0); i++)
            {
                for (int j = 0; j < forest.GetLength(1); j++)
                {
                    if(forest[i,j] == Tree.OnFire)
                    {
                        
                        //burn up
                        if(j > 0)
                        {
                            if(forest[i, j - 1] == Tree.Alive)
                            {
                                forest[i, j - 1] = Tree.ToBurn;
                            }
                        }

                        // burn right
                        if (i < (forest.GetLength(0)-1))
                        {

                            if(forest[i + 1, j] == Tree.Alive)
                            {
                                forest[i + 1, j] = Tree.ToBurn;
                            }
                        }

                        //burn down
                        if (j < (forest.GetLength(1)-1))
                        {
                            if (forest[i, j + 1] == Tree.Alive)
                            {
                                forest[i, j + 1] = Tree.ToBurn;
                            }
                        }


                        //burn left
                        if (i > 0) //dont array out of bounds
                        {
                            if (forest[i - 1, j] == Tree.Alive)
                            {
                                forest[i - 1, j] = Tree.ToBurn;
                            }
                        }

                        //Wind check
                        if(chkbx_wind.Checked)
                        {
                            //get numeric up_down wind value
                            double windPercentage = Convert.ToDouble(numeric_windPercentage.Value);

                            //see the next array element/cell
                            //this if check makes sure we dont array out of bounds
                            if (i < forest.GetLength(0) - 2)
                            {
                                var windSetOnFire = new Random();

                                if(windSetOnFire.NextDouble() < windPercentage)
                                {
                                    if(forest[i + 2, j] == Tree.Alive)
                                    {
                                        forest[i + 2, j] = Tree.ToBurn;
                                    }
                                }

                            }

                            //see the next->next array element cell (+ 1 + 1 + 1)
                            //this if check makes sure we dont array out of bounds
                            if (i < forest.GetLength(1) - 3)
                            {
                                var windSetOnFire = new Random();

                                //has half the chance as the previous wind check
                                if(windSetOnFire.NextDouble() < (windPercentage/2))
                                {
                                    if (forest[i + 3, j] == Tree.Alive)
                                    {
                                        forest[i + 3, j] = Tree.ToBurn;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Timer interval based on the numeric_timeToBurn control's value
        /// </summary>
        private void btn_startFire_Click(object sender, EventArgs e)
        {
            //trigger redraw
            timer_burn.Interval = Convert.ToInt32(numeric_timeToBurn.Value);
            timer_burn.Enabled = true;
        }


        /// <summary>
        /// invoke the StartForestFire() method which starts the burn.
        /// This timer invokes the StartForestFire() method and a repaint to the image
        /// </summary>
        private void timer_burn_Tick(object sender, EventArgs e)
        {

            StartForestFire();

            timerIntervalCheck++;

            //trigger repaint
            img_forest.Invalidate();

        }
    }
}
