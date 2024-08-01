using UnityEngine;

namespace nitou {

    /// <summary>
    /// <see cref="Animator"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static partial class AnimatorExtensions {

        /// <summary>
        /// ���ݍĐ����Ă���A�j���[�V�������I�����Ă��邩�H
        /// </summary>
        public static bool IsCompleted(this Animator self) {
            return self.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f;
        }

        /// <summary>
        /// ���ݍĐ����Ă���A�j���[�V�������w��X�e�[�g���I�����Ă��邩�H
        /// </summary>
        public static bool IsCompleted(this Animator self, int stateHash) {
            return self.GetCurrentAnimatorStateInfo(0).shortNameHash == stateHash && self.IsCompleted();
        }

        /// <summary>
        /// ���ݍĐ����Ă���A�j���[�V�����̎w�莞��(����)���߂��Ă��邩�H
        /// </summary>
        public static bool IsPassed(this Animator self, float normalizedTime) {
            return self.GetCurrentAnimatorStateInfo(0).normalizedTime > normalizedTime;
        }

        /// <summary>
        /// �A�j���[�V�������ŏ�����Đ�����
        /// </summary>
        public static void PlayBegin(this Animator self, int shortNameHash) {
            self.Play(shortNameHash, 0, 0.0f);
        }
    }

}