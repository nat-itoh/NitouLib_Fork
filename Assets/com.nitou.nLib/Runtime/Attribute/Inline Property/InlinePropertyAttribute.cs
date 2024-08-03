using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using nitou.EditorShared;
#endif

// [�Q�l]
//  _: InlinePropertyAttribute class  https://odininspector.com/documentation/sirenix.odininspector.inlinepropertyattribute

namespace nitou {

    [AttributeUsage(
        AttributeTargets.Field, 
        Inherited = true, 
        AllowMultiple = false)
    ]
    public class InlinePropertyAttribute : PropertyAttribute {
        public InlinePropertyAttribute() { }
    }
}


#if UNITY_EDITOR
namespace nitou.EditorScripts {

    [CustomPropertyDrawer(typeof(InlinePropertyAttribute))]
    public class InlinePropertyDrawer : PropertyDrawer {

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            // �v���p�e�B�̑S�Ẵt�B�[���h�̍������v�Z
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            
            /*
            // �S�̂̍������v�Z
            float totalHeight = position.y;

            // ���x���ƃt�B�[���h�̈ʒu��ݒ�
            Rect fieldPosition = new Rect(position.x, totalHeight, position.width, EditorGUIUtility.singleLineHeight);

            // �v���p�e�B���ċA�I�ɑ���
            SerializedProperty currentProperty = property.Copy();
            SerializedProperty nextSiblingProperty = property.Copy();
            nextSiblingProperty.NextVisible(false); // �ŏ��̎��̌Z��v���p�e�B���擾

            // ���݂̃v���p�e�B�𑖍����A���̃v���p�e�B���Z��v���p�e�B���z����܂ő�����
            bool enterChildren = true;

            using (new EditorUtil.GUIColorScope(Colors.GreenYellow)) {

                while (currentProperty.NextVisible(enterChildren) && !SerializedProperty.EqualContents(currentProperty, nextSiblingProperty)) {
                    EditorGUI.PropertyField(fieldPosition, currentProperty, true);
                    fieldPosition.y += EditorGUI.GetPropertyHeight(currentProperty, true) + EditorGUIUtility.standardVerticalSpacing;
                    enterChildren = false;
                }
            }

            */
        }
    }

}
#endif