using UnityEngine;

namespace nitou.Shared{

    /// <summary>
    /// �p�b�P�[�W�̊e��ݒ���Ǘ�����ÓI�N���X
    /// </summary>
    internal static class PackageInfo {

        /// <summary>
        /// �p�b�P�[�W�̃f�B���N�g���p�X
        /// </summary>
        internal static readonly PackageDirectoryPath packagePath = null;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        static PackageInfo() {
            packagePath = new PackageDirectoryPath("com.nitou.nLib");
        }
    }
}
