using UniRx;
using UnityEngine;

namespace nitou.HitSystem{
    using nitou.Inspector;

    /// <summary>
    /// �q�b�g��^����I�u�W�F�N�g
    /// </summary>
    public abstract class HitVolume<TData> : MonoBehaviour, IHitProvider<TData>
        where TData : HitData {

        [DisableInPlayMode]
        [SerializeField, Indent] protected LayerMask _hitLayer;

        protected Subject<TData> _onHitApplySubject = new();

        /// <summary>
        /// �R���C�_�[
        /// </summary>
        public abstract Collider Collider { get; }
                
        /// <summary>
        /// �q�b�g���̒ʒm
        /// </summary>
        public System.IObservable<TData> OnHitApplay => _onHitApplySubject;


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method 

        protected virtual void Reset() {
            _hitLayer = LayerMaskUtil.OnlyDefault();
        }

        protected void OnEnable() {
            if (Collider != null) {
                Collider.enabled = true;
                Collider.isTrigger = true;
            }
        }

        protected void OnDisable() {
            if (Collider != null) {
                Collider.enabled = false;
            }
        }

        protected void OnDestroy() {
            _onHitApplySubject.Dispose();
            _onHitApplySubject = null;
        }

        protected void OnTriggerEnter(Collider other) {
            if (other.TryGetComponent<IHitReciver<TData>>(out var reciver)
                && other.IsInLayerMask(_hitLayer)) {

                // �q�b�g����
                var data = CreateHitData(reciver);
                reciver.OnReciveHit(data);

                // �C�x���g�ʒm
                _onHitApplySubject.OnNext(data);
            }
        }


        /// ----------------------------------------------------------------------------
        // Public Method 

        /// <summary>
        /// �q�b�g�f�[�^�𐶐�����
        /// </summary>
        public abstract TData CreateHitData(IHitReciver<TData> reciver);

    }
}
