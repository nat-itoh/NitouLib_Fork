using UnityEngine;

// [REF] 
//  LIGHT11: �V�[���̃��[�h�Ə������^�C�~���O�������Ɨ������� https://light11.hatenadiary.com/entry/2022/02/24/202754

namespace nitou.SceneSystem{

    /// <summary>
    /// �V�[���ǂݍ��݂��Ǘ�����N���X�D
    /// </summary>
    internal class SceneHandleManager : IInitializeOnEnterPlayMode {

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public SceneHandleManager() {
            SceneInitialization.Register(this);
        }

        /// <summary>
        /// 
        /// </summary>
        void IInitializeOnEnterPlayMode.OnEnterPlayMode() {
            throw new System.NotImplementedException();
        }




    }
}
