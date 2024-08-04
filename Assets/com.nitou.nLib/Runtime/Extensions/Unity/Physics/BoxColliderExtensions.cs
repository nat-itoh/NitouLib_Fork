using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// [�Q�l]
//  _: How can I get a Box Collider's "corners" (vertices) positions? https://gamedev.stackexchange.com/questions/128833/how-can-i-get-a-box-colliders-corners-vertices-positions

namespace nitou {

    /// <summary>
    /// <see cref="BoxCollider"/>�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static partial class BoxColliderExtensions {

        /// <summary>
        /// �e�K�w���l�������X�P�[�����擾����g�����\�b�h
        /// </summary>
        public static Vector3 GetScaledSize(this BoxCollider box) {
            return Vector3.Scale(box.transform.lossyScale, box.size);
        }

        /// <summary>
        /// �_��<see cref="BoxCollider"/>�̓����Ɋ܂܂�邩���肷��g�����\�b�h
        /// </summary>
        public static bool Contains(this BoxCollider box, Vector3 point) {

            var localPoint = box.transform.InverseTransformPoint(point);
            var scaledHalfSize = box.GetScaledSize().Half();

            // �S�Ă̎��ŋ��E���ɂ���΁A�_��BoxCollider�����ɂ���
            return (Mathf.Abs(localPoint.x) <= scaledHalfSize.x)
                && (Mathf.Abs(localPoint.y) <= scaledHalfSize.y)
                && (Mathf.Abs(localPoint.z) <= scaledHalfSize.z);
        }

        /// <summary>
        /// ����<see cref="BoxCollider"/>�̓����Ɋ��S�Ɋ܂܂�邩���肷��g�����\�b�h
        /// </summary>
        public static bool Contains(BoxCollider box, SphereCollider sphere) {
            float radius = sphere.GetScaledRadius();
            Vector3 center = sphere.transform.TransformPoint(sphere.center);

            // BOX�e�ʂƂ̋����Ŕ���
            var planes = box.GetPlanes();
            foreach (var plane in planes) {
                if (plane.GetDistanceToPoint(center) < -radius) {
                    return false;
                }
            }
            return true;
        }


        /// ----------------------------------------------------------------------------
        #region MyRegion

        /// <summary>
        /// �ł����������𒲂ׂ�g�����\�b�h
        /// </summary>
        public static Axis GetLongestAxis(this BoxCollider box) {
            var scale = box.GetScaledSize();

            Axis axis = (scale.x, scale.y, scale.z) switch {
                var (x, y, z) when (x >= y && x >= z) => Axis.X,
                var (x, y, z) when (y >= x && y >= z) => Axis.Y,
                var (x, y, z) when (z >= x && z >= y) => Axis.Z,
                _ => Axis.X // Fallback, though it shouldn't be reached
            };

            return axis;
        }

        /// <summary>
        /// �R���C�_�[���S����e������(x,y,z)�̋��E���W
        /// </summary>
        public static (Vector3 vx, Vector3 vy, Vector3 vz) GetAxisBoundPoints(this BoxCollider box) {

            var trans = box.transform;
            var scale = box.GetScaledSize().Half();

            return (
                vx: trans.right * scale.x,
                vy: trans.up * scale.y,
                vz: trans.forward * scale.z);
        }

        /// <summary>
        /// �R���C�_�[���S����e������(x,y,z)�̋��E���W
        /// </summary>
        public static (Vector3 positive, Vector3 negative) GetAxisBoundPoints(this BoxCollider box, Axis axis) {

            var trans = box.transform;
            var scale = box.GetScaledSize().Half();

            return axis switch {
                Axis.X => (trans.right * scale.x, -trans.right * scale.x),
                Axis.Y => (trans.up * scale.y, -trans.up * scale.y),
                Axis.Z => (trans.forward * scale.z, -trans.forward * scale.z),
                _ => throw new System.NotImplementedException()
            };
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region ���_/��/�ʂ̎擾

        // [�Q�l]
        //  qiita: Unity��BoxCollider�̒��_���擾����X�N���v�g https://qiita.com/RYUMAGE/items/dae74abaf2b7888dcbfa
        //  qiita: BoxCollider�̊e�ʂ�Plane�Ƃ��Ď擾����X�N���v�g https://qiita.com/RYUMAGE/items/8fc826825ef27e178225

        /// <summary>
        /// <see cref="BoxCollider"/> �̂W���_�̃��[���h���W���擾����g�����\�b�h
        /// </summary>
        public static Vector3[] GetVertices(this BoxCollider box) {

            var center = box.transform.TransformPoint(box.center);

            (var vx, var vy, var vz) = box.GetAxisBoundPoints();
            var p1 = -vx + vy + vz;
            var p2 = vx + vy + vz;
            var p3 = vx + -vy + vz;
            var p4 = -vx + -vy + vz;

            var vertices = new Vector3[8];
            vertices[0] = center + p1;
            vertices[1] = center + p2;
            vertices[2] = center + p3;
            vertices[3] = center + p4;

            vertices[4] = center - p1;
            vertices[5] = center - p2;
            vertices[6] = center - p3;
            vertices[7] = center - p4;

            return vertices;
        }

        /// <summary>
        /// <see cref="BoxCollider"/> ��6�ʂ��擾����g�����\�b�h
        /// </summary>
        public static Plane[] GetPlanes(this BoxCollider box) {

            var trans = box.transform;
            var center = trans.TransformPoint(box.center);

            (var vx, var vy, var vz) = box.GetAxisBoundPoints();

            var planes = new Plane[6];
            planes[0] = new Plane(trans.right, center + vx);
            planes[1] = new Plane(-trans.right, center - vx);
            planes[2] = new Plane(trans.up, center + vy);
            planes[3] = new Plane(-trans.up, center - vy);
            planes[4] = new Plane(trans.forward, center + vz);
            planes[5] = new Plane(-trans.forward, center - vz);

            return planes;
        }

        /// <summary>
        /// <see cref="BoxCollider"/> �̐������擾����g�����\�b�h
        /// </summary>
        public static LineSegment3[] GetLines(this BoxCollider box, Axis axis) {

            var vertices = box.GetVertices();
            var lines = new List<LineSegment3>();

            // �g�ݍ��킹�̔z�� (��GetVertices()�̗v�f���Ɋ�Â�)
            (int i, int j)[] indexPairs = axis switch {
                Axis.X => new (int, int)[] { (0, 1), (3, 2), (5, 4), (6, 7) },
                Axis.Y => new (int, int)[] { (2, 1), (3, 0), (4, 7), (5, 6) },
                Axis.Z => new (int, int)[] { (6, 0), (7, 1), (4, 2), (5, 3) },
                _ => throw new System.NotImplementedException()
            };

            // LineSeqment3�ɕϊ�
            return indexPairs
                .Select(index => new LineSegment3(vertices[index.i], vertices[index.j]))
                .ToArray();
        }
        #endregion


        /// ----------------------------------------------------------------------------
        // ���_ / �� / �ʂ̎擾

        /// <summary>
        /// Gets the closest plane to a given point.
        /// </summary>
        public static Plane GetClosestPlane(this BoxCollider box, Vector3 point) {
            var planes = box.GetPlanes();

            float minDistance = float.MaxValue;
            Plane closestPlane = planes[0];

            foreach (var plane in planes) {
                float distance = Mathf.Abs(plane.GetDistanceToPoint(point));
                if (distance < minDistance) {
                    minDistance = distance;
                    closestPlane = plane;
                }
            }
            return closestPlane;
        }
    }
}
