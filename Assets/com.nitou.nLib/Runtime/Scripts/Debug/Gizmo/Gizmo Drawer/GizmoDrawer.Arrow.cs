using UnityEngine;

// [�Q�l]
//  github: MatthewMaker/DrawArrow.cs https://gist.github.com/MatthewMaker/5293052

namespace nitou.DebugInternal {
    internal static partial class GizmoDrawer {

        /// <summary>
        /// ���
        /// </summary>
        internal static class Arrow {

            public enum ArrowType {
                Line,
                Solid
            }

            private const int CIRCLE_SEGMENTS = 8;


            /// ----------------------------------------------------------------------------
            #region �`�惁�\�b�h

            /// <summary>
            /// �ʒu�C�������w�肵�Ė���`�悷��
            /// </summary>
            public static void DrawRayArrow(ArrowType type, Vector3 pos, Vector3 direction,
                float arrowHeadLength = 0.08f, float arrowHeadAngle = 20.0f) {

                // �����O�Ȃ�I��
                if (direction == Vector3.zero) return;

                // Arrow shaft
                Gizmos.DrawRay(pos, direction);

                // Arrow head
                switch (type) {
                    case ArrowType.Line: {
                            var (right, left) = CalcArrowHeadDirection(direction, arrowHeadAngle);
                            Gizmos.DrawRay(pos + direction, right * arrowHeadLength);
                            Gizmos.DrawRay(pos + direction, left * arrowHeadLength);
                            break;
                        }
                    case ArrowType.Solid: {
                            float radius = 0.025f;
                            Cylinder.DrawWireCone(
                                PlaneType.XY,   // ��Z��������ɉ�]
                                pos + direction,
                                Quaternion.LookRotation(direction),
                                radius,
                                arrowHeadLength,
                                CIRCLE_SEGMENTS);
                            break;
                        }
                }

            }

            /// <summary>
            /// �Q�_���w�肵�Ė���`�悷��
            /// </summary>
            public static void DrawLineArrow(ArrowType type, Vector3 from, Vector3 to,
                float arrowHeadLength = 0.2f, float arrowHeadAngle = 20.0f) {

                // �����O�Ȃ�I��
                if (Mathf.Approximately(Vector3.Distance(from, to), 0f)) return;

                // Arrow shaft
                Gizmos.DrawLine(from, to);

                // Arrow head
                var direction = to - from;
                switch (type) {
                    case ArrowType.Line: {
                            var (right, left) = CalcArrowHeadDirection(direction, arrowHeadAngle);
                            Gizmos.DrawRay(to, right * arrowHeadLength);
                            Gizmos.DrawRay(to, left * arrowHeadLength);
                            break;
                        }
                    case ArrowType.Solid: {
                            float radius = 0.025f;
                            Cylinder.DrawWireCone(
                                PlaneType.XY,   // ��Z��������ɉ�]
                                from + direction,
                                Quaternion.LookRotation(direction),
                                radius,
                                arrowHeadLength,
                                CIRCLE_SEGMENTS);
                            break;
                        }
                }


            }
            #endregion


            /// ----------------------------------------------------------------------------
            // Private Method

            /// <summary>
            /// ����[�̂Q�������v�Z����
            /// </summary>
            private static (Vector3 right, Vector3 left) CalcArrowHeadDirection(Vector3 direction, float arrowHeadAngle) =>
                (
                    right: Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * Vector3.forward,
                    left: Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * Vector3.forward
                );
        }
    }
}
