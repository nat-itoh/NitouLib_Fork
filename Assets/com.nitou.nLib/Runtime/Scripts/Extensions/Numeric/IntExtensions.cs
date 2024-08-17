using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// [�Q�l]
//  qiita: C#�Ő��l���J���}�t��������ɕϊ�������@ https://qiita.com/benjamin1gou/items/fd95dc47bc31ec734b83

namespace nitou {

    /// <summary>
    /// <see cref="int"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class IntExtensions {

        /// ----------------------------------------------------------------------------
        #region �l�̔���

        /// <summary>
        /// �������ǂ����𔻒肷��g�����\�b�h
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEven(this int self) => (self % 2) == 0;

        /// <summary>
        /// ����ǂ����𔻒肷��g�����\�b�h
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOdd(this int self) => (self % 2) != 0;

        /// <summary>
        /// �C���f�b�N�X���͈͓��ɂ��邩�ǂ����𔻒肷��g�����\�b�h
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInRange<T>(this int index, IReadOnlyCollection<T> collection) {
            bool isBetween = (0 <= index && index < collection.Count);
            return isBetween;
        }

        /// <summary>
        /// �C���f�b�N�X���͈͊O�ɂ��邩�ǂ����𔻒肷��g�����\�b�h
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOutRage<T>(this int index, IReadOnlyCollection<T> collection) {
            return !index.IsInRange(collection);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �l�̕␳

        /// <summary>
        /// ���̒l�ɂ���g�����\�b�h
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Positive(this int self) =>
            Mathf.Abs(self);

        /// <summary>
        /// ���̒l�ɂ���g�����\�b�h
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Negative(this int self) =>
            Mathf.Abs(self) * (-1);

        /// <summary>
        /// ���͂��w��͈͓��̒l�ɐ�������g�����\�b�h
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(this int self, int min, int max) =>
            Mathf.Clamp(self, min, max);

        /// <summary>
        /// ���l�����Z���āA�͈͂𒴂������� 0 ����̒l�Ƃ��ď������ĕԂ��g�����\�b�h
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Repeat(this int self, int value, int max) => (self + value + max) % max;

        #endregion


        /// ----------------------------------------------------------------------------
        #region ������ւ̕ϊ�

        /// <summary>
        /// �w�肳�ꂽ������0���߂����������Ԃ��g�����\�b�h
        /// </summary>
        public static string ToString_ZeroFill(this int self, int numberOfDigits) =>
            self.ToString("D" + numberOfDigits);

        /// <summary>
        /// �w�肳�ꂽ�����̌Œ菬���_����t�������������Ԃ��g�����\�b�h
        /// </summary>
        /// <remarks>
        /// 123.FixedPoint(2) �� "123.00"
        /// 123.FixedPoint(4) �� "123.0000"
        /// </remarks>
        public static string ToString_FixedPoint(this int self, int numberOfDigits) =>
            self.ToString("F" + numberOfDigits);

        /// <summary>
        /// �w�肳�ꂽ�@�@�g�����\�b�h
        /// </summary>
        public static string ToString_Separate(this int self) =>
            string.Format("{0:#,0}", self);

        /// <summary>
        /// �J���}�t���������Ԃ��g�����\�b�h
        /// </summary>
        /// <remarks>
        /// 1000000 �� "1,000,000"
        /// </remarks>
        public static string ToString_WithComma(this int self) =>
            self.ToString("N0");
        #endregion
    }
}