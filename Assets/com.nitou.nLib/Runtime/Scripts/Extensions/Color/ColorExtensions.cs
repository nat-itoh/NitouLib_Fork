using UnityEngine;
using UnityEngine.UI;

// [�Q�l]
//  �Q�[��UI�l�b�g : DOTween�ō쐬�������[�V����17���܂ރv���W�F�N�g�����J https://game-ui.net/?p=975
//  �R�K�l�u���O: Color �̑�����ȗ������� Deconstruction https://baba-s.hatenablog.com/entry/2019/09/03/230300
//  _: Image�̐F���ꂼ��ύX����g�� https://hi-network.sakura.ne.jp/wp/2021/01/26/post-3660/


namespace nitou {

    /// <summary>
    /// <see cref="Color"/>�^�̊�{�I�Ȋg�����\�b�h�W�D
    /// </summary>
    public static partial class ColorExtensions {

        /// <summary>
        /// �f�R���X�g���N�^�D
        /// </summary>
        public static void Deconstruct(this Color self, out float r, out float g, out float b) {
            r = self.r;
            g = self.g;
            b = self.b;
        }

        /// <summary>
        /// �f�R���X�g���N�^�D
        /// </summary>
        public static void Deconstruct(this Color self, out float r, out float g, out float b, out float a) {
            r = self.r;
            g = self.g;
            b = self.b;
            a = self.a;
        }


        /// ----------------------------------------------------------------------------

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

        /// <summary>
        /// �J���[��ϊ�����g�����\�b�h
        /// </summary>
        public static string ToHtmlStringRGB(this Color color) {
            return $"#{ColorUtility.ToHtmlStringRGB(color)}";
        }

        /// <summary>
        /// �J���[��ϊ�����g�����\�b�h
        /// </summary>
        public static string ToHtmlStringRGBA(this Color color) {
            return $"#{ColorUtility.ToHtmlStringRGBA(color)}";
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