
namespace nitou {

    public interface IPauseable{

        /// <summary>
        /// �|�[�Y��Ԃ��ǂ����D
        /// </summary>
        public bool IsPaused { get; }

        /// <summary>
        /// �|�[�Y�����D
        /// </summary>
        public void OnPause();

        /// <summary>
        /// �|�[�Y���������D
        /// </summary>
        public void Unpause();
    }
}