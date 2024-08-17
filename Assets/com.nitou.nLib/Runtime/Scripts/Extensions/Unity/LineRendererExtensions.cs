using System.Collections.Generic;

// [�Q�l]
//  �˂������V�e�B: Line Renderer�Ŕj����`�悷�� https://nekojara.city/unity-dashed-line

namespace UnityEngine {

    /// <summary>
    /// <see cref="LineRenderer"/>�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class LineRendererExtensions {

        /// <summary>
        /// startColor, endColor���ꊇ�Őݒ肷��g�����\�b�h
        /// </summary>
        public static void SetColor(this LineRenderer self, Color color) {
            self.startColor = color;
            self.endColor = color;
        }

        /// <summary>
        /// <see cref="LineRenderer.widthCurve"/>�Ɉ�蕝��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetConstantWidth(this LineRenderer self, float width) {
            self.widthCurve = AnimationCurve.Constant(0, 1, width);
        }


        /// ----------------------------------------------------------------------------
        // ����

        public static float CaluculateLegth(this LineRenderer self) {
            var totalLegth = 0f;

            for (var i = 0; i < self.positionCount - 1; i++) {
                totalLegth += Vector3.Distance(
                    self.GetPosition(i),
                    self.GetPosition(i + 1));
            }

            // �����[�v����ꍇ�́C�ŏ��ƍŌ�̒��_�̋��������Z����
            if (self.loop) {
                totalLegth += Vector3.Distance(
                    self.GetPosition(0),
                    self.GetPosition(self.positionCount - 1));
            }

            return totalLegth;
        }

    }
}
