#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

namespace nitou.Tools.Hierarchy.EditorSctipts {
    using nitou.EditorShared;

    public class HierarchySettingsProvider : SettingsProvider {

        // �ݒ�̃p�X (����1�K�w�́uPreferences�v�ɂ���)
        private const string SettingPath = "Project/_Nitou/Hierarchy";

        private Editor _editor;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public HierarchySettingsProvider(string path, SettingsScope scopes, IEnumerable<string> keywords) : base(path, scopes, keywords) { }

        /// <summary>
        /// ���̃��\�b�h���d�v�ł�
        /// �Ǝ���SettingsProvider��Ԃ����ƂŁA�ݒ荀�ڂ�ǉ����܂�
        /// </summary>
        [SettingsProvider]
        public static SettingsProvider CreateSettingProvider() {
            // ����O������keywords�́A�������ɂ��̐ݒ荀�ڂ����������邽�߂̃L�[���[�h
            return new HierarchySettingsProvider(SettingPath, SettingsScope.Project, null);
        }



        public override void OnActivate(string searchContext, VisualElement rootElement) {

            var preferences = HierarchySettingsSO.instance;

            // ��ScriptableSingleton��ҏW�\�ɂ���
            preferences.hideFlags = HideFlags.HideAndDontSave & ~HideFlags.NotEditable;

            // �ݒ�t�@�C���̕W���̃C���X�y�N�^�[�̃G�f�B�^�𐶐�
            Editor.CreateCachedEditor(preferences, null, ref _editor);
        }


        public override void OnGUI(string searchContext) {

            EditorGUI.BeginChangeCheck();

            // �ݒ�t�@�C���̕W���C���X�y�N�^��\��
            _editor.OnInspectorGUI();

            //EditorGUILayout.LabelField("�e�X�g����");

            if (EditorGUI.EndChangeCheck()) {
                HierarchySettingsSO.instance.Save();
            }
        }

    }
}
#endif