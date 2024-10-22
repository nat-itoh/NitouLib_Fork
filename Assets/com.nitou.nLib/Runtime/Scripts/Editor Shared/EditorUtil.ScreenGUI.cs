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
        /// �X�N���[�����W�w���GameWindow���GUI��`�悷�邽�߂�Util�N���X
        /// </summary>
        public static class ScreenGUI {

            private static readonly Texture2D _lineTexture;

            static ScreenGUI() {
                _lineTexture = new Texture2D(1, 1);
            }


            /// ----------------------------------------------------------------------------
            #region Basic Method

            /// <summary>
            /// 
            /// </summary>
            public static void Box(Rect screenRect) {
                UnityEngine.GUI.Box(Convetor.ScreenToGUI(screenRect), "");
            }

            /// <summary>
            /// �⏕����\������
            /// </summary>
            public static void AuxiliaryLine(Vector2 position, float width, Color color) {

                // Rect
                var horizontalRect = new Rect(0f, position.y, position.x, width);
                var verticalRect = new Rect(position.x, 0f, width, position.y);

                using (new EditorUtil.GUIColorScope(color)) {
                    UnityEngine.GUI.DrawTexture(Convetor.ScreenToGUI(horizontalRect), _lineTexture);
                    UnityEngine.GUI.DrawTexture(Convetor.ScreenToGUI(verticalRect), _lineTexture);
                }
            }

            #endregion


            /// ----------------------------------------------------------------------------
            #region Label

            /// <summary>
            /// GUI.Label()�̃��b�v���\�b�h
            /// </summary>
            public static void Label(Vector2 screenPos, string text = "", 
                int fontSize = 20, TextAnchor alignment = TextAnchor.LowerLeft, Color? color = null) {

                Style.label.fontSize = fontSize;
                Style.label.alignment = alignment;
                Style.label.normal.textColor = color ?? Colors.White;
                
                // �`��͈�
                var size = Style.label.CalcSize(new GUIContent(text));
                var rect = new Rect(screenPos - size, size *2f);

                // �f�o�b�O
                //UnityEngine.GUI.Box(Convetor.ScreenToGUI(rect), "");

                // ���x���`��
                UnityEngine.GUI.Label(Convetor.ScreenToGUI(rect), text, Style.label);
            }


            //public struct FontSize

            #endregion


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

                // �L���b�V��
                public readonly static GUIStyle borderLine;
                public readonly static GUIStyle label;
                public readonly static GUIStyle box;


                static Style() {

                    // �⏕��
                    borderLine = new GUIStyle(UnityEngine.GUI.skin.box);
                    borderLine.normal.background = Texture2D.blackTexture;
                    borderLine.normal.textColor = Color.clear;      // ���w�i�𓧖��ɂ���

                    // ���x��
                    label = new GUIStyle(UnityEngine.GUI.skin.label) { 
                        alignment = TextAnchor.LowerCenter,
                        fontSize = 10                        
                    };

                    // �{�b�N�X
                    box = new GUIStyle(UnityEngine.GUI.skin.box);
                    box.normal.background = Texture2D.grayTexture;
                }




            }
        }

    }
}
#endif