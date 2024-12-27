#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.Build;

// [REF]
//  �͂Ȃ���: Player Settings��ScriptingDefineSymbols���X�N���v�g����擾�E�ݒ肷����@ https://www.hanachiru-blog.com/entry/2024/06/03/120000

namespace nitou.EditorScripts {

    /// <summary>
    /// 
    /// </summary>
    [InitializeOnLoad]
    internal static class DefineSymbolsSetter{

        // ��`�������V���{��
        private const string SYMBOL_TO_DEFINE = "NLIB_PACKAGE_SYMBOL";


        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        static DefineSymbolsSetter() {

            var buildTarget = NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup);

            // �p�b�P�[�W���C���X�g�[�����ꂽ�Ƃ��Ɏ��s����鏈��
            AddDefineSymbolsIfNeeded();

            AddDefineSymbolsIfNeeded(buildTarget, "USN_USE_ASYNC_METHODS");
            //AddDefineSymbolsIfNeeded(buildTarget, "UNITASK_DOTWEEN_SUPPORT");
        }


        /// ----------------------------------------------------------------------------

        /// <summary>
        /// �V���{�����`����
        /// </summary>
        private static void AddDefineSymbolsIfNeeded() {

            // ���݂̃r���h�^�[�Q�b�g���Ƃ̒�`�ς݂̃V���{�����擾
            string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);

            // �V���{�������łɒ�`����Ă��Ȃ����`�F�b�N
            if (!defines.Contains(SYMBOL_TO_DEFINE)) {
                // �V���{��������`�Ȃ�ǉ�
                defines += ";" + SYMBOL_TO_DEFINE;

                // �V���{����ݒ�
                PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, defines);

                // �f�o�b�O�p���O
                Debug.Log($"Added define symbol: {SYMBOL_TO_DEFINE}");
            } else {
                //Debug.Log($"{SYMBOL_TO_DEFINE} is already defined.");
            }
        }

        /// <summary>
        /// �V���{�����`����
        /// </summary>
        private static void AddDefineSymbolsIfNeeded(NamedBuildTarget buildTarget, string symbol) {

            // �r���h�^�[�Q�b�g�̒�`�ς݂̃V���{�����擾
            string defines = PlayerSettings.GetScriptingDefineSymbols(buildTarget);

            // �V���{�������łɒ�`����Ă��Ȃ����`�F�b�N
            if (!defines.Contains(symbol)) {
                // �V���{��������`�Ȃ�ǉ�
                defines += ";" + symbol;

                // �V���{����ݒ�
                PlayerSettings.SetScriptingDefineSymbols(buildTarget, symbol);

                // �f�o�b�O�p���O
                Debug.Log($"Added define symbol: {SYMBOL_TO_DEFINE}");
            } else {
                //Debug.Log($"{SYMBOL_TO_DEFINE} is already defined.");
            }
        }
    }
}
#endif
