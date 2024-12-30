﻿using System;
using System.Collections.Generic;
using UnityEngine;

// [参考]
//  qiita: 角度を扱うときはfloatじゃなくて専用のAngle構造体を用意すると捗る https://qiita.com/yutorisan/items/63679fc1babb142e5b01

namespace nitou {

    /// <summary>
    /// 角度情報を扱う構造体
    /// </summary>
    public struct Angle : IEquatable<Angle>, IComparable<Angle> {

        /// <summary>
        /// 正規化していない角度の累積値
        /// </summary>
        private readonly float _totalDegree;


        /// ----------------------------------------------------------------------------
        #region Properity

        /// <summary>
        /// 正規化していない角度値[degree]
        /// </summary>
        public float TotalDegree => _totalDegree;

        /// <summary>
        /// 正規化していない角度値[rad]
        /// </summary>
        public float TotalRadian => DegToRad(TotalDegree);

        /// <summary>
        /// 正規化された角度値(-180 &lt; angle &lt;= 180)[degree]
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
        /// 正規化された角度値をラジアン(-π &lt; rad &lt; π)で取得します。
        /// </summary>
        public float NormalizedRadian => DegToRad(NormalizedDegree);

        /// <summary>
        /// 正規化された角度値(0 &lt;= angle &lt; 360)を取得します。
        /// </summary>
        public float PositiveNormalizedDegree {
            get {
                var normalized = NormalizedDegree;
                return normalized >= 0 ? normalized : normalized + 360;
            }
        }

        /// <summary>
        /// 正規化された角度値をラジアン(0 &lt;= rad &lt; 2π)で取得します。
        /// </summary>
        public float PositiveNormalizedRadian => DegToRad(PositiveNormalizedDegree);

        /// <summary>
        /// 角度が何周しているかを取得します。
        /// 例：370°→1周, -1085°→-3周
        /// </summary>
        public int Lap => ((int)_totalDegree) / 360;

        /// <summary>
        /// 1周以上しているかどうか(360°以上、もしくは-360°以下かどうか)を取得します。
        /// </summary>
        public bool IsCircled => Lap != 0;

        /// <summary>
        /// 360の倍数の角度であるかどうかを取得します。
        /// </summary>
        public bool IsTrueCircle => IsCircled && _totalDegree % 360 == 0;

        /// <summary>
        /// 正の角度かどうかを取得します。
        /// </summary>
        public bool IsPositive => _totalDegree >= 0;
        #endregion


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// 角度を度数法で指定して、新規インスタンスを作成する．
        /// </summary>
        /// <param name="angle">度数法の角度</param>
        /// <exception cref="NotFiniteNumberException"/>
        private Angle(float angle) {
            _totalDegree = ArithmeticCheck(() => angle);
        }

        /// <summary>
        /// 周回数と角度を指定して、新規インスタンスを作成する．
        /// </summary>
        /// <param name="lap">周回数</param>
        /// <param name="angle">度数法の角度</param>
        /// <exception cref="NotFiniteNumberException"/>
        /// <exception cref="OverflowException"/>
        private Angle(int lap, float angle) {
            _totalDegree = ArithmeticCheck(() => checked(360 * lap + angle));
        }

        /// ----------------------------------------------------------------------------
        // Static Method

        /// <summary>
        /// 度数法の値を使用して新規インスタンスを取得します。
        /// </summary>
        /// <param name="degree">度数法の角度(°)</param>
        /// <returns></returns>
        /// <exception cref="NotFiniteNumberException"/>
        public static Angle FromDegree(float degree) => new Angle(degree);

        /// <summary>
        /// 周回数と角度を指定して、新規インスタンスを取得します。
        /// </summary>
        /// <param name="lap">周回数</param>
        /// <param name="degree">度数法の角度(°)</param>
        /// <returns></returns>
        /// <exception cref="NotFiniteNumberException"/>
        public static Angle FromDegree(int lap, float degree) => new Angle(lap, degree);

        /// <summary>
        /// 弧度法の値を使用して新規インスタンスを取得します。
        /// </summary>
        /// <param name="radian">弧度法の角度(rad)</param>
        /// <returns></returns>
        /// <exception cref="NotFiniteNumberException"/>
        public static Angle FromRadian(float radian) => new Angle(RadToDeg(radian));

        /// <summary>
        /// 周回数と角度を指定して、新規インスタンスを取得します。
        /// </summary>
        /// <param name="lap">周回数</param>
        /// <param name="radian">弧度法の角度(rad)</param>
        /// <returns></returns>
        /// <exception cref="NotFiniteNumberException"/>
        public static Angle FromRadian(int lap, float radian) => new Angle(lap, RadToDeg(radian));

        /// <summary>
        /// 角度0°の新規インスタンスを取得します。
        /// </summary>
        public static Angle Zero => new Angle(0);

        /// <summary>
        /// 角度360°の新規インスタンスを取得します。
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

        public override string ToString() => $"{Lap}x + {_totalDegree - Lap * 360}°";

        public int CompareTo(Angle other) => _totalDegree.CompareTo(other._totalDegree);

        /// <summary>
        /// 正規化された角度(-180° &lt; degree &lt;= 180°)を取得します。
        /// </summary>
        /// <returns></returns>
        public Angle Normalize() => new Angle(NormalizedDegree);

        /// <summary>
        /// 正の値で正規化された角度(0° &lt;= degree &lt; 360°)を取得します。
        /// </summary>
        /// <returns></returns>
        public Angle PositiveNormalize() => new Angle(PositiveNormalizedDegree);

        /// <summary>
        /// 方向を反転させた角度を取得します。
        /// 例：90°→-270°, -450°→630°
        /// </summary>
        /// <returns></returns>
        public Angle Reverse() {
            //ゼロならゼロ
            if (this == Zero) return Zero;
            //真円の場合は真逆にする
            if (IsTrueCircle) return new Angle(-Lap, 0);
            if (IsCircled) { //1周以上している
                if (IsPositive) { //360~
                    return new Angle(-Lap, NormalizedDegree - 360);
                } else { //~-360
                    return new Angle(-Lap, NormalizedDegree + 360);
                }
            } else { //1周していない
                if (IsPositive) { //0~360
                    return new Angle(_totalDegree - 360);
                } else { //-360~0
                    return new Angle(_totalDegree + 360);
                }
            }
        }

        /// <summary>
        /// 符号を反転させた角度を取得します。
        /// </summary>
        /// <returns></returns>
        public Angle SignReverse() => new Angle(-_totalDegree);

        /// <summary>
        /// 角度の絶対値を取得します。
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
        /// 演算結果が数値であるかを確かめる
        /// </summary>
        private static float ArithmeticCheck(Func<float> func) {
            var ans = func();
            if (float.IsInfinity(ans)) throw new NotFiniteNumberException("演算の結果、角度が正の無限大または負の無限大になりました");
            if (float.IsNaN(ans)) throw new NotFiniteNumberException("演算の結果、角度がNaNになりました");
            return ans;
        }

        private static float RadToDeg(float rad) => rad * 180 / Mathf.PI;

        private static float DegToRad(float deg) => deg * (Mathf.PI / 180);
    }
}
