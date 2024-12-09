using System;
using System.Collections.Generic;

namespace nitou {

    /// <summary>
    /// <see cref="List{T}"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class ListExtensions {

        /// <summary>
        /// �Ō�̗v�f�����o���g�����\�b�h�D�v�f��0�Ȃ�<see cref="InvalidOperationException">��O</see>�𓊂���D
        /// </summary>
        public static T PopLast<T>(this IList<T> list) {
            if (list.Count == 0) {
                throw new InvalidOperationException();
            }

            var t = list[list.Count - 1];

            list.RemoveAt(list.Count - 1);

            return t;
        }


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
        
        
        /// ----------------------------------------------------------------------------
        #region �v�f�̍폜

        #endregion

    }
}
