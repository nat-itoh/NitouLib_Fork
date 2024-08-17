using UnityEngine;

namespace nitou.Tools.Hierarchy {

    /// <summary>
    /// �q�G�����L�[�g���p�̃_�~�[�I�u�W�F�N�g�D
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Nitou/Hierarchy Object")]
    public class HierarchyObject : MonoBehaviour {
        
        public enum Mode {
            UseSettings = 0,
            None = 1,
            RemoveInPlayMode = 2,
            RemoveInBuild = 3
        }

        [SerializeField] Mode _hierarchyObjectMode = Mode.UseSettings;


        public Mode HierarchyObjectMode => _hierarchyObjectMode;
    }
}