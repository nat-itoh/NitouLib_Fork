using System.Collections.Generic;

namespace nitou {

    /// <summary>
    /// <see cref="List{T}"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class ListExtensions {

        /// <summary>
        /// �w�肵���C���f�b�N�X�����X�g�͈͓����m�F����
        /// </summary>
        public static bool IsInRange<T>(this int index, IReadOnlyList<T> list) {
            return 0 <= index && index < list.Count;
        }

        /// <summary>
        /// �w�肵���C���f�b�N�X�����X�g�͈͊O���m�F����
        /// </summary>
        public static bool IsOutOfRange<T>(this int index, IReadOnlyList<T> list) {
            return !index.IsInRange(list);
        }
    }
}
