namespace SYDE461_UI
{
    partial class InstructionVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructionVideo));
            this.axInstruction = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axInstruction)).BeginInit();
            this.SuspendLayout();
            // 
            // axInstruction
            // 
            this.axInstruction.Enabled = true;
            this.axInstruction.Location = new System.Drawing.Point(12, 12);
            this.axInstruction.Name = "axInstruction";
            this.axInstruction.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axInstruction.OcxState")));
            this.axInstruction.Size = new System.Drawing.Size(517, 452);
            this.axInstruction.TabIndex = 0;
            this.axInstruction.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axInstruction_PlayStateChange);
            // 
            // InstructionVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 476);
            this.Controls.Add(this.axInstruction);
            this.Name = "InstructionVideo";
            this.Text = "InstructionVideo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstructionVideo_FormClosing);
            this.Load += new System.EventHandler(this.InstructionVideo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axInstruction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axInstruction;
    }
}