using System;

namespace nitou{

    public interface IDataHolder<T>{

        /// <summary>
        /// �l�̕ω���ʒm����X�g���[���D
        /// </summary>
        IObservable<T> OnValueChanged { get; }

        /// <summary>
        /// �l���擾����
        /// </summary>
        T GetValue();

        /// <summary>
        /// �l��ݒ肷��D
        /// </summary>
        void SetValue(T value);
    }
}
