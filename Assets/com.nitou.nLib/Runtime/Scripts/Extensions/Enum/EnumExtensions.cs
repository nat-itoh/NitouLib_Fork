using System;

namespace nitou {

    /// <summary>
    /// �񋓌^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class EnumExtensions {

        /// <summary>
        /// �w�肵���l�̂����ꂩ�ƈ�v���邩�m�F����g�����\�b�h
        /// </summary>
        public static bool IsAnyOf<TEnum>(this TEnum value, params TEnum[] values)
            where TEnum : Enum {

            if (values == null) {
                throw new ArgumentNullException(nameof(values), "The values array cannot be null.");
            }

            foreach (var val in values) {
                if (value.Equals(val)) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool HasFlags<TEnum>(this TEnum value, params TEnum[] flags)
            where TEnum : Enum {

            if (flags == null) {
                throw new ArgumentNullException(nameof(flags), "The values array cannot be null.");
            }

            foreach (var flag in flags) {
                if (!value.HasFlag(flag)) {
                    return false;
                }
            }
            return true;
        }
    }
}
