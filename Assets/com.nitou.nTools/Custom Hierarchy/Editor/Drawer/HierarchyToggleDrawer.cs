#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEngine;

// [�Q�l]
//  _: Hierarchy �ŃI�u�W�F�N�g�̃R���|�[�l���g�ꗗ���A�C�R���\�� https://www.midnightunity.net/unity-extension-hierarchy-show-components/
//  github : Alchemy/HierarchyToggleDrawer.cs https://github.com/AnnulusGames/Alchemy/blob/main/Alchemy/Assets/Alchemy/Editor/Hierarchy/HierarchyToggleDrawer.cs

namespace nitou.Tools.Hierarchy.EditorSctipts {
    using nitou.EditorShared;
    using nitou.Tools.Shared;

    public sealed class HierarchyToggleDrawer : HierarchyDrawer {

        private const float TOGGLE_SIZE = 16f;
        private const float ICON_SIZE = 14f;
        private const float RIGHT_OFFSET = 2.7f;

        private static readonly Color _disableColor = new(1.0f, 1.0f, 1.0f, 0.5f);


        /// ----------------------------------------------------------------------------
        // Public Method

        public override void OnGUI(int instanceID, Rect selectionRect) {
            
            // GameObject�擾
            var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) return;
            if (gameObject.TryGetComponent<HierarchyObject>(out _)) return;     // ���_�~�[�I�u�W�F�N�g�͂͂���

            // �ݒ�f�[�^
            var settings = nToolsSettings.GetOrCreateSettings();

            // �g�O���{�^��
            if (settings.ShowHierarchyToggles) {
                var rect = selectionRect;
                rect.x = rect.xMax - RIGHT_OFFSET;  // ���E�[�ɔz�u
                rect.width = TOGGLE_SIZE;

                // Active��Ԃ̔��f
                var active = GUI.Toggle(rect, gameObject.activeSelf, string.Empty);
                if (active != gameObject.activeSelf) {
                    Undo.RecordObject(gameObject, $"{(active ? "Activate" : "Deactivate")} GameObject '{gameObject.name}'");
                    gameObject.SetActive(active);
                    EditorUtility.SetDirty(gameObject);
                }
            }

            // �A�C�R��
            if (settings.ShowComponentIcons) {
                // �`��ʒu
                var rect = selectionRect;
                rect.x = rect.xMax - ((settings.ShowHierarchyToggles ? TOGGLE_SIZE : 0f) + RIGHT_OFFSET);
                rect.y += 1f;
                rect.width = ICON_SIZE;
                rect.height = ICON_SIZE;

                // �I�u�W�F�N�g���������Ă���R���|�[�l���g�ꗗ���擾
                var components = gameObject.GetComponents<Component>()
                    //.AsEnumerable()           // ��Transform & RectTransform��\������ꍇ�͂�����
                    .Where(x => x is not Transform)
                    .Reverse();

                // �A�C�R���̕`��
                var existsScriptIcon = false;
                foreach (var component in components) {
                    var image = AssetPreview.GetMiniThumbnail(component);
                    if (image == null) continue;

                    if (image == EditorUtil.Icons.scriptIcon.image) {
                        if (existsScriptIcon) continue;
                        existsScriptIcon = true;
                    }
                    var color =   component.IsEnabled() ? Color.white : _disableColor;
                    DrawIcon(ref rect, image, color);
                }
            }
        }


        /// ----------------------------------------------------------------------------
        // Static Method

        private static void DrawIcon(ref Rect rect, Texture image, Color color) {
            
            using (new EditorUtil.GUIColorScope(color)) {
                GUI.DrawTexture(rect, image, ScaleMode.ScaleToFit);
                rect.x -= rect.width;
            }
        }

    }

}
#endif