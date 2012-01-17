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
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.bgw_red = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(703, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Squeeze the Ball!";
            // 
            // ExerciseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 431);
            this.Controls.Add(this.label2);
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
        private System.ComponentModel.BackgroundWorker bgw;
        private System.ComponentModel.BackgroundWorker bgw_red;
        private System.Windows.Forms.Label label2;
    }
}