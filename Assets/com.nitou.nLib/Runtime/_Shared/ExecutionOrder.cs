using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [�Q�l]
//  �˂������V�e�B: �X�N���v�g�̎��s�����𐧌䂷�� https://nekojara.city/unity-script-execution-order
//  �e���V���[��: �R���|�[�l���g�̃C�x���g���s���ɂ��Ă�Tips https://tsubakit1.hateblo.jp/entry/2017/02/05/003714

namespace nitou {

    public static class GameConfigs{

        /// <summary>
        /// ExecutionOrder���w�肷�邽�߂̐ÓI�N���X�i���I�[�_�[�l�̐ݒ�Ɋւ��Ă͖͍����j
        /// </summary>
        public static class ExecutionOrder {

            public const int VERY_FARST = -1000;
            public const int FARST = -100;
            public const int LATE = 100;
        }


    }
}
