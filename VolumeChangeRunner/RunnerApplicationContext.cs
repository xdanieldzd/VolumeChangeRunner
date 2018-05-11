using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace VolumeChangeRunner
{
    class RunnerApplicationContext : ApplicationContext
    {
        public static RunnerApplicationContext CurrentContext { get; private set; }

        NotifyIcon notifyIcon;
        ContextMenu contextMenu;

        VolumeChangeWatcher volumeChangeWatcher;

        public RunnerApplicationContext()
        {
            if (CurrentContext == null)
                CurrentContext = this;

            Application.ApplicationExit += Application_ApplicationExit;

            InitializeComponent();

            volumeChangeWatcher = new VolumeChangeWatcher();
            volumeChangeWatcher.VolumeChangedEvent += VolumeChangeWatcher_VolumeChangedEvent;

            SetIconVisibility(true);
        }

        private void VolumeChangeWatcher_VolumeChangedEvent(object sender, VolumeChangeEventArgs e)
        {
            foreach (RunnerEntry runnerEntry in Program.ApplicationConfig.RunnerEntries.Where(x => e.DriveInfo.Name.StartsWith(x.DriveLetter)))
            {
                if ((e.EventType == VolumeChangeEventType.DeviceArrival && runnerEntry.EventType == RunnerEventType.DriveAttached) ||
                    (e.EventType == VolumeChangeEventType.DeviceRemoval && runnerEntry.EventType == RunnerEventType.DriveRemoved))
                {
                    var eventString = string.Empty;
                    switch (runnerEntry.EventType)
                    {
                        case RunnerEventType.DriveAttached: eventString = "attached"; break;
                        case RunnerEventType.DriveRemoved: eventString = "removed"; break;
                    }
                    ShowBalloonTip($"Drive {e.DriveInfo.Name} has been {eventString}. Running command...");

                    var processStartInfo = new ProcessStartInfo()
                    {
                        FileName = runnerEntry.CommandToRun,
                        Arguments = runnerEntry.CommandArguments,
                        UseShellExecute = true
                    };

                    try
                    {
                        Process.Start(processStartInfo);
                    }
                    catch (System.ComponentModel.Win32Exception)
                    {
                        MessageBox.Show($"Tried to run command {Path.GetFileName(runnerEntry.CommandToRun)}, but command could not be found. Please check your configuration.", $"{Application.ProductName} - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Unexpected error occured: {ex.GetType().Name} - {ex.Message}. Please consult the documentation.", $"{Application.ProductName} - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            Program.ApplicationConfig.Save();
            SetIconVisibility(false);
        }

        private void ShowConfigForm()
        {
            var configForm = new ConfigForm();
            configForm.ShowDialog();
            Program.ApplicationConfig.Save();
        }

        private void InitializeComponent()
        {
            contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("&Configure...", (s, e) => { ShowConfigForm(); }) { DefaultItem = true });
            contextMenu.MenuItems.Add("-");
            contextMenu.MenuItems.Add("&About...", (s, e) => { ShowAboutBox(); });
            contextMenu.MenuItems.Add("E&xit", (s, e) => { Application.Exit(); });

            notifyIcon = new NotifyIcon
            {
                ContextMenu = contextMenu,
                Icon = NativeMethods.GetStockIcon(NativeMethods.SHSTOCKICONID.SIID_DRIVEFIXED, NativeMethods.IconSize.Large)
            };
            notifyIcon.DoubleClick += (s, e) => { ShowConfigForm(); };

            UpdateNotifyIcon();
        }

        public void ShowAboutBox()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var version = new Version((assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false).FirstOrDefault() as AssemblyFileVersionAttribute).Version);
            var description = (assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false).FirstOrDefault() as AssemblyDescriptionAttribute).Description;
            var copyright = (assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false).FirstOrDefault() as AssemblyCopyrightAttribute).Copyright;

            var aboutCaption = $"About {Application.ProductName}";
            var aboutText = $"{Application.ProductName} v{version.Major}.{version.Minor} - {copyright}\n\n{description}.";

            MessageBox.Show(aboutText, aboutCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UpdateNotifyIcon()
        {
            notifyIcon.Text = $"{Application.ProductName}, {Program.ApplicationConfig.RunnerEntries.Count} item(s)";
        }

        public void ShowBalloonTip(string text)
        {
            notifyIcon.ShowBalloonTip(5000, Application.ProductName, text, ToolTipIcon.Info);
        }

        private void SetIconVisibility(bool visible)
        {
            if (notifyIcon != null)
                notifyIcon.Visible = visible;
        }
    }
}
