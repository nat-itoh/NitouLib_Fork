using System;
using System.Collections.Generic;
using System.Linq;
using nitou;

namespace UniRx {

    /// <summary>
    /// <see cref="ReactiveCollection{T}"/>�̊g�����\�b�h�W�D
    /// </summary>
    public static class ReactiveCollectionExtensions {

        /// <summary>
        /// �ύX�����������Ƃ�ʒm����Observable��Ԃ�.
        /// </summary>
        public static IObservable<Unit> ObserveAnyChanged<T>(this ReactiveCollection<T> self) {
            return Observable.Merge(
                self.ObserveAdd().AsUnitObservable(),
                self.ObserveCountChanged().AsUnitObservable(),
                self.ObserveMove().AsUnitObservable(),
                self.ObserveRemove().AsUnitObservable(),
                self.ObserveReplace().AsUnitObservable(),
                self.ObserveReset().AsUnitObservable()
                )
                .ThrottleFrame(1, FrameCountType.EndOfFrame);
        }

        /// <summary>
        /// ���g������S�ē���ւ���g�����\�b�h.
        /// </summary>
        public static ReactiveCollection<T> Set<T>(this ReactiveCollection<T> self, IList<T> source) {
            int before = self.Count;
            int after = source.Count;
            int minCount = before < after ? before : after;

            // Replace.
            for (int i = 0; i < minCount; i++) {
                self[i] = source[i];
            }

            // Add.
            for (int i = before; i < after; i++) {
                self.Add(source[i]);
            }

            // Remove.
            for (int i = before - 1; after <= i; i--) {
                self.RemoveAt(i);
            }
            return self;
        }

        /// <summary>
        /// ���g�𓯊�������g�����\�b�h�D
        /// ����ɒǉ�/�폜�̃C�x���g���΂����΂���邪�C�v�f�̏����͍l�����Ȃ��D
        /// </summary>
        public static void SynchronizeWith<T>(this ReactiveCollection<T> self, IEnumerable<T> source) {
            // �v�f�̍폜
            self.RemoveAll(x => !source.Contains(x));
            // �v�f�̒ǉ�
            self.AddRangeIfNotContains(source);
        }

        /// <summary>
        /// �����}�b�`����C���f�b�N�X���擾����g�����\�b�h.
        /// </summary>
        public static int FindIndex<T>(this ReactiveCollection<T> self, Predicate<T> match) {
            for (int i = 0; i < self.Count; i++) {
                if (match(self[i]))
                    return i;
            }
            return -1;
        }

    }
}
