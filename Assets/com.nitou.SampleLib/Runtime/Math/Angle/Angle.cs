using System;
using System.Collections.Generic;
using UnityEngine;

// [�Q�l]
//  qiita: �p�x�������Ƃ���float����Ȃ��Đ�p��Angle�\���̂�p�ӂ���ƒ��� https://qiita.com/yutorisan/items/63679fc1babb142e5b01

namespace nitou {

    /// <summary>
    /// �p�x���������\����
    /// </summary>
    public struct Angle : IEquatable<Angle>, IComparable<Angle> {

        /// <summary>
        /// ���K�����Ă��Ȃ��p�x�̗ݐϒl
        /// </summary>
        private readonly float _totalDegree;


        /// ----------------------------------------------------------------------------
        #region Properity

        /// <summary>
        /// ���K�����Ă��Ȃ��p�x�l[degree]
        /// </summary>
        public float TotalDegree => _totalDegree;

        /// <summary>
        /// ���K�����Ă��Ȃ��p�x�l[rad]
        /// </summary>
        public float TotalRadian => DegToRad(TotalDegree);

        /// <summary>
        /// ���K�����ꂽ�p�x�l(-180 &lt; angle &lt;= 180)[degree]
        /// </summary>
        public float NormalizedDegree {
            get {
                float lapExcludedDegree = _totalDegree - (Lap * 360);
                if (lapExcludedDegree > 180) return lapExcludedDegree - 360;
                if (lapExcludedDegree <= -180) return lapExcludedDegree + 360;
                return lapExcludedDegree;
            }
        }

        /// <summary>
        /// ���K�����ꂽ�p�x�l�����W�A��(-�� &lt; rad &lt; ��)�Ŏ擾���܂��B
        /// </summary>
        public float NormalizedRadian => DegToRad(NormalizedDegree);

        /// <summary>
        /// ���K�����ꂽ�p�x�l(0 &lt;= angle &lt; 360)���擾���܂��B
        /// </summary>
        public float PositiveNormalizedDegree {
            get {
                var normalized = NormalizedDegree;
                return normalized >= 0 ? normalized : normalized + 360;
            }
        }

        /// <summary>
        /// ���K�����ꂽ�p�x�l�����W�A��(0 &lt;= rad &lt; 2��)�Ŏ擾���܂��B
        /// </summary>
        public float PositiveNormalizedRadian => DegToRad(PositiveNormalizedDegree);

        /// <summary>
        /// �p�x���������Ă��邩���擾���܂��B
        /// ��F370����1��, -1085����-3��
        /// </summary>
        public int Lap => ((int)_totalDegree) / 360;

        /// <summary>
        /// 1���ȏサ�Ă��邩�ǂ���(360���ȏ�A��������-360���ȉ����ǂ���)���擾���܂��B
        /// </summary>
        public bool IsCircled => Lap != 0;

        /// <summary>
        /// 360�̔{���̊p�x�ł��邩�ǂ������擾���܂��B
        /// </summary>
        public bool IsTrueCircle => IsCircled && _totalDegree % 360 == 0;

        /// <summary>
        /// ���̊p�x���ǂ������擾���܂��B
        /// </summary>
        public bool IsPositive => _totalDegree >= 0;
        #endregion


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �p�x��x���@�Ŏw�肵�āA�V�K�C���X�^���X���쐬����D
        /// </summary>
        /// <param name="angle">�x���@�̊p�x</param>
        /// <exception cref="NotFiniteNumberException"/>
        private Angle(float angle) {
            _totalDegree = ArithmeticCheck(() => angle);
        }

        /// <summary>
        /// ���񐔂Ɗp�x���w�肵�āA�V�K�C���X�^���X���쐬����D
        /// </summary>
        /// <param name="lap">����</param>
        /// <param name="angle">�x���@�̊p�x</param>
        /// <exception cref="NotFiniteNumberException"/>
        /// <exception cref="OverflowException"/>
        private Angle(int lap, float angle) {
            _totalDegree = ArithmeticCheck(() => checked(360 * lap + angle));
        }

        /// ----------------------------------------------------------------------------
        // Static Method

        /// <summary>
        /// �x���@�̒l���g�p���ĐV�K�C���X�^���X���擾���܂��B
        /// </summary>
        /// <param name="degree">�x���@�̊p�x(��)</param>
        /// <returns></returns>
        /// <exception cref="NotFiniteNumberException"/>
        public static Angle FromDegree(float degree) => new Angle(degree);

        /// <summary>
        /// ���񐔂Ɗp�x���w�肵�āA�V�K�C���X�^���X���擾���܂��B
        /// </summary>
        /// <param name="lap">����</param>
        /// <param name="degree">�x���@�̊p�x(��)</param>
        /// <returns></returns>
        /// <exception cref="NotFiniteNumberException"/>
        public static Angle FromDegree(int lap, float degree) => new Angle(lap, degree);

        /// <summary>
        /// �ʓx�@�̒l���g�p���ĐV�K�C���X�^���X���擾���܂��B
        /// </summary>
        /// <param name="radian">�ʓx�@�̊p�x(rad)</param>
        /// <returns></returns>
        /// <exception cref="NotFiniteNumberException"/>
        public static Angle FromRadian(float radian) => new Angle(RadToDeg(radian));

