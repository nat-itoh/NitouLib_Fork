#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

// [�Q�l]
//  qiita: Unity�œƎ��̐ݒ��UI��񋟂ł���SettingsProvider�̏Љ�Ɛݒ�t�@�C���̕ۑ��ɂ��� https://qiita.com/sune2/items/a88cdee6e9a86652137c

namespace nitou.Tools.Hierarchy{
    using nitou.Tools.Shared;

    public class HierarchySettingsProvider : SettingsProvider {

        private SerializedObject _settings;

        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public HierarchySettingsProvider(string path, SettingsScope scopes) : base(path, scopes) { }

        /// <summary>
        /// ���̃��\�b�h���d�v�ł�
        /// �Ǝ���SettingsProvider��Ԃ����ƂŁA�ݒ荀�ڂ�ǉ����܂�
        /// </summary>
        [SettingsProvider]
        public static SettingsProvider CreateSettingProvider() {

            // ����O������keywords�́A�������ɂ��̐ݒ荀�ڂ����������邽�߂̃L�[���[�h
            return new HierarchySettingsProvider(ModuleInfo.SettingsMenuPath, SettingsScope.Project) { 
                label = "Hierarchy Settings",
                keywords = new HashSet<string>(new[] { "Nitou, Inspector, Hierarchy" })
            };
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnActivate(string searchContext, VisualElement rootElement) {

            var preferences = HierarchySettingsSO.instance;

            // ��ScriptableSingleton��ҏW�\�ɂ���
            preferences.hideFlags = HideFlags.HideAndDontSave & ~HideFlags.NotEditable;

            _settings = new SerializedObject(preferences);
        }

        /// <summary>
        /// GUI�`��D
        /// </summary>
        public override void OnGUI(string searchContext) {

            using (new EditorGUILayout.HorizontalScope()) {
                GUILayout.Space(10f);
                using (new EditorGUILayout.VerticalScope()) {

                    using (var changeCheck = new EditorGUI.ChangeCheckScope()) {
                        
                        EditorGUILayout.LabelField("Behaviour", EditorStyles.boldLabel);
                        EditorGUILayout.PropertyField(_settings.FindProperty("hierarchyObjectMode"));

                        EditorGUILayout.Space();
                        
                        EditorGUILayout.LabelField("Drawer", EditorStyles.boldLabel);
                        EditorGUILayout.PropertyField(_settings.FindProperty("showHierarchyToggles"), new GUIContent("Show Toggles"));
                        EditorGUILayout.PropertyField(_settings.FindProperty("showComponentIcons"));
                        var showTreeMap = _settings.FindProperty("showTreeMap");
                        EditorGUILayout.PropertyField(showTreeMap);
                        if (showTreeMap.boolValue) {
                            EditorGUI.indentLevel++;
                            EditorGUILayout.PropertyField(_settings.FindProperty("treeMapColor"), new GUIContent("Color"));
                            EditorGUI.indentLevel--;
                        }

                        var showSeparator = _settings.FindProperty("showSeparator");
                        EditorGUILayout.PropertyField(showSeparator, new GUIContent("Show Row Separator"));
                        if (showSeparator.boolValue) {
                            EditorGUI.indentLevel++;
                            EditorGUILayout.PropertyField(_settings.FindProperty("separatorColor"), new GUIContent("Color"));
                            EditorGUI.indentLevel--;
                            var showRowShading = _settings.FindProperty("showRowShading");
                            EditorGUILayout.PropertyField(showRowShading);
                            if (showRowShading.boolValue) {
                                EditorGUI.indentLevel++;
                                EditorGUILayout.PropertyField(_settings.FindProperty("evenRowColor"));
                                EditorGUILayout.PropertyField(_settings.FindProperty("oddRowColor"));
                                EditorGUI.indentLevel--;
                            }
                        }

                        if (changeCheck.changed) {
                            _settings.ApplyModifiedProperties();
                            HierarchySettingsSO.instance.Save();
                        }
                    }
                }
            }

        }

    }
}
#endif