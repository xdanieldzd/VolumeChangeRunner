using System.Windows.Forms;
using System.Drawing;

namespace VolumeChangeRunner.Controls
{
    public class ModernForm : Form
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            foreach (Control control in Controls)
            {
                if (control.Font == DefaultFont)
                    control.Font = SystemFonts.MessageBoxFont;
            }
        }
    }
}
