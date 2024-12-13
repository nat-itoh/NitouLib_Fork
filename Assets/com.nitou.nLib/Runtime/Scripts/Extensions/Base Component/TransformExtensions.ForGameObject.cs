using UnityEngine;

namespace nitou {

    /// <summary>
    /// GameObject�^�̊g�����\�b�h���Ǘ�����N���X
    /// </summary>
    public static partial class GameObjectExtensions {

        /// ----------------------------------------------------------------------------
        #region �ʒu�̐ݒ�

        /// <summary>
        /// �ʒu��ݒ肵�܂�
        /// </summary>
        public static void SetPosition(this GameObject self, Vector3 position) {
            self.transform.position = position;
        }

        /// <summary>
        /// X���W��ݒ肵�܂�
        /// </summary>
        public static void SetPositionX(this GameObject self, float x) {
            self.transform.SetPositionX(x);
        }

        /// <summary>
        /// Y���W��ݒ肵�܂�
        /// </summary>
        public static void SetPositionY(this GameObject self, float y) {
            self.transform.SetPositionY(y);
        }

        /// <summary>
        /// Z���W��ݒ肵�܂�
        /// </summary>
        public static void SetPositionZ(this GameObject self, float z) {
            self.transform.SetPositionZ(z);
        }

        /// <summary>
        /// ���[�J�����W�n�̈ʒu��ݒ肵�܂�
        /// </summary>
        public static void SetLocalPosition(this GameObject self, Vector3 localPosition) {
            self.transform.localPosition = localPosition;
        }

        /// <summary>
        /// ���[�J�����W�n��X���W��ݒ肵�܂�
        /// </summary>
        public static void SetLocalPositionX(this GameObject self, float x) {
            self.transform.SetLocalPositionX(x);
        }

        /// <summary>
        /// ���[�J�����W�n��Y���W��ݒ肵�܂�
        /// </summary>
        public static void SetLocalPositionY(this GameObject self, float y) {
            self.transform.SetLocalPositionY(y);
        }

        /// <summary>
        /// ���[�J����Z���W��ݒ肵�܂�
        /// </summary>
        public static void SetLocalPositionZ(this GameObject self, float z) {
            self.transform.SetLocalPositionZ(z);
        }


        /// <summary>
        /// X���W�ɉ��Z���܂�
        /// </summary>
        public static void AddPositionX(this GameObject self, float x) {
            self.transform.AddPositionX(x);
        }

        /// <summary>
        /// Y���W�ɉ��Z���܂�
        /// </summary>
        public static void AddPositionY(this GameObject self, float y) {
            self.transform.AddPositionY(y);
        }

        /// <summary>
        /// Z���W�ɉ��Z���܂�
        /// </summary>
        public static void AddPositionZ(this GameObject self, float z) {
            self.transform.AddPositionZ(z);
        }

        /// <summary>
        /// ���[�J�����W�n��X���W�ɉ��Z���܂�
        /// </summary>
        public static void AddLocalPositionX(this GameObject self, float x) {
            self.transform.AddLocalPositionX(x);
        }

        /// <summary>
        /// ���[�J�����W�n��Y���W�ɉ��Z���܂�
        /// </summary>
        public static void AddLocalPositionY(this GameObject self, float y) {
            self.transform.AddLocalPositionY(y);
        }

