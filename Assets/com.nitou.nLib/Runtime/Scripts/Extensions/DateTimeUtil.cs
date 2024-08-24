using System;
using System.Globalization;

// [�Q�l]
//  LIGHT11: 

namespace nitou {
    public static class DateTimeUtil {

        const string DatetimeSerializeFormat = "yyyy-MM-dd HH:mm:ss";

        public static string DateTimeToString(DateTime dateTime) {
            return dateTime.ToString(DatetimeSerializeFormat);
        }

        private static bool StringToDateTime(string dateTimeString, out DateTime result) {
            if (DateTime.TryParseExact(dateTimeString, DatetimeSerializeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var r)) {
                result = r;
                return true;
            }
            result = DateTime.MinValue;
            return false;
        }
    }
}