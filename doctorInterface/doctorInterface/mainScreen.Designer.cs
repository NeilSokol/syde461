namespace doctorInterface
{
    partial class mainScreen
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.patientListbox = new System.Windows.Forms.ListBox();
            this.patientLabel = new System.Windows.Forms.Label();
            this.addExerciseButton = new System.Windows.Forms.Button();
            this.exerciseDate = new System.Windows.Forms.DateTimePicker();
            this.exerciseDatelabel = new System.Windows.Forms.Label();
            this.exerciseComboBox = new System.Windows.Forms.ComboBox();
            this.exerciseLabel = new System.Windows.Forms.Label();
            this.ampTrackBar = new System.Windows.Forms.TrackBar();
            this.amplificationLabel = new System.Windows.Forms.Label();
            this.numRepLabel = new System.Windows.Forms.Label();
            this.repTrackBar = new System.Windows.Forms.TrackBar();
            this.repCountLabel = new System.Windows.Forms.Label();
            this.ampLabel = new System.Windows.Forms.Label();
            this.currentExerciseLabel = new System.Windows.Forms.Label();
            this.exerciseDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ampTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exerciseDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(230, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(224, 31);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Patient Exercises";
            // 
            // patientListbox
            // 
            this.patientListbox.FormattingEnabled = true;
            this.patientListbox.Location = new System.Drawing.Point(35, 93);
            this.patientListbox.Name = "patientListbox";
            this.patientListbox.Size = new System.Drawing.Size(239, 147);
            this.patientListbox.TabIndex = 1;
            this.patientListbox.SelectedIndexChanged += new System.EventHandler(this.patientListbox_SelectedIndexChanged);
            // 
            // patientLabel
            // 
            this.patientLabel.AutoSize = true;
            this.patientLabel.Location = new System.Drawing.Point(32, 64);
            this.patientLabel.Name = "patientLabel";
            this.patientLabel.Size = new System.Drawing.Size(40, 13);
            this.patientLabel.TabIndex = 2;
            this.patientLabel.Text = "Patient";
            // 
            // addExerciseButton
            // 
            this.addExerciseButton.Location = new System.Drawing.Point(578, 572);
            this.addExerciseButton.Name = "addExerciseButton";
            this.addExerciseButton.Size = new System.Drawing.Size(212, 46);
            this.addExerciseButton.TabIndex = 3;
            this.addExerciseButton.Text = "Add Exercise";
            this.addExerciseButton.UseVisualStyleBackColor = true;
            this.addExerciseButton.Click += new System.EventHandler(this.addExerciseButton_Click);
            // 
            // exerciseDate
            // 
            this.exerciseDate.Location = new System.Drawing.Point(590, 267);
            this.exerciseDate.Name = "exerciseDate";
            this.exerciseDate.Size = new System.Drawing.Size(200, 20);
            this.exerciseDate.TabIndex = 4;
            // 
            // exerciseDatelabel
            // 
            this.exerciseDatelabel.AutoSize = true;
            this.exerciseDatelabel.Location = new System.Drawing.Point(498, 274);
            this.exerciseDatelabel.Name = "exerciseDatelabel";
            this.exerciseDatelabel.Size = new System.Drawing.Size(73, 13);
            this.exerciseDatelabel.TabIndex = 5;
            this.exerciseDatelabel.Text = "Exercise Date";
            // 
            // exerciseComboBox
            // 
            this.exerciseComboBox.FormattingEnabled = true;
            this.exerciseComboBox.Items.AddRange(new object[] {
            "pinch"});
            this.exerciseComboBox.Location = new System.Drawing.Point(590, 323);
            this.exerciseComboBox.Name = "exerciseComboBox";
            this.exerciseComboBox.Size = new System.Drawing.Size(121, 21);
            this.exerciseComboBox.TabIndex = 6;
            // 
            // exerciseLabel
            // 
            this.exerciseLabel.AutoSize = true;
            this.exerciseLabel.Location = new System.Drawing.Point(498, 331);
            this.exerciseLabel.Name = "exerciseLabel";
            this.exerciseLabel.Size = new System.Drawing.Size(47, 13);
            this.exerciseLabel.TabIndex = 7;
            this.exerciseLabel.Text = "Exercise";
            // 
            // ampTrackBar
            // 
            this.ampTrackBar.LargeChange = 10;
            this.ampTrackBar.Location = new System.Drawing.Point(590, 466);
            this.ampTrackBar.Maximum = 50;
            this.ampTrackBar.Minimum = 10;
            this.ampTrackBar.Name = "ampTrackBar";
            this.ampTrackBar.Size = new System.Drawing.Size(189, 45);
            this.ampTrackBar.TabIndex = 8;
            this.ampTrackBar.Value = 10;
            this.ampTrackBar.ValueChanged += new System.EventHandler(this.ampTrackBar_ValueChanged);
            // 
            // amplificationLabel
            // 
            this.amplificationLabel.AutoSize = true;
            this.amplificationLabel.Location = new System.Drawing.Point(498, 466);
            this.amplificationLabel.Name = "amplificationLabel";
            this.amplificationLabel.Size = new System.Drawing.Size(66, 13);
            this.amplificationLabel.TabIndex = 9;
            this.amplificationLabel.Tag = "";
            this.amplificationLabel.Text = "Amplification";
            // 
            // numRepLabel
            // 
            this.numRepLabel.AutoSize = true;
            this.numRepLabel.Location = new System.Drawing.Point(498, 400);
            this.numRepLabel.Name = "numRepLabel";
            this.numRepLabel.Size = new System.Drawing.Size(84, 13);
            this.numRepLabel.TabIndex = 10;
            this.numRepLabel.Tag = "";
            this.numRepLabel.Text = "Number of Reps";
            // 
            // repTrackBar
            // 
            this.repTrackBar.Location = new System.Drawing.Point(590, 400);
            this.repTrackBar.Maximum = 20;
            this.repTrackBar.Minimum = 1;
            this.repTrackBar.Name = "repTrackBar";
            this.repTrackBar.Size = new System.Drawing.Size(189, 45);
            this.repTrackBar.TabIndex = 11;
            this.repTrackBar.Value = 1;
            this.repTrackBar.ValueChanged += new System.EventHandler(this.repTrackBar_ValueChanged);
            // 
            // repCountLabel
            // 
            this.repCountLabel.AutoSize = true;
            this.repCountLabel.Location = new System.Drawing.Point(796, 400);
            this.repCountLabel.Name = "repCountLabel";
            this.repCountLabel.Size = new System.Drawing.Size(0, 13);
            this.repCountLabel.TabIndex = 12;
            // 
            // ampLabel
            // 
            this.ampLabel.AutoSize = true;
            this.ampLabel.Location = new System.Drawing.Point(797, 466);
            this.ampLabel.Name = "ampLabel";
            this.ampLabel.Size = new System.Drawing.Size(0, 13);
            this.ampLabel.TabIndex = 13;
            // 
            // currentExerciseLabel
            // 
            this.currentExerciseLabel.AutoSize = true;
            this.currentExerciseLabel.Location = new System.Drawing.Point(35, 345);
            this.currentExerciseLabel.Name = "currentExerciseLabel";
            this.currentExerciseLabel.Size = new System.Drawing.Size(88, 13);
            this.currentExerciseLabel.TabIndex = 14;
            this.currentExerciseLabel.Text = "Patient Exercises";
            // 
            // exerciseDataGrid
            // 
            this.exerciseDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exerciseDataGrid.Location = new System.Drawing.Point(38, 387);
            this.exerciseDataGrid.Name = "exerciseDataGrid";
            this.exerciseDataGrid.Size = new System.Drawing.Size(353, 231);
            this.exerciseDataGrid.TabIndex = 15;
            // 
            // mainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 647);
            this.Controls.Add(this.exerciseDataGrid);
            this.Controls.Add(this.currentExerciseLabel);
            this.Controls.Add(this.ampLabel);
            this.Controls.Add(this.repCountLabel);
            this.Controls.Add(this.repTrackBar);
            this.Controls.Add(this.numRepLabel);
            this.Controls.Add(this.amplificationLabel);
            this.Controls.Add(this.ampTrackBar);
            this.Controls.Add(this.exerciseLabel);
            this.Controls.Add(this.exerciseComboBox);
            this.Controls.Add(this.exerciseDatelabel);
            this.Controls.Add(this.exerciseDate);
            this.Controls.Add(this.addExerciseButton);
            this.Controls.Add(this.patientLabel);
            this.Controls.Add(this.patientListbox);
            this.Controls.Add(this.titleLabel);
            this.Name = "mainScreen";
            this.Text = "mainScreen";
            ((System.ComponentModel.ISupportInitialize)(this.ampTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exerciseDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ListBox patientListbox;
        private System.Windows.Forms.Label patientLabel;
        private System.Windows.Forms.Button addExerciseButton;
        private System.Windows.Forms.DateTimePicker exerciseDate;
        private System.Windows.Forms.Label exerciseDatelabel;
        private System.Windows.Forms.ComboBox exerciseComboBox;
        private System.Windows.Forms.Label exerciseLabel;
        private System.Windows.Forms.TrackBar ampTrackBar;
        private System.Windows.Forms.Label amplificationLabel;
        private System.Windows.Forms.Label numRepLabel;
        private System.Windows.Forms.TrackBar repTrackBar;
        private System.Windows.Forms.Label repCountLabel;
        private System.Windows.Forms.Label ampLabel;
        private System.Windows.Forms.Label currentExerciseLabel;
        private System.Windows.Forms.DataGridView exerciseDataGrid;
    }
}