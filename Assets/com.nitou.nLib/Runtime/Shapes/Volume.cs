using UnityEngine;

namespace nitou {
    public static partial class Shapes {

        /// <summary>
        /// �`��̊��N���X
        /// </summary>
        [System.Serializable]
        public abstract class Volume {

            /// <summary>
            /// ���[�J�����W
            /// </summary>
            public Vector3 position = Vector3.one;

            /// <summary>
            /// ��]�i�I�C���[�p�j
            /// </summary>
            public Vector3 eulerAngle = Vector3.zero;


            /// ----------------------------------------------------------------------------
            // Property

            /// <summary>
            /// ��]�i�N�H�[�^�j�I���j
            /// </summary>
            public Quaternion rotation => Quaternion.Euler(eulerAngle);

            /// <summary>
            /// ������iX���j
            /// </summary>
            public Vector3 right => rotation * Vector3.right;

            /// <summary>
            /// ������iY���j
            /// </summary>
            public Vector3 up => rotation * Vector3.up;

            /// <summary>
            /// ������iZ���j
            /// </summary>
            public Vector3 forward => rotation * Vector3.forward;


            /// ----------------------------------------------------------------------------
            // Public Method

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public Volume(Vector3 position, Quaternion rotation) {
                this.position = position;
                this.eulerAngle = rotation.eulerAngles;
            }

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public Volume(Transform transform) {
                this.position = transform.position;
                this.eulerAngle = transform.rotation.eulerAngles;
            }

            protected Volume() {}

            /// <summary>
            /// ���[���h���W�n�ł̈ʒu���擾����
            /// </summary>
            public Vector3 GetWorldPosition(Transform transform) {
                return transform.TransformPoint(this.position);
            }

            /// <summary>
            /// ���[���h���W�n�ł̉�]���擾����
            /// </summary>
            public Quaternion GetWorldRotaion(Transform transform) {
                return transform.rotation * Quaternion.Euler(this.eulerAngle);
            }
        }        
    }   
}
