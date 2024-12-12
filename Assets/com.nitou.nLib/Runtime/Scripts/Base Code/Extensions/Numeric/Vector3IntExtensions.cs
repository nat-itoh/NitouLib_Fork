using System;
using UnityEngine;

// [�Q�l]
//  �R�K�l�u���O:�@Vector3Int�̑�����ȗ�������Deconstruction�@https://baba-s.hatenablog.com/entry/2019/09/03/230600

namespace nitou {

    public static partial class Vector3IntExtensions     {

        /// <summary>
        /// �f�R���X�g���N�^�D
        /// </summary>
        public static void Deconstruct(this Vector3Int self, out int x, out int y, out int z) {
            x = self.x;
            y = self.y;
            z = self.z;
        }
    }
}
