using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace nitou{

    /// <summary>
    /// �͈͂�<see cref="int"/>�^�ŕ\���\����
    /// </summary>
    public class RangeInt : IRangeValue<int>{

        [SerializeField] int _min;
        [SerializeField] int _max;

        public int Min {
            get => _min;
            set => _min = Mathf.Min(_min, value);
        }

        public int Max {
            get => _max;
            set => _max = Mathf.Max(_max, value);
        }

        /// <summary>
        /// �����l
        /// </summary>
        public int Mid => _min + (_max - _min) / 2;

        /// <summary>
        /// �͈͂̒���
        /// </summary>
        public int Length => Mathf.Abs(_max - _min);

        /// <summary>
        /// �͈͓��̃����_���Ȓl
        /// </summary>
        public int Random => _min < _max ? UnityEngine.Random.Range(_min, _max+1) : _min;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public RangeInt(int min, int max) {
            _min = min;
            _max = Mathf.Max(min, max);
        }

        /// <summary>
        /// �l���͈͓������ׂ�
        /// </summary>
        public bool Contains(int value) {
            return value.IsInRange(_min, _max);
        }

        public float Clamp(int value) {
            return Mathf.Clamp(value, _min, _max);
        }

    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(RangeInt))]
    public class RangeIntEditor : RangeValueEditor {

        protected override void ValidateValue(SerializedProperty minProperty, SerializedProperty maxProperty) {
            // ���������l����ɂ��āA�傫�����l�����������l��菬�����Ȃ�Ȃ��悤�ɂ��Ă݂悤�B
            if (maxProperty.floatValue < minProperty.floatValue) {
                minProperty.floatValue = maxProperty.floatValue;
            }
        }

    }
#endif

}
