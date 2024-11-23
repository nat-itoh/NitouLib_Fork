using System;

// [�Q�l]
//  ���C�u�h�A�u���O: �W�F�l���N�X�^�̔�r���@ http://templatecreate.blog.jp/archives/30579779.html

namespace nitou {

    /// <summary>
    /// �񋓌^�̗v�f���ɈӖ����������邽�߂̃��b�p�[�iNext,Previous�ւ̑J�ځj
    /// </summary>
    public class CountableEnum<T> where T : Enum {
        
        private readonly Array _valueArray;  // �Ώ�(�񋓌^)�̑S�v�f
        private int _id;            // ���ݒl�̃C���f�b�N�X


        /// ----------------------------------------------------------------------------
        // Properity

        public Type Type { get => Get(0).GetType(); }
        public T Head { get => Get(0); }
        public T Tail { get => Get(_valueArray.Length - 1); }
        public T Current { get => Get(_id); }

        // ����
        public bool IsHead { get => Get(_id).Equals(Head); }
        public bool IsTail { get => Get(_id).Equals(Tail); }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public CountableEnum(T target) {
            _valueArray = Enum.GetValues(target.GetType());      // �񋓌^�̑S�v�f
            _id = GetId(target);                             // �w��v�f�̃C���f�b�N�X
        }

        // ��r
        public bool Is(T target) => Get(_id).CompareTo(target) == 0;

        // �J��
        public T MoveNext() {
            _id = IsTail ? 0 : _id + 1;   // ���̒l�ɐi�߂�
            return Current;
        }
        public T MovePrevious() {
            _id = IsHead ? _valueArray.Length - 1 : _id - 1;   // �O�̒l�ɖ߂�
            return Current;
        }

        // �f�o�b�O
        public override string ToString() {
            return string.Format("type:{0} [{1}-{2}]  current:{3}", Type, Head, Tail, Get(_id));
        }


        /// ----------------------------------------------------------------------------
        // Private Method
        
        private T Get(int id) => (T)_valueArray.GetValue(id);
        
        private int GetId(T key) {
            for (int i = 0; i < _valueArray.Length; i++) {
                var value = Get(i);
                if (key.Equals(value)) return i;
            }
            throw new System.ArgumentException();
        }
    }

}
