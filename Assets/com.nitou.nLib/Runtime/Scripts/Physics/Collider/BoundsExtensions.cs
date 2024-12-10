using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace nitou {

    /// <summary>
    /// <see cref="Bounds"/>�̊�{�I�Ȋg�����\�b�h�W�D
    /// </summary>
    public static class BoundsExtensions {

        /// <summary>
        /// Bounds �̑S���_���擾���܂��B
        /// </summary>
        /// <param name="bounds">�Ώۂ� Bounds</param>
        /// <returns>�S8���_�̔z��</returns>
        public static Vector3[] GetCorners(this Bounds bounds) {
            Vector3[] corners = new Vector3[8];
            corners[0] = bounds.min; // ������
            corners[1] = new Vector3(bounds.min.x, bounds.min.y, bounds.max.z); // ������O
            corners[2] = new Vector3(bounds.min.x, bounds.max.y, bounds.min.z); // ���㉜
            corners[3] = new Vector3(bounds.min.x, bounds.max.y, bounds.max.z); // �����O
            corners[4] = new Vector3(bounds.max.x, bounds.min.y, bounds.min.z); // �E����
            corners[5] = new Vector3(bounds.max.x, bounds.min.y, bounds.max.z); // �E����O
            corners[6] = new Vector3(bounds.max.x, bounds.max.y, bounds.min.z); // �E�㉜
            corners[7] = bounds.max; // �E���O
            return corners;
        }

        /// <summary>
        /// ����<see cref="Bounds"/>���͈͓��Ɋ��S�Ɋ܂܂�Ă��邩�m�F����g�����\�b�h�D
        /// </summary>
        public static bool Contains(this Bounds self, Bounds other) {

            // AABB�̓��O����
            return self.Contains(other.min) && self.Contains(other.max);
        }

        /// <summary>
        /// ���҂��܂�Bounds��Ԃ��g�����\�b�h�D
        /// </summary>
        public static Bounds Union(this Bounds a, Bounds b) {
            // Calculate the minimum and maximum corners of the union bounds
            var min = Vector3.Min(a.min, b.min);
            var max = Vector3.Max(a.max, b.max);

            // Create and return a new Bounds that encompasses both
            return new Bounds((min + max) * 0.5f, max - min);
        }


        /// ----------------------------------------------------------------------------
        #region Gizmos

        /// <summary>
        /// Gizmo��\������g�����\�b�h�D
        /// </summary>
        public static void DrawGizmo(this Bounds self, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                Gizmos.DrawWireCube(self.center, self.size);
            }
        }

        /// <summary>
        /// Gizmo��\������g�����\�b�h�D
        /// </summary>
        public static void DrawGizmo(this Bounds self) => DrawGizmo(self, Colors.Green);
        #endregion
    }


    public static class BoundUtil {

        public static Bounds Union(IReadOnlyCollection<Bounds> bounds) {
            if (bounds == null || bounds.Count < 1) throw new System.InvalidOperationException();
            if (bounds.Count == 1) return bounds.First();

            var min = bounds.Select(b => b.min).Aggregate((minPt, nextPt) => Vector3.Min(minPt, nextPt));
            var max = bounds.Select(b => b.max).Aggregate((maxPt, nextPt) => Vector3.Max(maxPt, nextPt));

            return new Bounds((min + max) * 0.5f, max - min);
        }
    }
}