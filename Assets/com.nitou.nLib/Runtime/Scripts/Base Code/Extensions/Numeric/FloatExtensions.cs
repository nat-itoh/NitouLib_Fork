using System.Runtime.CompilerServices;
using UnityEngine;

// [REF]
//  �z�g�g�M�X�ʐM: UnityEngine.Mathf��System.Math�ǂ������g���̂��ǂ��H�Ƃ����b https://shibuya24.info/entry/unity-csharp-mathf

namespace nitou {

    /// <summary>
    /// <see cref="float"/>�^�̊�{�I�Ȋg�����\�b�h�W�D
    /// </summary>
    public static partial class FloatExtensions {

        /// ----------------------------------------------------------------------------
        #region �l�̔���

        /// <summary>
        /// ���̒l���ǂ����𔻒肷��g�����\�b�h�D
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPositive(this float self) =>
            self > 0;

        /// <summary>
        /// ���̒l���ǂ����𔻒肷��g�����\�b�h�D
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNegative(this float self) =>
            self < 0;

        public static bool IsOver(this float self, float value) =>
            self > value;

        /// <summary>
        /// �l���O�����肷��g�����\�b�h�D
        /// </summary>
        public static bool IsZero(this float self) =>
            Mathf.Approximately(self, 0f);

        #endregion


        /// ----------------------------------------------------------------------------
        #region �l�̕␳

        /// <summary>
        /// ���̒l�ɂ���g�����\�b�h�D
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Positive(this float self) =>
            Mathf.Abs(self);

        /// <summary>
        /// ���̒l�ɂ���g�����\�b�h�D
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Negative(this float self) =>
            Mathf.Abs(self) * (-1);

        /// <summary>
        /// �w��͈͓��̒l�ɐ�������g�����\�b�h�D
        /// </summary>
        public static float Clamp(this float self, float min, float max) =>
            Mathf.Clamp(self, min, max);

        /// <summary>
        /// �w��͈͓��̒l�ɐ�������g�����\�b�h�D
        /// </summary>
        public static float Clamp01(this float self) =>
            Mathf.Clamp01(self);

        /// <summary>
        /// �l��؂�̂Ă�Int�^�ŕԂ��g�����\�b�h�D
        /// </summary>
        public static int FloorToInt(this float self) =>
            Mathf.FloorToInt(self);

        /// <summary>
        /// �l���ۂ߂�Int�^�ŕԂ��g�����\�b�h�D
        /// </summary>
        public static int RoundToInt(this float self) =>
            Mathf.RoundToInt(self);

        // [NOTE]
        //  _: �l�����͈̔͂Ɏ��߂�g�����\�b�h https://12px.com/blog/2023/01/remap/

        /// <summary>
        /// �����̒l��Ԃ��g�����\�b�h�D
        /// </summary>
        public static float Remap(this float value,
            float fromMin, float fromMax,
            float toMin, float toMax,
            bool clamp = true) {
            var val = (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
            return clamp ? Mathf.Clamp(val, toMin, toMax) : val;
        }

        #endregion


        /// ----------------------------------------------------------------------------
        #region �ȈՌv�Z

        /// <summary>
        /// �����̒l��Ԃ��g�����\�b�h�D
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Half(this float self) => self * 0.5f;

        /// <summary>
        /// �Q�{�̒l��Ԃ��g�����\�b�h�D
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Twice(this float self) => self * 2f;
        #endregion
    }
}