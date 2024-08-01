using System.Collections.Generic;
using UnityEngine;

namespace nitou {
    public partial class Gizmos_ {

        /// <summary>
        /// <see cref="Gizmos.color"/>��ݒ肷�邽�߂̃X�R�[�v
        /// </summary>
        public class ColorScope : System.IDisposable {

            private Color oldColor;

            public ColorScope(Color newColor) {
                oldColor = Gizmos.color;
                Gizmos.color = newColor;
            }

            public void Dispose() {
                Gizmos.color = oldColor;
            }
        }
    }
}
