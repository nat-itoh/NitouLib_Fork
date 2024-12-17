using System;
using UnityEngine;
using UnityEditor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;

// [REF]
//  youtube: Data Manager - Scriptable Object Editor Window https://www.youtube.com/watch?v=1zu41Ku46xU&t=23s

namespace nitou.DataManagement {

    /// <summary>
    /// 
    /// </summary>
    public static class GUIUtils {

        /// <summary>
        /// �I���{�^���̃��X�g
        /// </summary>
        public static bool SelectButonList(ref Type selectedType, Type[] typesToDisplay) {

            var rect = GUILayoutUtility.GetRect(0, 25);

            for (int i = 0; i < typesToDisplay.Length; i++) {
                var name = typesToDisplay[i].Name;
                var buttonRect = rect.Split(i, typesToDisplay.Length);

                //
                if (GUIUtils.SelectButton(buttonRect, name, typesToDisplay[i] == selectedType)) {
                    selectedType = typesToDisplay[i];
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// �I���{�^��
        /// </summary>
        public static bool SelectButton(Rect rect, string name, bool selected) {

            // �{�^���������ꂽ��"true"��Ԃ�
            if (GUI.Button(rect, GUIContent.none, GUIStyle.none)) return true;

            // �{�^���\���̍Ē���
            if (Event.current.type == EventType.Repaint) {
                var style = new GUIStyle(EditorStyles.miniButtonMid);
                style.stretchHeight = true;
                style.fixedHeight = rect.height;
                style.Draw(rect, GUIHelper.TempContent(name), false, false, selected, false);
            }

            return true;
        }

    }

}