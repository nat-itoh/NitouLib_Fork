using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace nitou {

    /// <summary>
    /// <see cref="Bounds"/>�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class BoundsExtensions {

        /// <summary>
        /// ����<see cref="Bounds"/>���͈͓��Ɋ��S�Ɋ܂܂�Ă��邩�m�F����g�����\�b�h
        /// </summary>
        public static bool Contains(this Bounds self, Bounds other) {

            // AABB�̓��O����
            return self.Contains(other.min) && self.Contains(other.max);
        }


        /// <summary>
        /// ���҂��܂�Bounds��Ԃ��g�����\�b�h
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
        /// Gizmo��\������g�����\�b�h
        /// </summary>
        public static void DrawGizmo(this Bounds self){
            using (new Gizmos_.ColorScope(Color.green)) {
                Gizmos.DrawWireCube(self.center, self.size);
            }
        }

        /// <summary>
        /// Gizmo��\������g�����\�b�h
        /// </summary>
        public static void DrawGizmo(this Bounds self, Color color) {
            Gizmos.DrawCube(self.center, self.size);
        }
        #endregion
    }


    public static class BoundUtil {

        public static Bounds Union(IReadOnlyList<Bounds> boundsList) {
            if (boundsList == null || boundsList.Count < 1) throw new System.InvalidOperationException();
            if (boundsList.Count == 1) return boundsList.First();

            var min = boundsList.Select(b => b.min).Aggregate((minPt, nextPt) => Vector3.Min(minPt, nextPt));
            var max = boundsList.Select(b => b.max).Aggregate((maxPt, nextPt) => Vector3.Max(maxPt, nextPt));

            return new Bounds((min + max) * 0.5f, max - min);
        }
    }



}