using System;
using UnityEngine;

// [�Q�l]
//  �R�K�l�u���O:�@Vector3Int�̑�����ȗ�������Deconstruction�@https://baba-s.hatenablog.com/entry/2019/09/03/230600

namespace nitou {

    /// <summary>
    /// <see cref="Vector2Int"/>�^�̊�{�I�Ȋg�����\�b�h�W�D
    /// </summary>
    public static partial class Vector2IntExtensions     {

        /// <summary>
        /// �f�R���X�g���N�^�D
        /// </summary>
        public static void Deconstruct(this Vector2Int self, out int x, out int y) {
            x = self.x;
            y = self.y;
        }
    }
}
