#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace nitou.Tools.SceneSystem{
    using nitou.EditorShared;

    /// <summary>
    /// 
    /// </summary>
    internal sealed class SceneSwitcherSettingsSO : ScriptableSingleton<SceneSwitcherSettingsSO>, ISettingsData{


        /// <summary>
        /// �f�[�^��ۑ�����
        /// </summary>
        public void Save() => base.Save(saveAsText: true);
    }
}
#endif
