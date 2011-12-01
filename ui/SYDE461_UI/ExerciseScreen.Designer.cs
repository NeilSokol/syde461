namespace SYDE461_UI
{
    partial class ExerciseScreen
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fingerDistanceValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ballBox = new System.Windows.Forms.PictureBox();
            this.glTest = new OpenTK.GLControl();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.bgw_red = new System.ComponentModel.BackgroundWorker();
            this.BallBoxLabel = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(40, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(357, 222);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // fingerDistanceValue
            // 
            this.fingerDistanceValue.AutoSize = true;
            this.fingerDistanceValue.Location = new System.Drawing.Point(37, 368);
            this.fingerDistanceValue.Name = "fingerDistanceValue";
            this.fingerDistanceValue.Size = new System.Drawing.Size(0, 13);
            this.fingerDistanceValue.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Finger Distance";
            // 
            // ballBox
            // 
            this.ballBox.Location = new System.Drawing.Point(436, 41);
            this.ballBox.Name = "ballBox";
            this.ballBox.Size = new System.Drawing.Size(357, 222);
            this.ballBox.TabIndex = 6;
            this.ballBox.TabStop = false;
            // 
            // glTest
            // 
            this.glTest.BackColor = System.Drawing.Color.Black;
            this.glTest.Location = new System.Drawing.Point(643, 269);
            this.glTest.Name = "glTest";
            this.glTest.Size = new System.Drawing.Size(150, 150);
            this.glTest.TabIndex = 7;
            this.glTest.VSync = false;
            // 
            // bgw
            // 
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // bgw_red
            // 
            this.bgw_red.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_red_DoWork);
            this.bgw_red.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_red_RunWorkerCompleted);
            // 
            // BallBoxLabel
            // 
            this.BallBoxLabel.Location = new System.Drawing.Point(637, 14);
            this.BallBoxLabel.Name = "BallBoxLabel";
            this.BallBoxLabel.ReadOnly = true;
            this.BallBoxLabel.Size = new System.Drawing.Size(144, 20);
            this.BallBoxLabel.TabIndex = 8;
            this.BallBoxLabel.Text = "Squeeze the Ball!";
            // 
            // ExerciseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 431);
            this.Controls.Add(this.BallBoxLabel);
            this.Controls.Add(this.glTest);
            this.Controls.Add(this.ballBox);
            this.Controls.Add(this.fingerDistanceValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ExerciseScreen";
            this.Text = "Exercise Screen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExerciseScreen_FormClosing);
            this.Load += new System.EventHandler(this.ExerciseScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label fingerDistanceValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ballBox;
        private OpenTK.GLControl glTest;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.ComponentModel.BackgroundWorker bgw_red;
        private System.Windows.Forms.TextBox BallBoxLabel;
    }
}