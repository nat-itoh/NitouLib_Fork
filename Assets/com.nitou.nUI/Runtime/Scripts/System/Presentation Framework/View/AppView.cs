using Cysharp.Threading.Tasks;
using UnityEngine;

namespace nitou.UI.PresentationFramework {

    /// <summary>
    /// UI�v�f�̃C���X�^���X�D
    /// </summary>
    public abstract class AppView<TState> : MonoBehaviour where TState : AppViewState {
        
        /// <summary>
        /// ���������������Ă��邩�ǂ����D
        /// </summary>
        private bool _isInitialized;

        /// <summary>
        /// �����������D
        /// </summary>
        public async UniTask InitializeAsync(TState state) {
            if (_isInitialized) return;

            _isInitialized = true;

            await Initialize(state);
        }

        /// <summary>
        /// ���������� (���h���N���X�ł̒�`�p)�D
        /// </summary>
        protected abstract UniTask Initialize(TState state);
    }

}
