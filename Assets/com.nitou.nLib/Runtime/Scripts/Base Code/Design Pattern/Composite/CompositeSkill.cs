using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [�Q�l]
//  qiita: Unity�Ŋw�ԃf�U�C���p�^�[��08: Composite �p�^�[�� https://qiita.com/Cova8bitdot/items/1c57d856027a33e99eb0
//  qiita: Composite�p�^�[�� https://qiita.com/WestRiver/items/11c48ec3929322e296a7

namespace nitou.DesignPattern.Demo {

    public class Character {
        public void Heal(float amount) { }
        public void ClearDebuffAll() { }
    }

    public interface ISkill {
        void Invoke(Character[] targets);
    }


    public class CompositeSkill : ISkill, ICollection<ISkill> {

        protected readonly object _gate = new ();
        protected List<ISkill> list = new ();

        // ===== ISkill =====

        void ISkill.Invoke(Character[] targets) {
            if (targets == null) return;
            foreach (var skill in list) {
                skill.Invoke(targets);
            }
        }

        // ===== ICollection =====

        public int Count => list.Count;

        public bool IsReadOnly => false;

        public void Add(ISkill item) { list.Add(item); }

        public void Clear() { list.Clear(); }

        public bool Contains(ISkill item) {
            return list.Contains(item);
        }

        public void CopyTo(ISkill[] array, int arrayIndex) {
            int startIndex = Mathf.Min(arrayIndex, array.Length - 1);
            for (int i = startIndex; i < array.Length; i++) {
                Add(array[i]);
            }
        }

        public bool Remove(ISkill item) {
            return list.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public IEnumerator<ISkill> GetEnumerator() {
            var res = new List<ISkill>();

            lock (_gate) {
                foreach (var d in list) {
                    if (d != null) res.Add(d);
                }
            }

            return res.GetEnumerator();
        }
    }


    /// <summary>
    /// HP���S�񕜃X�L��
    /// </summary>
    public class FullHealSkill : ISkill {
        void ISkill.Invoke(Character[] targets) {
            if (targets == null) return;
            foreach (var target in targets) {
                target.Heal(100.0f);
            }
        }
    }

    /// <summary>
    /// ��Ԉُ�񕜃X�L��
    /// </summary>
    public class FullCure : ISkill {
        void ISkill.Invoke(Character[] targets) {
            if (targets == null) return;
            foreach (var target in targets) {
                target.ClearDebuffAll();
            }
        }
    }


    /// <summary>
    /// ���S�񕜃X�L��
    /// </summary>
    public class PerfectHeal : CompositeSkill {
        public PerfectHeal() {
            // ���S�� = HP�S�� + �S��Ԉُ��
            list.Add(new FullHealSkill());
            list.Add(new FullCure());
        }
    }
}
