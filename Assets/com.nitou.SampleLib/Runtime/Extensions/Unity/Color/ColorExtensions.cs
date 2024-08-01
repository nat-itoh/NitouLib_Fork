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

        /// ----------------------------------------------------------------------------
        #region SpriteRenderer

        /// <summary>
        /// ���l��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetAlpha(this SpriteRenderer spriteRenderer, float alpha) {
            var color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
        #endregion
               


        /// ----------------------------------------------------------------------------
        #region Misc

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