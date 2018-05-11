using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolumeChangeRunner
{
    /* ICON: https://code.launchpad.net/~ubuntu-branches/ubuntu/trusty/breathe-icon-theme/trusty 
             https://bazaar.launchpad.net/~ubuntu-branches/ubuntu/trusty/breathe-icon-theme/trusty/view/head:/LICENSE */

    static class Program
    {
        public static ApplicationConfig ApplicationConfig { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfig = ApplicationConfig.Load();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RunnerApplicationContext());
        }
    }
}
