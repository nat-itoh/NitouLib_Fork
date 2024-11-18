using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Project.Test {

    public class ProcessExecuter {

        private readonly IEnumerable<IProcess> _processes;
        private bool _isPaused;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ProcessExecuter(IEnumerable<IProcess> processes) {
            _processes = processes ?? throw new ArgumentNullException(nameof(processes));
        }

        /// <summary>
        /// 
        /// </summary>
        public async UniTask Run(CancellationToken token) {
            try {
                foreach (var process in _processes) {
                    // �񓯊��Ɉꎞ��~��҂���
                    while (_isPaused) {
                        await UniTask.Yield(PlayerLoopTiming.Update, token);
                    }

                    token.ThrowIfCancellationRequested();  // �O������̃L�����Z���m�F

                    await process.RunAsync(token);
                }
            } catch (OperationCanceledException) {
                Debug.Log("Execution was cancelled.");
            }
        }

        public void Pause() {
            _isPaused = true;
            Debug.Log("Execution paused.");
        }

        public void Resume() {
            _isPaused = false;
            Debug.Log("Execution resumed.");
        }
    }
}
