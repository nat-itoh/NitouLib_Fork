using UnityEngine;

namespace nitou {

    /// <summary>
    /// ����
    /// </summary>
    public enum PlaneType {
        XY,
        YZ,
        ZX,
    }

    /// <summary>
    /// <see cref="Plane"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class PlaneExtensions {



    }


    public static class PlaneUtil {

        /// <summary>
        /// ���ʂɑΉ������@���x�N�g�����擾����
        /// </summary>
        public static Vector3 GetNormal(PlaneType type) {
            return type switch {
                PlaneType.XY => Vector3.forward,
                PlaneType.YZ => Vector3.right,
                PlaneType.ZX => Vector3.up,
                _ => throw new System.NotImplementedException()
            };
        }

    }

}
