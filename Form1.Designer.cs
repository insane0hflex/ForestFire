namespace ForestFire
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.img_forest = new System.Windows.Forms.PictureBox();
            this.btn_populateForest = new System.Windows.Forms.Button();
            this.num_forestDensity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.img_forest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_forestDensity)).BeginInit();
            this.SuspendLayout();
            // 
            // img_forest
            // 
            this.img_forest.Location = new System.Drawing.Point(144, 12);
            this.img_forest.Name = "img_forest";
            this.img_forest.Size = new System.Drawing.Size(600, 600);
            this.img_forest.TabIndex = 0;
            this.img_forest.TabStop = false;
            // 
            // btn_populateForest
            // 
            this.btn_populateForest.Location = new System.Drawing.Point(12, 12);
            this.btn_populateForest.Name = "btn_populateForest";
            this.btn_populateForest.Size = new System.Drawing.Size(108, 23);
            this.btn_populateForest.TabIndex = 1;
            this.btn_populateForest.Text = "Populate Forest";
            this.btn_populateForest.UseVisualStyleBackColor = true;
            this.btn_populateForest.Click += new System.EventHandler(this.btn_populateForest_Click);
            // 
            // num_forestDensity
            // 
            this.num_forestDensity.DecimalPlaces = 2;
            this.num_forestDensity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.num_forestDensity.Location = new System.Drawing.Point(8, 56);
            this.num_forestDensity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_forestDensity.Name = "num_forestDensity";
            this.num_forestDensity.Size = new System.Drawing.Size(120, 20);
            this.num_forestDensity.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 630);
            this.Controls.Add(this.num_forestDensity);
            this.Controls.Add(this.btn_populateForest);
            this.Controls.Add(this.img_forest);
            this.Name = "Form1";
            this.Text = "Forest Fire Model";
            ((System.ComponentModel.ISupportInitialize)(this.img_forest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_forestDensity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox img_forest;
        private System.Windows.Forms.Button btn_populateForest;
        private System.Windows.Forms.NumericUpDown num_forestDensity;
    }
}

