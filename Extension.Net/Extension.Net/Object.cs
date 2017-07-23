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
                    return obj.ToGuid<T>();

                if (typeof(T) == typeof(bool))
                    return obj.ToBoolean<T>();

                return (T)SystemConvert.ChangeType(obj, typeof(T));
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        private static T ToGuid<T>(this object obj)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromInvariantString(obj.ToString());
        }

        private static T ToBoolean<T>(this object obj, T defaultValue = default(T))
        {
            string text = obj.ToString();
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            if (text == "true" || text == "1")
                return (T)converter.ConvertFromInvariantString("true");

            if (text == "false" || text == "0")
                return (T)converter.ConvertFromInvariantString("false");

            return defaultValue;
        }
    }
}