using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace nitou {

    /// <summary>
    /// 0�`1�͈̔͂̐��K�����ꂽ�ŏ��l�ƍő�l���������߂̍\���́B
    /// </summary>
    [System.Serializable]
    public struct NormalizedRange {

        [SerializeField, Range(0f, 1f)]
        private float _minValue;

        [SerializeField, Range(0f, 1f)]
        private float _maxValue;

        /// <summary>
        /// �ŏ��l�i0�`1�͈̔́j�B
        /// </summary>
        public float Min {
            get => _minValue;
            set => _minValue = Mathf.Clamp01(value);
        }

        /// <summary>
        /// �ő�l�i0�`1�͈̔́j�B
        /// </summary>
        public float Max {
            get => _maxValue;
            set => _maxValue = Mathf.Clamp01(value);
        }

        /// <summary>
        /// �R���X�g���N�^�B�ŏ��l�ƍő�l��0�`1�͈̔͂ɐ��K�����Đݒ肵�܂��B
        /// </summary>
        public NormalizedRange(float minValue, float maxValue) {
            _minValue = Mathf.Clamp01(minValue);
            _maxValue = Mathf.Clamp01(maxValue);
        }

        /// <summary>
        /// ���̃C���X�^���X�̒l�𕶎���Ƃ��ĕԂ��܂��B
        /// </summary>
        public override string ToString() {
            return $"Min: {_minValue:0.00}, Max: {_maxValue:0.00}";
        }
    }
}

#if UNITY_EDITOR
namespace nitou.EditorScripts {

    [CustomPropertyDrawer(typeof(NormalizedRange))]
    public class NormalizedRangePropertyDrawer : PropertyDrawer {

        /// <summary>
        /// �v���p�e�B��GUI��`�悵�܂��B
        /// </summary>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            // �v���p�e�B�̃X�R�[�v��ݒ�
            using (new EditorGUI.PropertyScope(position, label, property)) {
                // "_minValue"��"_maxValue"�v���p�e�B���擾
                SerializedProperty minValueProperty = property.FindPropertyRelative("_minValue");
                SerializedProperty maxValueProperty = property.FindPropertyRelative("_maxValue");

                if (minValueProperty != null && maxValueProperty != null) {
                    float minValue = minValueProperty.floatValue;
                    float maxValue = maxValueProperty.floatValue;

                    // MinMaxSlider�Œl�����
                    EditorGUI.MinMaxSlider(position, label, ref minValue, ref maxValue, 0f, 1f);

                    // ���͂��ꂽ�l��Clamp���Ĕ��f
                    minValueProperty.floatValue = Mathf.Clamp01(minValue);
                    maxValueProperty.floatValue = Mathf.Clamp01(maxValue);
                } else {
                    EditorGUI.LabelField(position, label.text, "Error: '_minValue' or '_maxValue' not found.");
                }
            }
        }

        /// <summary>
        /// �v���p�e�B�̍������擾���܂��B
        /// </summary>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return EditorGUIUtility.singleLineHeight;
        }
    }
}
#endif
