using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace nitou.DebugInternal {
    internal static partial class GizmoDrawer{

        /// <summary>
        /// ��{�}�`
        /// </summary>
        internal static class Basic {

            /// ----------------------------------------------------------------------------
            #region ��

            /// <summary>
            /// �_���ɐ܂����`�悷��
            /// </summary>
            public static void DrawLines(IReadOnlyList<Vector3> points) {
                if (points == null || points.Count <= 1) return;

                Vector3 from = points.First();
                points.Skip(1).ForEach(p => {
                    Gizmos.DrawLine(from, p);
                    from = p;
                });
            }

            /// <summary>
            /// �Q�O���[�v�̊e�Ή��_�����Ԑ���`�悷��
            /// </summary>
            public static void DrawLineSet(IReadOnlyList<Vector3> points1, IReadOnlyList<Vector3> points2) {
                if (points1 == null || points2 == null || points1.Count != points2.Count) return;

                for (int i = 0; i < points1.Count; i++) {
                    Gizmos.DrawLine(points1[i], points2[i]);
                }
            }
            #endregion

        }
    }
}
