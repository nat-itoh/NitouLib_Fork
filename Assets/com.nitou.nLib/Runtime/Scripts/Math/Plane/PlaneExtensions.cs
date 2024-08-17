using UnityEngine;

// [�Q�l]
//  Document: Plane https://docs.unity3d.com/ja/2023.2/ScriptReference/Plane.html
//  �˂������V�e�B: ���ʂ̌v�Z���y�ł���Plane�\���̂̎g���� https://nekojara.city/unity-plane-struct

namespace nitou {

    /// <summary>
    /// ����
    /// </summary>
    public enum PlaneType {
        XY,
        YZ,
        ZX,
    }

    /// <summary>
    /// <see cref="Plane"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class PlaneExtensions {

        /// <summary>
        /// 
        /// </summary>
        public static Vector3 GetPosition(this Plane self) {
            return self.normal * self.distance;
        }

        /// <summary>
        /// �I�[�o�[���b�v���Ă��邩���肷��g�����\�b�h
        /// </summary>
        public static bool IsOverlapping(this Plane self, Vector3 position, float radius) {
            if (radius <= 0f) throw new System.InvalidOperationException("radius must be greater than 0.");

            // ��Plane.GetDistanceToPoint�͕����t��������Ԃ��̂ŁC�Q��Ŕ�r
            return Mathf.Pow(self.GetDistanceToPoint(position), 2) <= Mathf.Pow(radius, 2);
        }

        /// <summary>
        /// �M�Y����\������
        /// </summary>
        public static void DrawGizmo(this Plane self, Color color) {
            Gizmos_.DrawSphere(self.GetPosition(), 0.1f, color);
            Gizmos_.DrawLineArrow(self.GetPosition(), self.normal, color);
        }

    }


    public static class PlaneUtil {

        /// <summary>
        /// ���ʂɑΉ������@���x�N�g�����擾����
        /// </summary>
        public static Vector3 GetNormal(this PlaneType type) {
            return type switch {
                PlaneType.XY => Vector3.forward,
                PlaneType.YZ => Vector3.right,
                PlaneType.ZX => Vector3.up,
                _ => throw new System.NotImplementedException()
            };
        }

    }

}
