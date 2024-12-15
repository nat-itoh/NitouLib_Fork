using UnityEngine;
using Sirenix.OdinInspector;

// [REF]
//  qiita: 3D�I�u�W�F�N�g�̎c������ https://qiita.com/madoramu_f/items/fada99645cd03fd7f515
//  UnityIndies: �}�e���A���A�������ĂȂ��Ƃ����Ƀ��������[�N https://www.create-forever.games/unity-material-memory-leak/

namespace nitou.MaterialControl {

    /// <summary>
    /// �}�e���A���̑�����s���R���|�[�l���g�D
    /// </summary>
    public abstract class MaterialController<T> : MonoBehaviour, INormalizedValueTicker
        where T : MaterialHandler {

        [Title(IKey.TARGET)]

        [DisableInPlayMode]
        [SerializeField, Indent] Renderer _renderer = null;
        [ReadOnly]
        [SerializeField, Indent] Shader _shader = null;

        protected T _handler = null;

        [Title(IKey.PROPERITY)]
        [SerializeField, Indent] NormalizedValue _rate;

        /// <summary>
        /// �Ώۃ}�e���A���D
        /// </summary>
        public T Handler => _handler;

        /// <summary>
        /// �}�e���A���ϐ����ꊇ���삷�邽�߂̃v���p�e�B�D
        /// </summary>
        public NormalizedValue Rate {
            get => _rate;
            set {
                _rate = value;
                if (_handler != null) {
                    _handler.Rate = _rate;
                }
            }
        }


        /// ----------------------------------------------------------------------------
        // Lifecycle Events

        private void Awake() {
            _handler = CreateHandler(_shader);
            _renderer.SetSharedMaterial(_handler);

            _handler.Rate = _rate;
        }

        private void OnDestroy() {
            _handler?.Dispose();
        }

        private void OnValidate() {
            if (_renderer == null) _renderer = gameObject.GetComponent<Renderer>();
            if (_handler != null) {
                _handler.Rate = _rate;
            }
            if (_shader == null) _shader = FindShader();
        }


        /// ----------------------------------------------------------------------------
        // Protected Method 

        /// <summary>
        /// �n���h���[�𐶐�����D
        /// </summary>
        protected abstract T CreateHandler(Shader shader);

        /// <summary>
        /// �ΏۃV�F�[�_�[���擾����D
        /// </summary>
        protected abstract Shader FindShader();
    }

}

