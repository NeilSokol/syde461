using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Media;

namespace SYDE461_UI
{
    // This is the main class for the UI
    // This will have to be modified when we join up the Kinect
    // component to the UI
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //create login screen and show
            LoginScreen logscreen = new LoginScreen();

            //Debug logscreen = new Debug("pinch");
            //PinchExercise pinch = new PinchExercise(logscreen); 
            
            //InstructionVideo logscreen = new InstructionVideo();

            Application.Run(logscreen);

        }
    }
}
