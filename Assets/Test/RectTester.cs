using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test {

    public class RectTester : MonoBehaviour {

        [SerializeField] RectTransform _canvas;
        [SerializeField] RectTransform _target;


        public Vector2 viewport;
        public float canvasLength;
        public float rectLength;


        private void Update() {
            if (_canvas == null || _target == null) {
                viewport = Vector2.zero;
                return;
            }

            // �T�C�Y
            canvasLength = _canvas.GetGrobalWidth();
            rectLength = _target.GetGrobalWidth();

            // �r���[�|�[�g���W
            viewport = _target.GetViewportPosition(_canvas);

        }


    }

    /// <summary>
    /// <see cref="RectTransform"/>�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static partial class RectTransformExtensions {

        // �v�Z�p
        private static readonly Vector3[] _corners = new Vector3[4];

        #region Get Position/Size
        
        // [NOTE]
        //  RectTransform.GetCorners��0:�����A1����A2:�E��A3:�E���̏��œ_���i�[�����

        /// <summary>
        /// ���[���h���W�ł̕����擾����
        /// </summary>
        public static float GetGrobalWidth(this RectTransform self) {
            self.GetWorldCorners(_corners);
            float width = Vector3.Distance(_corners[0], _corners[3]);
            return width;
        }

        /// <summary>
        /// ���[���h���W�ł̍������擾����
        /// </summary>
        public static float GetWorldHeight(this RectTransform self) {
            self.GetWorldCorners(_corners);
            float height = Vector3.Distance(_corners[0], _corners[1]);
            return height;
        }

        /// <summary>
        /// ���[���h���W�ł̈ʒu�ƃT�C�Y���擾����
        /// </summary>
        public static (Vector2 pos, Vector2 size) GetWorldPositionAndSize(this RectTransform self) {
            self.GetWorldCorners(_corners);
            Vector2 pos = _corners[0];  // ��Z�͖���
            float width = Vector3.Distance(_corners[0], _corners[3]);  
            float height = Vector3.Distance(_corners[0], _corners[1]); 
            return (pos, new Vector2(width, height));
        }

        /// <summary>
        /// �L�����o�X�ɑ΂��鑊�Έʒu(0~1)���擾����
        /// </summary>
        public static Vector2 GetViewportPosition(this RectTransform self) {
            // [NOTE]
            // Game��ʂł̐�΍��W���擾����̂��ӊO�ƍ���������߁A
            // Canvas���瑊�Έʒu���擾������j�Ŏ���.

            // ���߂�Canvas���擾
            var canvas = self.GetParentCanvas();
            if (canvas == null) {
                Debug.LogWarning("RectTransform is not a child of a Canvas. Returning Vector2.zero.");
                return Vector2.zero;
            }
            var canvasRect = canvas.GetComponent<RectTransform>();

            // ���[���h���W�ł̈ʒu�E�T�C�Y (��pixel���W�ł͂Ȃ�)
            var (canvasPos, canvasSize) = canvasRect.GetWorldPositionAndSize();
            var (selfPos, _) = self.GetWorldPositionAndSize();

            // �L�����o�X�̈ʒu�E�T�C�Y�Ő��K���������W�i��canva�l�� 0 ~ 1�j
            return new Vector2(
                (selfPos.x - canvasPos.x) / canvasSize.x,
                (selfPos.y - canvasPos.y) / canvasSize.y);
        }
        #endregion


        #region Misc

        /// <summary>
        /// �e�K�w�����ǂ��ď�������<see cref="Canvas"/>���擾����g�����\�b�h
        /// </summary>
        public static Canvas GetParentCanvas(this RectTransform self) {
            var currentTrans = self.transform;
            while (currentTrans != null) {
                if (currentTrans.TryGetComponent<Canvas>(out var canvas)) {
                    return canvas;
                }
                currentTrans = currentTrans.parent;
            }
            return null;
        }
        #endregion
    }

}