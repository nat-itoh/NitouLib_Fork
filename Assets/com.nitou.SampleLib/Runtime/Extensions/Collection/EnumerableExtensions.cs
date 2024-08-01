using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace nitou {

    /// <summary>
    /// <see cref="IEnumerable"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static partial class EnumerableExtensions {

        /// ----------------------------------------------------------------------------
        #region �v�f�̔���

        // [�Q�l]
        // _: IEnumerable.IsNullOrEmpty https://csharpvbcomparer.blogspot.com/2014/04/tips-ienumerable-isnullorempty.html

        /// <summary>
        /// Null,�܂��͋󂩂ǂ������ׂ�g�����\�b�h
        /// </summary>
        public static bool IsNullOrEmptyEnumerable<T>(this IEnumerable<T> source) {
            if (source == null) return true;
            using (var e = source.GetEnumerator()) return !e.MoveNext();
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �v�f�̕ϊ�

        /// <summary>
        /// null���������V�[�P���X�ɕϊ�����g�����\�b�h
        /// </summary>
        public static IEnumerable<T> WithoutNull<T>(this IEnumerable<T> source) where T : class {
            return source.Where(item => item != null);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �v�f�̑���

        /// <summary>
        /// IEnumerable�̊e�v�f�ɑ΂��āA�w�肳�ꂽ���������s����g�����\�b�h
        /// </summary>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T, int> action) {
            foreach (var n in source.Select((val, index) => new { val, index })) {
                action(n.val, n.index);
            }
            return source;
        }

        /// <summary>
        /// IEnumerable�̊e�v�f�ɑ΂��āA�w�肳�ꂽ���������s����g�����\�b�h
        /// </summary>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (var n in source) {
                action(n);
            }
            return source;
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �v�f�̎擾

        /// <summary>
        /// �ő�l�ƍŏ��l���擾����g�����\�b�h
        /// </summary>
        public static (T min, T max) MinMax<T>(this IEnumerable<T> source)
            where T : IComparable<T> {
            if (source is null) throw new ArgumentNullException(nameof(source));

            using (var enumerator = source.GetEnumerator()) {
                if (!enumerator.MoveNext()) throw new InvalidOperationException("Sequence contains no elements");

                // �����l
                T min = enumerator.Current;
                T max = enumerator.Current;

                while (enumerator.MoveNext()) {
                    if (enumerator.Current.CompareTo(max) > 0) {
                        max = enumerator.Current;
                    }
                    if (enumerator.Current.CompareTo(min) < 0) {
                        min = enumerator.Current;
                    }
                }

                return (min, max);
            }
        }

        /// <summary>
        /// �ő�l�ƍŏ��l���擾����g�����\�b�h
        /// </summary>
        public static (TResult min, TResult max) MinMax<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
            where TResult : IComparable<TResult> {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (selector is null) throw new ArgumentNullException(nameof(selector));

            using (var enumerator = source.GetEnumerator()) {
                if (!enumerator.MoveNext()) throw new InvalidOperationException("Sequence contains no elements");

                // �����l
                TResult minValue = selector(enumerator.Current);
                TResult maxValue = selector(enumerator.Current);

                while (enumerator.MoveNext()) {
                    TResult currentValue = selector(enumerator.Current);

                    if (currentValue.CompareTo(maxValue) > 0) {
                        maxValue = currentValue;
                    }
                    if (currentValue.CompareTo(minValue) < 0) {
                        minValue = currentValue;
                    }
                }

                return (minValue, maxValue);
            }
        }

        /// <summary>
        /// �ő�l�ƍŏ��l���擾����g�����\�b�h
        /// </summary>
        public static (T min, T max) MinMax<T>(this IEnumerable<T> source, Func<T, T, bool> isGreaterThan) {
            if (source is null) throw new System.ArgumentNullException(nameof(source));
            if (isGreaterThan is null) throw new System.ArgumentNullException(nameof(isGreaterThan));

            using (var enumerator = source.GetEnumerator()) {
                if (!enumerator.MoveNext()) throw new InvalidOperationException("Sequence contains no elements");

                // �����l
                T min = enumerator.Current;
                T max = enumerator.Current;

                while (enumerator.MoveNext()) {
                    var current = enumerator.Current;

                    if (isGreaterThan(current, max)) {
                        max = current;
                    }
                    if (!isGreaterThan(current, min)) {
                        min = current;
                    }
                }

                return (min, max);
            }
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region  ���̑�

        

        /// <summary>
        /// Csv �`���̕�����ɕϊ����܂��B
        /// </summary>
        public static string ToCsv(this IEnumerable<string> enumerable, char separator = ',') {
            if (enumerable == null) return null;

            var csv = new StringBuilder();
            enumerable.ForEach(v => {
                string val = v;
                if (v.Contains("\"") || v.Contains("\n")) {
                    if (v.Contains("\"")) {
                        // �_�u���N�H�[�g������ꍇ�̓_�u���N�H�[�g���Q�ɏd�˂�B(" => "")
                        val = val.Replace("\"", "\"\"");
                    }
                    // �_�u���N�H�[�g�܂��͉��s������ꍇ�̓_�u���N�H�[�g�ň͂ށB
                    val = $"\"{val}\"";
                }
                csv.AppendFormat("{0}{1}", val, separator);
            });
            return csv.ToString(0, csv.Length - 1);
        }
        #endregion
    }
}