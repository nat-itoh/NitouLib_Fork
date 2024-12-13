using UnityEngine;

// [�Q�l]
//  �R�K�l�u���O: Transform�^�̈ʒu���]�p�A�T�C�Y�̐ݒ���y�ɂ��� https://baba-s.hatenablog.com/entry/2014/02/28/000000
//  _:  Transform�Ƀ��Z�b�g������ǉ����Ă݂� https://ookumaneko.wordpress.com/2015/10/01/unity%E3%83%A1%E3%83%A2-transform%E3%81%AB%E3%83%AA%E3%82%BB%E3%83%83%E3%83%88%E5%87%A6%E7%90%86%E3%82%92%E8%BF%BD%E5%8A%A0%E3%81%97%E3%81%A6%E3%81%BF%E3%82%8B/#:~:text=%E3%83%AF%E3%83%BC%E3%83%AB%E3%83%89%E3%82%92%E3%83%AA%E3%82%BB%E3%83%83%E3%83%88%E3%81%97%E3%81%9F%E3%81%84%E6%99%82,%E5%80%A4%E3%82%92%E3%83%AA%E3%82%BB%E3%83%83%E3%83%88%E5%87%BA%E6%9D%A5%E3%81%BE%E3%81%99%E3%80%82
//  github: BreadcrumbsUnityCsReference/Editor/Mono/GameObjectUtility.bindings.cs https://github.com/Unity-Technologies/UnityCsReference/blob/master/Editor/Mono/GameObjectUtility.bindings.cs#L75

namespace nitou {

    /// <summary>
    /// GameObject�̊g�����\�b�h�N���X
    /// </summary>
    public static partial class TransformExtensions {

        /// ----------------------------------------------------------------------------
        #region �ʒu�̐ݒ�

        /// <summary>
        /// X���W��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetPositionX(this Transform self, float x) =>
            self.position = new Vector3(x, self.position.y, self.position.z);

        /// <summary>
        /// Y���W��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetPositionY(this Transform self, float y) =>
            self.position = new Vector3(self.position.x, y, self.position.z);

        /// <summary>
        /// Z���W��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetPositionZ(this Transform self, float z) =>
            self.position = new Vector3(self.position.x, self.position.y, z);

        /// <summary>
        /// ���[�J����X���W��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetLocalPositionX(this Transform self, float x) =>
            self.localPosition = new Vector3(x, self.localPosition.y, self.localPosition.z);

        /// <summary>
        /// ���[�J����Y���W��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetLocalPositionY(this Transform self, float y) =>
            self.localPosition = new Vector3(self.localPosition.x, y, self.localPosition.z);

        /// <summary>
        /// ���[�J����Z���W��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetLocalPositionZ(this Transform self, float z) =>
            self.localPosition = new Vector3(self.localPosition.x, self.localPosition.y, z);


        /// <summary>
        /// X���W�ɉ��Z����g�����\�b�h
        /// </summary>
        public static void AddPositionX(this Transform self, float x) =>
            self.SetPositionX(x + self.position.x);

        /// <summary>
        /// Y���W�ɉ��Z����g�����\�b�h
        /// </summary>
        public static void AddPositionY(this Transform self, float y) =>
            self.SetPositionY(y + self.position.y);

        /// <summary>
        /// Z���W�ɉ��Z����g�����\�b�h
        /// </summary>
        public static void AddPositionZ(this Transform self, float z) =>
            self.SetPositionZ(z + self.position.z);

        /// <summary>
        /// ���[�J����X���W�ɉ��Z����g�����\�b�h
        /// </summary>
        public static void AddLocalPositionX(this Transform self, float x) =>
            self.SetLocalPositionX(x + self.localPosition.x);

        /// <summary>
        /// ���[�J����Y���W�ɉ��Z����g�����\�b�h
        /// </summary>
        public static void AddLocalPositionY(this Transform self, float y) =>
            self.SetLocalPositionY(y + self.localPosition.y);

        /// <summary>
        /// ���[�J����Z���W�ɉ��Z����g�����\�b�h
        /// </summary>
        public static void AddLocalPositionZ(this Transform self, float z) =>
            self.SetLocalPositionZ(z + self.localPosition.z);
        #endregion


        /// ----------------------------------------------------------------------------
        #region �p�x�̐ݒ�

        /// <summary>
        /// X�������̉�]�p��ݒ肵�܂�
        /// </summary>
        public static void SetEulerAngleX(this Transform self, float x) =>
            self.eulerAngles = new Vector3(x, self.eulerAngles.y, self.eulerAngles.z);

        /// <summary>
        /// Y�������̉�]�p��ݒ肵�܂�
        /// </summary>
        public static void SetEulerAngleY(this Transform self, float y) =>
            self.eulerAngles = new Vector3(self.eulerAngles.x, y, self.eulerAngles.z);

