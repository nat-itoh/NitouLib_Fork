using System.Collections.Generic;
using System.Linq;


namespace nitou {

    public interface IActivatable {

        /// <summary>
        /// �A�N�e�B�u�ȏ�Ԃ��ǂ���
        /// </summary>
        public bool IsActive { get; }

        /// <summary>
        /// �A�N�e�B�u��Ԃɂ���
        /// </summary>
        public void Activate();

        /// <summary>
        /// ��A�N�e�B�u��Ԃɂ���
        /// </summary>
        public void Deactivate();
    }


    /// <summary>
    /// <see cref="IActivatable"/>�^�̊g�����\�b�h�W
    /// </summary>
    public static class ActivatableExtensions {

        /// <summary>
        /// �S�ẴI�u�W�F�N�g���A�N�e�B�u���ǂ������m�F����
        /// </summary>
        public static bool AllActive(this IEnumerable<IActivatable> activatables) {
            return activatables.All(a => a.IsActive);
        }
    }
}