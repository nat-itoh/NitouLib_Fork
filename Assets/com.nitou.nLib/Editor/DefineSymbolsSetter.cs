#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

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
            // �p�b�P�[�W���C���X�g�[�����ꂽ�Ƃ��Ɏ��s����鏈��
            AddDefineSymbolsIfNeeded();
        }

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
    }
}
#endif
