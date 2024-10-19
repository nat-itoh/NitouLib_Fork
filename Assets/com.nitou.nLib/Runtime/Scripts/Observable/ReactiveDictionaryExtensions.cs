using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace nitou {

    /// <summary>
    /// ReactiveDictionary�g�����\�b�h.
    /// </summary>
    public static class ReactiveDictionaryExtensions {

        /// <summary>
        /// �ύX�����������Ƃ�ʒm����Observable.
        /// </summary>
        public static IObservable<Unit> ObserveAnyChanged<TKey, TValue>(this ReactiveDictionary<TKey, TValue> self) {
            return Observable.Merge(
                self.ObserveAdd().AsUnitObservable(),
                self.ObserveCountChanged().AsUnitObservable(),
                self.ObserveRemove().AsUnitObservable(),
                self.ObserveReplace().AsUnitObservable(),
                self.ObserveReset().AsUnitObservable()
                )
                .ThrottleFrame(1);
        }

        /// <summary>
        /// ���g������S�ē���ւ���.
        /// </summary>
        public static void Set<TKey, TValue>(this ReactiveDictionary<TKey, TValue> self, IEnumerable<TValue> source, Func<TValue, TKey> selector) {
            HashSet<TKey> activeKeys = new HashSet<TKey>();

            foreach (TValue value in source) {
                TKey key = selector(value);
                activeKeys.Add(key);
                self[key] = value;
            }

            //�A�N�e�B�u���X�g�ɓ����Ă��Ȃ��A�C�e�������O.
            TKey[] removeKeys = self.Keys
                    .Where(key => !activeKeys.Contains(key))
                    .ToArray();
            foreach (var key in removeKeys) {
                self.Remove(key);
            }
        }

        /// <summary>
        /// ���g������S�ē���ւ���.
        /// </summary>
        public static void Set<TKey, TValue, TRValue>(this ReactiveDictionary<TKey, TRValue> self, IEnumerable<TValue> source, Func<TValue, TKey> selector)
                where TRValue : IReactiveProperty<TValue>, new() {
            HashSet<TKey> activeKeys = new HashSet<TKey>();

            foreach (TValue value in source) {
                TKey key = selector(value);
                activeKeys.Add(key);

                //value�����݂��Ȃ��ꍇ�A�V��������.
                if (!self.ContainsKey(key))
                    self[key] = new TRValue();
                self[key].Value = value;
                self[key] = self[key];
            }

            //�A�N�e�B�u���X�g�ɓ����Ă��Ȃ��A�C�e�������O.
            TKey[] removeKeys = self.Keys
                    .Where(key => !activeKeys.Contains(key))
                    .ToArray();

            foreach (var key in removeKeys) {
                self.Remove(key);
            }
        }
    }
}
