using UnityEngine;
using UnityEngine.UI;

// [�Q�l]
//  �Q�[��UI�l�b�g : DOTween�ō쐬�������[�V����17���܂ރv���W�F�N�g�����J https://game-ui.net/?p=975
//  _: Image�̐F���ꂼ��ύX����g�� https://hi-network.sakura.ne.jp/wp/2021/01/26/post-3660/

namespace nitou {

    /// <summary>
    /// <see cref="Color"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static partial class ColorExtensions {

        /// <summary>
        /// 
        /// </summary>
        public static Color WithRed(this Color color, float red) {
            return new Color(red, color.g, color.b, color.a);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Color WithGreen(this Color color, float green) {
            return new Color(color.r, green, color.b, color.a);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Color WithBlue(this Color color, float blue) {
            return new Color(color.r, color.g, blue, color.a);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Color WithAlpha(this Color color, float alpha) {
            return new Color(color.r, color.g, color.b, alpha);
        }


        /// ----------------------------------------------------------------------------
        #region Misc

        /// <summary>
        /// ���l��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetAlpha(this SpriteRenderer spriteRenderer, float alpha) {
            var color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }

        /// <summary>
        /// ���l��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetAlphasInChildren(this GameObject obj, float alpha) {
            var spriteRenderers = obj.GetComponentsInChildren<SpriteRenderer>();
            var graphics = obj.GetComponentsInChildren<Graphic>();

            if (spriteRenderers != null) {
                foreach (var spriteRenderer in spriteRenderers) {
                    spriteRenderer.SetAlpha(alpha);
                }
            }

            if (graphics != null) {
                foreach (var graphic in graphics) {
                    graphic.SetAlpha(alpha);
                }
            }
        }
        #endregion
    }
}