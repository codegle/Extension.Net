using System;

namespace Extension.Net
{
    public static partial class Extension
    {
        public static string ToBigDateTime(this DateTime datetime, string dateSeperator = "-", string middleSeperator = " ", string timeSeperator = ":")
        {
            return datetime.ToString($"yyyy'{dateSeperator}'MM'{dateSeperator}'dd{middleSeperator}HH'{timeSeperator}'mm'{timeSeperator}'ss");
        }

        public static string ToSmallDateTime(this DateTime datetime, string dateSeperator = "-", string middleSeperator = " ", string timeSeperator = ":")
        {
            return datetime.ToString($"yy'{dateSeperator}'M'{dateSeperator}'d{middleSeperator}H'{timeSeperator}'m'{timeSeperator}'s");
        }

        public static string ToBigDate(this DateTime datetime, string seperator = "-")
        {
            return datetime.ToString($"yyyy'{seperator}'MM'{seperator}'dd");
        }

        public static string ToSmallDate(this DateTime datetime, string seperator = "-")
        {
            return datetime.ToString($"yy'{seperator}'M'{seperator}'d");
        }

        public static string ToBigTime(this DateTime datetime, string seperator = ":")
        {
            return datetime.ToString($"HH'{seperator}'mm'{seperator}'ss");
        }

        public static string ToSmallTime(this DateTime datetime, string seperator = ":")
        {
            return datetime.ToString($"H'{seperator}'m'{seperator}'s");
        }
    }
}