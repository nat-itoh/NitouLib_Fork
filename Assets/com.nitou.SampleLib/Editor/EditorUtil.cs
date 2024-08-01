#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// [�Q�l]
//  zenn: Unity�ŃR�[�h����GUI����� https://zenn.dev/kumas/books/325ed71592f6f5/viewer/0f1174
//  hatena: Editor�g���Ŏg����UI�@�\�̊T�v (GUI / GUILayout / EditorGUI / EditorGUILayout) https://yotiky.hatenablog.com/entry/unity_editorextension-guisummary
//  LIGHT11: �G�f�B�^�g���`�[�g�V�[�g https://light11.hatenadiary.com/entry/2018/07/08/134405
//  qiita: �G�f�B�^�g���Ŏd�؂����`�� https://qiita.com/Gok/items/96e8747269bf4a2a9cc5

namespace nitou.EditorShared {
    public static partial class EditorUtil {

        /// <summary>
        /// 
        /// </summary>
        public static partial class GUI {
                    
            /// ----------------------------------------------------------------------------
            #region  Url

            public static void UrlLabel(string displayText, string url) {

                GUILayout.Label(displayText, EditorStyles.linkLabel);
                Rect rect = GUILayoutUtility.GetLastRect();

                EditorGUIUtility.AddCursorRect(rect, MouseCursor.Link);
                var nowEvent = Event.current;
                if (nowEvent.type == EventType.MouseDown && rect.Contains(nowEvent.mousePosition)) {
                    Help.BrowseURL(url);
                }
            }
            #endregion


            


            /// <summary>
            /// ��Ԃ̃I���I�t�؂�ւ�
            /// </summary>
            static public bool DrawHeader(string text, string key, bool forceOn) {
                bool state = EditorPrefs.GetBool(key, true);

                GUILayout.Space(3f);
                if (!forceOn && !state) UnityEngine.GUI.backgroundColor = new Color(0.8f, 0.8f, 0.8f);
                GUILayout.BeginHorizontal();
                GUILayout.Space(3f);

                UnityEngine.GUI.changed = false;

                if (!GUILayout.Toggle(true, "<b><size=11>" + text + "</size></b>", "dragtab", GUILayout.MinWidth(20f))) state = !state;
                if (UnityEngine.GUI.changed) EditorPrefs.SetBool(key, state);

                GUILayout.Space(2f);
                GUILayout.EndHorizontal();
                UnityEngine.GUI.backgroundColor = Color.white;
                if (!forceOn && !state) GUILayout.Space(3f);
                return state;
            }
        }



        public static void Test(string path, string ext) {

            if (path.IsNullOrEmpty() || System.IO.Path.GetExtension(path) != "." + ext) {

                // ��������ۑ��p�X���Ȃ��Ƃ��̓V�[���̃f�B���N�g�����Ƃ��Ă����肷��i�p�r����j
                if (string.IsNullOrEmpty(path)) {
                    path = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene().path;
                    if (!string.IsNullOrEmpty(path)) {
                        path = System.IO.Path.GetDirectoryName(path);
                    }
                }
                if (string.IsNullOrEmpty(path)) {
                    path = "Assets";
                }
            }

        }

    }
}
#endif