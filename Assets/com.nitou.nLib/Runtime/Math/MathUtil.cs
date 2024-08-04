using System.Collections.Generic;
using UnityEngine;

namespace nitou{

    /// <summary>
    /// <see cref="Mathf"/>�ɑ���Ȃ��@�\��񋟂��郆�[�e�B���e�B�N���X
    /// </summary>
    public static class MathUtil{

        /// ----------------------------------------------------------------------------
        #region �v�f�̎擾

        /// <summary>
        /// �v�f�̍ő�l��Ԃ�
        /// </summary>
        public static float Max(Vector2 vector) {
            return Mathf.Max(vector.x, vector.y);
        }

        /// <summary>
        /// �v�f�̍ő�l��Ԃ�
        /// </summary>
        public static float Max(Vector3 vector) {
            return Mathf.Max(vector.x, vector.y, vector.z);
        }

        /// <summary>
        /// �v�f�̍ŏ��l��Ԃ�
        /// </summary>
        public static float Min(Vector2 vector) {
            return Mathf.Min(vector.x, vector.y);
        }

        /// <summary>
        /// �v�f�̍ŏ��l��Ԃ�
        /// </summary>
        public static float Min(Vector3 vector) {
            return Mathf.Min(vector.x, vector.y, vector.z);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �~�`���W

        private const int MIN_SEGMENT = 3;

        /// <summary>
        /// �~��̍��W���擾����
        /// </summary>
        public static List<Vector3> CirclePoints(float radius = 1f, int segments = 20,
            Vector3 offset = default, bool isLoop = true,
            PlaneType type = PlaneType.ZX) {

            var pointCount = Mathf.Max(segments, MIN_SEGMENT);
            var deltaAngle = (Mathf.PI * 2) / pointCount;

            // ��360�x�̓_���܂߂����ꍇ�́{�P
            if (isLoop) pointCount++;

            // �_��̌v�Z
            var points = new List<Vector3>();
            for (int i = 0; i < pointCount; i++) {
                points.Add(CirclePoint(radius, i * deltaAngle, type) + offset);
            }
            return points;
        }

        /// <summary>
        /// �~��̍��W���擾����
        /// </summary>
        public static Vector3 CirclePoint(float radius, float angle, PlaneType type = PlaneType.ZX) {
         return type switch {
                PlaneType.XY => new Vector3(
                    x: radius * Mathf.Cos(angle),
                    y: radius * Mathf.Sin(angle),
                    z: 0f),
                PlaneType.YZ => new Vector3(
                    x: 0f,
                    y: radius * Mathf.Cos(angle),
                    z: radius * Mathf.Sin(angle)),
                PlaneType.ZX => new Vector3(
                    x: radius * Mathf.Sin(angle),
                    y: 0f,
                    z: radius * Mathf.Cos(angle)),
                _ => throw new System.NotImplementedException()
            };
        }      
        #endregion


        /// ----------------------------------------------------------------------------
        #region �p�x�ϊ�

        /// <summary>
        /// 2�����x�N�g������p�x(radian)�֕ϊ�����g�����\�b�h
        /// </summary>
        public static float VectorToRad(this Vector2 vector) {
            return Mathf.Atan2(vector.y, vector.x);
        }

        /// <summary>
        /// �p�x(radian)����2�����x�N�g���֕ϊ�����g�����\�b�h
        /// </summary>
        public static Vector2 RadToVector(this float radian) {
            return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        }

        /// <summary>
        /// 2�����x�N�g������p�x(degree)�֕ϊ�����g�����\�b�h
        /// </summary>
        public static float VectorToDeg(this Vector2 vector) {
            return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        }

        /// <summary>
        /// �p�x(degree)����2�����x�N�g���֕ϊ�����g�����\�b�h
        /// </summary>
        public static Vector2 DegToVector(this float degree) {
            return new Vector2(Mathf.Cos(degree * Mathf.Deg2Rad), Mathf.Sin(degree * Mathf.Deg2Rad));
        }

        #endregion

    }

}