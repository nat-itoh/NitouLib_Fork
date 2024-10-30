#if UNITY_EDITOR
using System.Reflection;
using UnityEngine;
using UnityEditor;

namespace nitou.EditorScripts.Drawers {
    using nitou.Inspector;



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
        private const int SPACE_HEIGHT = 5;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var titleAttribute = (TitleAttribute)attribute;

            // �^�C�g���̍���
            var titlePosition = position.SetHeight(EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(titlePosition, titleAttribute.TitleText, EditorStyles.boldLabel);

            // ������`��
            Rect linePosition = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, 1);
            EditorGUI.DrawRect(linePosition, Color.gray);

            // ���̃t�B�[���h��`�悷��ʒu�𒲐�
            Rect propertyPosition = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + SPACE_HEIGHT, position.width, position.height);

            // �����ŐV�������x���𐶐����Ďg�p
            GUIContent propertyLabel = new GUIContent(property.displayName);
            EditorGUI.PropertyField(propertyPosition, property, propertyLabel, true);
        }


        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            // �^�C�g���A�����A�v���p�e�B�̃X�y�[�X���l�����č������v�Z
            return EditorGUIUtility.singleLineHeight + SPACE_HEIGHT + base.GetPropertyHeight(property, label);
        }
    }
    #endregion


}
#endif