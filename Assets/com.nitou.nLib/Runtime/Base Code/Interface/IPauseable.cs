
namespace nitou {

    public interface IPauseable{

        /// <summary>
        /// �|�[�Y��Ԃ��ǂ���
        /// </summary>
        public bool IsPaused { get; }

        /// <summary>
        /// �|�[�Y����
        /// </summary>
        public void OnPause();

        /// <summary>
        /// �|�[�Y��������
        /// </summary>
        public void Unpause();
    }
}