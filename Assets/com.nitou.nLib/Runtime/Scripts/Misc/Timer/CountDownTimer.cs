using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

// [�Q�l]
//  qiita: UniRx�ŃJ�E���g�_�E���^�C�}�[����� https://qiita.com/toRisouP/items/581ffc0ddce7090b275b
//  zenn: �I���I��UniRx�^�C�}�[ https://zenn.dev/keisuke114/scraps/5581b16d793806

namespace nitou {

    /// <summary>
    /// �J�E���g�_�E�������̃^�C�}�[
    /// </summary>
    public class CountDownTimer : ITimer, IDisposable {

        private readonly ReactiveProperty<int> _currentRP;
        private readonly Subject<Unit> _overSubject = new();
        private IDisposable _subscription = null;

        private float _elapsedTime;           // �����v�Z�p�̕ϐ�

        /// <summary>
        /// 
        /// </summary>
        public int Max { get; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsTimeOverd => _currentRP.Value <= 0f;

        /// <summary>
        /// ���݂̎���
        /// </summary>
        public IReadOnlyReactiveProperty<int> Current => _currentRP;

        /// <summary>
        /// �I���ʒm
        /// </summary>
        public IObservable<Unit> OverObservable => _overSubject;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public CountDownTimer(int max) {
            if (max <= 0) throw new System.InvalidOperationException();
            
            Max = max;

            _elapsedTime = Max;
            _currentRP = new ReactiveProperty<int>(Max);
        }

        /// <summary>
        /// �I������
        /// </summary>
        public void Dispose() {
            Stop();

            _currentRP?.Dispose();
            _overSubject?.Dispose();
        }


        /// ----------------------------------------------------------------------------
        // Public Method (�^�C�}�[����)

        public void Start() {
            if (_subscription != null) {
                Debug_.LogWarning("Timer is already running.");
                return;
            }
            if(IsTimeOverd) {
                Debug_.LogWarning("Time is up. Requires reset to use.");
                return;
            }

            // �X�V����
            _subscription = Observable.EveryUpdate()
                .Subscribe(_ => {
                    // Time.deltaTime�Ɋ�Â��čX�V
                    _elapsedTime -= Time.deltaTime;
                    _currentRP.Value = Mathf.CeilToInt(_elapsedTime);    // �����̖���������ɐ؂�グ

                    // �c�莞�Ԃ�0�ɂȂ�����TimeOver�C�x���g�𔭍s
                    if(IsTimeOverd) {
                        _overSubject.OnNext(Unit.Default);
                        Stop();
                    }
                });
        }

        public void Stop() {
            _subscription?.Dispose();
            _subscription = null;
        }

        public void Reset() {
            _elapsedTime = Max;
            _currentRP.Value = Max;
        }

    }
}
