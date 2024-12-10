using System;

namespace nitou{

    /// <summary>
    /// <see cref="IComparable"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class ComparableExtensions{

        public static bool LessThan<T>(this T self, T other) where T : IComparable<T> {
            return self.CompareTo(other) < 0;
        }

        public static bool GreaterThan<T>(this T self, T other) where T : IComparable<T> {
            return self.CompareTo(other) > 0;
        }

        public static bool LessThanEqual<T>(this T self, T other) where T : IComparable<T> {
            return self.CompareTo(other) <= 0;
        }

        public static bool GreaterThanEqual<T>(this T self, T other) where T : IComparable<T> {
            return self.CompareTo(other) >= 0;
        }
    }
}
