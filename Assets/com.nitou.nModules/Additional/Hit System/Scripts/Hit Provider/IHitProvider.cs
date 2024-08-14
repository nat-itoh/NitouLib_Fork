using UnityEngine;

namespace nitou.HitSystem{

    /// <summary>
    /// �U�������^����I�u�W�F�N�g
    /// </summary>
    public interface IHitProvider<TData> where TData : HitData{

        /// <summary>
        /// �q�b�g�f�[�^�𐶐�����
        /// </summary>
        public TData CreateHitData(IHitReciver<TData> reciver);
    }
}
