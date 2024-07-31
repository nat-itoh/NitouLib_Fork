using UnityEngine;

namespace nitou {

    /// <summary>
    /// LayerMask�̊g�����\�b�h�N���X
    /// </summary>
    public static class LayerMaskExtensions {

        /// ----------------------------------------------------------------------------
        #region Layer�̔���

        /// <summary>
        /// LayerMask�Ɏw�肵�����C���[���܂܂�Ă��邩�ǂ����𒲂ׂ�g�����\�b�h
        /// </summary>
        public static bool Contains(this LayerMask self, int layerId) {
            return ((1 << layerId) & self) != 0;
        }

        /// <summary>
        /// LayerMask�Ɏw�肵�����C���[���܂܂�Ă��邩�ǂ����𒲂ׂ�g�����\�b�h
        /// </summary>
        public static bool Contains(this LayerMask self, string layerName) {
            return self.Contains(LayerMask.NameToLayer(layerName));
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region Layer�̒ǉ�/�폜

        /// <summary>
        /// LayerMask�Ɏw�肵�����C���[��ǉ�����g�����\�b�h
        /// </summary>
        public static LayerMask Add(this LayerMask self, LayerMask layerId) {
            return self | (1 << layerId);
        }

        /// <summary>
        /// LayerMask�Ɏw�肵�����C���[��ǉ�����g�����\�b�h
        /// </summary>
        public static LayerMask Add(this LayerMask self, string layerName) {
            return self.Add(LayerMask.NameToLayer(layerName));
        }

        /// <summary>
        /// LayerMask����w�肵�����C���[���폜����g�����\�b�h
        /// </summary>
        public static LayerMask Remove(this LayerMask self, LayerMask layerId) {
            return self & ~(1 << layerId);
        }

        /// <summary>
        /// LayerMask����w�肵�����C���[���폜����g�����\�b�h
        /// </summary>
        public static LayerMask Remove(this LayerMask self, string layerName) {
            return self.Remove(LayerMask.NameToLayer(layerName));
        }

        /// <summary>
        /// LayerMask�Ɏw�肵�����C���[��ǉ�/�폜�̐؂�ւ�
        /// </summary>
        public static LayerMask Toggle(this LayerMask self, LayerMask layerId) {
            return self ^ (1 << layerId);
        }

        /// <summary>
        /// LayerMask�Ɏw�肵�����C���[��ǉ�/�폜�̐؂�ւ�
        /// </summary>
        public static LayerMask Toggle(this LayerMask self, string layerName) {
            return self.Toggle(LayerMask.NameToLayer(layerName));
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region ���̑�

        /// <summary>
        /// 
        /// </summary>
        public static string ToBinaryString(this LayerMask self) {
            // LayerMask �̒l���擾���A2�i���̕�����ɕϊ�����
            return System.Convert.ToString(self.value, 2).PadLeft(32, '0');
        }

        #endregion

    }
}
