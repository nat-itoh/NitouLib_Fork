using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

// [�Q�l]
//  Hatena: �ŏ��ƍő�̒l���Ǘ�����\���̂���肽���� https://www.urablog.xyz/entry/2017/06/14/094730

namespace nitou {

    /// <summary>
    /// �͈͂�<see cref="float"/>�^�ŕ\���\����
    /// </summary>
    [System.Serializable]
    public struct RangeFloat : IRangeValue<float> {

        [SerializeField] float _min;
        [SerializeField] float _max;

        public float Min {
            get => _min;
            set => _min = Mathf.Min(_max, value);
        }

        public float Max {
            get => _max;
            set => _max = Mathf.Max(_min, value);
        }

        /// <summary>
        /// �����l
        /// </summary>
        public float Mid => _min + (_max - _min) / 2f;

        /// <summary>
        /// �͈͂̒���
        /// </summary>
        public float Length => Mathf.Abs(_max - _min);

        /// <summary>
        /// �͈͓��̃����_���Ȓl
        /// </summary>
        public float Random => _min < _max ? UnityEngine.Random.Range(_min, _max) : _min;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public RangeFloat(float min, float max) {
            _min = min;
            _max = Mathf.Max(min, max);     // ��min����Ƃ���
        }

        /// <summary>
        /// �l���͈͓������ׂ�
        /// </summary>
        public bool Contains(float value) {
            return value.IsInRange(_min, _max);
        }

        /// <summary>
        /// �p�����[�^ t (0~1)�Ő��`��Ԃ����l��Ԃ�
        /// </summary>
        public float Lerp(float t) {
            return Mathf.Lerp(_min, _max, t);
        }

        /// <summary>
        /// �p�����[�^ t �Ő��`��Ԃ����l��Ԃ�
        /// </summary>
        public float LerpUnclamped(float t) {
            return Mathf.LerpUnclamped(_min, _max, t);
        }

        /// <summary>
        /// �p�����[�^t���擾����
        /// </summary>
        public float InverseLerp(float value) {
            return Mathf.InverseLerp(_min, _max, value);
        }

        /// <summary>
        /// �l��͈͓��ɐ�������
        /// </summary>
        public float Clamp(float value) {
            return Mathf.Clamp(value, _min, _max);
        }


        /// ----------------------------------------------------------------------------
        // Static Method

        /// <summary>
        /// ���͈̔͂̒l�����݂͈̔͂Ƀ��}�b�v���܂��B
        /// </summary>
        public static float Remap(float value, RangeFloat from, RangeFloat to) {
            float t = from.InverseLerp(value);
            return to.Lerp(t);
        }
    }


    public static partial class FloatExtensions {

        /// <summary>
        /// �l��͈͓��ɐ�������g�����\�b�h
        /// </summary>
        public static float Clamp(this float value, RangeFloat range) {
            return range.Clamp(value);
        }

        /// <summary>
        /// �l���͈͓��ɂ��邩�ǂ����𔻒肷��g�����\�b�h
        /// </summary>
        public static bool IsInRange(this float value, RangeFloat range) {
            return range.Contains(value);
        }
    }



#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(RangeFloat))]
    public class RangeFloatEditor : RangeValueEditor {

        protected override void ValidateValue(SerializedProperty minProperty, SerializedProperty maxProperty) {
            // ���������l����ɂ��āA�傫�����l�����������l��菬�����Ȃ�Ȃ��悤�ɂ��Ă݂悤�B
            if (maxProperty.floatValue < minProperty.floatValue) {
                minProperty.floatValue = maxProperty.floatValue;
            }
        }

    }
#endif
}
