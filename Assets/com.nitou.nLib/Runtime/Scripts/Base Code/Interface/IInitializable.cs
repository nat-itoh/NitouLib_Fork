
// [Memo]
//  �C�ӂ̃^�C�~���O�Ń��Z�b�g���������Ƃ��������邽�߁C�C���^�[�t�F�[�X���쐬�D
//  �e�I�u�W�F�N�g����ċA�I�ɏ������邱�Ƃ���ړI�D

namespace nitou {

    public interface IInitializable {

        /// <summary>
        /// ���������������Ă��邩�ǂ����D
        /// </summary>
        public bool IsInitialized { get; }

        /// <summary>
        /// �����������D
        /// </summary>
        public void Initialize();
    }


    public interface IInitializable<T> {

        /// <summary>
        /// ���������������Ă��邩�ǂ����D
        /// </summary>
        public bool IsInitialized { get; }

        /// <summary>
        /// �����������D
        /// </summary>
        public void Initialize(T item);
    }


    public interface IInitializable<T1, T2> {

        /// <summary>
        /// ���������������Ă��邩�ǂ����D
        /// </summary>
        public bool IsInitialized { get; }

        /// <summary>
        /// �����������D
        /// </summary>
        public void Initialize(T1 item1, T2 item2);
    }
}