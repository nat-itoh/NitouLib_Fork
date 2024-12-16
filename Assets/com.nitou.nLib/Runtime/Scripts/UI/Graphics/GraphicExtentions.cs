using UnityEngine;
using UnityEngine.UI;

namespace nitou{

    /// <summary>
    /// <see cref="Graphic"/>�^�̊�{�I�Ȋg�����\�b�h�W�D
    /// </summary>
    public static partial class GraphicExtentions{

        /// ----------------------------------------------------------------------------
        #region �J���[�ݒ�

        /// <summary>
        /// �J���[�l(0~1)��ݒ肷��g�����\�b�h�D
        /// </summary>
        public static void SetColor(this Graphic graphic, float r, float g, float b, float a) {
            graphic.color = new Color(r, g, b, a);
        }

        /// <summary>
        /// �J���[�l(0~255)��ݒ肷��g�����\�b�h�D
        /// </summary>
        public static void SetColor32(this Graphic graphic, byte r, byte g, byte b, byte a) {
            graphic.color = new Color32(r, g, b, a);
        }

        /// <summary>
        /// RGB�l��ݒ肷��g�����\�b�h�D
        /// </summary>
        public static void SetRGB(this Graphic graphic, float r, float g, float b) {
            var color = graphic.color;
            color.r = r;
            color.g = g;
            color.b = b;
            graphic.color = color;
        }

        /// <summary>
        /// R�l��ݒ肷��g�����\�b�h�D
        /// </summary>
        public static void SetR(this Graphic graphic, float r) {
            var color = graphic.color;
            color.r = r;
            graphic.color = color;
        }

        /// <summary>
        /// G�l��ݒ肷��g�����\�b�h�D
        /// </summary>
        public static void SetG(this Graphic graphic, float g) {
            var color = graphic.color;
            color.g = g;
            graphic.color = color;
        }

        /// <summary>
        /// B�l��ݒ肷��g�����\�b�h�D
        /// </summary>
        public static void SetB(this Graphic graphic, float b) {
            var color = graphic.color;
            color.b = b;
            graphic.color = color;
        }

        /// <summary>
        /// ���l��ݒ肷��g�����\�b�h�D
        /// </summary>
        public static void SetAlpha(this Graphic graphic, float alpha) {
            var color = graphic.color;
            color.a = alpha;
            graphic.color = color;
        }
        #endregion

    }
}
