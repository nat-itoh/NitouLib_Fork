#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// [�Q�l]
//  hatena: EditorWindow �� GUIStyle ���g���ۂ̒��� https://hacchi-man.hatenablog.com/entry/2020/03/17/220000
//  hatena: �F�ʂ� GUIStyle ���L���b�V������N���X https://hacchi-man.hatenablog.com/entry/2020/08/16/220000

namespace nitou.EditorShared {
    public static partial class EditorUtil {
        public static partial class Styles {

            public static GUIStyle folderHeader;


            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            static Styles(){
                
                folderHeader = new GUIStyle("ShurikenModuleTitle") {
                    font = new GUIStyle(EditorStyles.label).font,
                    fontSize = 12,
                    border = new RectOffset(15, 7, 4, 4),
                    fixedHeight = 22,
                    contentOffset = new Vector2(20f, -2f),
                };


            }

            public static GUIStyle XmlText() {
                return new GUIStyle(EditorStyles.label) {
                    alignment = TextAnchor.UpperLeft,
                    richText = true,
                };
            }




        }

    }
}

#endif