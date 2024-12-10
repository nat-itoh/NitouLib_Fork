using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using UnityScreenNavigator.Runtime.Core.Modal;

// [NOTE] "USN_USE_ASYNC_METHODS"�V���{�����K�v�D

namespace nitou.UI.PresentationFramework {

    [RequireComponent(typeof(CanvasGroup))]
    public abstract class Modal<TRootView, TViewState> : Modal
        where TRootView : AppView<TViewState>
        where TViewState : AppViewState {

        public TRootView root;
        private TViewState _state;

        /// <summary>
        /// �������ς݂��ǂ����D
        /// </summary>
        public bool IsInitialized => _isInitialized;
        private bool _isInitialized;

        /// <summary>
        /// �������̃^�C�~���O�D
        /// </summary>
        protected virtual ViewInitializationTiming RootInitializationTiming => ViewInitializationTiming.BeforeFirstEnter;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// View State�̐ݒ�D
        /// </summary>
        public void Setup(TViewState state) {
            Assert.IsNotNull(root);
            _state = state;
        }


        /// ----------------------------------------------------------------------------
        // Lifecycle Events

        public override async Task Initialize() {
            Assert.IsNotNull(root);

            await base.Initialize();

            // RootView�̏���������
            if (RootInitializationTiming == ViewInitializationTiming.Initialize && !_isInitialized) {
                await root.InitializeAsync(_state);
                _isInitialized = true;
            }
        }

        public override async Task WillPushEnter() {
            Assert.IsNotNull(root);

            await base.WillPushEnter();

            // RootView�̏���������
            if (RootInitializationTiming == ViewInitializationTiming.BeforeFirstEnter && !_isInitialized) {
                await root.InitializeAsync(_state);
                _isInitialized = true;
            }
        }
    }
}
