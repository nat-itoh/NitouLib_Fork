#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

// [�Q�l]
//  _: Unity�̃G�f�B�^�g���� FoldOut ���������悭����̂�����Ă݂� https://tips.hecomi.com/entry/2016/10/15/004144
//  _: �ҏW�s�̃p�����[�^��Inspector�ɕ\������ https://kazupon.org/unity-no-edit-param-view-inspector/
//  Hatena: �C���f���g�t����GUI.Button��\������ https://neptaco.hatenablog.jp/entry/2019/05/18/234426

namespace nitou.EditorShared {
    public static partial class EditorUtil {
        
        
        public static partial class GUI {

            /// ----------------------------------------------------------------------------
            #region Object Field

            /// <summary>
            /// MonoBehaviour�t�@�C���ւ̎Q�Ƃ�\������
            /// </summary>
            public static void MonoBehaviourField<T>(T target) where T : MonoBehaviour {

                using (new EditorGUI.DisabledGroupScope(true)) {
                    EditorGUILayout.ObjectField("Script:", MonoScript.FromMonoBehaviour(target), typeof(T), false);
                }
            }

            /// <summary>
            /// Scriptable Object�t�@�C���ւ̎Q�Ƃ�\������
            /// </summary>
            public static void ScriptableObjectField<T>(T target) where T : ScriptableObject {

                using (new EditorGUI.DisabledGroupScope(true)) {
                    EditorGUILayout.ObjectField("Script:", MonoScript.FromScriptableObject(target), typeof(T), false);
                }
            }

            /// <summary>
            /// PropertyField��ReadOnly�ŕ\������
            /// </summary>
            public static void ReadOnlyPropertyField(SerializedProperty property, params GUILayoutOption[] options) {
                using (new EditorGUI.DisabledScope(true)) {
                    EditorGUILayout.PropertyField(property, options);
                }
            }

            #endregion


            /// ----------------------------------------------------------------------------
            #region Button

            /// <summary>
            /// GUI.Button���C���f���g�t���ŕ\������
            /// </summary>
            public static bool IndentedButton(GUIContent content) {
                var rect = EditorGUI.IndentedRect(EditorGUILayout.GetControlRect());
                return UnityEngine.GUI.Button(rect, content);
            }

            /// <summary>
            /// GUI.Button���C���f���g�t���ŕ\������
            /// </summary>
            public static bool IndentedButton(string content) =>
                IndentedButton(new GUIContent(content));

            #endregion


            /// ----------------------------------------------------------------------------
            #region Decoration

            /// <summary>
            /// �d�؂����\������
            /// </summary>
            public static void HorizontalLine(Color color, int thickness = 1, int padding = 10, bool useIndentLevel = false) {

                using (new EditorGUILayout.HorizontalScope()) {
                    var splitterRect = EditorGUILayout.GetControlRect(false, GUILayout.Height(thickness + padding));
                    splitterRect = EditorGUI.IndentedRect(splitterRect);
                    splitterRect.height = thickness;
                    splitterRect.y += padding / 2;

                    EditorGUI.DrawRect(splitterRect, color);
                }
            }

            /// <summary>
            /// �d�؂����\������
            /// </summary>
            public static void HorizontalLine(int thickness = 1, int padding = 10, bool useIndentLevel = false) =>
                HorizontalLine(EditorColors.ButtonBackgroundHover, thickness, padding, useIndentLevel);
            #endregion



            /// ----------------------------------------------------------------------------
            #region Foldout

            // [�Q�l]
            //  _: Unity �̃G�f�B�^�g���� FoldOut ���������悭����̂�����Ă݂� https://tips.hecomi.com/entry/2016/10/15/004144 
            //  github: https://github.com/Unity-Technologies/MissilesPerfectMaster/blob/master/Assets/CinematicEffects/Common/Editor/EditorGUIHelper.cs

