using System;
using System.Collections.Generic;

namespace nitou.DesignPattern.Pooling {

    /// <summary>
    /// <see cref="List{T}"/>�������I�ɍė��p���邽�߂̐ÓI�N���X
    /// </summary>
    public static class ListPool<T> {

        // [MEMO]
        // �ő�i�[����ݒ�ł���悤�ɂ��邱�Ƃ��������ׂ�

        private static readonly object @lock = new ();
        private static readonly Stack<List<T>> free = new ();
        private static readonly HashSet<List<T>> busy = new ();

        /// <summary>
        /// ���X�g���擾����D
        /// </summary>
        public static List<T> New() {
            lock (@lock) {
                if (free.Count == 0) {
                    free.Push(new List<T>());
                }

                var array = free.Pop();

                busy.Add(array);

                return array;
            }
        }

        /// <summary>
        /// �g�p�ς݂̃��X�g���v�[���ɖ߂��D
        /// </summary>
        public static void Free(List<T> list) {
            lock (@lock) {
                if (!busy.Contains(list)) {
                    throw new ArgumentException("The list to free is not in use by the pool.", nameof(list));
                }

                list.Clear();

                busy.Remove(list);

                free.Push(list);
            }
        }
    }

    public static class XListPool {

        public static List<T> ToListPooled<T>(this IEnumerable<T> source) {
            var list = ListPool<T>.New();

            foreach (var item in source) {
                list.Add(item);
            }

            return list;
        }

        public static void Free<T>(this List<T> list) {
            ListPool<T>.Free(list);
        }
    }
}