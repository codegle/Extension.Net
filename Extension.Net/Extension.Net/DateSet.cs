using System;
using System.Data;
using System.Collections.Generic;

namespace Extension.Net
{
    public static partial class Extension
    {
        public static DataTable GetFirstTable(this DataSet set)
        {
            if (set != null && set.Tables.Count > 0)
                return set.Tables[0];

            return null;
        }

        public static DataRow GetFirstRow(this DataSet set)
        {
            DataTable table = set.GetFirstTable();
            if (table != null)
                return table.GetFirstRow();

            return null;
        }

        public static T GetFirstCell<T>(this DataSet set, T defaultValue = default(T))
        {
            DataRow row = set.GetFirstRow();
            if (row != null)
                return row.GetFirstCell<T>(defaultValue);

            return defaultValue;
        }

        public static DataRow GetFirstRow(this DataTable table)
        {
            if (table != null && table.Rows.Count > 0)
                return table.Rows[0];

            return null;
        }

        public static T GetFirstCell<T>(this DataTable table, T defaultValue = default(T))
        {
            DataRow row = table.GetFirstRow();
            if (row != null)
                return row.GetFirstCell<T>(defaultValue);

            return defaultValue;
        }

        public static T GetFirstCell<T>(this DataRow row, T defaultValue = default(T))
        {
            if (row != null)
                return row[0].To<T>(defaultValue);

            return defaultValue;
        }

        public static List<T> ToModels<T>(this DataSet set, Func<DataRow, T> Convert)
        {
            DataTable table = set.GetFirstTable();
            if (table != null)
                return table.ToModels<T>(Convert);

            return new List<T>();
        }

        public static List<T> ToModels<T>(this DataTable table, Func<DataRow, T> Convert)
        {
            List<T> models = new List<T>();

            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                    models.Add(Convert(row));
            }

            return models;
        }

        public static T ToModel<T>(this DataRow row, Func<DataRow, T> Convert)
        {
            if (row != null)
                return Convert(row);

            return default(T);
        }
    }
}