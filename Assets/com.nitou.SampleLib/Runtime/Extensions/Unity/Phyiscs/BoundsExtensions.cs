using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nitou {

    /// <summary>
    /// <see cref="Bounds"/>�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class BoundsExtensions {

        /// <summary>
        /// Gizmo��\������g�����\�b�h
        /// </summary>
        public static void DrawGizmo(this Bounds self){
            Gizmos.DrawCube(self.center, self.size);
        }

        /// <summary>
        /// Gizmo��\������g�����\�b�h
        /// </summary>
        public static void DrawGizmo(this Bounds self, Color color) {
            Gizmos.DrawCube(self.center, self.size);
        }

        /// <summary>
        /// ����<see cref="Bounds"/>���͈͓��Ɋ��S�Ɋ܂܂�Ă��邩�m�F����g�����\�b�h
        /// </summary>
        public static bool Contains(this Bounds self, Bounds other) {

            // AABB�̓��O����
            return self.Contains(other.min) && self.Contains(other.max);
        }
    }

}