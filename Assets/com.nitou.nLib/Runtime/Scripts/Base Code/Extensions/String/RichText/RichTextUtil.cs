using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [�Q�l]
//  Document : �T�|�[�g����郊�b�`�e�L�X�g�^�O https://docs.unity3d.com/ja/2022.3/Manual/UIE-supported-tags.html
//  _: TextMeshPro�̃��b�`�e�L�X�g�^�O�ꗗ https://madnesslabo.net/utage/?page_id=12903
//  _: TextMeshPro �Ŏg���郊�b�`�e�L�X�g�^�O�܂Ƃ� https://www.midnightunity.net/textmeshpro-richtext-tags/#google_vignette

namespace nitou.RichText {

    /// <summary>
    /// ����������b�`�e�L�X�g�֕ϊ�����g�����\�b�h�W
    /// </summary>
    public static class RichTextUtil {

        /// <summary>
        /// �J���[�^�O��}������
        /// </summary>
        public static string WithColorTag(this string self, Color color) {
            return string.Format("<color=#{0:X2}{1:X2}{2:X2}>{3}</color>",
                (byte)(color.r * 255f),
                (byte)(color.g * 255f),
                (byte)(color.b * 255f),
                self
            );
        }

        /// <summary>
        /// �����^�O��}������
        /// </summary>
        public static string WithBoldTag(this string self) {
            return $"<b>{self}</b>";
        }

        /// <summary>
        /// �Α̃^�O��}������
        /// </summary>
        public static string WithItalicTag(this string self) {
            return $"<i>{self}</i>";
        }

        /// <summary>
        /// �A���_�[���C���^�O��}������
        /// </summary>
        public static string WithUnderlineTag(this string self) {
            return $"<u>{self}</u>";
        }

        /// <summary>
        /// ���������^�O��}������
        /// </summary>
        public static string WithStrikethroughTag(this string self) {
            return $"<s>{self}</s>";
        }

        /// <summary>
        /// �T�C�Y�^�O��}������
        /// </summary>
        public static string WithSizeTag(this string self, int size) {
            return $"<size={size}>{self}</size>";
        }

        /// <summary>
        /// �C���f���g�^�O��}������
        /// </summary>
        public static string WithIndentTag(this string self, int charNum = 1) {
            return $"<indent={Mathf.Clamp(charNum, 1, 20)}em>{self}</indent>";
        }
    }
}