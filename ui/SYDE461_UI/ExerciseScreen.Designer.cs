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
            this.fingerDistanceValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ballBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.correctedDistanceValue = new System.Windows.Forms.Label();
            this.labelStroke = new System.Windows.Forms.Label();
            this.comboBoxHealth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ballBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fingerDistanceValue
            // 
            this.fingerDistanceValue.AutoSize = true;
            this.fingerDistanceValue.Location = new System.Drawing.Point(70, 646);
            this.fingerDistanceValue.Name = "fingerDistanceValue";
            this.fingerDistanceValue.Size = new System.Drawing.Size(0, 13);
            this.fingerDistanceValue.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 621);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Finger Distance";
            // 
            // ballBox
            // 
            this.ballBox.Location = new System.Drawing.Point(66, 67);
            this.ballBox.Name = "ballBox";
            this.ballBox.Size = new System.Drawing.Size(357, 222);
            this.ballBox.TabIndex = 6;
            this.ballBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "Squeeze the ball!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 621);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Corrected Finger Distance";
            // 
            // correctedDistanceValue
            // 
            this.correctedDistanceValue.AutoSize = true;
            this.correctedDistanceValue.Location = new System.Drawing.Point(303, 647);
            this.correctedDistanceValue.Name = "correctedDistanceValue";
            this.correctedDistanceValue.Size = new System.Drawing.Size(0, 13);
            this.correctedDistanceValue.TabIndex = 12;
            // 
            // labelStroke
            // 
            this.labelStroke.AutoSize = true;
            this.labelStroke.Location = new System.Drawing.Point(493, 621);
            this.labelStroke.Name = "labelStroke";
            this.labelStroke.Size = new System.Drawing.Size(79, 13);
            this.labelStroke.TabIndex = 14;
            this.labelStroke.Text = "Stroke Severity";
            // 
            // comboBoxHealth
            // 
            this.comboBoxHealth.FormattingEnabled = true;
            this.comboBoxHealth.Items.AddRange(new object[] {
            "No Stroke",
            "6 Month Recovery",
            "1 Month Recovery",
            "Severe Stroke"});
            this.comboBoxHealth.Location = new System.Drawing.Point(493, 645);
            this.comboBoxHealth.Name = "comboBoxHealth";
            this.comboBoxHealth.Size = new System.Drawing.Size(121, 21);
            this.comboBoxHealth.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 33);
            this.label4.TabIndex = 17;
            this.label4.Text = "Completed reps";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(382, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 33);
            this.label5.TabIndex = 18;
            this.label5.Text = "0";
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(136, 439);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(227, 76);
            this.exit.TabIndex = 19;
            this.exit.Text = "Leave exercise";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(66, 374);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 33);
            this.label6.TabIndex = 20;
            this.label6.Text = "Reps remaining";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(382, 374);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 33);
            this.label7.TabIndex = 21;
            this.label7.Text = "5";
            // 
            // ExerciseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 683);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelStroke);
            this.Controls.Add(this.comboBoxHealth);
            this.Controls.Add(this.correctedDistanceValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ballBox);
            this.Controls.Add(this.fingerDistanceValue);
            this.Controls.Add(this.label1);
            this.Name = "ExerciseScreen";
            this.Text = "Exercise Screen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExerciseScreen_FormClosing);
            this.Load += new System.EventHandler(this.ExerciseScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ballBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label fingerDistanceValue;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox ballBox;
        //public System.ComponentModel.BackgroundWorker bgw;
        //public System.ComponentModel.BackgroundWorker bgw_red;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label correctedDistanceValue;
        private System.Windows.Forms.Label labelStroke;
        private System.Windows.Forms.ComboBox comboBoxHealth;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button exit;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
    }
}