using UnityEngine;

// [�Q�l]
//  _: Unity��LayerMask�𑀍삷����@�F�X https://12px.com/blog/2021/11/layermask/
//  Hatena: �������Z�A�Փ˔���A�R���C�_�[�̌��o�ȂǂŎg��LayerMask�ɂ��� https://indie-game-creation-with-unity.hatenablog.com/entry/layer-mask

namespace nitou {

    /// <summary>
    /// LayerMask�ɐÓI���\�b�h��ǉ�����N���X
    /// </summary>
    public static class LayerMaskUtil {

        /// ----------------------------------------------------------------------------
        // Public Method�@(LayerMAsk�̐���)

        /// <summary>
        /// �S�ē�����LayerMask
        /// </summary>
        public static LayerMask AllIn => -1;

        /// <summary>
        /// ���LayerMask
        /// </summary>
        public static LayerMask Empty => 1;

        /// <summary>
        /// ���背�C���[�̂ݓ�����LayerMask
        /// </summary>
        public static LayerMask Only(int layer) => 1 << layer;

        /// <summary>
        /// ���背�C���[�̂ݓ�����LayerMask
        /// </summary>
        public static LayerMask Only(string layerName) => 1 << LayerMask.NameToLayer(layerName);

        /// <summary>
        /// "Default"�̂ݓ�����LayerMask
        /// </summary>
        public static LayerMask OnlyDefault() => Only("Default");   // ��0�ł���

    }

}
