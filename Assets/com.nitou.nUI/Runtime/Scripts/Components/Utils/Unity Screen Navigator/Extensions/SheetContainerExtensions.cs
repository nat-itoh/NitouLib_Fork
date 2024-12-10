using UnityEngine;

namespace UnityScreenNavigator.Runtime.Core.Sheet {

    /// <summary>
    /// <see cref="SheetContainer"/>�^�̊�{�I�Ȋg�����\�b�h�W�D
    /// </summary>
    public static class SheetContainerExtensions {

        /// <summary>
        /// �R���e�i���󂩂ǂ����D
        /// </summary>
        public static bool IsEmpty(this SheetContainer container) {
            return container.Sheets.Count == 0;
        }

        /// <summary>
        /// �A�N�e�B�u�ȃV�[�g�����݂��邩�ǂ����D
        /// </summary>
        public static bool HasActiveSheet(this SheetContainer container) {
            return container.ActiveSheet != null;
        }

    }
}
