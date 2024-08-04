using UnityEngine;

namespace nitou {
    public partial class Shapes {

        /// <summary>
        /// �����̂̌`���\���C���X�^���X
        /// </summary>
        [System.Serializable]
        public class Box : ShapeBase {

            /// <summary>
            /// �T�C�Y
            /// </summary>
            public Vector3 size = Vector3.zero;


            /// ----------------------------------------------------------------------------
            // Public Method

            public Box(Vector3 position, Quaternion rotation, Vector3 size)
                : base(position, rotation) {
                this.size = size;
            }

            private Box(){}

            public override string ToString() {
                return $"[Box] position: {position}, rotation: {eulerAngle}, size: {size}";
            }
        }

    }


    public static partial class BoxColliderExtensions {

        /// <summary>
        /// �`������擾����
        /// </summary>
        public static Shapes.Box GetShape(this BoxCollider self) {

            // ���[���h���W�n�ł̈ʒu�C��]�C�T�C�Y
            Vector3 worldCenter = self.transform.TransformPoint(self.center);
            Quaternion worldRotation = self.transform.rotation;
            Vector3 worldSize = Vector3.Scale(self.transform.lossyScale, self.size);

            // Box�̃v���p�e�B��ݒ�
            var boxShape = new Shapes.Box(worldCenter, worldRotation, worldSize);
            return boxShape;
        }
    }
}
