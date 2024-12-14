using System;
using UniRx;
using UnityEngine.UI;

namespace nitou {

    /// <summary>
    /// <see cref="Toggle"/>�^�̊�{�I�Ȋg�����\�b�h�W�D
    /// </summary>
    public static partial class ToggleExtensions {

        /// ----------------------------------------------------------------------------
        // �C�x���g�̓o�^

        /// <summary>
        /// �C�x���g�o�^���ȗ�������g�����\�b�h
        /// </summary>
        public static IDisposable SetOnValueChangedDestination(this Toggle self, Action<bool> onValueChanged) {
            return self.onValueChanged
                .AsObservable()
                .Subscribe(onValueChanged.Invoke)
                .AddTo(self);
        }
    }
}
