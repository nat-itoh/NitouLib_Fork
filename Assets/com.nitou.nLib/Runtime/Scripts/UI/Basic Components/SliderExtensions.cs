using System;
using UniRx;
using UnityEngine.UI;

namespace nitou {

    /// <summary>
    /// <see cref="Slider"/>�^�̊�{�I�Ȋg�����\�b�h�W�D
    /// </summary>
    public static partial class SliderExtensions {

        /// ----------------------------------------------------------------------------
        // �C�x���g�̓o�^

        /// <summary>
        /// �C�x���g�o�^���ȗ�������g�����\�b�h
        /// </summary>
        public static IDisposable SetOnValueChangedDestination(this Slider self, Action<float> onValueChanged) {
            return self.onValueChanged
                .AsObservable()
                .Subscribe(onValueChanged.Invoke)
                .AddTo(self);
        }

    }
}
