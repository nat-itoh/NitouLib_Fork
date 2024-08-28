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

        /// [TODO] �@�\���\���ɑ��������ɁA�ȉ����e���\�b�h�֕t�^����
        //   [MethodImpl(MethodImplOptions.AggressiveInlining)]


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
        public static Vector2 ToVector2(this Vector3 self) {
                return new Vector2(self.x, self.y);
            }

        /// <summary>
        /// �v�f���m�̊���Z
        /// </summary>
        public static Vector3 Divide(this Vector3 self, Vector3 other) {
            return new Vector3(
                other.x != 0 ? self.x / other.x : 0,
                other.y != 0 ? self.y / other.y : 0,
                other.z != 0 ? self.z / other.z : 0
            );
        }

        /// <summary>
        /// �v�f���m�̊���Z
        /// </summary>
        public static Vector3 Divide(this Vector3 self, Vector3 other, float defaultValue) {
            return new Vector3(
                other.x != 0 ? self.x / other.x : defaultValue,
                other.y != 0 ? self.y / other.y : defaultValue,
                other.z != 0 ? self.z / other.z : defaultValue
            );
        }


        /// ----------------------------------------------------------------------------
        #region �v�f�̔���

        /// <summary>
        /// �ő�̗v�f�̒l���擾����
        /// </summary>
        public static float MaxElement(this Vector3 self) {
            return Mathf.Max(self.x, self.y, self.z);
        }

        /// <summary>
        /// �ŏ��̗v�f�̒l���擾����
        /// </summary>
        public static float MinElement(this Vector3 self) {
            return Mathf.Min(self.x, self.y, self.z);
        }

        /// <summary>
        /// �ő�̗v�f�̎����擾����
        /// </summary>
        public static Axis MaxAxis(this Vector3 self) {
            // [NOTE] �l���������ꍇ��(x , y , z)�̏��ŗD�悳���
            if (self.x >= self.y && self.x >= self.z) {
                return Axis.X;
            } else if (self.y >= self.x && self.y >= self.z) {
                return Axis.Y;
            } else {
                return Axis.Z;
            }
        }

        /// <summary>
        /// �ŏ��̗v�f�̎����擾����
        /// </summary>
        public static Axis MinAxis(this Vector3 self) {
            // [NOTE] �l���������ꍇ��(x > y > z)�̏��ŗD�悳���
            if (self.x <= self.y && self.x <= self.z) {
                return Axis.X;
            } else if (self.y <= self.x && self.y <= self.z) {
                return Axis.Y;
            } else {
                return Axis.Z;
            }
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �l�̕ϊ� 

        /// <summary>
        /// X�l�̂ݕύX�����l��Ԃ��g�����\�b�h
        /// </summary>
        public static Vector3 WithX(this Vector3 self, float x) => new Vector3(x, self.y, self.z);

        /// <summary>
        /// Y�l�̂ݕύX�����l��Ԃ��g�����\�b�h
        /// </summary>
        public static Vector3 WithY(this Vector3 self, float y) => new Vector3(self.x, y, self.z);

        /// <summary>
        /// Z�l�̂ݕύX�����l��Ԃ��g�����\�b�h
        /// </summary>
        public static Vector3 WithZ(this Vector3 self, float z) => new Vector3(self.x, self.y, z);

        // ------ 

        /// <summary>
        /// X�l�̂ݕύX�����l��Ԃ��g�����\�b�h
        /// </summary>
        public static Vector3 KeepX(this Vector3 self) => new Vector3(self.x, 0, 0);

        /// <summary>
        /// Y�l�̂ݕύX�����l��Ԃ��g�����\�b�h
        /// </summary>
        public static Vector3 KeepY(this Vector3 self) => new Vector3(0, self.y, 0);

        /// <summary>
        /// Z�l�̂ݕύX�����l��Ԃ��g�����\�b�h
        /// </summary>
        public static Vector3 KeepZ(this Vector3 self) => new Vector3(0, 0, self.z);

        /// <summary>
        /// Vector3��x, y, z�̂����ő�̗v�f�݂̂�ێ����A���̗v�f��0�ɂ���g�����\�b�h
        /// </summary>
        public static Vector3 KeepMax(this Vector3 self) {

            // �ő�̒l�����v�f�̂ݕێ�
            if (self.x >= self.y && self.x >= self.z) {
                return self.KeepX();
            } else if (self.y >= self.x && self.y >= self.z) {
                return self.KeepY();
            } else {
                return self.KeepZ();
            }
        }

        /// <summary>
        /// Vector3��x, y, z�̂����ŏ��̗v�f�݂̂�ێ����A���̗v�f��0�ɂ���g�����\�b�h
        /// </summary>
        public static Vector3 KeepMin(this Vector3 self) {

            // �ő�̒l�����v�f�̂ݕێ�
            if (self.x <= self.y && self.x <= self.z) {
                return self.KeepX();
            } else if (self.y <= self.x && self.y <= self.z) {
                return self.KeepY();
            } else {
                return self.KeepZ();
            }
        }


        #endregion


        /// ----------------------------------------------------------------------------
        #region �l�̕ϊ� 

        /// <summary>
        /// �S�Ă̗v�f�𐳂̒l�ɂ���g�����\�b�h
        /// </summary>
        public static Vector3 Positate(this Vector3 self) => new Vector3(Mathf.Abs(self.x), Mathf.Abs(self.y), Mathf.Abs(self.z));

        /// <summary>
        /// �S�Ă̗v�f�𕉂̒l�ɂ���g�����\�b�h
        /// </summary>
        public static Vector3 Negate(this Vector3 self) => new Vector3(Mathf.Abs(self.x), Mathf.Abs(self.y), Mathf.Abs(self.z));

        // -----

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

        #endregion




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

        /// <summary>
        /// �S�Ă̗v�f���w��͈͓̔���Clamp����g�����\�b�h
        /// </summary>
        public static Vector3 Clamp(this Vector3 self, float min, float max) {
            return new Vector3(
                Mathf.Clamp(self.x, min, max), 
                Mathf.Clamp(self.y, min, max), 
                Mathf.Clamp(self.z, min, max));
        }

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


        
        #endregion


        public static Vector3 FindMinVector(IEnumerable<Vector3> ptList) {
            // LINQ���g�p���čŏ��̃x�N�g����������
            return ptList.Aggregate((minVec, nextVec) => Vector3.Min(minVec, nextVec));
        }
    }

}