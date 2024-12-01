using System.Collections.Generic;

// [REF]
//  UnityDoc: InitializeOnEnterPlayModeAttribute https://docs.unity3d.com/ja/2023.2/ScriptReference/InitializeOnEnterPlayModeAttribute.html

namespace Unity.SceneManagement {

    /// <summary>
    /// �o�^���ꂽ<see cref="SceneLoader"/>�֘A�N���X�̏������������s���N���X�D
    /// </summary>
    internal static class SceneInitialization {

        private static readonly List<IInitializeOnEnterPlayMode> _initializes = new();

        public static void Register(IInitializeOnEnterPlayMode initializer) {
            _initializes.Add(initializer);
        }


        /// ----------------------------------------------------------------------------
#if UNITY_EDITOR
        [UnityEditor.InitializeOnEnterPlayMode]
        private static void InitializeOnEnterPlayMode() {
            _initializes.ForEach(i => i.OnEnterPlayMode());
        }
#endif
    }
}