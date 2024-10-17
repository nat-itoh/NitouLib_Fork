using System.Collections.Generic;
using UnityEngine;

// [�Q�l]
//  github: neuneu9/unity-gizmos-utility https://github.com/neuneu9/unity-gizmos-utility/blob/master/GizmosUtility.cs
//  github: code-beans/GizmoExtensions https://github.com/code-beans/GizmoExtensions/blob/master/src/GizmosExtensions.cs

namespace nitou {
    using nitou.DebugInternal;
    using ArrowType = nitou.DebugInternal.GizmoDrawer.Arrow.ArrowType;

    /// <summary>
    /// Gizmo�`��Ɋւ���ėp�@�\��񋟂��郉�C�u���� (���t�@�T�[�h�N���X)
    /// </summary>
    public static class Gizmos_ {

        /// ----------------------------------------------------------------------------
        #region 3D�}�`

        /// <summary>
        /// ������`�悷��
        /// </summary>
        public static void DrawRay(Vector3 pos, Vector3 direction, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                Gizmos.DrawRay(pos, direction);
            }
        }

        /// <summary>
        /// ������`�悷��
        /// </summary>
        public static void DrawLine(Vector3 from, Vector3 to, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                Gizmos.DrawLine(from, to);
            }
        }

        /// <summary>
        /// ������`�悷��
        /// </summary>
        public static void DrawLine(LineSegment2 segment, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                Gizmos.DrawLine(segment.start, segment.end);
            }
        }

        /// <summary>
        /// ������`�悷��
        /// </summary>
        public static void DrawLine(LineSegment3 segment, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                Gizmos.DrawLine(segment.start, segment.end);
            }
        }

        /// <summary>
        /// �܂����`�悷��
        /// </summary>
        public static void DrawLines(IReadOnlyList<Vector3> points, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Basic.DrawLines(points);
            }
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region 3D�}�` (Ray)

        /// <summary>
        /// ����`�悷��
        /// </summary>
        public static void DrawRayArrow(Vector3 pos, Vector3 direction, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f) {
            GizmoDrawer.Arrow.DrawRayArrow(ArrowType.Solid, pos, direction, arrowHeadLength, arrowHeadAngle);
        }

        /// <summary>
        /// ����`�悷��
        /// </summary>
        public static void DrawRayArrow(Vector3 pos, Vector3 direction, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Arrow.DrawRayArrow(ArrowType.Solid, pos, direction, arrowHeadLength, arrowHeadAngle);
            }
        }

        // ----- 

        /// <summary>
        /// ����`�悷��
        /// </summary>
        public static void DrawLineArrow(Vector3 from, Vector3 to, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f) {
            GizmoDrawer.Arrow.DrawLineArrow(ArrowType.Solid, from, to, arrowHeadLength, arrowHeadAngle);
        }

        /// <summary>
        /// ����`�悷��
        /// </summary>
        public static void DrawLineArrow(Vector3 from, Vector3 to, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Arrow.DrawLineArrow(ArrowType.Solid, from, to, arrowHeadLength, arrowHeadAngle);
            }
        }

        /// <summary>
        /// ����`�悷��
        /// </summary>
        public static void DrawLineArrow(LineSegment2 segment, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Arrow.DrawLineArrow(ArrowType.Solid, segment.start, segment.end, arrowHeadLength, arrowHeadAngle);
            }
        }

        /// <summary>
        /// ����`�悷��
        /// </summary>
        public static void DrawLineArrow(LineSegment3 segment, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Arrow.DrawLineArrow(ArrowType.Solid, segment.start, segment.end, arrowHeadLength, arrowHeadAngle);
            }
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region 3D�}�` (Arc)

        /// <summary>
        /// �~��`�悷��
        /// </summary>
        public static void DrawWireCircle(Vector3 center, float radius) {
            GizmoDrawer.Basic.DrawCircle(PlaneType.ZX, center, Quaternion.identity, radius);
        }

        /// <summary>
        /// �~��`�悷��
        /// </summary>
        public static void DrawWireCircle(Vector3 center, float radius, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Basic.DrawCircle(PlaneType.ZX, center, Quaternion.identity, radius);
            }
        }

        /// <summary>
        /// �~��`�悷��
        /// </summary>
        public static void DrawWireCircle(Vector3 center, float radius, PlaneType type, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Basic.DrawCircle(type, center, Quaternion.identity, radius);
            }
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region 3D�}�` (Cube)

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawWireCube(Vector3 center, Vector3 size) {
            GizmoDrawer.Cube.DrawWireCube(center, Quaternion.identity, size);
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawWireCube(Vector3 center, Vector3 size, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Cube.DrawWireCube(center, Quaternion.identity, size);
            }
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawWireCube(Vector3 center, Quaternion rotation, Vector3 size) {
            GizmoDrawer.Cube.DrawWireCube(center, rotation, size);
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawWireCube(Vector3 center, Quaternion rotation, Vector3 size, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Cube.DrawWireCube(center, rotation, size);
            }
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawWireCube(Transform transform, Vector3 size) {
            GizmoDrawer.Cube.DrawWireCube(transform.position, transform.rotation, size);
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawWireCube(Transform transform, Vector3 size, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Cube.DrawWireCube(transform.position, transform.rotation, size);
            }
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawWireCube(BoxCollider collider) {
            GizmoDrawer.Cube.DrawWireCube(collider.GetWorldCenter(), collider.transform.rotation, collider.size);
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawWireCube(BoxCollider collider, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Cube.DrawWireCube(collider.GetWorldCenter(), collider.transform.rotation, collider.size);
            }
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawWireCube(Shapes.Box box) {
            GizmoDrawer.Cube.DrawWireCube(box.position, box.rotation, box.size);
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawWireCube(Shapes.Box box, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Cube.DrawWireCube(box.position, box.rotation, box.size);
            }
        }

        // -----

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawCube(Vector3 center, Vector3 size) {
            GizmoDrawer.Cube.DrawCube(center, Quaternion.identity, size);
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawCube(Vector3 center, Vector3 size, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Cube.DrawCube(center, Quaternion.identity, size);
            }
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawCube(Vector3 center, Quaternion rotation, Vector3 size) {
            GizmoDrawer.Cube.DrawCube(center, rotation, size);
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawCube(Vector3 center, Quaternion rotation, Vector3 size, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Cube.DrawCube(center, rotation, size);
            }
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawCube(Transform transform, Vector3 size) {
            GizmoDrawer.Cube.DrawCube(transform.position, transform.rotation, size);
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawCube(Transform transform, Vector3 size, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Cube.DrawCube(transform.position, transform.rotation, size);
            }
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawCube(BoxCollider collider) {
            GizmoDrawer.Cube.DrawCube(collider.GetWorldCenter(), collider.transform.rotation, collider.size);
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawCube(BoxCollider collider, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Cube.DrawCube(collider.GetWorldCenter(), collider.transform.rotation, collider.size);
            }
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawCube(Shapes.Box box) {
            GizmoDrawer.Cube.DrawCube(box.position, box.rotation, box.size);
        }

        /// <summary>
        /// �L���[�u��`�悷��
        /// </summary>
        public static void DrawCube(Shapes.Box box, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Cube.DrawCube(box.position, box.rotation, box.size);
            }
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region 3D�}�` (Sphere)

        /// <summary>
        /// ����`�悷��
        /// </summary>
        public static void DrawWireSphere(Vector3 position, float radius, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                Gizmos.DrawWireSphere(position, radius);
            }
        }

        /// <summary>
        /// ����`�悷��
        /// </summary>
        public static void DrawWireSphere(SphereCollider collider, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                Gizmos.DrawWireSphere(collider.GetWorldCenter(), collider.radius);
            }
        }

        /// <summary>
        /// ����`�悷��
        /// </summary>
        public static void DrawSphere(Vector3 position, float radius, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                Gizmos.DrawSphere(position, radius);
            }
        }

        /// <summary>
        /// ����`�悷��
        /// </summary>
        public static void DrawSphere(SphereCollider collider, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                Gizmos.DrawSphere(collider.GetWorldCenter(), collider.radius);
            }
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region 3D�}�` (Cylinder)

        /// <summary>
        /// �~����`�悷��
        /// </summary>
        public static void DrawWireCylinder(Vector3 center, float radius, float height) {
            GizmoDrawer.Cylinder.DrawWireCylinder(PlaneType.ZX, center, Quaternion.identity, radius, height);
        }

        /// <summary>
        /// �~����`�悷��
        /// </summary>
        public static void DrawWireCylinder(Vector3 center, float radius, float height, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Cylinder.DrawWireCylinder(PlaneType.ZX, center, Quaternion.identity, radius, height);
            }
        }

        /// <summary>
        /// �~����`�悷��
        /// </summary>
        public static void DrawWireCylinder(Transform transform, float radius, float height) {
            GizmoDrawer.Cylinder.DrawWireCylinder(PlaneType.ZX, transform.position, transform.rotation, radius, height);
        }

        /// <summary>
        /// �~����`�悷��
        /// </summary>
        public static void DrawWireCylinder(Transform transform, float radius, float height, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Cylinder.DrawWireCylinder(PlaneType.ZX, transform.position, transform.rotation, radius, height);
            }
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region 3D�}�` (Cone)

        /// <summary>
        /// �~����`�悷��
        /// </summary>
        public static void DrawWireCone(Vector3 center, float radius, float height) {
            GizmoDrawer.Cylinder.DrawWireCone(PlaneType.ZX, center, Quaternion.identity, radius, height);
        }

        /// <summary>
        /// �~����`�悷��
        /// </summary>
        public static void DrawWireCone(Transform transform, float radius, float height) {
            GizmoDrawer.Cylinder.DrawWireCone(PlaneType.ZX, transform.position, transform.rotation, radius, height);
        }

        /// <summary>
        /// �~����`�悷��
        /// </summary>
        public static void DrawWireCone(Transform transform, float radius, float height, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                GizmoDrawer.Cylinder.DrawWireCone(PlaneType.ZX, transform.position, transform.rotation, radius, height);
            }
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region 3D�}�` (Mesh)

        /// <summary>
        /// ���b�V����`�悷��
        /// </summary>
        public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                Gizmos.DrawMesh(mesh, position, rotation);
            }
        }

        /// <summary>
        /// ���b�V����`�悷��
        /// </summary>
        public static void DrawMesh(Mesh mesh, Transform transform, Color color) {
            using (new GizmoUtil.ColorScope(color)) {
                Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
            }
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region 3D�}�` (Misc)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collider"></param>
        /// <param name="color"></param>
        public static void DrawCollider(in Collider collider, Color color) {
            var trs = collider.transform;
            var position = trs.position;
            var rotation = trs.rotation;
            var scale = trs.localScale;

            switch (collider) {
                case MeshCollider meshCollider:
                    DrawMesh(meshCollider.sharedMesh, trs, color);
                    break;
                case BoxCollider boxCollider:
                    DrawCube(boxCollider, color);
                    break;
                case SphereCollider sphereCollider:
                    DrawSphere(sphereCollider, color);
                    break;
                case CapsuleCollider:
                case CharacterController:
                    // [TODO] ��������
                    //DrawMesh(CapsuleMesh, position, rotation, scale, color, alpha);
                    break;
            }
        }
        #endregion

    }
}
