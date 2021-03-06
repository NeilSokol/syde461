﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Media;
using Microsoft.Research.Kinect.Nui;
using Microsoft.Research.Kinect.Audio;
using System.Threading;
using AForge.Imaging;
using AForge.Vision;
using AForge;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace SYDE461_UI
{
    partial class Debug : Form
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelStroke = new System.Windows.Forms.Label();
            this.comboBoxHealth = new System.Windows.Forms.ComboBox();
            this.correctedDistanceValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ballBox = new System.Windows.Forms.PictureBox();
            this.fingerDistanceValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(494, 330);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(352, 236);
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(344, 386);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 33);
            this.label7.TabIndex = 37;
            this.label7.Text = "5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 33);
            this.label6.TabIndex = 36;
            this.label6.Text = "Reps remaining";
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(98, 451);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(227, 76);
            this.exit.TabIndex = 35;
            this.exit.Text = "Leave exercise";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(344, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 33);
            this.label5.TabIndex = 34;
            this.label5.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 33);
            this.label4.TabIndex = 33;
            this.label4.Text = "Completed reps";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(881, 67);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(357, 222);
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(490, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(357, 222);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // labelStroke
            // 
            this.labelStroke.AutoSize = true;
            this.labelStroke.Location = new System.Drawing.Point(455, 633);
            this.labelStroke.Name = "labelStroke";
            this.labelStroke.Size = new System.Drawing.Size(79, 13);
            this.labelStroke.TabIndex = 30;
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
            this.comboBoxHealth.Location = new System.Drawing.Point(455, 657);
            this.comboBoxHealth.Name = "comboBoxHealth";
            this.comboBoxHealth.Size = new System.Drawing.Size(121, 21);
            this.comboBoxHealth.TabIndex = 29;
            // 
            // correctedDistanceValue
            // 
            this.correctedDistanceValue.AutoSize = true;
            this.correctedDistanceValue.Location = new System.Drawing.Point(265, 659);
            this.correctedDistanceValue.Name = "correctedDistanceValue";
            this.correctedDistanceValue.Size = new System.Drawing.Size(0, 13);
            this.correctedDistanceValue.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 633);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Corrected Finger Distance";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 32);
            this.label2.TabIndex = 26;
            this.label2.Text = "Squeeze the ball!";
            // 
            // ballBox
            // 
            this.ballBox.Location = new System.Drawing.Point(28, 79);
            this.ballBox.Name = "ballBox";
            this.ballBox.Size = new System.Drawing.Size(357, 222);
            this.ballBox.TabIndex = 25;
            this.ballBox.TabStop = false;
            // 
            // fingerDistanceValue
            // 
            this.fingerDistanceValue.AutoSize = true;
            this.fingerDistanceValue.Location = new System.Drawing.Point(32, 658);
            this.fingerDistanceValue.Name = "fingerDistanceValue";
            this.fingerDistanceValue.Size = new System.Drawing.Size(0, 13);
            this.fingerDistanceValue.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 633);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Finger Distance";
            // 
            // Debug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 710);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelStroke);
            this.Controls.Add(this.comboBoxHealth);
            this.Controls.Add(this.correctedDistanceValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ballBox);
            this.Controls.Add(this.fingerDistanceValue);
            this.Controls.Add(this.label1);
            this.Name = "Debug";
            this.Text = "Exercise Screen";
            this.Load += new System.EventHandler(this.Debug_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public PictureBox pictureBox3;
        public Label label7;
        public Label label6;
        private Button exit;
        public Label label5;
        private Label label4;
        public PictureBox pictureBox2;
        public PictureBox pictureBox1;
        private Label labelStroke;
        private ComboBox comboBoxHealth;
        public Label correctedDistanceValue;
        private Label label3;
        public Label label2;
        public PictureBox ballBox;
        public Label fingerDistanceValue;
        private Label label1;

        //public System.ComponentModel.BackgroundWorker bgw;
        //public System.ComponentModel.BackgroundWorker bgw_red;
    }
}
