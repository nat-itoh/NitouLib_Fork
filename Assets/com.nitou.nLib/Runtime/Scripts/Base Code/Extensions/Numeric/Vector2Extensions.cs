using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// [�Q�l]
//  �R�K�l�u���O: Vector2 �̑�����ȗ������� Deconstruction https://baba-s.hatenablog.com/entry/2019/09/03/230900

namespace nitou {

    /// <summary>
    /// <see cref="Vector2"/>�^�̊�{�I�Ȋg�����\�b�h�W�D
    /// </summary>
    public static partial class Vector2Extensions {

        /// <summary>
        /// �f�R���X�g���N�^�D
        /// </summary>
        public static void Deconstruct(this Vector2 self, out float x, out float y) {
            x = self.x;
            y = self.y;
        }


        /// ----------------------------------------------------------------------------
        #region �l�̎擾

        /// <summary>
        /// �ő�̗v�f�̒l���擾����g�����\�b�h�D
        /// </summary>
        public static float MaxElement(this Vector2 self) {
            return Mathf.Max(self.x, self.y);
        }

        /// <summary>
        /// �ŏ��̗v�f�̒l���擾����g�����\�b�h�D
        /// </summary>
        public static float MixElement(this Vector2 self) {
            return Mathf.Min(self.x, self.y);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        // �ȈՌv�Z

        /// <summary>
        /// �p�x���v�Z����g�����\�b�h�D
        /// </summary>
        public static float Angle(this Vector2 self, Vector2 other) {
            return Vector2.Angle(self, other);
        }

        /// <summary>
        /// 
        /// </summary>
        public static float SignedAngle(this Vector2 self, Vector2 other) {
            return Vector2.SignedAngle(self, other);
        }

        /// <summary>
        /// 
        /// </summary>
        public static float Angle90(this Vector2 self, Vector2 other) {
            var degree = Vector2.Angle(self, other);
            return (degree <= 90) ? degree : degree -90;
        }


        /// ----------------------------------------------------------------------------
        // �ȈՌv�Z

        /// <summary>
        /// �����̒l��Ԃ�
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Half(this Vector2 self) => self * 0.5f;

        /// <summary>
        /// �Q�{�̒l��Ԃ�
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Twice(this Vector2 self) => self * 2f;

    }
}
