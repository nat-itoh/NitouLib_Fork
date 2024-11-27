
namespace nitou {

    /// <summary>
    /// UnityProject���̃f�[�^�A�܂��̓f�B���N�g�����w���p�X�̃C���^�[�t�F�[�X
    /// </summary>
    public interface IUnityProjectPath{

        /// <summary>
        /// Convert to project path that start with "Assets/".
        /// </summary>
        string ToProjectPath();

        /// <summary>
        /// Covert to absolute path.
        /// </summary>
        string ToAbsolutePath();
    }
}
