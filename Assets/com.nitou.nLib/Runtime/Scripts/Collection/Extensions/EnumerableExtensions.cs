using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

// [REF]
//  qiita: .NET 9��LINQ�ɒǉ����ꂽ���\�b�h https://qiita.com/RyotaMurohoshi/items/595b87e1db93768d0d44
// _: IEnumerable.IsNullOrEmpty https://csharpvbcomparer.blogspot.com/2014/04/tips-ienumerable-isnullorempty.html

namespace nitou {

    /// <summary>
    /// <see cref="IEnumerable"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static partial class EnumerableExtensions {

        /// ----------------------------------------------------------------------------
        #region �v�f�̔���

        /// <summary>
        /// Null,�܂��͋󂩂ǂ������ׂ�g�����\�b�h�D
        /// </summary>
        public static bool IsNullOrEmptyEnumerable<T>(this IEnumerable<T> source) {
            return source == null || !source.Any();
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �v�f�̕ϊ�

        /// <summary>
        /// null���������V�[�P���X�ɕϊ�����g�����\�b�h�D
        /// </summary>
        public static IEnumerable<T> WithoutNull<T>(this IEnumerable<T> source) where T : class {
            return source.Where(item => item != null);
        }

        /// <summary>
        /// �e�v�f�ɃC���f�b�N�X��t�^�����V�[�P���X���擾����g�����\�b�h�D
        /// </summary>
        public static IEnumerable<(T item, int index)> Index<T>(this IEnumerable<T> source) {
            return source.Select((item, index) => (item, index));
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �v�f�̑���

        /// <summary>
        /// IEnumerable�̊e�v�f�ɑ΂��āA�w�肳�ꂽ���������s����g�����\�b�h�D
        /// </summary>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T, int> action) {
            foreach ((var item, var index) in source.Index()) {
                action(item, index);
            }
            return source;
        }

        /// <summary>
        /// IEnumerable�̊e�v�f�ɑ΂��āA�w�肳�ꂽ���������s����g�����\�b�h�D
        /// </summary>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (var item in source) {
                action(item);
            }
            return source;
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �v�f�̎擾

        /// <summary>
        /// �w��v�f�̃C���f�b�N�X���擾����g�����\�b�h�D�V�[�P���X�Ɋ܂܂�Ȃ��ꍇ��-1��Ԃ��D
        /// </summary>
        public static int IndexOf<T>(this IEnumerable<T> source, T value) {
            if (source == null) throw new ArgumentNullException(nameof(source));

            int index = 0;
            var comparer = EqualityComparer<T>.Default;

            foreach (var item in source) {
                if (comparer.Equals(item, value))
                    return index;

                index++;
            }

            return -1; // ������Ȃ��ꍇ
        }

        /// <summary>
        /// �w��v�f�̃C���f�b�N�X���擾����g�����\�b�h�D�V�[�P���X�Ɋ܂܂�Ȃ��ꍇ��-1��Ԃ��D
        /// </summary>
        public static int IndexOf<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            int index = 0;
            foreach (var item in source) {
                if (predicate(item))
                    return index;

                index++;
            }

            return -1; // �����ɍ��v����v�f���Ȃ��ꍇ
        }


        /// <summary>
        /// �����Ɋ�Â��čŏ��̗v�f���擾����g�����\�b�h�D
        /// </summary>
        public static T MinBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> selector)
            where TKey : IComparable<TKey> {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return source
                .Aggregate((min, current) => selector(current)
                .CompareTo(selector(min)) < 0 ? current : min);
        }

        /// <summary>
        /// �����Ɋ�Â��čő�̗v�f���擾����g�����\�b�h�D
        /// </summary>
        public static T MaxBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> selector)
            where TKey : IComparable<TKey> {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return source
                .Aggregate((max, current) => selector(current)
                .CompareTo(selector(max)) > 0 ? current : max);
        }

        /// <summary>
        /// �ő�l�ƍŏ��l���擾����g�����\�b�h�D
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
        /// �ő�l�ƍŏ��l���擾����g�����\�b�h�D
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
        /// �ő�l�ƍŏ��l���擾����g�����\�b�h�D
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
        #region  ������ւ̕ϊ�

        /// <summary>
        /// Csv�`���̕�����ɕϊ����܂��B
        /// </summary>
        public static string ToCsvText(this IEnumerable<string> source, char separator = ',') {
            if (source == null) return null;

            var csv = new StringBuilder();
            source.ForEach(v => {
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

        /// <summary>
        /// 
        /// </summary>
        public static string ToBracketedString<T>(this IEnumerable<T> source) {
            return $"[{string.Join(", ", source)}]";
        }
        #endregion
    }
}