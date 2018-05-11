using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;

namespace VolumeChangeRunner
{
    public enum VolumeChangeEventType : ushort
    {
        ConfigurationChanged = 0x0001,
        DeviceArrival = 0x0002,
        DeviceRemoval = 0x0003,
        Docking = 0x0004
    }

    public class VolumeChangeWatcher
    {
        public event EventHandler<VolumeChangeEventArgs> VolumeChangedEvent;

        public VolumeChangeWatcher()
        {
            var eventQuery = new WqlEventQuery($"SELECT * FROM Win32_VolumeChangeEvent");
            var eventWatcher = new ManagementEventWatcher(eventQuery);
            eventWatcher.EventArrived += EventWatcher_EventArrived;
            eventWatcher.Start();
        }

        private void EventWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            var drive = (string)e.NewEvent.GetPropertyValue("DriveName");
            var type = (VolumeChangeEventType)(ushort)e.NewEvent.GetPropertyValue("EventType");
            var time = (ulong)e.NewEvent.GetPropertyValue("TIME_CREATED");

            VolumeChangedEvent?.Invoke(this, new VolumeChangeEventArgs(type, DateTime.FromFileTime((long)time), new DriveInfo(drive)));
        }
    }

    public class VolumeChangeEventArgs : EventArgs
    {
        public VolumeChangeEventType EventType { get; private set; }
        public DateTime EventTime { get; private set; }
        public DriveInfo DriveInfo { get; private set; }

        public VolumeChangeEventArgs(VolumeChangeEventType eventType, DateTime eventTime, DriveInfo driveInfo)
        {
            EventType = eventType;
            EventTime = eventTime;
            DriveInfo = driveInfo;
        }
    }
}
