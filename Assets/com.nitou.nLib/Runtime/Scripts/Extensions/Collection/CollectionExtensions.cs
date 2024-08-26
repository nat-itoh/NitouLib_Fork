using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// [�Q�l]
//  Hatena Blog: Action, Func, Predicate�f���Q�[�g���g���Ă݂� https://oooomincrypto.hatenadiary.jp/entry/2022/04/24/201149
//  JojoBase: �g�����\�b�h�͍���Ē��߂Ă����ƕ֗��ł� https://johobase.com/custom-extension-methods-list/#i-5
//  JojoBase: �R���N�V�����̊g�����\�b�h Collection Extensions https://johobase.com/collection-extensions-methods-list/
//  qiita: ����Ƃ�����ƕ֗��Ȋg�����\�b�h�Љ� https://qiita.com/s_mino_ri/items/0fd2e2b3cebb7a62ad46

namespace nitou {

    /// <summary>
    /// Collection�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static partial class CollectionExtensions {

        /// ----------------------------------------------------------------------------
        #region �v�f�̔���

        /// <summary>
        /// �R���N�V������Null�܂��͋󂩂ǂ����𔻒肷��g�����\�b�h
        /// </summary>
        public static bool IsNullOrEmpty(this ICollection self) {
            return self == null || self.Count == 0;
        }

        /// <summary>
        /// �w�肵���v�f���S�ăR���N�V�������ɂ��邩�ǂ����𔻒肷��g�����\�b�h
        /// </summary>
        public static bool ContainsAll<T>(this ICollection<T> self, params T[] items) {
            foreach (T item in items) {
                if (self.Contains(item)) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// �����̗v�f�̂����ꂩ���R���N�V�����Ɋi�[����Ă��邩�ǂ����𔻒肷��g�����\�b�h
        /// </summary>
        public static bool ContainsAny<T>(this ICollection<T> self, params T[] items) {
            foreach (T item in items) {
                if (self.Contains(item)) {
                    return true;
                }
            }
            return false;
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �v�f�̒ǉ�

        /// <summary>
        /// �w�肵�����������𖞂����ꍇ�ɗv�f��ǉ�����g�����\�b�h
        /// </summary>
        public static bool AddIf<T>(this ICollection<T> self, Predicate<T> predicate, T item) {
            if (predicate(item)) {
                self.Add(item);
                return true;
            }
            return false;
        }

        /// <summary>
        /// �v�f��Null�̏ꍇ�ɃR���N�V�����ɒǉ�����g�����\�b�h
        /// </summary>
        public static bool AddIfNotNull<T>(this ICollection<T> self, T item) where T : class {
            if (item != null) {
                self.Add(item);
                return true;
            }
            return false;
        }

        /// <summary>
        /// �v�f���R���N�V�������Ɋ܂܂�Ȃ���Βǉ�����g�����\�b�h
        /// </summary>
        public static bool AddIfNotContains<T>(this ICollection<T> self, T item) {
            if (!self.Contains(item)) {
                self.Add(item);
                return true;
            }
            return false;
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �v�f�̍폜

        /// <summary>
        /// �w�肵�����������𖞂����ꍇ�ɗv�f���폜����g�����\�b�h
        /// </summary>
        public static void RemoveIf<T>(this ICollection<T> self, Predicate<T> predicate, T item) {
            if (predicate(item)) {
                self.Remove(item);
            }
        }

        /// <summary>
        /// �����̗v�f���폜����g�����\�b�h
        /// </summary>
        public static void RemoveRange<T>(this ICollection<T> self, params T[] items) {
            foreach (T item in items) {
                self.Remove(item);
            }
        }

        /// <summary>
        /// �����̗v�f�̂��ꂼ��ɑ΂��Ďw�肵�������𖞂����ꍇ�ɍ폜����g�����\�b�h
        /// </summary>
        public static void RemoveRangeIf<T>(this ICollection<T> self, Predicate<T> predicate, params T[] items) {
            foreach (T item in items) {
                if (predicate(item)) {
                    self.Remove(item);
                }
            }
        }
        #endregion

    }
}