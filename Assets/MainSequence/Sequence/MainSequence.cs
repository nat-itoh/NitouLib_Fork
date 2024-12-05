using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Demo.Sequencer {

    public class MainSequence : ISequence {

        /// <summary>
        /// �V�[�P���X���s�D
        /// </summary>
        public async UniTask Run(CancellationToken token = default) {

            Debug.Log("Main sequence started.");
            await UniTask.WaitForSeconds(3, cancellationToken: token);
            Debug.Log("Main sequence ended.");
        }
    }
}
