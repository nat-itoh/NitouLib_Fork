#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// [�Q�l]
//  hatena: EditorWindow �� GUIStyle ���g���ۂ̒��� https://hacchi-man.hatenablog.com/entry/2020/03/17/220000
//  hatena: �F�ʂ� GUIStyle ���L���b�V������N���X https://hacchi-man.hatenablog.com/entry/2020/08/16/220000

namespace nitou.EditorShared {
    public static partial class EditorUtil {
        public static partial class Style {




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