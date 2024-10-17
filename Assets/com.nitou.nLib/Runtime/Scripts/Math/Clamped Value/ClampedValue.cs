using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

// [�Q�l]
//  _: �t�B�[���h�̒l�Ȃǂ��C���X�y�N�^�ŉ��ɕ��ׂĕ\������   http://fantom1x.blog130.fc2.com/blog-entry-419.html
//  LIGHT11: Serializable�ȃN���X�ɂ̓f�t�H���g�R���X�g���N�^��Y�ꂸ���悤�Ƃ����b https://light11.hatenadiary.com/entry/2022/12/26/191200

namespace nitou {

    /// <summary>
    /// �ő�A�ŏ��͈̔͂ɐ��������l
    /// </summary>
    [System.Serializable]
    public class ClampedValue{

        [SerializeField] float _min = 0;
        [SerializeField] float _max = 1;
        [SerializeField] float _value;

        public float Min => _min;
        public float Max => _max;

        public float Value {
            get => _value;
            set => _value = Mathf.Clamp(value, _min, _max);
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        private ClampedValue() { }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public ClampedValue(float min, float max, float value = 0) {
            _min = min;
            _max = Mathf.Max(min,max);  // ��min����Ƃ���
            Value = value;
        }

        public static implicit operator float(ClampedValue clampedValue) {
            return clampedValue.Value;
        }

        /// <summary>
        /// ������`���ŃI�u�W�F�N�g�̏�Ԃ�Ԃ�
        /// </summary>
        public override string ToString() {
            return $"(Min: {Min}, Max: {Max}, Value: {Value})";
        }
    }
}


/// ----------------------------------------------------------------------------
#if UNITY_EDITOR
namespace nitou.EditorScripts {

    [CustomPropertyDrawer(typeof(ClampedValue))]
    public class ClampedValueEditor : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

            // Field
            var minProperty = property.FindPropertyRelative("_min");
            var maxProperty = property.FindPropertyRelative("_max");
            var valueProperty = property.FindPropertyRelative("_value");

            ValidateRange(minProperty, maxProperty);

            //    EditorGUI.BeginProperty(position, label, property);
            using (var scope = new EditorGUI.PropertyScope(position, label, property)) {
                //���O
                Rect fieldRect = EditorGUI.PrefixLabel(position, label);

                /*
                //���x��
                fieldRect.width *= 1f / 3f; //3���ׂ�ꍇ (n �̂Ƃ��A1 / n)
                EditorGUI.indentLevel = 0;
                EditorGUIUtility.labelWidth = 30f;  //���x����(�K��)

                //�e�v�f
                //EditorGUI.PropertyField(fieldRect, minProperty, minContent);
                GUI.Label(fieldRect, $"min: {minProperty.floatValue}");

                fieldRect.x += fieldRect.width;
                */
                valueProperty.floatValue = EditorGUI.Slider(fieldRect, valueProperty.floatValue, minProperty.floatValue, maxProperty.floatValue);
                //EditorGUI.PropertyField(fieldRect, valueProperty);
                //valueProperty.floatValue = Mathf.Clamp(newValue, minProperty.floatValue, maxProperty.floatValue);

                /*

                fieldRect.x += fieldRect.width;
                //EditorGUI.PropertyField(fieldRect, maxProperty, maxContent);
                GUI.Label(fieldRect, $"max: {maxProperty.floatValue}");
               */
            }


        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return EditorGUIUtility.singleLineHeight;
        }

        private void ValidateRange(SerializedProperty minProperty,SerializedProperty maxProperty) {

            maxProperty.floatValue = Mathf.Max(minProperty.floatValue, maxProperty.floatValue);
        }
    }
}
#endif
