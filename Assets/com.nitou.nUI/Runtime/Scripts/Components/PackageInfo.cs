
namespace nitou.UI.Shared{

    /// <summary>
    /// �p�b�P�[�W�̊e��ݒ���Ǘ�����ÓI�N���X�D
    /// </summary>
    internal static class PackageInfo {

        /// <summary>
        /// �p�b�P�[�W�̃f�B���N�g���p�X�D
        /// </summary>
        internal static readonly PackageDirectoryPath packagePath = null;

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        static PackageInfo() {
            packagePath = new PackageDirectoryPath("com.nitou.nUI");
        }
    }
}
