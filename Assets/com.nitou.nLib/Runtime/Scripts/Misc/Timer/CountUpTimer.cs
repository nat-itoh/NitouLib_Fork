using System;
using UniRx;
using UnityEngine;

// [�Q�l]
//  _: Mathf�̐؂�グ�A�؂�̂āA�����ۂ߁B�g���������厖��� https://ekulabo.com/mathf-round

namespace nitou {

    /// <summary>
    /// �J�E���g�A�b�v�����̃^�C�}�[
    /// </summary>
    public class CountUpTimer : ITimer, IDisposable {

        private readonly ReactiveProperty<int> _currentRP;
        private IDisposable _subscription = null;

        private float _elapsedTime;           // �����v�Z�p�̕ϐ�

        /// ----------------------------------------------------------------------------
        // Properity

        /// <summary>
        /// ���݂̎���
        /// </summary>
        public IReadOnlyReactiveProperty<int> Current => _currentRP;


        /// ----------------------------------------------------------------------------
        // Public Method

        public CountUpTimer() {
            _elapsedTime = 0;
            _currentRP = new ReactiveProperty<int>(0);
        }

        public void Dispose() {
            Stop();

            _currentRP.Dispose();
        }


        /// ----------------------------------------------------------------------------
        // Public Method (�^�C�}�[����)
        
        public void Start() {
            if (_subscription != null) {
                Debug_.LogWarning("Timer is already running.");
                return;
            }

            // �X�V����
            _subscription = Observable.EveryUpdate()
                .Subscribe(_ => {
                    // Time.deltaTime�Ɋ�Â��čX�V
                    _elapsedTime += Time.deltaTime;
                    _currentRP.Value = Mathf.FloorToInt(_elapsedTime); // �����̖���������ɐ؂艺��
                });
        }

        public void Stop() {
            _subscription?.Dispose();
            _subscription = null;
        }

        public void Reset() {
            _elapsedTime = 0;
            _currentRP.Value = 0;
        }
    }
}