        /// <summary>
        /// Z�������̉�]�p��ݒ肵�܂�
        /// </summary>
        public static void SetEulerAngleZ(this Transform self, float z) =>
            self.eulerAngles = new Vector3(self.eulerAngles.x, self.eulerAngles.y, z);

        /// <summary>
        /// ���[�J����X�������̉�]�p��ݒ肵�܂�
        /// </summary>
        public static void SetLocalEulerAngleX(this Transform self, float x) =>
            self.localEulerAngles = new Vector3(x, self.localEulerAngles.y, self.localEulerAngles.z);

        /// <summary>
        /// ���[�J����Y�������̉�]�p��ݒ肵�܂�
        /// </summary>
        public static void SetLocalEulerAngleY(this Transform self, float y) =>
            self.localEulerAngles = new Vector3(self.localEulerAngles.x, y, self.localEulerAngles.z);

        /// <summary>
        /// ���[�J����Z�������̉�]�p��ݒ肵�܂�
        /// </summary>
        public static void SetLocalEulerAngleZ(this Transform self, float z) =>
            self.localEulerAngles = new Vector3(self.localEulerAngles.x, self.localEulerAngles.y, z);


        /// <summary>
        /// X�������̉�]�p�����Z���܂�
        /// </summary>
        public static void AddEulerAngleX(this Transform self, float x) =>
            self.SetEulerAngleX(self.eulerAngles.x + x);

        /// <summary>
        /// Y�������̉�]�p�����Z���܂�
        /// </summary>
        public static void AddEulerAngleY(this Transform self, float y) =>
            self.SetEulerAngleY(self.eulerAngles.y + y);

        /// <summary>
        /// Z�������̉�]�p�����Z���܂�
        /// </summary>
        public static void AddEulerAngleZ(this Transform self, float z) =>
            self.SetEulerAngleZ(self.eulerAngles.z + z);

        /// <summary>
        /// ���[�J����X�������̉�]�p�����Z���܂�
        /// </summary>
        public static void AddLocalEulerAngleX(this Transform self, float x) =>
            self.SetLocalEulerAngleX(self.localEulerAngles.x + x);

        /// <summary>
        /// ���[�J����Y�������̉�]�p�����Z���܂�
        /// </summary>
        public static void AddLocalEulerAngleY(this Transform self, float y) =>
            self.SetLocalEulerAngleY(self.localEulerAngles.y + y);

        /// <summary>
        /// ���[�J����X�������̉�]�p�����Z���܂�
        /// </summary>
        public static void AddLocalEulerAngleZ(this Transform self, float z) =>
            self.SetLocalEulerAngleZ(self.localEulerAngles.z + z);
        #endregion


        /// ----------------------------------------------------------------------------
        #region �X�P�[���̐ݒ�

        /// <summary>
        /// X�������̃��[�J�����W�n�̃X�P�[�����O�l��ݒ肵�܂�
        /// </summary>
        public static void SetLocalScaleX(this Transform self, float x) =>
            self.localScale = new Vector3(x, self.localScale.y, self.localScale.z);

        /// <summary>
        /// Y�������̃��[�J�����W�n�̃X�P�[�����O�l��ݒ肵�܂�
        /// </summary>
        public static void SetLocalScaleY(this Transform self, float y) =>
            self.localScale = new Vector3(self.localScale.x, y, self.localScale.z);

        /// <summary>
        /// Z�������̃��[�J�����W�n�̃X�P�[�����O�l��ݒ肵�܂�
        /// </summary>
        public static void SetLocalScaleZ(this Transform self, float z) =>
            self.localScale = new Vector3(self.localScale.x, self.localScale.y, z);


        /// <summary>
        /// X�������̃��[�J�����W�n�̃X�P�[�����O�l�����Z���܂�
        /// </summary>
        public static void AddLocalScaleX(this Transform self, float x) =>
            self.SetLocalScaleX(self.localScale.x + x);

        /// <summary>
        /// Y�������̃��[�J�����W�n�̃X�P�[�����O�l�����Z���܂�
        /// </summary>
        public static void AddLocalScaleY(this Transform self, float y) =>
            self.SetLocalScaleY(self.localScale.y + y);

        /// <summary>
        /// Z�������̃��[�J�����W�n�̃X�P�[�����O�l�����Z���܂�
        /// </summary>
        public static void AddLocalScaleZ(this Transform self, float z) =>
            self.SetLocalScaleZ(self.localScale.z + z);
        #endregion


        /// ----------------------------------------------------------------------------
        #region �e�q�֌W

        /// <summary>
        /// Makes the given game objects children of the transform.
        /// </summary>
        public static void AddChildren(this Transform transform, params GameObject[] children) {
            foreach (var child in children) {
                child.transform.SetParent(transform);
            }
        }

