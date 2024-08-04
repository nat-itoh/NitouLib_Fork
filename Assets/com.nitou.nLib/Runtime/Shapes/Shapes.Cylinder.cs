using UnityEngine;

namespace nitou {
    public partial class Shapes {

        /// <summary>
        /// �~���̌`���\���C���X�^���X
        /// </summary>
        [System.Serializable]
        public class Cylinder : ShapeBase {

            /// <summary>
            /// ���a
            /// </summary>
            public float radius = 0.5f;

            /// <summary>
            /// ����
            /// </summary>
            public float height = 1.5f;


            /// ----------------------------------------------------------------------------
            // Public Method

            public Cylinder(Vector3 position, Quaternion rotation, float radius, float height)
                : base(position, rotation) {
                this.radius = radius;
                this.height = height;
            }

            private Cylinder() { }

            public override string ToString() {
                return $"[Box] position: {position}, rotation: {eulerAngle}, radius: {radius}, height: {height}";
            }
        }
    }
}
