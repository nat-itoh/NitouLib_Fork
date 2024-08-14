#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

namespace nitou.EditorScripts.Drawers {
    using nitou.Inspector;

    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public sealed class ReadOnlyDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }

    [CustomPropertyDrawer(typeof(IndentAttribute))]
    public class IndentDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var indentAttribute = (IndentAttribute)attribute;
            EditorGUI.indentLevel += indentAttribute.indent;
            EditorGUI.PropertyField(position, property, label, true);
            EditorGUI.indentLevel -= indentAttribute.indent;
        }
    }

    [CustomPropertyDrawer(typeof(LabelTextAttribute))]
    public class LabelTextDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var labelTextAttribute = (LabelTextAttribute)attribute;
            EditorGUI.PropertyField(position, property, new GUIContent(labelTextAttribute.Text), true);
        }
    }

    [CustomPropertyDrawer(typeof(TitleAttribute))]
    public class TitleDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            TitleAttribute titleAttribute = (TitleAttribute)attribute;

            // �^�C�g���̍���
            Rect titlePosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(titlePosition, titleAttribute.TitleText, EditorStyles.boldLabel);

            // ������`��
            Rect linePosition = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, 1);
            EditorGUI.DrawRect(linePosition, Color.gray);

            // ���̃t�B�[���h��`�悷��ʒu�𒲐�
            Rect propertyPosition = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 3, position.width, position.height);
            EditorGUI.PropertyField(propertyPosition, property, label, true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            // �^�C�g���A�����A�v���p�e�B�̃X�y�[�X���l�����č������v�Z
            return EditorGUIUtility.singleLineHeight + 4 + base.GetPropertyHeight(property, label);
        }
    }
}
#endif