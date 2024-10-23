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
