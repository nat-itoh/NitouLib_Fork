using System;
using System.Collections.Generic;
using UniRx;

namespace nitou {

    /// <summary>
    /// <see cref="T"/>�^�̃f�[�^��ێ��ł���I�u�W�F�N�g�D
    /// </summary>
    public interface IDataHolder<T> {

        /// <summary>
        /// �l���ω������Ƃ��ɒʒm����Observable�D
        /// </summary>
        public IObservable<T> OnValueChanged { get; }

        /// <summary>
        /// �l���擾����D
        /// </summary>
        public T GetValue();

        /// <summary>
        /// �l��ݒ肷��D
        /// </summary>
        public void SetValue(T value);
    }


    public static class DataHolderExtensions {

        /// <summary>
        /// �o�����o�C���f�B���O�D
        /// </summary>
        public static void BindTo<T>(this IReactiveProperty<T> property, IDataHolder<T> target, ICollection<IDisposable> disposables) {

            // Property �� Target
            property.SubscribeWithState(target, (x, t) => t.SetValue(x)).AddTo(disposables);

            // Targer �� Property
            target.OnValueChanged.SubscribeWithState(property, (x, p) => p.Value = x).AddTo(disposables);
        }
    }
}
