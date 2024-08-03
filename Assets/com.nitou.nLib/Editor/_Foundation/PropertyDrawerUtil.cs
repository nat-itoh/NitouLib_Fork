# if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// [�Q�l]
//  LIGHT11: PropertyDrawer�Ńf�t�H���g��GUI��`�悷�� https://light11.hatenadiary.com/entry/2019/05/13/215814

namespace nitou.EditorShared {

    /// <summary>
    /// <see cref="PropertyDrawer"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class PropertyDrawerUtil {

        /// <summary>
        /// �f�t�H���g��GUI��\������
        /// </summary>
        public static void DrawDefaultGUI(Rect position, SerializedProperty property, GUIContent label) {

            property = property.serializedObject.FindProperty(property.propertyPath);   // ��������Ă�H

            var fieldRect = position;
            fieldRect.height = EditorGUIUtility.singleLineHeight;

            using (new EditorGUI.PropertyScope(fieldRect, label, property)) {


                // [TODO] ����



            }

        }


        public static float GetDefaultPropertyHeight() {


            // [TODO] ����

            return 0f;
        }

    }
}
#endif