#if UNITY_EDITOR
using System.Reflection;
using UnityEngine;
using UnityEditor;

namespace nitou.EditorScripts.Drawers {
    using nitou.Inspector;

    /// ----------------------------------------------------------------------------
    #region d

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
            EditorGUI.indentLevel += indentAttribute.IndentLevel;
            EditorGUI.PropertyField(position, property, label, true);
            EditorGUI.indentLevel -= indentAttribute.IndentLevel;
        }
    }

    #endregion


    /// ----------------------------------------------------------------------------
    #region Condition

    [CustomPropertyDrawer(typeof(DisableInPlayModeAttribute))]
    public class DisableInPlayModeDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            GUI.enabled = !Application.isPlaying;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }

    [CustomPropertyDrawer(typeof(HideInPlayModeAttribute))]
    public class HideInPlayModeDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            if (!Application.isPlaying) {
                EditorGUI.PropertyField(position, property, label, true);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            if (!Application.isPlaying) {
                return EditorGUI.GetPropertyHeight(property, label, true);
            }
            return 0; // Hide the property by setting height to 0
        }
    }

    #endregion


    /// ----------------------------------------------------------------------------
	#region Title label

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
    #endregion


}
#endif