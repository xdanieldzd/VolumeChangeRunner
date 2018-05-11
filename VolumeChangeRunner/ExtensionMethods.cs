using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumeChangeRunner
{
    public static class ExtensionMethods
    {
        public static T GetAttribute<T>(this Enum @enum) where T : Attribute
        {
            var type = @enum.GetType();
            var memberInfos = type.GetMember(@enum.ToString());
            var attributes = memberInfos.First().GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0 ? (T)attributes[0] : null);
        }
    }
}
