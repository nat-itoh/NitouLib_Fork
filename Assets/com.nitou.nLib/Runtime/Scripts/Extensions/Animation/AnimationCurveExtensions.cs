using UnityEngine;

namespace nitou {

    /// <summary>
    /// <see cref="AnimationCurve"/>�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class AnimationCurveExtensions {

        /// ----------------------------------------------------------------------------
        #region Clamp

        /// <summary>
        /// �l�i�c���j�͈̔͂𐧌�����g�����\�b�h
        /// </summary>
        public static AnimationCurve ClampValue(this AnimationCurve curve, RangeFloat valueRange) {
            var keys = curve.keys;
            if (keys.Length <= 0) return curve;

            // �l�̏C��
            for (int i = 0; i < keys.Length; i++) {
                keys[i].value = valueRange.Clamp(keys[i].value);
            }

            curve.keys = keys;
            return curve;
        }

        /// <summary>
        /// �l�i�c���j�͈̔͂𐧌�����g�����\�b�h
        /// </summary>
        public static AnimationCurve ClampValue01(this AnimationCurve curve) {
            var keys = curve.keys;
            if (keys.Length <= 0) return curve;

            // �l�̏C��
            for (int i = 0; i < keys.Length; i++) {
                keys[i].value = Mathf.Clamp01(keys[i].value);
            }

            curve.keys = keys;
            return curve;
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region Normalize

        // [�Q�l]
        //  LIGHT11: ���K�����ꂽAnimationCurve�̓��̓t�B�[���h��\������ https://light11.hatenadiary.com/entry/2019/10/08/012902

        /// <summary>
        /// ���ԁi�����j�𐳋K������g�����\�b�h
        /// </summary>
        public static AnimationCurve NormalizeTime(this AnimationCurve curve) {
            var keys = curve.keys;
            if (keys.Length <= 0) return curve;

            var (minTime, maxTime) = keys.MinMax(selector: x => x.time);

            var range = maxTime - minTime;
            var timeScale = (range < 0.0001f) ? 1 : 1 / range;

            // �l�̏C��
            for (var i = 0; i < keys.Length; ++i) {
                keys[i].time = (keys[i].time - minTime) * timeScale;
            }

            curve.keys = keys;
            return curve;
        }

        /// <summary>
        /// �l�i�c���j�𐳋K������g�����\�b�h
        /// </summary>
        public static AnimationCurve NormalizeValue(this AnimationCurve curve) {
            var keys = curve.keys;
            if (keys.Length <= 0) return curve;

            var (minValue, maxValue) = keys.MinMax(selector: x => x.value);

            var range = maxValue - minValue;
            var valScale = range < 1 ? 1 : 1 / range;
            var valOffset = 0f;
            if (range < 1f) {
                if (minValue > 0f && minValue + range <= 1f) {
                    valOffset = minValue;
                } else {
                    valOffset = 1f - range;
                }
            }

            // �l�̏C��
            for (var i = 0; i < keys.Length; ++i) {
                keys[i].value = (keys[i].value - minValue) * valScale + valOffset;
            }

            curve.keys = keys;
            return curve;
        }
        #endregion
    }


    // [TODO] �������v���Z�b�g�I�ȃ��\�b�h�𐮔����� (2024.08.01)
    public static class AnimationCurveUtil { }
}