            /// <summary>
            /// Foldout�\�ȃw�b�_�[��\������
            /// </summary>
            public static bool FoldoutHeader(string title, bool display) {

                // ParticleSystem�Ŏg�p����Ă���GUI Style
                var style = new GUIStyle("ShurikenModuleTitle") {
                    font = new GUIStyle(EditorStyles.label).font,
                    fontSize = 12,
                    border = new RectOffset(15, 7, 4, 4),
                    fixedHeight = 22,
                    contentOffset = new Vector2(20f, -2f),
                };

                // �̈�̕`��
                var rect = GUILayoutUtility.GetRect(16f, 22f, style);
                UnityEngine.GUI.Box(rect, title, style);

                var e = Event.current;

                // �̕`��
                if (e.type == EventType.Repaint) {
                    var toggleRect = new Rect(rect.x + 4f, rect.y + 2f, 13f, 13f);
                    EditorStyles.foldout.Draw(toggleRect, false, false, display, false);
                }

                // fold��ON/OFF�؂�ւ�
                else if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition)) {
                    display = !display;
                    e.Use();
                }

                return display;
            }

            public static bool Header(SerializedProperty group, SerializedProperty enabledField) {
                var display = group == null || group.isExpanded;
                var enabled = enabledField != null && enabledField.boolValue;
                var title = group == null ? "Unknown Group" : ObjectNames.NicifyVariableName(group.displayName);

                Rect rect = GUILayoutUtility.GetRect(16f, 22f, Styles.folderHeader);
                UnityEngine.GUI.Box(rect, title, Styles.folderHeader);

                Rect toggleRect = new Rect(rect.x + 4f, rect.y + 4f, 13f, 13f);
                if (Event.current.type == EventType.Repaint)
                    Styles.headerCheckbox.Draw(toggleRect, false, false, enabled, false);

                var e = Event.current;

                if (e.type == EventType.MouseDown) {
                    if (toggleRect.Contains(e.mousePosition) && enabledField != null) {
                        enabledField.boolValue = !enabledField.boolValue;
                        e.Use();
                    } else if (rect.Contains(e.mousePosition) && group != null) {
                        display = !display;
                        group.isExpanded = !group.isExpanded;
                        e.Use();
                    }
                }
                return display;
            }

            /// <summary>
            /// 
            /// </summary>
            public class FoldoutGroupScope : UnityEngine.GUI.Scope {

                // �����X�R�[�v�v�f
                private readonly EditorGUILayout.FadeGroupScope _fadeGroup;
                private readonly EditorGUI.IndentLevelScope _indentScope;
                private readonly EditorGUILayout.VerticalScope _verticalScope;

                public bool Visible => _fadeGroup.visible;

                /// <summary>
                /// �R���X�g���N�^
                /// </summary>
                public FoldoutGroupScope(string headerTitle, AnimBool animBool, bool withBackdrop = false) {

                    if (withBackdrop) {
                        _verticalScope = new EditorGUILayout.VerticalScope(UnityEngine.GUI.skin.box);
                    }

                    animBool.target = EditorUtil.GUI.FoldoutHeader(headerTitle, animBool.target);
                    _fadeGroup = new EditorGUILayout.FadeGroupScope(animBool.faded);
                    _indentScope = new EditorGUI.IndentLevelScope();

                }

                /// <summary>
                /// �I������
                /// </summary>
                protected override void CloseScope() {
                    _fadeGroup?.Dispose();
                    _indentScope?.Dispose();
                    _verticalScope?.Dispose();
                }
            }

            #endregion


            /// ----------------------------------------------------------------------------
            #region  Misc

            public static void UrlLabel(string displayText, string url) {

                GUILayout.Label(displayText, EditorStyles.linkLabel);
                Rect rect = GUILayoutUtility.GetLastRect();

                EditorGUIUtility.AddCursorRect(rect, MouseCursor.Link);
                var nowEvent = Event.current;
                if (nowEvent.type == EventType.MouseDown && rect.Contains(nowEvent.mousePosition)) {
                    Help.BrowseURL(url);
                }
            }

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
            #endregion
        }
    }
}
#endif


