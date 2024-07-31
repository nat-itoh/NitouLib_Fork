using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// [�Q�l]
//  �R�K�l�u���O: Vector2 �̑�����ȗ������� Deconstruction https://baba-s.hatenablog.com/entry/2019/09/03/230900

namespace nitou {

    /// <summary>
    /// <see cref="Vector2"/>�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class Vector2Extensions {

        /// <summary>
        /// �f�R���X�g���N�^
        /// </summary>
        public static void Deconstruct(this Vector2 self, out float x, out float y) {
            x = self.x;
            y = self.y;
        }


        /// ----------------------------------------------------------------------------
        #region �l�̎擾

        /// <summary>
        /// �ő�̗v�f�̒l���擾����
        /// </summary>
        public static float MaxElement(this Vector2 self) {
            return Mathf.Max(self.x, self.y);
        }

        /// <summary>
        /// �ŏ��̗v�f�̒l���擾����
        /// </summary>
        public static float MixElement(this Vector2 self) {
            return Mathf.Min(self.x, self.y);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        // �ȈՌv�Z

        public static float Angle(this Vector2 self, Vector2 other) {
            return Vector2.Angle(self, other);
        }

        public static float SignedAngle(this Vector2 self, Vector2 other) {
            return Vector2.SignedAngle(self, other);
        }

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
