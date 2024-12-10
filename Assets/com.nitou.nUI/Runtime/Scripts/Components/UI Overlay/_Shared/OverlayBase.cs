using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace nitou.UI.Overlay {

    /// <summary>
    /// �I�[�o���C�̊��N���X
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class OverlayBase : MonoBehaviour, IUIOverlay {

        public enum State {
            Open,
            Transition,
            Close,
        }

        protected CanvasGroup _canvasGroup;

        /// <summary>
        /// �J�ڏ�ԁD
        /// </summary>
        public State OverlayState { get; private set; } = State.Transition;

        /// <summary>
        /// �W�G��������Ԃ��ǂ���
        /// </summary>
        public bool IsClose => OverlayState is State.Close;

        /// <summary>
        /// �W�G��������Ԃ��ǂ���
        /// </summary>
        public bool IsOpen => OverlayState is State.Open;


        /// ----------------------------------------------------------------------------
        // Lifecycle Events

        protected async UniTaskVoid Start() {
            _canvasGroup = gameObject.GetComponent<CanvasGroup>();

            Initialize();

            // ������Ԃ�񓯊��Őݒ�
            await OpenInternal(0f);
            OverlayState = State.Open;
        }


        protected virtual void Initialize() {}


        /// ----------------------------------------------------------------------------
        // Public Methord

        /// <summary>
        /// Progress: 1��0�̉�ʑJ�ڃA�j���[�V����
        /// </summary>
        public async UniTask OpenAsync(float duration = 1f) {
            // �����S�ɕ����󋵂łȂ���ΏI��
            if (!IsClose) return;

            OverlayState = State.Transition;
            await OpenInternal(duration);
            OverlayState = State.Open;
        }

        /// <summary>
        /// Progress: 0��1�̉�ʑJ�ڃA�j���[�V����
        /// </summary>
        public async UniTask CloseAsync(float duration = 1f) {
            // �����S�ɊJ�����󋵂łȂ���ΏI��
            if (!IsOpen) return;

            OverlayState = State.Transition;
            await CloseInternal(duration);
            OverlayState = State.Close;
        }


        /// ----------------------------------------------------------------------------
        // Public Methord (�J�ڃA�j���[�V����)

        protected abstract UniTask OpenInternal(float duration);

        protected abstract UniTask CloseInternal(float duration);
    }

}