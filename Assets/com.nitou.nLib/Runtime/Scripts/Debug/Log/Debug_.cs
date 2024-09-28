using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using UnityEngine;

// [�Q�l]
//  qiita: UnityEditor�̎��̂�Debug.Log���o�����@ https://qiita.com/toRisouP/items/d856d65dcc44916c487d
//  zonn: Debug.Log��֗��ɂ��邽�߂ɍH�v���Ă��邱�� https://zenn.dev/happy_elements/articles/38be21755773e0
//  _: Color�^�ϐ������Ƃ�Debug.Log�̕����F��ύX���� https://nmxi.hateblo.jp/entry/2019/02/24/235216
//  kan�̃�����: ConditionalAttribute�ŕ����̃V���{����AND��OR������������@ https://kan-kikuchi.hatenablog.com/entry/ConditionalAttribute_AND_OR
//  kan�̃�����: �J���p�r���h���ɗL���ɂȂ�DEVELOPMENT_BUILD��DEBUG�̈Ⴂ https://kan-kikuchi.hatenablog.com/entry/DEVELOPMENT_BUILD_DEBUG

namespace nitou {
    using nitou.RichText;
    using System.Text.RegularExpressions;
    using Debug = UnityEngine.Debug;

    /// <summary>
    /// Debug�̃��b�p�[�N���X
    /// </summary>
    public static partial class Debug_ {

        /// ----------------------------------------------------------------------------
        #region Public Method (��{���O)

        /// <summary>
        /// UnityEditor��ł̂ݎ��s�����Log���\�b�h
        /// </summary>
        [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]
        public static void Log(object o) => Debug.Log(FormatObject(o));

        /// <summary>
        /// UnityEditor��ł̂ݎ��s�����Log���\�b�h
        /// </summary>
        [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]
        public static void Log(object o, Color color) => Debug.Log(FormatObject(o).WithColorTag(color));

        public static void Log(params object[] messages) {
            var message = string.Join(',', messages.Select(FormatObject));
            Debug.Log(message);
        }

        /// <summary>
        /// UnityEditor��ł̂ݎ��s�����LogWarning���\�b�h
        /// </summary>
        [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]
        public static void LogWarning(object o) => Debug.LogWarning(FormatObject(o));

        /// <summary>
        /// UnityEditor��ł̂ݎ��s�����LogWarning���\�b�h
        /// </summary>
        [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]
        public static void LogWarning(object o, Color color) => Debug.LogWarning(FormatObject(o).WithColorTag(color));

        /// <summary>
        /// UnityEditor��ł̂ݎ��s�����LogError���\�b�h
        /// </summary>
        [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]
        public static void LogError(object o) => Debug.LogError(o);

        /// <summary>
        /// UnityEditor��ł̂ݎ��s�����LogWarning���\�b�h
        /// </summary>
        [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]
        public static void LogError(object o, Color color) => Debug.LogError(FormatObject(o).WithColorTag(color));

        #endregion


        /// ----------------------------------------------------------------------------
        #region Public Method (�R���N�V����)

        private static readonly int MAX_ROW_NUM = 100;

        /// <summary>
        /// UnityEditor��ł̂ݎ��s�����Log���\�b�h
        /// </summary>
        [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]
        public static void ListLog<T>(IReadOnlyList<T> list) => Log(list.Convert<T>());

        /// <summary>
        /// UnityEditor��ł̂ݎ��s�����Log���\�b�h
        /// </summary>
        [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]
        public static void ListLog<T>(IReadOnlyList<T> list, Color color) => Log(list.Convert<T>(), color);

        /// <summary>
        /// UnityEditor��ł̂ݎ��s�����Log���\�b�h
        /// </summary>
        [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]
        public static void DictLog<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> dict) => Log(dict.Convert<TKey, TValue>());

        #endregion


        /// ----------------------------------------------------------------------------
        #region Private Method (�ϊ����\�b�h)

        /// <summary>
        /// ������ւ̕ϊ��i��null�C�󕶎������ʂł���`���j
        /// </summary>
        private static string FormatObject(object o) {
            if (o is null) {
                return "(null)";
            } 
            if (o as string == string.Empty) {
                return "(empty)";
            }
            return o.ToString();
        }

        /// <summary>
        /// ���X�g�v�f�𕶎���ɕϊ�����
        /// </summary>
        private static string Convert<T>(this IReadOnlyList<T> list) {
            if (list == null) return "(null)";

            var sb = new StringBuilder();
            sb.Append($"(The total number of elements is {list.Count})\n");

            // ������֕ϊ�
            for (int index = 0; index < list.Count; index++) {
                // �ő�s���𒴂����ꍇ�C
                if (index >= MAX_ROW_NUM) {
                    sb.Append($"(+{list.Count - MAX_ROW_NUM} items has been omitted)");
                    break;
                }
                // �v�f�ǉ�
                var rowText = $"[ {index} ] = {list[index]}";
#if UNITY_2022_1_OR_NEWER
                sb.Append($"{rowText.WithIndentTag()} \n");
#else
                sb.Append($"    {rowText} \n");
#endif
            }
            return sb.ToString();
        }

        /// <summary>
        /// �f�B�N�V���i���v�f�𕶎���ɕϊ�����
        /// </summary>
        private static string Convert<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dict) {
            if (dict == null) return "(null)";

            var sb = new StringBuilder();
            sb.Append($"(The total number of elements is {dict.Count})\n");

            // ������֕ϊ�
            int index = 0;
            foreach ((var key, var value) in dict) {
                // �ő�s���𒴂����ꍇ�C
                if (index >= MAX_ROW_NUM) {
                    sb.Append($"(+{dict.Count - MAX_ROW_NUM} items has been omitted)");
                    break;
                }

                // �v�f�ǉ�
                var rowText = $"[ {key} ] = {value}";
#if UNITY_2022_1_OR_NEWER
                sb.Append($"{rowText.WithIndentTag()} \n");
#else
                sb.Append($"    {rowText} \n");
#endif
                index++;
            }
            return sb.ToString();
        }


        static string DecorateColorTag(object message) {
            var sb = new StringBuilder();
            var messageString = message.ToString();
            sb.Append(messageString);
            var reg = new Regex("\\[(?<tag>.*?)\\]", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            var matches = reg.Matches(messageString);
            foreach (var match in matches.Reverse()) {
                var tag = match.Groups["tag"].Value;
                // HashCode�����Ƃɉ��炩�̐F���擾
                var color = Colors.SelectFromManyColors(tag.GetHashCode());
                sb.Insert(match.Index + match.Length, "</color></b>");
                sb.Insert(match.Index, $"<b><color={Colors.ToRgbCode(color)}>");
            }

            return sb.ToString();
        }

        #endregion

    }

}