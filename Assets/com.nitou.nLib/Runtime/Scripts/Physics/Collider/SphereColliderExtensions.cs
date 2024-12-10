using System.Collections.Generic;
using UnityEngine;

namespace nitou {

    /// <summary>
    /// <see cref="SphereCollider"/>�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class SphereColliderExtensions {

        /// ----------------------------------------------------------------------------
        // 

        /// <summary>
        /// �O���[�o�����W�ɕϊ������R���C�_�[���S���W���擾����g�����\�b�h
        /// </summary>
        public static Vector3 GetWorldCenter(this SphereCollider self) {
            return self.transform.TransformPoint(self.center);
        }

        /// <summary>
        /// �e�K�w���l���������a���擾����g�����\�b�h
        /// </summary>
        public static float GetScaledRadius(this SphereCollider sphere) {
            // (��Sphere�R���C�_�[�͏�ɋ��`���ێ����āC���a�Ɋe���̍ő�X�P�[�����K�p�����)
            return sphere.radius * MathUtil.Max(sphere.transform.lossyScale);
        }


        /// ----------------------------------------------------------------------------


        /// <summary>
        /// �w����W��<see cref="SphereCollider"/>�̓����Ɋ܂܂�邩���肷��g�����\�b�h
        /// </summary>
        public static bool Contains(this SphereCollider sphere, Vector3 point) {

            var localPoint = sphere.transform.InverseTransformPoint(point);
            var scaledRadius = sphere.GetScaledRadius();

            return localPoint.sqrMagnitude <= scaledRadius * scaledRadius;
        }


    }

    public struct SphereData {
        public readonly Vector3 position;
        public readonly float radius;

        public SphereData(Vector3 position, float radius) {
            this.position = position;
            this.radius = Mathf.Max(0, radius);
        }
    }

}
