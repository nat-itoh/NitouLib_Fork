using System;
using UniRx;

namespace nitou.UI.Component {

    /// <summary>
    /// Interface of the UI that handles the �gSubmit�h event.
    /// </summary>
    public interface IUISubmitable : IUIComponent {

        /// <summary>
        /// ������͂��ꂽ���̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnSubmited { get; }
    }

}