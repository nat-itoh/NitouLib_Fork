using UnityEngine;

namespace nitou {
    public class BoxColliderShapeVisualizer : MonoBehaviour {

        public bool drawGizmo;

        public Shapes.Box _box;


        void OnDrawGizmos() {
            if (!drawGizmo) return;

            // BoxCollider���擾
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            if (boxCollider == null) return;

            // GetShape���\�b�h���g�p����BoxShape���擾
            Shapes.Box boxShape = boxCollider.GetShape();

            // BoxCollider��Gizmo�`��i�ԐF�j
            Gizmos.color = Color.red;
            DrawBoxColliderGizmo(boxCollider);

            // BoxShape��Gizmo�`��i�ΐF�j
            Gizmos.color = Color.green;
            DrawBoxShapeGizmo(boxShape);
        }

        private void DrawBoxColliderGizmo(BoxCollider boxCollider) {
            // BoxCollider�̒��S�ƃT�C�Y�Ɋ�Â���Gizmo��`��
            Vector3 worldCenter = boxCollider.transform.TransformPoint(boxCollider.center);
            Vector3 worldSize = Vector3.Scale(boxCollider.size, boxCollider.transform.lossyScale);
            Gizmos.matrix = Matrix4x4.TRS(worldCenter, boxCollider.transform.rotation, worldSize);
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }

        private void DrawBoxShapeGizmo(Shapes.Box boxShape) {
            Gizmos.matrix = Matrix4x4.TRS(boxShape.position, boxShape.rotation, boxShape.size);
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }
    }
}
