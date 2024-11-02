using System;
using System.Linq;
using System.Collections.Generic;

// [�Q�l]
//  kan�̃�����: enum�̔ėp�I�ȕ֗����\�b�h���܂Ƃ߂��֗��N���X https://kan-kikuchi.hatenablog.com/entry/EnumUtility
//  qiita: C# 7.3����Generic�����Enum���g����悤�Ȃ��ĕ֗� https://qiita.com/m-otoguro/items/8b9fa888aed0733ca3a1
//  note: Enum�����p����֗��֐��܂Ƃ� https://note.com/projectmeme/n/nbbe8da48ba34

namespace nitou {

    /// <summary>
    /// <see cref="Enum"/>�^�ɑ΂���ėp���\�b�h�W
    /// </summary>
    public static class EnumUtil {

        /// --------------------------------------------------------------------
        #region �v�f�̎擾

        /// <summary>
        /// ���ڐ����擾
        /// </summary>
        public static int Count<T>() where T : Enum {
            return Enum.GetValues(typeof(T)).Length;
        }

        /// <summary>
        /// �ŏ��̗v�f���擾����
        /// </summary>
        public static T GetFirst<T>() where T : Enum {
            return (T)Enum.GetValues(typeof(T)).GetValue(0);
        }

        /// <summary>
        /// �Ō�̗v�f���擾����
        /// </summary>
        public static T GetLast<T>() where T : Enum {
            var array = Enum.GetValues(typeof(T));
            return (T)array.GetValue(array.Length - 1);
        }

        /// <summary>
        /// ���̗v�f���擾����
        /// </summary>
        public static bool TryGetNext<T>(T target, out T next) where T : Enum {
            var values = (T[])Enum.GetValues(typeof(T));
            int index = Array.IndexOf(values, target);

            if (index >= 0 && index < values.Length - 1) {
                next = values[index + 1];
                return true;
            }

            next = default(T);
            return false;
        }

        /// <summary>
        /// �O�̗v�f���擾����
        /// </summary>
        public static bool TryGetPrevious<T>(T target, out T previous) where T : Enum {
            var values = (T[])Enum.GetValues(typeof(T));
            int index = Array.IndexOf(values, target);

            if (index > 0) {
                previous = values[index - 1];
                return true;
            }

            // �ŏ��̗v�f�̏ꍇ�̓��X�g�̍Ō�̗v�f��Ԃ�
            previous = values[values.Length - 1];
            return false;
        }

        /// <summary>
        /// ���ڂ������_���Ɉ�擾
        /// </summary>
        public static T GetRandom<T>() where T : Enum {
            int no = UnityEngine.Random.Range(0, Count<T>());
            return NoToType<T>(no);
        }

        /// <summary>
        /// �S�Ă̍��ڂ�������List���擾
        /// </summary>
        public static T[] GetAllInList<T>() where T : Enum {
            return (T[])Enum.GetValues(typeof(T));
        }
        #endregion


        /// --------------------------------------------------------------------
        #region �v�f�̕ϊ�

        /// <summary>
        /// ���͂��ꂽ������Ɠ������ڂ��擾
        /// </summary>
        public static T KeyToType<T>(string targetKey) where T : Enum {
            return (T)Enum.Parse(typeof(T), targetKey);
        }

        /// <summary>
        /// ���͂��ꂽ�ԍ��̍��ڂ��擾
        /// </summary>
        public static T NoToType<T>(int targetNo) where T : Enum {
            if (!Enum.IsDefined(typeof(T), targetNo)) {
                throw new ArgumentOutOfRangeException(nameof(targetNo), $"Invalid enum value: {targetNo}");
            }
            return (T)Enum.ToObject(typeof(T), targetNo);
        }
        #endregion


        /// --------------------------------------------------------------------
        #region �v�f�̔���

        /// <summary>
        /// ���͂��ꂽ������̍��ڂ��܂܂�Ă��邩
        /// </summary>
        public static bool ContainsKey<T>(string tagetKey) where T : Enum {
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
        public static bool IsFirst<T>(T target) where T : Enum {
            return target.ToString() == (GetFirst<T>().ToString());
        }

        /// <summary>
        /// �Ō�̗v�f���ǂ���
        /// </summary>
        public static bool IsLast<T>(T target) where T : Enum {
            return target.ToString() == (GetLast<T>().ToString());
        }
        #endregion


        /// --------------------------------------------------------------------
        #region ���̑�

        /// <summary>
        /// �S�Ă̍��ڂɑ΂��ăf���Q�[�g�����s
        /// </summary>
        public static void ForEach<T>(Action<T> action) where T : Enum {
            foreach (T t in Enum.GetValues(typeof(T))) {
                action(t);
            }
        }
        #endregion
    }
}
