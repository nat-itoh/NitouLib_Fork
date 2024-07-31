using System.Runtime.CompilerServices;
using UnityEngine;

// [�Q�l]
//  PG���� : Vector3(�\����)�Ɏ������g�̒l��ύX����g�����\�b�h���`���� https://takap-tech.com/entry/2022/12/24/175039
//  �R�K�l�u���O:�@Vector3 �̑�����ȗ������� Deconstruction�@https://baba-s.hatenablog.com/entry/2019/09/03/230700

namespace nitou {

    /// <summary>
    /// <see cref="Vector3"/>�̊g�����\�b�h�N���X
    /// </summary>
    public static partial class Vector3Extensions {

        /// <summary>
        /// �f�R���X�g���N�^
        /// </summary>
        public static void Deconstruct(this Vector3 self, out float x, out float y, out float z) {
            x = self.x;
            y = self.y;
            z = self.z;
        }


        /// ----------------------------------------------------------------------------
        #region �l�̎擾

        /// <summary>
        /// �ő�̗v�f�̒l���擾����
        /// </summary>
        public static float MaxElement(this Vector3 self) {
            return Mathf.Max(self.x, self.y, self.z);
        }

        /// <summary>
        /// �ŏ��̗v�f�̒l���擾����
        /// </summary>
        public static float MixElement(this Vector3 self) {
            return Mathf.Min(self.x, self.y, self.z);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        // �l�̐ݒ�

        /// <summary>
        /// X�l��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetX(ref this Vector3 self, float x) => self.x = x;

        /// <summary>
        /// Y�l��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetY(ref this Vector3 self, float y) => self.y = y;

        /// <summary>
        /// Z�l��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetZ(ref this Vector3 self, float z) => self.z = z;


        /// ----------------------------------------------------------------------------
        // �l�̉��Z

        /// <summary>
        /// X�l�ɉ��Z����g�����\�b�h
        /// </summary>
        public static void AddX(ref this Vector3 self, float x) => self.x += x;

        /// <summary>
        /// Y�l�ɉ��Z����g�����\�b�h
        /// </summary>
        public static void AddY(ref this Vector3 self, float y) => self.y += y;

        /// <summary>
        /// Z�l�ɉ��Z����g�����\�b�h
        /// </summary>
        public static void AddZ(ref this Vector3 self, float z) => self.z += z;




        /// ----------------------------------------------------------------------------
        // Clamp

        /// <summary>
        /// <see cref="Vector3.ClampMagnitude(Vector3, float)"/>�̊g�����\�b�h
        /// </summary>
        public static Vector3 ClampMagnitude(this Vector3 self, float maxLength) {
            return Vector3.ClampMagnitude(self, maxLength);
        }

        /// <summary>
        /// <see cref="Vector3.ClampMagnitude(Vector3, float)"/>�̊g�����\�b�h
        /// </summary>
        public static Vector3 ClampMagnitude01(this Vector3 self) {
            return Vector3.ClampMagnitude(self, 1);
        }


        /// ----------------------------------------------------------------------------
        // �ȈՌv�Z

        /// <summary>
        /// �����̒l��Ԃ��g�����\�b�h
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Half(this Vector3 self) => self * 0.5f;

        /// <summary>
        /// �Q�{�̒l��Ԃ��g�����\�b�h
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Twice(this Vector3 self) => self * 2f;


        /// ----------------------------------------------------------------------------
        // �ȈՌv�Z

        /// <summary>
        /// X�l�̂ݕύX�����l��Ԃ��g�����\�b�h
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 WithX(this Vector3 self, float x) => new Vector3(x, self.y, self.z);

        /// <summary>
        /// Y�l�̂ݕύX�����l��Ԃ��g�����\�b�h
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 WithY(this Vector3 self, float y) => new Vector3(self.x, y, self.z);

        /// <summary>
        /// Z�l�̂ݕύX�����l��Ԃ��g�����\�b�h
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 WithZ(this Vector3 self, float z) => new Vector3(self.x, self.y, z);
    }

}