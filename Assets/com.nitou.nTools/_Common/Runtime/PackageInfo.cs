
namespace nitou.Tools.Shared{

    /// <summary>
    /// �p�b�P�[�W�̊e��ݒ���Ǘ�����ÓI�N���X
    /// </summary>
    internal static class PackageInfo{

        /// <summary>
        /// �p�b�P�[�W�̃f�B���N�g���p�X
        /// </summary>
        internal static readonly PackageDirectoryPath PackagePath = null;

        /// <summary>
        /// ProjectSettings�̃��j���[�p�X
        /// </summary>
        internal static readonly string SettingsMenuPath = "Project/Nitou Tools/";

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        static PackageInfo() {
            PackagePath = new PackageDirectoryPath("com.nitou.nTools");
        }
    }
}
