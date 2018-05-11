using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolumeChangeRunner.Controls
{
    public class ListViewEx : ListView, INotifyPropertyChanged
    {
        public bool IsAnyEntrySelected => (SelectedIndices.Count > 0);

        public ListViewEx()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.EnableNotifyMessage, true);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x14)
                base.OnNotifyMessage(m);
        }

        protected override void OnItemSelectionChanged(ListViewItemSelectionChangedEventArgs e)
        {
            base.OnItemSelectionChanged(e);
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsAnyEntrySelected)));
        }
    }
}
