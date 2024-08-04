using System.Collections.Generic;
using UnityEngine;

// [�Q�l]
//  Hatena: Gizmo ��`�悷��ۂɉ�]������ https://hacchi-man.hatenablog.com/entry/2021/05/23/220000

namespace nitou.DebugFuncition {

    public static class CubeDrawer{

        public enum Type {
            WireCube,
            Cube,
        }

        /// ----------------------------------------------------------------------------
        #region �`�惁�\�b�h

        /// <summary>
		/// �L���[�u��`�悷��
		/// </summary>
		public static void DrawCube(Type type, Vector3 center, Quaternion rotation, Vector3 size) {

            if (rotation.Equals(default)) {
                rotation = Quaternion.identity;
            }

            var matrix = Matrix4x4.TRS(center, rotation, size);
            using ( new GizmoUtil.MatrixScope(matrix)){
                
                // �`�揈��
                switch (type) {
                    case Type.WireCube:
                        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
                        break;

                    case Type.Cube:
                        Gizmos.DrawCube(Vector3.zero, Vector3.one);
                        break;
                }
            }
        }   
        #endregion
    }
}
