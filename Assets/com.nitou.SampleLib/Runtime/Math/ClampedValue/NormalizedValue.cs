using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace nitou {

    /// <summary>
    /// ���K�����ꂽ�l�i�l��O�`�P�j���������߂̍\����
    /// </summary>
    [System.Serializable]
    public struct NormalizedValue {

        private float _value;

        public float Value {
            get => _value;
            set => _value = Mathf.Clamp01(value);
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public NormalizedValue(float value) {
            _value = Mathf.Clamp01(value);
        }

        public static implicit operator float(NormalizedValue normalizedValue) {
            return normalizedValue.Value;
        }

        public static implicit operator NormalizedValue(float value) {
            return new NormalizedValue(value);
        }

        public override string ToString() {
            return _value.ToString();
        }
    }
}


/// ----------------------------------------------------------------------------
#if UNITY_EDITOR
namespace nitou.EditorScripts {

    [CustomPropertyDrawer(typeof(NormalizedValue))]
    public class NormalizedFloatPropertyDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

            using (new EditorGUI.PropertyScope(position, label, property)) {
                // Find the value property
                SerializedProperty valueProperty = property.FindPropertyRelative("_value");

                // Draw a float slider
                float newValue = EditorGUI.Slider(position, label, valueProperty.floatValue, 0f, 1f);
                valueProperty.floatValue = Mathf.Clamp01(newValue);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return EditorGUIUtility.singleLineHeight;
        }
    }
}
#endif