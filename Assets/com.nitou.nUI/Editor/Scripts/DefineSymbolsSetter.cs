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
        private const string SYMBOL_USN_ASYNC = "USN_USE_ASYNC_METHODS";
        private const string SYMBOL_UNITASK_DOTWEEN = "UNITASK_DOTWEEN_SUPPORT";


        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        static DefineSymbolsSetter() {

            // �r���h�^�[�Q�b�g
            var buildTarget = NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            if (buildTarget == NamedBuildTarget.Unknown) return;

            // �p�b�P�[�W���C���X�g�[�����ꂽ�Ƃ��Ɏ��s����鏈��

            AddDefineSymbolsIfNeeded(buildTarget, SYMBOL_USN_ASYNC);
            AddDefineSymbolsIfNeeded(buildTarget, SYMBOL_UNITASK_DOTWEEN);
            //AddDefineSymbolsIfNeeded(buildTarget, "UNITASK_DOTWEEN_SUPPORT");
        }


        /// ----------------------------------------------------------------------------
        // Private Method

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
                Debug.Log($"Added define symbol: {symbol}");
            } else {
                //Debug.Log($"{SYMBOL_TO_DEFINE} is already defined.");
            }
        }
    }
}
#endif
