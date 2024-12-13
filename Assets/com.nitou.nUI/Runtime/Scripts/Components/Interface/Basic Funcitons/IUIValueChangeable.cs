using System;

namespace nitou.UI.Components{

    /// <summary>
    /// "ValueChange"�C�x���g������UI�ł��邱�Ƃ������C���^�[�t�F�[�X�D
    /// </summary>
    public interface IUIValueChangeable<TValue>{

        /// <summary>
        /// �l���ω��������̃C�x���g�ʒm�D
        /// </summary>
        public IObservable<TValue> OnValueChanged { get; }

    }
}
