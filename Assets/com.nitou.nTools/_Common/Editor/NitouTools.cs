#if UNITY_EDITOR
using UnityEngine;

namespace nitou.Tools.Shared{

    /// <summary>
    /// �p�b�P�[�W�̊e��ݒ���Ǘ�����ÓI�N���X
    /// </summary>
    internal static class NitouTools{

        // old
        internal static readonly nitou.EditorShared.PackageFolderInfo pacakageInfo;

        /// <summary>
        /// �p�b�P�[�W�̃f�B���N�g���p�X
        /// </summary>
        internal static readonly PackageDirectoryPath packagePath = null;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        static NitouTools() {
            pacakageInfo = new nitou.EditorShared.PackageFolderInfo(
                upmFolderName: "com.nitou.nTools",
                normalFolderName: "com.nitou.nTools");


            packagePath = new PackageDirectoryPath("com.nitou.nTools");
        }

    }
}
#endif