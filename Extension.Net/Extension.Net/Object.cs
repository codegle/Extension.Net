using System;
using System.ComponentModel;
using SystemConvert = System.Convert;

namespace Extension.Net
{
    public static partial class Extension
    {
        public static bool IsNull(this object obj)
        {
            return obj == null || obj == DBNull.Value || obj is string ? string.IsNullOrWhiteSpace(obj as string) : false;
        }

        public static bool NotNull(this object obj)
        {
            return !IsNull(obj);
        }

        public static T To<T>(this object obj, T defaultValue = default(T))
        {
            try
            {
                if (obj.IsNull())
                    return defaultValue;

                if (obj is T)
                    return (T)obj;

                if (typeof(T) == typeof(Guid))
                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(obj.ToString());
                if (typeof(T) == typeof(bool))
                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(obj.ToString() == "0" ? "false" : "true");
                else
                    return (T)SystemConvert.ChangeType(obj, typeof(T));
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }
}