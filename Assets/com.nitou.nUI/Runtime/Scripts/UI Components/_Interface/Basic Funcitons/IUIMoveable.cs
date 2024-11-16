using System;
using UnityEngine.EventSystems;

namespace nitou.UI.Component{

    /// <summary>
    /// Interface of the UI that handles the �gMove�h event
    /// </summary>
    public interface IUIMoveable : IUIComponent{

        /// <summary>
        /// Observable that nortifies when a "Move" input is detected.
        /// </summary>
        public IObservable<MoveDirection> OnMoved { get; }
    }
}
