using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace SYDE461_UI
{
    public partial class InstructionVideo : Form
    {
        public InstructionVideo()
        {
            InitializeComponent();
        }
        private void InstructionVideo_Load(object sender, EventArgs e)
        {
            axInstruction.uiMode = "none";
            try
            {
                axInstruction.URL = "C:\\Users\\UseIt\\Desktop\\Ang Lindsey Sokol\\syde461\\ui\\SYDE461_UI\\instructions.wmv";
                axInstruction.Ctlcontrols.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void axInstruction_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            //wait two seconds when video stops, then close

            if ((WMPLib.WMPPlayState)e.newState == WMPPlayState.wmppsMediaEnded | (WMPLib.WMPPlayState)e.newState == WMPPlayState.wmppsStopped)
            {
                System.Threading.Thread.Sleep(1000);
                this.Close();
            }
        }
    }
}
