using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

namespace nitou.UI.BasicScreens {
    using nitou.UI.Components;

    /// <summary>
    /// �P�I�����̊m�F���[�_��
    /// </summary>
    public class OneChiceConfirmModal : ConfirmModalBase {
  
        [TitleGroup("Buttons")]
        [SerializeField, Indent] protected Button _yesButton;


        public IObservable<Unit> OnYesButtonClicked => _yesButton.OnClickAsObservable();


        /// ----------------------------------------------------------------------------
        // Public Method

        public UniTask WaitUnitilClick() {
            return OnYesButtonClicked.ToUniTask(useFirstValue: true);
        }
    }

}