        /// <summary>
        /// ���[�J�����W�n��Z���W�ɉ��Z���܂�
        /// </summary>
        public static void AddLocalPositionZ(this GameObject self, float z) {
            self.transform.AddLocalPositionZ(z);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �p�x�̐ݒ�

        /// <summary>
        /// ��]�p��ݒ肵�܂�
        /// </summary>
        public static void SetEulerAngle(this GameObject self, Vector3 eulerAngles) {
            self.transform.eulerAngles = eulerAngles;
        }

        /// <summary>
        /// X�������̉�]�p��ݒ肵�܂�
        /// </summary>
        public static void SetEulerAngleX(this GameObject self, float x) {
            self.transform.SetEulerAngleX(x);
        }

        /// <summary>
        /// Y�������̉�]�p��ݒ肵�܂�
        /// </summary>
        public static void SetEulerAngleY(this GameObject self, float y) {
            self.transform.SetEulerAngleY(y);
        }

        /// <summary>
        /// Z�������̉�]�p��ݒ肵�܂�
        /// </summary>
        public static void SetEulerAngleZ(this GameObject self, float z) {
            self.transform.SetEulerAngleZ(z);
        }

        /// <summary>
        /// ���[�J�����W�n�̉�]�p��ݒ肵�܂�
        /// </summary>
        public static void SetLocalEulerAngle(this GameObject self, Vector3 localEulerAngles) {
            self.transform.localEulerAngles = localEulerAngles;
        }

        /// <summary>
        /// ���[�J�����W�n��X�������̉�]�p��ݒ肵�܂�
        /// </summary>
        public static void SetLocalEulerAngleX(this GameObject self, float x) {
            self.transform.SetLocalEulerAngleX(x);
        }

        /// <summary>
        /// ���[�J�����W�n��Y�������̉�]�p��ݒ肵�܂�
        /// </summary>
        public static void SetLocalEulerAngleY(this GameObject self, float y) {
            self.transform.SetLocalEulerAngleY(y);
        }

        /// <summary>
        /// ���[�J�����W�n��Z�������̉�]�p��ݒ肵�܂�
        /// </summary>
        public static void SetLocalEulerAngleZ(this GameObject self, float z) {
            self.transform.SetLocalEulerAngleZ(z);
        }


        /// <summary>
        /// X�������̉�]�p�����Z���܂�
        /// </summary>
        public static void AddEulerAngleX(this GameObject self, float x) {
            self.transform.AddEulerAngleX(x);
        }

        /// <summary>
        /// Y�������̉�]�p�����Z���܂�
        /// </summary>
        public static void AddEulerAngleY(this GameObject self, float y) {
            self.transform.AddEulerAngleY(y);
        }

        /// <summary>
        /// Z�������̉�]�p�����Z���܂�
        /// </summary>
        public static void AddEulerAngleZ(this GameObject self, float z) {
            self.transform.AddEulerAngleZ(z);
        }

        /// <summary>
        /// ���[�J�����W�n��X�������̉�]�p�����Z���܂�
        /// </summary>
        public static void AddLocalEulerAngleX(this GameObject self, float x) {
            self.transform.AddLocalEulerAngleX(x);
        }

        /// <summary>
        /// ���[�J�����W�n��Y�������̉�]�p�����Z���܂�
        /// </summary>
        public static void AddLocalEulerAngleY(this GameObject self, float y) {
            self.transform.AddLocalEulerAngleY(y);
        }

        /// <summary>
        /// ���[�J�����W�n��X�������̉�]�p�����Z���܂�
        /// </summary>
        public static void AddLocalEulerAngleZ(this GameObject self, float z) {
            self.transform.AddLocalEulerAngleZ(z);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �X�P�[���̐ݒ�

        /// <summary>
        /// ���[�J�����W�n�̉�]�p��ݒ肵�܂�
        /// </summary>
        public static void SetLocalScale(this GameObject self, Vector3 localScale) {
            self.transform.localScale = localScale;
        }

        /// <summary>
        /// X�������̃��[�J�����W�n�̃X�P�[�����O�l��ݒ肵�܂�
        /// </summary>
        public static void SetLocalScaleX(this GameObject self, float x) {
            self.transform.SetLocalScaleX(x);
        }

        /// <summary>
        /// Y�������̃��[�J�����W�n�̃X�P�[�����O�l��ݒ肵�܂�
        /// </summary>
        public static void SetLocalScaleY(this GameObject self, float y) {
            self.transform.SetLocalScaleY(y);
        }

        /// <summary>
        /// Z�������̃��[�J�����W�n�̃X�P�[�����O�l��ݒ肵�܂�
        /// </summary>
        public static void SetLocalScaleZ(this GameObject self, float z) {
            self.transform.SetLocalScaleZ(z);
        }


        /// <summary>
        /// X�������̃��[�J�����W�n�̃X�P�[�����O�l�����Z���܂�
        /// </summary>
        public static void AddLocalScaleX(this GameObject self, float x) {
            self.transform.AddLocalScaleX(x);
        }

        /// <summary>
        /// Y�������̃��[�J�����W�n�̃X�P�[�����O�l�����Z���܂�
        /// </summary>
        public static void AddLocalScaleY(this GameObject self, float y) {
            self.transform.AddLocalScaleY(y);
        }

        /// <summary>
        /// Z�������̃��[�J�����W�n�̃X�P�[�����O�l�����Z���܂�
        /// </summary>
        public static void AddLocalScaleZ(this GameObject self, float z) {
            self.transform.AddLocalScaleZ(z);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �e�q�֌W

        /// <summary>
        /// �e�I�u�W�F�N�g��ݒ肷��g�����\�b�h
        /// </summary>
        public static GameObject SetParent(this GameObject self, Transform parent, bool worldPositionStays = true) {
            self.transform.SetParent(parent, worldPositionStays);
            return self;
        }

        /// <summary>
        /// �e�I�u�W�F�N�g��ݒ肷��g�����\�b�h
        /// </summary>
        public static GameObject SetParent(this GameObject self, GameObject parent, bool worldPositionStays = true) {
            self.transform.SetParent(parent.transform, worldPositionStays);
            return self;
        }

        /// <summary>
        /// �e�I�u�W�F�N�g��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetParentAndAlign(this GameObject self, GameObject parent) {
            if (parent == null) return;

            self.transform.SetParent(parent.transform, false);

            // �e�Ɠ������C���[�ƈʒu��^���� (��GameObjectUtility.SetParentAndAlign�Ɠ���)
            self.SetLayerRecursively(parent.layer);

            // 
            var rectTransform = self.transform as RectTransform;
            if (rectTransform) {
                rectTransform.anchoredPosition = Vector2.zero;
                Vector3 localPosition = rectTransform.localPosition;
                localPosition.z = 0;
                rectTransform.localPosition = localPosition;
            }
            // 
            else {
                self.transform.localPosition = Vector3.zero;
            }

            self.transform.localRotation = Quaternion.identity;
            self.transform.localScale = Vector3.one;
        }
        #endregion
    }
}
