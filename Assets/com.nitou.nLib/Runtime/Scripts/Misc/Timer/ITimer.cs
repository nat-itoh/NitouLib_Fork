
namespace nitou{

    /// <summary>
    /// �^�C�}�[�̊�{������`�����C���^�[�t�F�[�X
    /// </summary>
    public interface ITimer {

        /// <summary>
        /// �J�n����
        /// </summary>
        public void Start();
        
        /// <summary>
        /// ��~����
        /// </summary>
        public void Stop();

        /// <summary>
        /// ���Z�b�g����
        /// </summary>
        public void Reset();
    }
}
