using UnityEngine;

namespace nitou {

    /// <summary>
    /// Transform��"position"��"rotation"�݂̂������f�[�^�\����
    /// </summary>
    [System.Serializable]
    public struct Coord {

        public Vector3 position;
        public Quaternion rotation;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public Coord(Vector3 position, Quaternion rotation) {
            this.position = position;
            this.rotation = rotation;
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public Coord(Transform transform) {
            this.position = transform.position;
            this.rotation = transform.rotation;
        }
    }


    public static partial class TransformExtension {

        /// <summary>
        /// �ʒu�Ǝp�����ꊇ�ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetPositionAndRotation(this Transform self, Coord coord) =>
            self.SetPositionAndRotation(coord.position, coord.rotation);
    }
}
