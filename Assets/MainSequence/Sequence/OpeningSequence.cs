using System;
using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Demo.Sequencer {

    public class OpeningSequence : ISequence {

        private readonly string _message;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public OpeningSequence(string message) {
            _message = message;
        }

        /// <summary>
        /// �V�[�P���X���s�D
        /// </summary>
        public async UniTask Run(CancellationToken token = default) {

            ShowMessage();

            // �X�L�b�v�{�^����������邩�A��莞�Ԍo�߂ŏI��
            var skipTask = WaitForSkipRequest(token);
            var timeoutTask = UniTask.Delay(TimeSpan.FromSeconds(10), cancellationToken: token);

            await UniTask.WhenAny(skipTask, timeoutTask);
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        private void ShowMessage() {
            Debug.Log($"Opening: {_message}");
        }


        private async UniTask WaitForSkipRequest(CancellationToken token) {
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space), cancellationToken: token);
            Debug.Log("skip");
        }

    }
}