        /// <summary>
        /// ���񐔂Ɗp�x���w�肵�āA�V�K�C���X�^���X���擾���܂��B
        /// </summary>
        /// <param name="lap">����</param>
        /// <param name="radian">�ʓx�@�̊p�x(rad)</param>
        /// <returns></returns>
        /// <exception cref="NotFiniteNumberException"/>
        public static Angle FromRadian(int lap, float radian) => new Angle(lap, RadToDeg(radian));

        /// <summary>
        /// �p�x0���̐V�K�C���X�^���X���擾���܂��B
        /// </summary>
        public static Angle Zero => new Angle(0);

        /// <summary>
        /// �p�x360���̐V�K�C���X�^���X���擾���܂��B
        /// </summary>
        public static Angle Round => new Angle(360);


        /// ----------------------------------------------------------------------------
        // Public Method

        public bool Equals(Angle other) => _totalDegree == other._totalDegree;

        public override bool Equals(object obj) {
            if (obj is Angle angle) return Equals(angle);
            else return false;
        }

        public override int GetHashCode() => -1748791360 + _totalDegree.GetHashCode();

        public override string ToString() => $"{Lap}x + {_totalDegree - Lap * 360}��";

        public int CompareTo(Angle other) => _totalDegree.CompareTo(other._totalDegree);

        /// <summary>
        /// ���K�����ꂽ�p�x(-180�� &lt; degree &lt;= 180��)���擾���܂��B
        /// </summary>
        /// <returns></returns>
        public Angle Normalize() => new Angle(NormalizedDegree);

        /// <summary>
        /// ���̒l�Ő��K�����ꂽ�p�x(0�� &lt;= degree &lt; 360��)���擾���܂��B
        /// </summary>
        /// <returns></returns>
        public Angle PositiveNormalize() => new Angle(PositiveNormalizedDegree);

        /// <summary>
        /// �����𔽓]�������p�x���擾���܂��B
        /// ��F90����-270��, -450����630��
        /// </summary>
        /// <returns></returns>
        public Angle Reverse() {
            //�[���Ȃ�[��
            if (this == Zero) return Zero;
            //�^�~�̏ꍇ�͐^�t�ɂ���
            if (IsTrueCircle) return new Angle(-Lap, 0);
            if (IsCircled) { //1���ȏサ�Ă���
                if (IsPositive) { //360~
                    return new Angle(-Lap, NormalizedDegree - 360);
                } else { //~-360
                    return new Angle(-Lap, NormalizedDegree + 360);
                }
            } else { //1�����Ă��Ȃ�
                if (IsPositive) { //0~360
                    return new Angle(_totalDegree - 360);
                } else { //-360~0
                    return new Angle(_totalDegree + 360);
                }
            }
        }

        /// <summary>
        /// �����𔽓]�������p�x���擾���܂��B
        /// </summary>
        /// <returns></returns>
        public Angle SignReverse() => new Angle(-_totalDegree);

        /// <summary>
        /// �p�x�̐�Βl���擾���܂��B
        /// </summary>
        /// <returns></returns>
        public Angle Absolute() => IsPositive ? this : SignReverse();



        /// ----------------------------------------------------------------------------
        #region Operater

        public static Angle operator +(Angle left, Angle right) =>
            new Angle(ArithmeticCheck(() => left._totalDegree + right._totalDegree));

        public static Angle operator -(Angle left, Angle right) =>
            new Angle(ArithmeticCheck(() => left._totalDegree - right._totalDegree));

        public static Angle operator *(Angle left, float right) =>
            new Angle(ArithmeticCheck(() => left._totalDegree * right));

        public static Angle operator /(Angle left, float right) =>
            new Angle(ArithmeticCheck(() => left._totalDegree / right));

        public static bool operator ==(Angle left, Angle right) =>
            left._totalDegree == right._totalDegree;

        public static bool operator !=(Angle left, Angle right) =>
            left._totalDegree != right._totalDegree;

        public static bool operator >(Angle left, Angle right) =>
            left._totalDegree > right._totalDegree;

        public static bool operator <(Angle left, Angle right) => left._totalDegree < right._totalDegree;

        public static bool operator >=(Angle left, Angle right) =>
            left._totalDegree >= right._totalDegree;

        public static bool operator <=(Angle left, Angle right) =>
            left._totalDegree <= right._totalDegree;
        #endregion


        /// ----------------------------------------------------------------------------
        // Static Method

        /// <summary>
        /// ���Z���ʂ����l�ł��邩���m���߂�
        /// </summary>
        private static float ArithmeticCheck(Func<float> func) {
            var ans = func();
            if (float.IsInfinity(ans)) throw new NotFiniteNumberException("���Z�̌��ʁA�p�x�����̖�����܂��͕��̖�����ɂȂ�܂���");
            if (float.IsNaN(ans)) throw new NotFiniteNumberException("���Z�̌��ʁA�p�x��NaN�ɂȂ�܂���");
            return ans;
        }

        private static float RadToDeg(float rad) => rad * 180 / Mathf.PI;

        private static float DegToRad(float deg) => deg * (Mathf.PI / 180);
    }
}
