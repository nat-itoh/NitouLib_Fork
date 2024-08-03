using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Alchemy.Inspector;

namespace nitou.SceneSystem {
    //using nitou.Sound;

    /// <summary>
    /// �V�[����ւ̎Q�ƋN�_�ƂȂ�I�u�W�F�N�g
    /// </summary>
    [DisallowMultipleComponent]
    public class SceneEntryPoint : MonoBehaviour, ISceneEntryPoint {

        [HideLabel]
        [SerializeField] private SceneType _sceneType = SceneType.MainLevel;

        // �J����
        [Group("Main Level Settings"), Indent]
        //[ShowIf("_sceneType", SceneType.MainLevel)]
        [SerializeField] private Camera _sceneCamera;

        // BGM
        [Group("Main Level Settings"), Indent]
        //[ShowIf("_sceneType", SceneType.MainLevel)]
        [SerializeField] private AudioClip _bgmClip;


        /// ----------------------------------------------------------------------------
        // Properity

        public Camera SceneCamera => _sceneCamera;
        public AudioClip SceneBGM => _bgmClip;


        /// ----------------------------------------------------------------------------
        // Protected Method

        protected virtual UniTask OnLoadInternal() => UniTask.CompletedTask;

        protected virtual UniTask OnUnloadInternal() => UniTask.CompletedTask;

        protected virtual UniTask OnActivateInternal() => UniTask.CompletedTask;

        protected virtual UniTask OnDeactivateInternal() => UniTask.CompletedTask;


        /// ----------------------------------------------------------------------------
        #region Interface Method

        /// <summary>
        /// �V�[�����ǂݍ��܂ꂽ���̏���
        /// </summary>
        async UniTask ISceneEntryPoint.OnSceneLoad() {

            if (_sceneCamera != null && SceneManager.sceneCount > 1) {
                _sceneCamera.gameObject.SetActive(false);
            }


            // �ʏ���
            //Debug_.Log("OnLoadInternal");
            await OnLoadInternal();
        }

        /// <summary>
        /// �V�[����������ꂽ���̏���
        /// </summary>
        async UniTask ISceneEntryPoint.OnSceneUnload() {
            await OnUnloadInternal();
        }

        /// <summary>
        /// �A�N�e�B�u�ȃV�[���ɐݒ肳�ꂽ���̏���
        /// </summary>
        async UniTask ISceneEntryPoint.OnSceneActivate() {

            // ���ʏ���
            switch (_sceneType) {
                case SceneType.MainLevel:

                    // �J�����̐؂�ւ�
                    if (_sceneCamera != null) {
                        CameraUtil.DeactivateAllCamera();
                        _sceneCamera.gameObject.SetActive(true);
                        _sceneCamera.enabled = true;
                    }

                    // BGM�Đ�
                    if (_bgmClip != null) {
                        //Sound.PlayBGM(_bgmClip);
                    }

                    break;

                case SceneType.SubLevel:
                    break;

                case SceneType.Other:
                    break;

                default:
                    break;
            }

            // �ʏ���
            await OnActivateInternal();
        }

        /// <summary>
        /// �A�N�e�B�u�ȃV�[������������ꂽ���̏���
        /// </summary>
        async UniTask ISceneEntryPoint.OnSceneDeactivate() {

            // ���ʏ���


            // �ʏ���
            await OnDeactivateInternal();
        }

        #endregion
    }
}
