#if UNITY_EDITOR
using System;
using UnityEngine;
using UnityEditor;

namespace nitou.Tools.Hierarchy{

    /// <summary>
    /// Editor�ŎQ�Ƃ���v���W�F�N�g�ŗL�̐ݒ�f�[�^
    /// </summary>
    [FilePath(
        "ProjectSettings/HierarchySettingsSO.asset",
        FilePathAttribute.Location.ProjectFolder
    )]
    public class HierarchySettingsSO : ScriptableSingleton<HierarchySettingsSO> {

        public int test;

        public void Save() => Save(true);
    }
}
#endif