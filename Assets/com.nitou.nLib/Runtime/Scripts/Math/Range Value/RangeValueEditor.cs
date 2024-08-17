#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace nitou {
    public abstract class RangeValueEditor : PropertyDrawer {

        protected static readonly GUIContent _minLabel = new ("min");
        protected static readonly GUIContent _maxLabel = new ("max");


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

            // �l�̎擾
            var minProperty = property.FindPropertyRelative("_min");
            var maxProperty = property.FindPropertyRelative("_max");
            ValidateValue(minProperty, maxProperty);

            label = EditorGUI.BeginProperty(position, label, property);

            // �v���p�e�B�̖��O������\��
            Rect contentPosition = EditorGUI.PrefixLabel(position, label);

            // Min��Max��2�̃v���p�e�B��\������̂ŁA�c��̃t�B�[���h�𔼕����B
            contentPosition.width /= 2.0f;

            EditorGUIUtility.labelWidth = 45f;
            EditorGUI.PropertyField(contentPosition, minProperty);

            contentPosition.x += contentPosition.width;
            EditorGUI.PropertyField(contentPosition, maxProperty);

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return EditorGUIUtility.singleLineHeight;
        }

        protected abstract void ValidateValue(SerializedProperty minProperty, SerializedProperty maxProperty);
    }
}
#endif