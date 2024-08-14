using UnityEngine;

namespace nitou.HitSystem {

    /// <summary>
    /// �U����������I�u�W�F�N�g
    /// </summary>
    public interface IHitReciver<TData>  where TData : HitData{

        /// <summary>
        /// ���S�ʒu
        /// </summary>
        public Vector3 Center { get; }

        /// <summary>
        /// �q�b�g���̏���
        /// </summary>
        void OnReciveHit(TData hitData);
    }

}