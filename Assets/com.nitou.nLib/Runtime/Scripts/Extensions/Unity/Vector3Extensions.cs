using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Vector2�ւ̕ϊ�
        /// </summary>
        public static Vector2 ToVector2(this Vector3 vector) {
                return new Vector2(vector.x, vector.y);
            }

        /// <summary>
        /// �v�f���m�̊���Z
        /// </summary>
        public static Vector3 Divide(this Vector3 vector, Vector3 other) {
            return new Vector3(
                other.x != 0 ? vector.x / other.x : 0,
                other.y != 0 ? vector.y / other.y : 0,
                other.z != 0 ? vector.z / other.z : 0
            );
        }

        /// <summary>
        /// �v�f���m�̊���Z
        /// </summary>
        public static Vector3 Divide(this Vector3 vector, Vector3 other, float defaultValue) {
            return new Vector3(
                other.x != 0 ? vector.x / other.x : defaultValue,
                other.y != 0 ? vector.y / other.y : defaultValue,
                other.z != 0 ? vector.z / other.z : defaultValue
            );
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
        #region �l�̕ϊ�

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


        // �ȈՌv�Z

        
        #endregion









        public static Vector3 FindMinVector(IEnumerable<Vector3> ptList) {
            // LINQ���g�p���čŏ��̃x�N�g����������
            return ptList.Aggregate((minVec, nextVec) => Vector3.Min(minVec, nextVec));
        }
    }

}