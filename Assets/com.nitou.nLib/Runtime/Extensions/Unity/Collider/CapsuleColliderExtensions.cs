using UnityEngine;

namespace nitou {

    /// <summary>
    /// <see cref="CapsuleCollider"/>�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class CapsuleColliderExtensions {

        /// ----------------------------------------------------------------------------
        // 

        /// <summary>
        /// �O���[�o�����W�ɕϊ������R���C�_�[���S���W���擾����g�����\�b�h
        /// </summary>
        public static Vector3 GetWorldCenter(this CapsuleCollider self) {
            return self.transform.TransformPoint(self.center);
        }

        /// <summary>
        /// �e�K�w���l���������a���擾����g�����\�b�h
        /// </summary>
        public static float GetScaledRadius(this CapsuleCollider capsule) {
            return capsule.radius * Mathf.Max(capsule.transform.lossyScale.x, capsule.transform.lossyScale.z);
        }

        /// <summary>
        /// �e�K�w���l�������������擾����g�����\�b�h
        /// </summary>
        public static float GetScaledHeight(this CapsuleCollider capsule) {
            return capsule.height * capsule.transform.lossyScale.y;
        }


        /// ----------------------------------------------------------------------------

        /// <summary>
        /// �w����W��<see cref="CapsuleCollider"/>�̓����Ɋ܂܂�邩���肷��g�����\�b�h
        /// </summary>
        public static bool Contains(this CapsuleCollider capsule, Vector3 point) {

            // �_�����[�J�����W�ɕϊ�
            var localPoint = capsule.transform.InverseTransformPoint(point);

            // �X�P�[�����l�������J�v�Z���̔��a�ƍ���
            float radius = capsule.GetScaledRadius();
            float height = capsule.GetScaledHeight();

            // �J�v�Z���̒��S�Ǝ�����
            Vector3 center = capsule.center;
            Vector3 axis = capsule.GetAxisVector();

            // �J�v�Z���̗��[�̋��̂̒��S���v�Z
            Vector3 point1 = center - axis * (height * 0.5f - radius);
            Vector3 point2 = center + axis * (height * 0.5f - radius);

            // �_�����̂̓����ɂ��邩���`�F�b�N
            if (Vector3.Distance(localPoint, point1) <= radius || Vector3.Distance(localPoint, point2) <= radius) {
                return true;
            }

            // �_���V�����_�[�����̓����ɂ��邩���`�F�b�N
            Vector3 projection = Vector3.Project(localPoint - point1, axis);
            if (projection.magnitude <= (height - radius * 2) && Vector3.Distance(localPoint, point1 + projection) <= radius) {
                return true;
            }

            return false;
        }


        /// ----------------------------------------------------------------------------
        // Public Method (Axis)

        /// <summary>
        /// <see cref="CapsuleCollider"/> �̎����擾����
        /// </summary>
        public static Axis GetAxis(this CapsuleCollider capsule) {
            return capsule.direction switch {
                0 => Axis.X,
                1 => Axis.Y,
                2 => Axis.Z,
                _ => throw new System.NotImplementedException()
            };
        }

        /// <summary>
        /// <see cref="CapsuleCollider"/> �̎��ɑΉ����� <see cref="Vector3"/> ���擾����
        /// </summary>
        public static Vector3 GetAxisVector(this CapsuleCollider capsule) {
            return capsule.direction switch {
                0 => capsule.transform.right,
                1 => capsule.transform.up,
                2 => capsule.transform.forward,
                _ => throw new System.NotImplementedException()
            };
        }
    }
}
