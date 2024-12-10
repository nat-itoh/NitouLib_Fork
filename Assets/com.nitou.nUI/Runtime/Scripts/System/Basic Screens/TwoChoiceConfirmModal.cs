using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

namespace nitou.UI.BasicScreens {
    using nitou.UI.Component;

    /// <summary>
    /// �Q�I�����̊m�F���[�_��
    /// </summary>
    public class TwoChoiceConfirmModal : ConfirmModalBase {

        [TitleGroup("Buttons")]
        [SerializeField, Indent] protected Button _yesButton;

        [TitleGroup("Buttons")]
        [SerializeField, Indent] protected Button _noButton;


        public IObservable<Unit> OnYesButtonClicked => _yesButton.OnClickAsObservable();
        public IObservable<Unit> OnNoButtonClicked => _noButton.OnClickAsObservable();


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �ǂ��炩�̃{�^�������������̂�ҋ@���邷��
        /// </summary>
        public UniTask<bool> WaitUntilClicked() {
            return Observable.Merge(
                   OnYesButtonClicked.Select(x => true),
                   OnNoButtonClicked.Select(x => false))
               .ToUniTask(useFirstValue: true);
        }
    }

}