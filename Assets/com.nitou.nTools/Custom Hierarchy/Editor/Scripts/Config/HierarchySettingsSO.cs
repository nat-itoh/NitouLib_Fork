#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace nitou.Tools.Hierarchy{
    using nitou.EditorShared;

    /// <summary>
    /// Editor�ŎQ�Ƃ���v���W�F�N�g�ŗL�̐ݒ�f�[�^
    /// </summary>
    [FilePath(
        "ProjectSettings/HierarchySettingsSO.asset",
        FilePathAttribute.Location.ProjectFolder
    )]
    internal sealed class HierarchySettingsSO : ScriptableSingleton<HierarchySettingsSO> , 
        ISettingsData{

        [SerializeField] HierarchyObjectMode hierarchyObjectMode = HierarchyObjectMode.RemoveInBuild;
        [SerializeField] bool showHierarchyToggles;
        [SerializeField] bool showComponentIcons;
        [SerializeField] bool showTreeMap;
        [SerializeField] Color treeMapColor = new(0.53f, 0.53f, 0.53f, 0.45f);
        [SerializeField] bool showSeparator;
        [SerializeField] bool showRowShading;
        [SerializeField] Color separatorColor = new(0.19f, 0.19f, 0.19f, 0f);
        [SerializeField] Color evenRowColor = new(0f, 0f, 0f, 0.07f);
        [SerializeField] Color oddRowColor = Color.clear;

        // Property
        public HierarchyObjectMode HierarchyObjectMode => hierarchyObjectMode;
        public bool ShowHierarchyToggles => showHierarchyToggles;
        public bool ShowComponentIcons => showComponentIcons;
        public bool ShowTreeMap => showTreeMap;
        public Color TreeMapColor => treeMapColor;
        public bool ShowSeparator => showSeparator;
        public bool ShowRowShading => showRowShading;
        public Color SeparatorColor => separatorColor;
        public Color EvenRowColor => evenRowColor;
        public Color OddRowColor => oddRowColor;

        /// <summary>
        /// �f�[�^��ۑ�����
        /// </summary>
        public void Save() => Save(true);
    }
}
#endif