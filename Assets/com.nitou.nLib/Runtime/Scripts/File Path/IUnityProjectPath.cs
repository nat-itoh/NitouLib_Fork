
namespace nitou{

    /// <summary>
    /// UnityProject���̃f�[�^�A�܂��̓f�B���N�g�����w���p�X�̃C���^�[�t�F�[�X
    /// </summary>
    public interface IUnityProjectPath{

        /// <summary>
        /// Project�f�B���N�g�����N�_�Ƃ����p�X�ɕϊ�����
        /// </summary>
        string ToProjectPath();

        /// <summary>
        /// ��΃p�X�ɕϊ�����
        /// </summary>
        string ToAbsolutePath();
    }
}
