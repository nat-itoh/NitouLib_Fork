using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// [REF]
//  qiita: �p�X���[�h�̂悤�ȃ����_���ȕ�����𐶐����ĕԂ��֐� https://baba-s.hatenablog.com/entry/2015/07/07/000000

namespace nitou {

    /// <summary>
    /// <see cref="string"/>�^�̔ėp���\�b�h�W�D
    /// </summary>
    public static class StringUtils {

        /// ----------------------------------------------------------------------------
        #region ������ւ̕ϊ�

        public static string ToFloatText(this float self) {
            return self.ToString("0.00");
        }

        public static string ToFloatText(this float self, int decimalPlaces = 2) {
            // �����_�ȉ��̌����Ɋ�Â��ăt�H�[�}�b�g
            string format = "0." + new string('0', decimalPlaces);
            return self.ToString(format);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region ������̐���

        private const string PASSWORD_CHARS = "0123456789abcdefghijklmnopqrstuvwxyz";
        
        /// <summary>
        /// �ȈՓI�ȃp�X���[�h�𐶐�����D
        /// </summary>
        public static string GeneratePassword(int length) {
            var sb = new System.Text.StringBuilder(length);
            var r = new System.Random();

            for (int i = 0; i < length; i++) {
                int pos = r.Next(PASSWORD_CHARS.Length);
                char c = PASSWORD_CHARS[pos];
                sb.Append(c);
            }

            return sb.ToString();
        }

        #endregion


        /// ----------------------------------------------------------------------------
        #region ������̐���
        
        // UniquName

        /// <summary>
        /// �R���N�V�������ŏd�����Ȃ����O���擾����D
        /// </summary>
        public static string GetUniqueName(string baseName, IEnumerable<string> existingNames, Func<string, int, string> selector) {
            string newName = baseName;
            int suffix = 1;

            // �d��������ꍇ�͐ڔ�����t���Ĉ�ӂ̖��O�𐶐�
            while (existingNames.Contains(newName)) {
                newName = selector(baseName, suffix);
                suffix++;
            }

            return newName;
        }

        /// <summary>
        /// �R���N�V�������ŏd�����Ȃ����O���擾����D
        /// </summary>
        public static string GetUniqueName(string baseName, IEnumerable<string> existingNames) {
            return GetUniqueName(baseName, existingNames, (baseName, index) => $"{baseName}({index})");
        }

        /// <summary>
        /// �R���N�V�������ŏd�����Ȃ��R�s�[�I�u�W�F�N�g�����擾����D
        /// </summary>
        public static string GetUniqueCopyDataName(string baseName, IEnumerable<string> existingNames) {
            string newName = GetCopyDataName(baseName);

            // �d��������ꍇ�Ɉ�ӂ̃R�s�[���𐶐�
            while (existingNames.Contains(newName)) {
                newName = GetCopyDataName(newName);
            }

            return newName;
        }


        /// ----------------------------------------------------------------------------
        // 

        /// <summary>
        /// Generates name for copyed instance.
        /// </summary>
        public static string GetCopyDataName(string baseName) {
            // [NOTE]
            //  Generates a unique "copy" name for a given base name by appending "_cpy" or "_cpy(n)" where n is an incremented number.
            //  If the base name already contains "_cpy" or "_cpy(n)", the number n is incremented to ensure uniqueness.

            // pattern : "_cpy" or "_cpy(no)"
            string pattern = @"_cpy(?:\((\d+)\))?$";
            Match match = Regex.Match(baseName, pattern);

            if (match.Success) {
                //  "_cpy(no)" �̏ꍇ
                if (match.Groups[1].Success && int.TryParse(match.Groups[1].Value, out int number)) {
                    // set incremented number
                    number++;
                    baseName = Regex.Replace(baseName, pattern, $"_cpy({number})");
                }
                // "_cpy" �̏ꍇ
                else {
                    baseName = baseName + "(1)";
                }
            } else {
                // "_cpy" �łȂ��ꍇ�A"_cpy" ��ǉ�
                baseName += "_cpy";
            }

            return baseName;
        }
        #endregion



    }


    public static class ParseUtils {

        /// ----------------------------------------------------------------------------
        #region ������̐���

        public static float FloatOrZero(string text) {
            return float.TryParse(text, out var result) ? result : 0f;
        }

        public static float FloatOrDefault(string text, float value) {
            return float.TryParse(text, out var result) ? result : value;
        }
        #endregion

    }

}