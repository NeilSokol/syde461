using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WMPLib;

namespace SYDE461_UI
{
    public partial class InstructionVideo : Form
    {
        public String vidLocation;

        public InstructionVideo()
        {
            InitializeComponent();
            
            vidLocation = "C:\\Users\\Admin\\syde461\\ui\\SYDE461_UI\\instructions.wmv";
        }
        public InstructionVideo(string url)
        {
            InitializeComponent();
            String referencePath = Directory.GetCurrentDirectory(); 
            String relativePath = "...\\...\\" + url;
            vidLocation = Path.GetFullPath(Path.Combine(referencePath, relativePath));
        }
        private void InstructionVideo_Load(object sender, EventArgs e)
        {
            axInstruction.uiMode = "none";
            try
            {
                //hardcoded URL, find a way to soft code
                //axInstruction.URL = "C:\\Users\\UseIt\\Desktop\\Ang Lindsey Sokol\\syde461\\ui\\SYDE461_UI\\instructions.wmv";
                axInstruction.URL = vidLocation;
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
