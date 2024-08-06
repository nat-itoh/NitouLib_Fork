
// [Memo]
//  �C�ӂ̃^�C�~���O�Ń��Z�b�g���������Ƃ��������邽�߁C�C���^�[�t�F�[�X���쐬�D
//  �L�q�̓������ړI�Ƃ��Ă��邽�߁C�|�����[�t�B�b�N�Ȏg�p�͖��z��D

namespace nitou {

    public interface ISetupable {
        public void Setup();
        public void Teardown();
    }

    public interface ISetupable<T> {
        public void Setup(T item);
        public void Teardown();
    }

    public interface ISetupable<T1, T2> {
        public void Setup(T1 item1, T2 item2);
        public void Teardown();
    }
}