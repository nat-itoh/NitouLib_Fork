
namespace nitou {

    public interface IActivatable {

        /// <summary>
        /// �A�N�e�B�u�ȏ�Ԃ��ǂ���
        /// </summary>
        public bool IsActive { get; }

        public void Activate();
        public void Deactivate();
    }
}