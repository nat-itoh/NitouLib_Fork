using System.Collections.Generic;

// [�Q�l]
//  qiita: �p�X���[�h�̂悤�ȃ����_���ȕ�����𐶐����ĕԂ��֐� https://baba-s.hatenablog.com/entry/2015/07/07/000000

namespace nitou {

    public static class StringUtil {

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

        /// <summary>
        /// �ȈՓI�ȃp�X���[�h�𐶐�����
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
        private const string PASSWORD_CHARS = "0123456789abcdefghijklmnopqrstuvwxyz";

        #endregion

    }


    public static class ParseUtil {

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