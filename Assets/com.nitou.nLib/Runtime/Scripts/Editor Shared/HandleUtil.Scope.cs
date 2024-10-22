#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace nitou.EditorShared{
    public static partial class HandleUtil {

        /// ----------------------------------------------------------------------------
        #region Color Scope

        /// <summary>
        /// Handles.color�ݒ���X�R�[�v�ŊǗ����邽�߂̃N���X
        /// </summary>
        public sealed class ColorScope : System.IDisposable {

            private readonly Color _oldColor;

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public ColorScope(Color color) {
                _oldColor = Handles.color;
                Handles.color = color;
            }

            /// <summary>
            /// �I������
            /// </summary>
            public void Dispose() {
                Handles.color = _oldColor;
            }
        }
        #endregion

    }
}
#endif
