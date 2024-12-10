using UnityEngine;

// [�Q�l]
//  PG����: RigidBody2D��AddExplosionForce��ǉ����� https://takap-tech.com/entry/2023/11/29/004251

namespace nitou {

    /// <summary>
    /// Rigidbody2D�̊g�����\�b�h�N���X
    /// </summary>
    public static partial class Rigidbody2DExtensions {

        /// <summary>
        /// �w�肵���I�u�W�F�N�g�ɔ�������͂�������g�����\�b�h
        /// </summary>
        public static void AddExplosionForce(this Rigidbody2D self, float explosionForce,
            in Vector2 explosionPosition, float explosionRadius,
            float upwardsModifier = 0, ForceMode2D mode = ForceMode2D.Force){
            
            Vector2 explosionDirection = self.position - explosionPosition;
            float explosionDistance = explosionDirection.magnitude;

            if (upwardsModifier == 0f) {
                explosionDirection /= explosionDistance;
            } else {
                explosionDirection.y += upwardsModifier;
                explosionDirection.Normalize();
            }

            Vector2 force = Mathf.Lerp(0, explosionForce,
                1.0f - explosionDistance / explosionRadius) * explosionDirection;

            self.AddForce(force, mode);
        }

        /// <summary>
        /// �w�肵���I�u�W�F�N�g�ɔ�������͂�������g�����\�b�h
        /// </summary>
        public static void AddExplosionForce(this Rigidbody2D self, float explosionForce,
            in Vector3 explosionPosition, float explosionRadius, float upwardsModifier) {

            AddExplosionForce(self, explosionForce, explosionPosition, explosionRadius, upwardsModifier, ForceMode2D.Force);
        }

        /// <summary>
        /// �w�肵���I�u�W�F�N�g�ɔ�������͂�������g�����\�b�h
        /// </summary>
        public static void AddExplosionForce(this Rigidbody2D self, float explosionForce,
            in Vector3 explosionPosition, float explosionRadius) {
            
            AddExplosionForce(self, explosionForce, explosionPosition, explosionRadius, 0);
        }
    }

}
