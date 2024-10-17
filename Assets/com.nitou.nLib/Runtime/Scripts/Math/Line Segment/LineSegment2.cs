using System.Linq;
using UnityEngine;

// [�Q�l]
//  �˂������V�e�B: �������m�̌������� https://nekojara.city/unity-line-segment-cross
//  qiita: �QD�����v�ZClass https://qiita.com/RYUMAGE/items/a00cdc92e65116f23183

namespace nitou {

    /// <summary>
    /// ������\���\����
    /// </summary>
    [System.Serializable]
    public struct LineSegment2 {

        public Vector2 start;
        public Vector2 end;


        /// ----------------------------------------------------------------------------
        // Property

        /// <summary>
        /// ���_
        /// </summary>
        public Vector2 Center => (start + end) * 0.5f;

        /// <summary>
        /// �����x�N�g��
        /// </summary>
        public Vector2 Vector => end - start;

        /// <summary>
        /// �@���x�N�g��
        /// </summary>
        public Vector2 Normal => Vector2.Perpendicular(Vector);


        /// ----------------------------------------------------------------------------
        // Public Method (��{���\�b�h)

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public LineSegment2(Vector2 start, Vector2 end) {
            this.start = start;
            this.end = end;
        }

        /// <summary>
        /// ����
        /// </summary>
        public LineSegment2 Clone() {
            return new LineSegment2(start, end);
        }

        /// <summary>
        /// �����x�N�g��
        /// </summary>
        public float Distance() {
            return Vector2.Distance(start, end);
        }

        /// <summary>
        /// �p�����[�^�i0~1�j���w�肵�Đ�����̓_���擾����
        /// </summary>
        public Vector2 GetPoint(float t) {
            return Vector2.Lerp(start, end, t);
        }

        /// <summary>
        /// ���������w�肵�āA������̓_����擾����
        /// </summary>
        public Vector2[] GetPoints(int num) {
            if (num <= 0) throw new System.InvalidOperationException("The number of divisions must be a positive integer greater than zero.");
            
            return EnumerableUtil.Linspace(start,end,num).ToArray();
        }

        /// <summary>
        /// �Q�̐��������s�����肷��
        /// </summary>
        public bool IsParallel(LineSegment2 other) {
            float cross = Cross(this.Vector, other.Vector);
            return Mathf.Abs(cross) < Vector2.kEpsilon;
        }

        /// <summary>
        /// �Q�̐������������Ă��邩�𔻒肷��
        /// </summary>
        public bool IsCrossing(LineSegment2 other) {
            Vector2 v1 = this.start - other.start;
            Vector2 v2 = this.end - other.start;
            Vector2 v3 = other.start - this.start;
            Vector2 v4 = other.end - this.start;
            return Cross(other.Vector, v1) * Cross(other.Vector, v2) < 0 &&
                Cross(this.Vector, v3) * Cross(this.Vector, v4) < 0;
        }

        /// <summary>
        /// �Q�̐����̌����_���v�Z����
        /// </summary>
        public Vector2 CrossPoint(LineSegment2 other) {
            Vector2 v1 = other.start - this.start;
            float nume = Cross(v1, other.Vector);
            float deno = Cross(Vector, other.Vector);

            // �������Ă��Ȃ��ꍇ�C
            if (Mathf.Abs(deno) < Mathf.Epsilon) {
                Debug_.LogWarning("Cross point is not exist.");
                return this.start;  // �������̊J�n�_��Ԃ�
            }

            float t = nume / deno;
            return this.start + Vector * t;
        }

        /// <summary>
        /// �ŋߖT�_���v�Z����
        /// </summary>
        public Vector2 GetNearestPoint(Vector2 point) {
            Vector2 v1 = point - start;
            float dot = Vector2.Dot(Vector, v1);

            Vector2 p = start + Vector * dot / Vector.sqrMagnitude;
            if (Vector2.Dot(p - start, Vector) < 0) {
                p = start;
            } else if (Vector2.Distance(start, p) > Distance()) {
                p = end;
            }

            return p;
        }

        /// <summary>
        /// �_�Ƃ̍ŒZ����
        /// </summary>
        public float DistanceFromPoint(Vector2 point) {
            return Vector2.Distance(GetNearestPoint(point), point);
        }


        /// ----------------------------------------------------------------------------
        // Static Method

        /// <summary>
        /// �O��
        /// </summary>
        public static float Cross(Vector2 vec1, Vector2 vec2) {
            return vec1.x * vec2.y - vec2.x * vec1.y;
        }        
    }
}
