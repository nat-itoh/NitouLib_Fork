using System;
using System.Collections.Generic;
using System.Linq;

// [REF]
//  �R�K�l�u���O: �z��⃊�X�g�̕��������\�ɂ��� Deconstruct https://baba-s.hatenablog.com/entry/2019/09/12/085000#google_vignette
//  StackOverflow: Does C# 7 have array/enumerable destructuring? https://stackoverflow.com/questions/47815660/does-c-sharp-7-have-array-enumerable-destructuring

namespace nitou {

    /// <summary>
    /// <see cref="List{T}"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static partial class ListExtensions {

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
        #region �v�f�̕���

        /// <summary>
        /// �f�R���X�g���N�^�D
        /// </summary>
        public static void Deconstruct<T>(this IList<T> self,
            out T first, out IList<T> rest) {
            first = self.Count > 0 ? self[0] : default;
            rest = self.Skip(1).ToArray();
        }

        /// <summary>
        /// �f�R���X�g���N�^�D
        /// </summary>
        public static void Deconstruct<T>(this IList<T> self,
            out T first, out T second, out IList<T> rest) {
            first = self.Count > 0 ? self[0] : default;
            second = self.Count > 1 ? self[1] : default;
            rest = self.Skip(2).ToArray();
        }

        /// <summary>
        /// �f�R���X�g���N�^�D
        /// </summary>
        public static void Deconstruct<T>(this IList<T> self,
            out T first, out T second, out T third, out IList<T> rest) {
            first = self.Count > 0 ? self[0] : default;
            second = self.Count > 1 ? self[1] : default;
            third = self.Count > 2 ? self[2] : default;
            rest = self.Skip(3).ToArray();
        }

        /// <summary>
        /// �f�R���X�g���N�^�D
        /// </summary>
        public static void Deconstruct<T>(this IList<T> self,
            out T first, out T second, out T third, out T four, out IList<T> rest) {
            first = self.Count > 0 ? self[0] : default;
            second = self.Count > 1 ? self[1] : default;
            third = self.Count > 2 ? self[2] : default;
            four = self.Count > 3 ? self[3] : default;
            rest = self.Skip(4).ToArray();
        }

        #endregion

    }
}
