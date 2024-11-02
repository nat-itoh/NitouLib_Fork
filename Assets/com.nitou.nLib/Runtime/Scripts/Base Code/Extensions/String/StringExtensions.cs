using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

// [�Q�l]
//  �R�K�l�u���O: �w�肳�ꂽ�����񂪓d�b�ԍ����ǂ�����Ԃ��֐� https://baba-s.hatenablog.com/entry/2014/11/10/110048

namespace nitou {

    /// <summary>
    /// <see cref="string"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static partial class StringExtensions {

        /// ----------------------------------------------------------------------------
        #region ������̔���

        /// <summary>
        /// ������ Null�������͋� ���ǂ����𔻒肷��
        /// </summary>
        public static bool IsNullOrEmpty(this string self) =>
            string.IsNullOrEmpty(self);

        /// <summary>
        /// ������ Null/�󕶎�/�󔒕��� ���ǂ����𔻒肷��
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string self) =>
            string.IsNullOrWhiteSpace(self);


        /// <summary>
        /// �w�肳�ꂽ�����ꂩ�̕�������܂ނ��ǂ����𔻒肷��
        /// </summary>
        public static bool IncludeAny(this string self, params string[] list) =>
        list.Any(c => self.Contains(c));

        /// <summary>
        /// �����񂪎w�肳�ꂽ�����ꂩ�̕�����Ɠ��������ǂ����𔻒肷��
        /// </summary>
        public static bool IsAny(this string self, params string[] values) =>
            values.Any(c => c == self);


        /// <summary>
        /// �����񂪃��[���A�h���X���ǂ�����Ԃ��܂�
        /// </summary>
        public static bool IsMailAddress(this string self) {
            if (string.IsNullOrEmpty(self)) { return false; }

            return Regex.IsMatch(
                self,
                @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$",
                RegexOptions.IgnoreCase
            );
        }

        /// <summary>
        /// �����񂪓d�b�ԍ����ǂ����𔻒肷��
        /// </summary>
        public static bool IsPhoneNumber(this string self) {
            if (string.IsNullOrEmpty(self)) { return false; }

            return Regex.IsMatch(
                self,
                @"^0\d{1,4}-\d{1,4}-\d{4}$"
            );
        }

        /// <summary>
        /// �����񂪗X�֔ԍ����ǂ����𔻒肷��
        /// </summary>
        public static bool IsZipCode(this string self) {
            if (string.IsNullOrEmpty(self)) { return false; }

            return Regex.IsMatch(
                self,
                @"^\d\d\d-\d\d\d\d$",
                RegexOptions.ECMAScript
            );
        }

        /// <summary>
        /// ������ URL ���ǂ����𔻒肷��
        /// </summary>
        public static bool IsUrl(this string self) {
            if (string.IsNullOrEmpty(self)) { return false; }

            return Regex.IsMatch(
               self,
               @"^s?https?://[-_.!~*'()a-zA-Z0-9;/?:@&=+$,%#]+$"
            );
        }

        // ----- 

        /// <summary>
        /// �R���N�V�����v�f�ɏd�������邩���肷��g�����\�b�h
        /// </summary>
        public static bool ContainsDuplicate(this IEnumerable<string> self) =>
            self.GroupBy(i => i).SelectMany(g => g.Skip(1)).Any();

        #endregion


        /// ----------------------------------------------------------------------------
        #region ������̏C��

        /// <summary>
        /// �����񂩂�󔒕������폜����
        /// </summary>
        public static string WithoutSpace(this string self) =>
            String.Concat(self.Where(c => !Char.IsWhiteSpace(c)));

        #endregion

    }
}