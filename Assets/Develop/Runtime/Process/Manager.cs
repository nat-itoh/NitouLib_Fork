using UnityEngine;
using UniRx;

namespace Project.Test{

    public enum EngineState {
        Teaching,
        Playing,
    }


    /// <summary>
    /// �������[�h�ƍĐ����[�h�����G�f�B�^�}�l�[�W���[�N���X�D
    /// </summary>
    public class Manager : MonoBehaviour{

        private readonly ReactiveProperty<EngineState> _currentStateRP = new(EngineState.Teaching);

        public IReadOnlyReactiveProperty<EngineState> CurrentStateRP => _currentStateRP;

    }
}
