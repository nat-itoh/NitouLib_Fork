using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// [�Q�l]
//  kan�̃�����: enum�̔ėp�I�ȕ֗����\�b�h���܂Ƃ߂��֗��N���X https://kan-kikuchi.hatenablog.com/entry/EnumUtility

namespace nitou {

    /// <summary>
    /// <see cref="Enum"/>�^�ɑ΂���ėp���\�b�h�W
    /// </summary>
    public static class EnumUtil {

        /// --------------------------------------------------------------------
        #region �񋓌^�v�f�̎擾

        /// <summary>
        /// ���ڐ����擾
        /// </summary>
        public static int Count<T>() where T : struct {
            return Enum.GetValues(typeof(T)).Length;
        }

        /// <summary>
        /// �ŏ��̗v�f���擾����
        /// </summary>
        public static T GetFirst<T>() where T : struct {
            return (T)Enum.GetValues(typeof(T)).GetValue(0);
        }

        /// <summary>
        /// �Ō�̗v�f���擾����
        /// </summary>
        public static T GetLast<T>() where T : struct {
            var array = Enum.GetValues(typeof(T));
            return (T)array.GetValue(array.Length - 1);
        }

        /// <summary>
        /// ���̗v�f���擾���� (������m�F���K�v�I)
        /// </summary>
        public static bool TryGetNext<T>(T target, out T next) where T : struct {

            var allInList = GetAllInList<T>();
            var index = allInList.FindIndex(x => x.ToString() == target.ToString());

            // �Ō�̗v�f�̏ꍇ
            if (index + 1 == allInList.Count) {
                next = NoToType<T>(0);
                return false;
            }

            next = allInList[index + 1];
            return true;
        }

        /// <summary>
        /// ���ڂ������_���Ɉ�擾
        /// </summary>
        public static T GetRandom<T>() where T : struct {
            int no = UnityEngine.Random.Range(0, Count<T>());
            return NoToType<T>(no);
        }

        /// <summary>
        /// �S�Ă̍��ڂ�������List���擾
        /// </summary>
        public static List<T> GetAllInList<T>() where T : struct {
            var list = new List<T>();
            foreach (T t in Enum.GetValues(typeof(T))) {
                list.Add(t);
            }
            return list;
        }
        #endregion


        /// --------------------------------------------------------------------
        #region �񋓌^�v�f�̕ϊ�

        /// <summary>
        /// ���͂��ꂽ������Ɠ������ڂ��擾
        /// </summary>
        public static T KeyToType<T>(string targetKey) where T : struct {
            return (T)Enum.Parse(typeof(T), targetKey);
        }

        /// <summary>
        /// ���͂��ꂽ�ԍ��̍��ڂ��擾
        /// </summary>
        public static T NoToType<T>(int targetNo) where T : struct {
            return (T)Enum.ToObject(typeof(T), targetNo);
        }
        #endregion


        /// --------------------------------------------------------------------
        #region �񋓌^�v�f�̔���

        /// <summary>
        /// ���͂��ꂽ������̍��ڂ��܂܂�Ă��邩
        /// </summary>
        public static bool ContainsKey<T>(string tagetKey) where T : struct {
            foreach (T t in Enum.GetValues(typeof(T))) {
                if (t.ToString() == tagetKey) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// �ŏ��̗v�f���ǂ���
        /// </summary>
        public static bool IsFirst<T>(T target) where T : struct {
            return target.ToString() == (GetFirst<T>().ToString());
        }

        /// <summary>
        /// �Ō�̗v�f���ǂ���
        /// </summary>
        public static bool IsLast<T>(T target) where T : struct {
            return target.ToString() == (GetLast<T>().ToString());
        }
        #endregion


        /// --------------------------------------------------------------------
        #region ���̑�

        /// <summary>
        /// �S�Ă̍��ڂɑ΂��ăf���Q�[�g�����s
        /// </summary>
        public static void ForEach<T>(Action<T> action) where T : struct {
            foreach (T t in Enum.GetValues(typeof(T))) {
                action(t);
            }
        }
        #endregion
    }




}


