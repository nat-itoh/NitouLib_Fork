using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Alchemy.Inspector;

// [�Q�l] 
//  qiita: ���܂���Collider��isTrigger���������Ĕ��肷����@��m�����̂Ń��� https://qiita.com/tsujihaneta/items/ec656c2092e06a881ca8

namespace nitou.HitSystem {
    using nitou.BachProcessor;

    /// <summary>
    /// �R���W�������o�p�R���|�[�l���g�̊��N���X
    /// </summary>
    public abstract class CollisionDetectorBase : ComponentBase {

        [Title("Update Settings")]

        /// <summary>
        /// ���s�^�C�~���O
        /// </summary>
        [DisableInPlayMode]
        //[HideLabel]
        [SerializeField, Indent] protected UpdateTiming Timing = UpdateTiming.Update;


        [Title("Hit Settings")]

        [DisableInPlayMode]
        [SerializeField, Indent] protected CachingTarget _cacheTargetType = CachingTarget.Collider;

        [DisableInPlayMode]
        [SerializeField, Indent] protected LayerMask _hitLayer;

        [DisableInPlayMode]
        [SerializeField, Indent] protected bool _useHitTag = false;

        [ShowIf("@_useHitTag")]
        [DisableInPlayMode]
        [SerializeField, Indent] protected string[] _hitTagArray;

        // --- 

        /// <summary>
        /// List of collided colliders.
        /// The indices correspond to those in <see cref="_hitObjects" />.
        /// </summary>
        protected readonly List<Collider> _hitColliders = new();

        /// <summary>
        /// List of colliders hit while the component is active.
        /// </summary>
        protected readonly List<GameObject> _hitObjects = new();

        /// <summary>
        /// List of colliders hit during the current frame.
        /// </summary>
        protected readonly List<Collider> _hitCollidersInThisFrame = new();

        /// <summary>
        /// List of GameObjects hit during the current frame.
        /// The type of objects stored may vary depending on the value of <see cref="CacheTargetType" />.
        /// </summary>
        protected readonly List<GameObject> _hitObjectsInThisFrame = new();


        /// ----------------------------------------------------------------------------
        // Property

        /// <summary>
        /// �q�b�g���Ă��邩�ǂ����i�R���C�_�[�����݂��邩�ǂ����j
        /// </summary>
        public bool IsHit => _hitColliders.Count > 0;

        /// <summary>
        /// True if there is contact with colliders in the current frame.
        /// This information is updated at the beginning of the frame when the component is active.
        /// </summary>
        public bool IsHitInThisFrame => _hitCollidersInThisFrame.Count > 0;

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyList<GameObject> HitObjects => _hitObjects;

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyList<GameObject> HitObjectsInThisFrame => _hitObjectsInThisFrame;


        /// <summary>
        /// �R���W���������o���ꂽ�Ƃ��̃C�x���g�ʒm
        /// </summary>
        public System.IObservable<List<GameObject>> OnHitObjects => _onHitObjectsSubject;
        private Subject<List<GameObject>> _onHitObjectsSubject = new();


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method

        protected virtual void Reset() {
            _hitLayer = LayerMaskUtil.Only("Default");
        }

        protected virtual void OnDestroy() {
            _onHitObjectsSubject.Dispose();
        }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// Retrieves the Collider associated with the object contained in <see cref="_hitObjects" />.
        /// </summary>
        public Collider GetColliderForGameObject(GameObject obj) {
            // If obj exists within HitObjects, return the corresponding Collider.
            // Otherwise, return null.
            var index = _hitObjects.IndexOf(obj);
            return index == -1 ? null : _hitCollidersInThisFrame[index];
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// Initializes a list of colliders that this component has collided with.
        /// </summary>
        protected void InitializeBufferOfCollidedCollision() {
            _hitColliders.Clear();
            _hitObjects.Clear();
            _hitObjectsInThisFrame.Clear();
            _hitCollidersInThisFrame.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        protected GameObject GetHitObject(Collider hit) {

            switch (_cacheTargetType) {
                case CachingTarget.RootObject: {
                        // Returns the root object of the collision target.
                        return hit.transform.root.gameObject;
                    }
                case CachingTarget.Rigidbody: {
                        // ��Rigidbody��null�̏ꍇ�C�R���C�_�[��Ԃ�.
                        var attachedRigidbody = hit.attachedRigidbody;
                        return (attachedRigidbody != null) ? attachedRigidbody.gameObject : hit.gameObject;
                    }
                case CachingTarget.CharacterController: {
                        // If the parent object of the collided target has a CharacterController, return the object with the CharacterController attached.
                        var controller = hit.transform.GetComponentInParent<CharacterController>();
                        return controller != null ? controller.gameObject : hit.gameObject;
                    }
                case CachingTarget.RigidbodyOrCharacterController: {
                        // If the parent object has a Rigidbody, return the object with the Rigidbody attached.
                        var attachedRigidbody = hit.attachedRigidbody;
                        if (attachedRigidbody != null)
                            return attachedRigidbody.gameObject;

                        // If the parent object has a CharacterController, return the object with the CharacterController attached.
                        var controller = hit.transform.GetComponentInParent<CharacterController>();
                        if (controller != null)
                            return controller.gameObject;

                        // If none of the above conditions are met, return the current Collider.
                        return hit.gameObject;
                    }
                default:
                    // Returns the GameObject of the collided Collider.
                    return hit.gameObject;
            }


        }

        /// <summary>
        /// �C�x���g�𔭉΂���
        /// </summary>
        protected void RaiseOnHitEvent(List<GameObject> objects) {
            _onHitObjectsSubject.OnNext(objects);
        }
    }

}
