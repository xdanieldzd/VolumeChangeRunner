using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.ComponentModel;

namespace VolumeChangeRunner
{
    public class ApplicationConfig : JsonConfiguration<ApplicationConfig>
    {
        [ScriptIgnore]
        public override string DefaultFilename => "Settings.json";

        public List<RunnerEntry> RunnerEntries { get; set; }

        public ApplicationConfig()
        {
            RunnerEntries = new List<RunnerEntry>();
        }
    }

    public enum RunnerEventType
    {
        [Description("On Drive Attached")]
        DriveAttached,
        [Description("On Drive Removed")]
        DriveRemoved
    }

    public class RunnerEntry : ICloneable
    {
        public string DriveLetter { get; set; }
        public string CommandToRun { get; set; }
        public string CommandArguments { get; set; }
        public RunnerEventType EventType { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
