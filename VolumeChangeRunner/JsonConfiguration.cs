using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Web.Script.Serialization;

namespace VolumeChangeRunner
{
    public abstract class JsonConfiguration<T> where T : JsonConfiguration<T>, new()
    {
        [ScriptIgnore]
        public virtual string DefaultFilename { get; }

        public void Save()
        {
            Save(this as T);
        }

        public static void Save(T settings)
        {
            var path = settings.GetFullPath();
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, (new JavaScriptSerializer()).Serialize(settings));
        }

        public static T Load()
        {
            T t = new T();
            var path = t.GetFullPath();

            if (File.Exists(path))
                t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(path));
            return t;
        }

        private string GetFullPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Application.ProductName, DefaultFilename);
        }
    }
}