        /// <summary>
        /// Makes the game objects of given components children of the transform.
        /// </summary>
        public static void AddChildren(this Transform transform, params Component[] children) {
            foreach (var child in children) {
                child.transform.SetParent(transform);
            }
        }


        #endregion


        /// ----------------------------------------------------------------------------
        #region ������

        /// <summary>
        /// ���[�J���̍��W�C��]�C�X�P�[��������������g�����\�b�h
        /// </summary>
        public static void ResetLocal(this Transform self) {
            self.ResetLocalPositionAndRotation();
            self.localScale = Vector3.one;
        }

        /// <summary>
        /// ���W�C��]�C�X�P�[��������������g�����\�b�h
        /// </summary>
        public static void ResetWorld(this Transform self) {
            self.ResetWorldPositionAndRotation();
            self.localScale = Vector3.one;
        }

        /// <summary>
        /// ���[�J���̍��W�C��]������������g�����\�b�h
        /// </summary>
        public static void ResetLocalPositionAndRotation(this Transform self) {
#if UNITY_2021_3_OR_NEWER
            self.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
#else
            self.localPosition = Vector3.zero;
            self.localRotation = Quaternion.identity;
#endif
        }

        /// <summary>
        /// ���[�J���̍��W�C��]������������g�����\�b�h
        /// </summary>
        public static void ResetWorldPositionAndRotation(this Transform self) {
#if UNITY_2021_3_OR_NEWER
            self.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
#else
            self.position = Vector3.zero;
            self.rotation = Quaternion.identity;
#endif
        }
        #endregion



        /// ----------------------------------------------------------------------------
        // ���ӏ��
        
        /// <summary>
        /// Get the direction vector towards a specified position.
        /// </summary>
        public static Vector3 GetDirectionToPosition(this Transform self, Vector3 position) {
            var delta = position - self.position;

            return delta.sqrMagnitude > 0 ? delta.normalized : Vector3.zero;
        }

        /// <summary>
        /// Get the direction vector towards a target.
        /// </summary>
        public static Vector3 GetDirectionToTarget(this Transform self, Transform target) {
            return GetDirectionToPosition(self, target.position);
        }


        /// <summary>
        /// Get the distance to a target position.
        /// </summary>
        public static float GetDistanceFromPosition(this Transform self, Vector3 position) {
            return Vector3.Distance(self.position, position);
        }

        /// <summary>
        /// Get the distance to a target Transform.
        /// </summary>
        public static float GetDistanceFromTransform(this Transform self, Transform target) {
            return GetDistanceFromPosition(self, target.position);
        }

        
        /// <summary>
        /// Get rotation towards a specified direction. (��Y���W�͖���)
        /// </summary>
        public static Quaternion GetYawRotationToPosition(this Transform self, Vector3 position) {
            var delta = position - self.position;
            delta.y = 0;
            return Quaternion.LookRotation(delta, Vector3.up);
        }

        /// <summary>
        /// Get rotation towards a specified direction while ignoring the Y-axis.
        /// </summary>
        /// <param name="self">Self</param>
        /// <param name="target">Transform to face towards</param>
        /// <returns>Rotation to face the target</returns>
        public static Quaternion GetYawRotationToTarget(this Transform self, Transform target) {
            return GetYawRotationToPosition(self, target.position);
        }


        /// <summary>
        /// Get the angle between Transform's forward and a vector.
        /// </summary>
        public static float GetDeltaAngle(this Transform self, Vector3 direction, bool ignoreY = true) {
            var forward = self.forward;
            if (ignoreY) {
                forward = Vector3.ProjectOnPlane(forward, Vector3.up);
                direction = Vector3.ProjectOnPlane(direction, Vector3.up);
            }

            return Vector3.SignedAngle(forward, direction, Vector3.up);
        }

        /// <summary>
        /// Get the angle between Transform's forward and a rotation.
        /// </summary>
        public static float GetDeltaAngle(this Transform self, Quaternion rotation, bool ignoreY = true) {
            var direction = rotation * Vector3.forward;
            return GetDeltaAngle(self, direction, ignoreY);
        }


        /// ----------------------------------------------------------------------------
        // ���̑�

        /// <summary>
        /// �w�肵����������������g�����\�b�h
        /// </summary>
        public static void LookDirection(this Transform self, Vector3 direction) {
            self.LookAt(self.position + direction);
        }

        /// <summary>
        /// �S�Ă̎q�v�f���폜����g�����\�b�h
        /// </summary>
        public static void DestroyAllChildren(this Transform self) {
            foreach (Transform child in self) {
                GameObject.Destroy(child.gameObject);
            }
        }
    }



    

}