# Extension.Net
提供了常用数据类型转换、常用方法封装等：  
**1）所有的扩展方法在使用时无需判断NULL或DBNull；  
2）所有的类型转换方法均提供默认值功能，当转换的对象为空或转换异常时，会返回该默认值。**

    public class Program
    {
        static void Main(string[] args)
        {
            ConvertTest();
            NullTest();
            DataSetTest();
            PatternTest();
            DateTimeFormatTest();
        }

        private static void ConvertTest()
        {
            int number = "12".To<int>();                // Returns: 12
            number = "DefaultValue".To<int>(-1);        // Returns: -1
            number = 3.14f.To<int>();                   // Returns: 3

            float numeric1 = "3.14".To<float>();        // Returns: 3.14
            double numeric2 = "3.14".To<double>();      // Returns: 3.14

            bool boolean = 1.To<bool>();                // Returns: true
            boolean = "0".To<bool>();                   // Returns: false
            boolean = "1".To<bool>();                   // Returns: true
            boolean = "2".To<bool>();                   // Returns: true

            string text = "EAF90998-1F75-4858-B139-90CD6407BF48";
            Guid guid = text.To<Guid>();                // Returns: Guid("EAF90998-1F75-4858-B139-90CD6407BF48")

            text = "2017-01-01";
            DateTime dateTime = text.To<DateTime>();    // Returns: 2017-01-01 00:00:00

            text = "2017-01-01 10:11:12";
            dateTime = text.To<DateTime>();             // Returns: 2017-01-01 10:11:12
        }

        private static void NullTest()
        {
            object obj = null;
            bool boolean = obj.IsNull();                // Returns: true

            obj = DBNull.Value;
            boolean = obj.IsNull();                     // Returns: true

            obj = string.Empty;
            boolean = obj.IsNull();                     // Returns: true

            obj = " ";
            boolean = obj.IsNull();                     // Returns: true

            obj = "Hello, Extension.Net!";
            boolean = obj.NotNull();                    // Returns: true
        }

        private static void DataSetTest()
        {
            DataSet set = null;
            DataTable table = set.GetFirstTable();
            DataRow row = set.GetFirstRow();
            string code = set.GetFirstCell<string>();
            code = table.GetFirstCell<string>();
            code = row.GetFirstCell<string>();

            User user = row.ToModel<User>(ToUser);
            List<User> users = table.ToModels<User>(ToUser);
            users = set.ToModels<User>(ToUser);
        }

        private static void PatternTest()
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            bool boolean = "fanwensheng@foxmailcom".IsPattern(pattern);
        }

        private static void DateTimeFormatTest()
        {
            string text = DateTime.Now.ToBigDateTime(); // Returns: 2017-07-01 17:20:09
            text = DateTime.Now.ToSmallDateTime();      // Returns: 17-7-1 17:20:9
            text = DateTime.Now.ToBigDate();            // Returns: 2017-07-01
            text = DateTime.Now.ToSmallDate();          // Returns: 17-7-1
            text = DateTime.Now.ToBigTime();            // Returns: 17:20:09
            text = DateTime.Now.ToSmallTime();          // Returns: 17:20:9

            text = DateTime.Now.ToBigDateTime("", "", "");      // Returns: 20170701172009
            text = DateTime.Now.ToBigDateTime("/", "@", ":");   // Returns: 2017/07/01@17:20:09
        }

        private static User ToUser(DataRow row)
        {
            User user = new User();
            // Converts from DataRow to User
            return user;
        }
    }
