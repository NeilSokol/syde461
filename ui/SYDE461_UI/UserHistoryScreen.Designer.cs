namespace SYDE461_UI
{
    partial class UserHistoryScreen
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
            this.sessionList = new System.Windows.Forms.ListBox();
            this.Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.exerciseGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.exerciseGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // sessionList
            // 
            this.sessionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sessionList.FormattingEnabled = true;
            this.sessionList.ItemHeight = 25;
            this.sessionList.Location = new System.Drawing.Point(35, 41);
            this.sessionList.Name = "sessionList";
            this.sessionList.Size = new System.Drawing.Size(157, 304);
            this.sessionList.TabIndex = 0;
            this.sessionList.SelectedIndexChanged += new System.EventHandler(this.sessionList_SelectedIndexChanged);
            // 
            // Close
            // 
            this.Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.Location = new System.Drawing.Point(411, 394);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(230, 77);
            this.Close.TabIndex = 1;
            this.Close.Text = "Close history";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // exerciseGridView
            // 
            this.exerciseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exerciseGridView.Location = new System.Drawing.Point(324, 60);
            this.exerciseGridView.Name = "exerciseGridView";
            this.exerciseGridView.Size = new System.Drawing.Size(317, 222);
            this.exerciseGridView.TabIndex = 4;
            // 
            // UserHistoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 503);
            this.Controls.Add(this.exerciseGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.sessionList);
            this.Name = "UserHistoryScreen";
            this.Text = "User History";
            ((System.ComponentModel.ISupportInitialize)(this.exerciseGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox sessionList;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView exerciseGridView;
    }
}