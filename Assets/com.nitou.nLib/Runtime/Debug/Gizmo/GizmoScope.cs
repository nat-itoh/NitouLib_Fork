using UnityEngine;

// [�Q�l]
//  _: Gizmos�ŕ��ʂ�`�悷�� https://nyama41.hatenablog.com/entry/draw_gizmos_plane

namespace nitou {
    public partial class GizmoUtil {

        /// <summary>
        /// Gizmo��<see cref="Color"/>��K�p����X�R�[�v
        /// </summary>
        public struct ColorScope : System.IDisposable {

            private readonly Color _oldColor;

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public ColorScope(Color color) {
                _oldColor = Gizmos.color;
                Gizmos.color = color;
            }

            /// <summary>
            /// �I������
            /// </summary>
            public void Dispose() {
                Gizmos.color = _oldColor;
            }
        }


        /// <summary>
        /// Gizmo��<see cref="Matrix4x4"/>��K�p����X�R�[�v
        /// </summary>
        public struct MatrixScope : System.IDisposable {

            private readonly Matrix4x4 _oldMatrix;

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public MatrixScope(Matrix4x4 matrix) {
                _oldMatrix = Gizmos.matrix;
                Gizmos.matrix = matrix;
            }

            /// <summary>
            /// �I������
            /// </summary>
            public void Dispose() {
                Gizmos.matrix = _oldMatrix;
            }
        }
    }
}
