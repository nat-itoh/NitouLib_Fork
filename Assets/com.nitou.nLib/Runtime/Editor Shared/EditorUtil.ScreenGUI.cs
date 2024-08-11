#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// [�Q�l]
//  hatena: Editor�g���Ŏg����UI�@�\�̊T�v (GUI / GUILayout / EditorGUI / EditorGUILayout) https://yotiky.hatenablog.com/entry/unity_editorextension-guisummary
//  zenn: Unity�ŃR�[�h����GUI����� https://zenn.dev/kumas/books/325ed71592f6f5/viewer/0f1174
//  LIGHT11: �G�f�B�^�g���`�[�g�V�[�g https://light11.hatenadiary.com/entry/2018/07/08/134405
//  qiita: �G�f�B�^�g���Ŏd�؂����`�� https://qiita.com/Gok/items/96e8747269bf4a2a9cc5

namespace nitou.EditorShared {
    public static partial class EditorUtil {

        /// <summary>
        /// 
        /// </summary>
        public static class ScreenGUI {

            private static readonly Texture2D lineTexture;

            static ScreenGUI() {
                lineTexture = new Texture2D(1, 1);
            }

            /// <summary>
            /// 
            /// </summary>
            public static void Box(Rect screenRect, string text = "") {
                UnityEngine.GUI.Box(Convetor.ScreenToGUI(screenRect), text);
            }

            /// <summary>
            /// �⏕����\������
            /// </summary>
            public static void AuxiliaryLine(Vector2 position) {

                float width = 2f;

                //var horizontalRect = Rect.MinMaxRect(0f, position.y, position.x, position.y);
                var horizontalRect = new Rect(0f, position.y, position.x, width);
                var verticalRect = new Rect(position.x, 0f, width, position.y);

                using (new EditorUtil.GUIColorScope(Colors.Gray)) {
                    UnityEngine.GUI.DrawTexture(Convetor.ScreenToGUI(horizontalRect), lineTexture);
                    UnityEngine.GUI.DrawTexture(Convetor.ScreenToGUI(verticalRect), lineTexture);
                }
                //UnityEngine.GUI.DrawTexture(new Rect(position.x, 0f, 1f, position.y), lineTexture);

                //UnityEngine.GUI.Box(Convetor.ScreenToGUI(horizontalRect),"");
                //UnityEngine.GUI.Box(Convetor.ScreenToGUI(verticalRect),"");
            }


            /// ----------------------------------------------------------------------------
            private static class Convetor {

                public static Rect ScreenToGUI(Rect screenRect) {
                    // Screen���W�n
                    var screenPos = screenRect.position;

                    // GUI���W�n
                    var guiPos = new Vector2(screenPos.x, Screen.height - screenPos.y);
                    var guiRect = new Rect(guiPos + (Vector2.down * screenRect.height), screenRect.size);

                    return guiRect;
                }

                public static Vector2 ScreenToGUI(Vector2 screenPos) {
                    return new Vector2(screenPos.x, Screen.height - screenPos.y);
                }
            }


            /// ----------------------------------------------------------------------------
            private static class Style {

                public readonly static GUIStyle borderLine;
                static Style() {
                    borderLine = new GUIStyle(UnityEngine.GUI.skin.box);

                    // �w�i�𓧖��ɂ���
                    borderLine.normal.background = Texture2D.blackTexture;
                    borderLine.normal.textColor = Color.clear;
                }

            }
        }



    }
}
#endif