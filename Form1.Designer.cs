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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.img_forest = new System.Windows.Forms.PictureBox();
            this.btn_populateForest = new System.Windows.Forms.Button();
            this.num_forestDensity = new System.Windows.Forms.NumericUpDown();
            this.btn_startFire = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer_burn = new System.Windows.Forms.Timer(this.components);
            this.chkbx_wind = new System.Windows.Forms.CheckBox();
            this.numeric_timeToBurn = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numeric_windPercentage = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.img_forest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_forestDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_timeToBurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_windPercentage)).BeginInit();
            this.SuspendLayout();
            // 
            // img_forest
            // 
            this.img_forest.Location = new System.Drawing.Point(144, 12);
            this.img_forest.Name = "img_forest";
            this.img_forest.Size = new System.Drawing.Size(600, 600);
            this.img_forest.TabIndex = 0;
            this.img_forest.TabStop = false;
            this.img_forest.Paint += new System.Windows.Forms.PaintEventHandler(this.img_forest_Paint);
            // 
            // btn_populateForest
            // 
            this.btn_populateForest.Location = new System.Drawing.Point(12, 67);
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
            5,
            0,
            0,
            131072});
            this.num_forestDensity.Location = new System.Drawing.Point(12, 41);
            this.num_forestDensity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_forestDensity.Name = "num_forestDensity";
            this.num_forestDensity.Size = new System.Drawing.Size(108, 20);
            this.num_forestDensity.TabIndex = 2;
            // 
            // btn_startFire
            // 
            this.btn_startFire.Location = new System.Drawing.Point(12, 246);
            this.btn_startFire.Name = "btn_startFire";
            this.btn_startFire.Size = new System.Drawing.Size(108, 23);
            this.btn_startFire.TabIndex = 3;
            this.btn_startFire.Text = "Start Fire";
            this.btn_startFire.UseVisualStyleBackColor = true;
            this.btn_startFire.Click += new System.EventHandler(this.btn_startFire_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Forest Density";
            // 
            // timer_burn
            // 
            this.timer_burn.Interval = 20;
            this.timer_burn.Tick += new System.EventHandler(this.timer_burn_Tick);
            // 
            // chkbx_wind
            // 
            this.chkbx_wind.AutoSize = true;
            this.chkbx_wind.Location = new System.Drawing.Point(12, 164);
            this.chkbx_wind.Name = "chkbx_wind";
            this.chkbx_wind.Size = new System.Drawing.Size(115, 17);
            this.chkbx_wind.TabIndex = 5;
            this.chkbx_wind.Text = "Enable Right Wind";
            this.chkbx_wind.UseVisualStyleBackColor = true;
            // 
            // numeric_timeToBurn
            // 
            this.numeric_timeToBurn.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numeric_timeToBurn.Location = new System.Drawing.Point(12, 128);
            this.numeric_timeToBurn.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numeric_timeToBurn.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numeric_timeToBurn.Name = "numeric_timeToBurn";
            this.numeric_timeToBurn.Size = new System.Drawing.Size(108, 20);
            this.numeric_timeToBurn.TabIndex = 6;
            this.numeric_timeToBurn.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Time Per Burn (ms)";
            // 
            // numeric_windPercentage
            // 
            this.numeric_windPercentage.DecimalPlaces = 2;
            this.numeric_windPercentage.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numeric_windPercentage.Location = new System.Drawing.Point(12, 210);
            this.numeric_windPercentage.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_windPercentage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numeric_windPercentage.Name = "numeric_windPercentage";
            this.numeric_windPercentage.Size = new System.Drawing.Size(108, 20);
            this.numeric_windPercentage.TabIndex = 9;
            this.numeric_windPercentage.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Wind Percentage";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 641);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numeric_windPercentage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numeric_timeToBurn);
            this.Controls.Add(this.chkbx_wind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_startFire);
            this.Controls.Add(this.num_forestDensity);
            this.Controls.Add(this.btn_populateForest);
            this.Controls.Add(this.img_forest);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Forest Fire Model";
            ((System.ComponentModel.ISupportInitialize)(this.img_forest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_forestDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_timeToBurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_windPercentage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox img_forest;
        private System.Windows.Forms.Button btn_populateForest;
        private System.Windows.Forms.NumericUpDown num_forestDensity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_startFire;
        private System.Windows.Forms.Timer timer_burn;
        private System.Windows.Forms.CheckBox chkbx_wind;
        private System.Windows.Forms.NumericUpDown numeric_timeToBurn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numeric_windPercentage;
    }
}

