using System;
using System.Collections.Generic;

namespace nitou {

    /// <summary>
    /// <see cref="List{T}"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class ListExtensions {

        /// ----------------------------------------------------------------------------
        #region �v�f�̍폜

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
        #endregion


        /// ----------------------------------------------------------------------------
        #region �v�f�̍폜

        /// <summary>
        /// �Y������v�f��S�č폜����g�����\�b�h�D
        /// </summary>
        public static void RemoveAll<T>(this IList<T> self, Func<T, bool> predicate) {
            for (int i = self.Count - 1; i >= 0; i--) {
                if (predicate(self[i])) {
                    self.RemoveAt(i);
                }
            }
        }
        #endregion

    }
}
