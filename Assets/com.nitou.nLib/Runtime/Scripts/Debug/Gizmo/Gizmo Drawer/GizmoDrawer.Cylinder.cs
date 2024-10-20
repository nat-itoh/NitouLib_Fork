using UnityEngine;
using nitou.DesignPattern.Pooling;

// [�Q�l]
//  Kan�̃�����: �M�Y���Ŗ��A�~���A�J�v�Z���A�~�A�ʂ�`��o����悤�ɂ���GizmoExtensions https://kan-kikuchi.hatenablog.com/entry/GizmoExtensions

namespace nitou.DebugInternal {
    internal static partial class GizmoDrawer {

        /// <summary>
        /// �~��
        /// </summary>
        internal static class Cylinder {

            /// <summary>
            /// �~�`���`����p�����[�^
            /// </summary>
            private struct DiscParam {
                public float radius;
                public int segments;
                public float offset;

                public DiscParam(float radius, int segments, float offset = default) {
                    this.radius = radius;
                    this.segments = segments;
                    this.offset = offset;
                }
            }


            /// ----------------------------------------------------------------------------
            #region �`�惁�\�b�h

            /// <summary>
            /// �~����`�悷��
            /// </summary>
            public static void DrawWireCylinder(PlaneType type, Vector3 center, Quaternion rotation, float radius, float height,int discSegments = 20) {

                if (rotation.Equals(default)) {
                    rotation = Quaternion.identity;
                }

                var matrix = Matrix4x4.TRS(center, rotation, Vector3.one);
                using (new GizmoUtil.MatrixScope(matrix)) {

                    var half = height / 2;

                    // Outer lines
                    int outerSegments = 5;
                    DrawWireCylinderOuterLines(
                        type,
                        new DiscParam(radius, outerSegments, half),
                        new DiscParam(radius, outerSegments, -half)
                    );

                    // Disks
                    DrawWireDisc(type, new DiscParam(radius, discSegments, half));
                    DrawWireDisc(type, new DiscParam(radius, discSegments, -half));
                }

            }

            /// <summary>
            /// �~����`�悷��
            /// </summary>
            public static void DrawWireCone(PlaneType type, Vector3 center, Quaternion rotation, float radius, float height,int discSegments = 20) {

                if (rotation.Equals(default)) {
                    rotation = Quaternion.identity;
                }

                var matrix = Matrix4x4.TRS(center, rotation, Vector3.one);
                using (new GizmoUtil.MatrixScope(matrix)) {

                    // Outer lines
                    int outerSegments = 5;
                    DrawWireConeOuterLines(type, new DiscParam(radius, outerSegments), height);

                    // Disks
                    DrawWireDisc(type, new DiscParam(radius, discSegments));
                }
            }
            #endregion


            /// ----------------------------------------------------------------------------
            #region Private Method

            /// <summary>
            /// �~���̑��ʕ���`�悷��
            /// </summary>
            private static void DrawWireCylinderOuterLines(PlaneType planeType, DiscParam upperDisc, DiscParam lowerDisc) {
                if (upperDisc.segments != lowerDisc.segments) return;

                // ���X�g�擾
                var upperPoints = ListPool<Vector3>.New();
                var lowerPoints = ListPool<Vector3>.New();

                // ���W�v�Z
                MathUtil.CirclePoints(
                    radius: upperDisc.radius,
                    resultPoints: upperPoints,
                    segments: upperDisc.segments,
                    offset: upperDisc.offset * planeType.GetNormal(),
                    isLoop: false,
                    type: planeType
                );
                MathUtil.CirclePoints(
                    radius: lowerDisc.radius,
                    resultPoints: lowerPoints,
                    segments: lowerDisc.segments,
                    offset: lowerDisc.offset * planeType.GetNormal(),
                    isLoop: false,
                    type: planeType
                );

                // �`��i���㉺�~�̊e�_�����Ԑ����j
                Basic.DrawLineSet(upperPoints, lowerPoints);

                // ���X�g���
                upperPoints.Free();
                lowerPoints.Free();
            }

            /// <summary>
            /// �~���̑��ʕ���`�悷��
            /// </summary>
            private static void DrawWireConeOuterLines(PlaneType type, DiscParam lowerDisc, float height) {

                // ���X�g�擾
                var lowerPoints = ListPool<Vector3>.New();

                var top = (lowerDisc.offset + height) * type.GetNormal();
                MathUtil.CirclePoints(
                    radius: lowerDisc.radius,
                    resultPoints: lowerPoints,
                    segments: lowerDisc.segments,
                    offset: lowerDisc.offset * type.GetNormal(),
                    isLoop: false,
                    type: type
                );

                // �`��i�����(�~)�̊e�_���璸�_�ւ̐����j
                lowerPoints.ForEach(p => Gizmos.DrawLine(p, top));

                // ���X�g���
                lowerPoints.Free();
            }

            /// <summary>
            /// �~�Ղ�`�悷��
            /// </summary>
            private static void DrawWireDisc(PlaneType planType, DiscParam disc) {

                // ���X�g�擾
                var points = ListPool<Vector3>.New();

                // ���W�v�Z
                MathUtil.CirclePoints(
                    radius: disc.radius,
                    resultPoints: points,
                    segments: disc.segments,
                    offset: disc.offset * planType.GetNormal(),
                    isLoop: true,
                    type: planType
                );

                // �`��
                Basic.DrawLines(points);

                // ���X�g���
                points.Free();
            }
            #endregion
        }

    }
}
