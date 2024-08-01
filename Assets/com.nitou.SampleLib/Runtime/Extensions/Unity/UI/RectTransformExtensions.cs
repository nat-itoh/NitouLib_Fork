using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// [�Q�l]
// �˂������V�e�B: RectTransform�̃T�C�Y���X�N���v�g����ύX���� https://nekojara.city/unity-rect-transform-size
// _: nGUI�Ȃǂ�RectTransform��width��height�Ȃǂ̒l��ύX������@ https://nekosuko.jp/1792/
// Unity Forums: Best algorithm to clamp a UI window within the canvas? https://forum.unity.com/threads/best-algorithm-to-clamp-a-ui-window-within-the-canvas.314034/
//  Hatena: RectTransform�̃X�N���[�����W��Rect���擾���� https://hacchi-man.hatenablog.com/entry/2020/12/11/220000

namespace nitou {
    //namespace UnityEngine {


    /// <summary>
    /// <see cref="RectTransform"/>�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class RectTransformExtensions {

        // [NOTE]
        //  �����Ƀ��[�X�P�[�X���������Ă���
        //  �E
        //  �E
        //  �E
        //  �E
        //  �E


        // �v�Z�p
        private static readonly Vector3[] _corners = new Vector3[4];
        private static readonly Vector3[] _corners2 = new Vector3[4];

        // �萔
        private const int CORNER_COUNT = 4;
        private const int LB = 0;   // Left bottom  ���������玞�v���Ɋi�[�����
        private const int LT = 1;   // Left top
        private const int RT = 2;   // Right top
        private const int RB = 3;   // Right bottom


        // ----------------------------------------------------------------------------

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


        /// ----------------------------------------------------------------------------
        #region �ϊ�

        // [�Q�l]
        //  �e���V���[��: Screen�̍��W��World�i3D�j���W�̕ϊ��ɂ��� https://tsubakit1.hateblo.jp/entry/2016/03/01/020510


        //public static Vector2 foo(Vector3 worldPoint) {

        //    return Vector2.zero;
        //}


        #endregion


        // ----------------------------------------------------------------------------
        #region �d�Ȃ蔻��

        // [�Q�l]
        //  kan�̃�����: RectTransform���d�Ȃ��Ă��邩(�Փ˂��Ă��邩)���R���C�_�[���g��Ȃ��Ŕ��肷��g�����\�b�h https://kan-kikuchi.hatenablog.com/entry/RectTransform_IsOverlapping
        //  Hatena: �����RectTransform�͈͓̔����ǂ������肷�� https://hacchi-man.hatenablog.com/entry/2020/05/09/220000

        /// <summary>
        /// ����<see cref="RectTransform"/>�Əd�Ȃ��Ă��邩���肷��g�����\�b�h
        /// </summary>
        public static bool Overlaps(this RectTransform self, RectTransform othrer) {

            // �R�[�i�[���W���擾
            self.GetWorldCorners(_corners);
            othrer.GetWorldCorners(_corners2);

            // �e�R�[�i�[���`�F�b�N
            for (var i =0; i< CORNER_COUNT; i++) {
                
                //rect1�̊p��rect2�̓����ɂ��邩
                if (IsPointInsideRect(_corners[i], _corners2)) {
                    return true;
                }
                //rect2�̊p��rect1�̓����ɂ��邩
                if (IsPointInsideRect(_corners2[i], _corners)) {
                    return true;
                }
            }

            return false;
        }

        // [�Q�l]
        //  _: �_�̑��p�`�ɑ΂�����O���� https://www.nttpc.co.jp/technology/number_algorithm.html
        private static bool IsPointInsideRect(Vector2 point, Vector3[] rectCorners) {
            var inside = false;

            //rectCorners�̊e���_�ɑ΂��āApoint��rect���ɂ��邩���m�F
            for (int i = 0, j = 3; i < CORNER_COUNT; j = i++) {
                // �������񐔂œ��O����
                if (((rectCorners[i].y > point.y) != (rectCorners[j].y > point.y)) &&
                    (point.x < (rectCorners[j].x - rectCorners[i].x) * (point.y - rectCorners[i].y) / (rectCorners[j].y - rectCorners[i].y) + rectCorners[i].x)) {
                    // ��������x�ɐ؂�ւ�
                    inside = !inside;
                }
            }

            return inside;
        }


        // 


        public static bool Contains(this RectTransform self, RectTransform other) {
            var selfBounds = GetBounds(self);
            var otherBounds = GetBounds(other);

            return selfBounds.Contains(new Vector3(otherBounds.min.x, otherBounds.min.y, 0f)) &&
                   selfBounds.Contains(new Vector3(otherBounds.max.x, otherBounds.max.y, 0f)) &&
                   selfBounds.Contains(new Vector3(otherBounds.min.x, otherBounds.max.y, 0f)) &&
                   selfBounds.Contains(new Vector3(otherBounds.max.x, otherBounds.min.y, 0f));
        }


        /// <summary>
        /// �v�Z�p��<see cref="Bounds"/>���擾����
        /// </summary>
        private static Bounds GetBounds(this RectTransform self) {
            var min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            var max = new Vector3(float.MinValue, float.MinValue, float.MinValue);

            // �ŏ��A�ő�̎擾
            self.GetWorldCorners(_corners);
            for (var i = 0; i < CORNER_COUNT; i++) {
                min = Vector3.Min(_corners[i], min);
                max = Vector3.Max(_corners[i], max);
            }

            max.z = 0f;
            min.z = 0f;

            // AABB���`
            var bounds = new Bounds(min, Vector3.zero);
            bounds.Encapsulate(max);
            return bounds;
        }

        #endregion




        /// ----------------------------------------------------------------------------

        public static Rect GetScreenRect(this RectTransform self, Camera camera) {
            self.GetWorldCorners(_corners);
            if (camera != null) {
                _corners[LB] = RectTransformUtility.WorldToScreenPoint(camera, _corners[LB]);
                _corners[RT] = RectTransformUtility.WorldToScreenPoint(camera, _corners[RT]);
            }

            var rect = new Rect {
                x = _corners[LB].x,
                y = _corners[LB].y,
                width = _corners[RT].x - _corners[LB].x,
                height = _corners[RT].y - _corners[LB].y
            };
            return rect;
        }

        public static Rect GetScreenRect(this RectTransform self, PointerEventData data) {
            return self.GetScreenRect(data.pressEventCamera);
        }


        public static Rect GetScreenRect(this RectTransform self) {
            var canvas = self.GetComponentInParent<Canvas>();
            return self.GetScreenRect(canvas.worldCamera);
        }



        /// ----------------------------------------------------------------------------
        // �T�C�Y�ݒ�

        /// <summary>
        /// Width��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetWidth(this RectTransform self, float width) {
            self.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        }

        /// <summary>
        /// Height��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetHeight(this RectTransform self, float height) {
            self.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }

        /// <summary>
        /// �T�C�Y���w�肷��g�����\�b�h
        /// </summary>
        public static void SetSize(this RectTransform self, Vector2 size) {

            // �e�v�f�̃T�C�Y�擾
            var parent = self.parent as RectTransform;
            var parentSize = parent != null ? parent.rect.size : Vector2.zero;

            // ���g�̃A���J�[�T�C�Y���v�Z
            var anchorSize = parentSize * (self.anchorMax - self.anchorMin);

            // ���̓T�C�Y����A���J�[�T�C�Y�����������ʂ�
            // sizeDelta�Ɏw�肷�ׂ��l
            self.sizeDelta = size - anchorSize;
        }


        /// ----------------------------------------------------------------------------
        // �s�{�b�g�ݒ�

        /// <summary>
        /// �s�{�b�gX��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetPivotX(this RectTransform self, float x) {
            self.pivot = new Vector2(Mathf.Clamp01(x), self.pivot.y);
        }

        /// <summary>
        /// �s�{�b�gY��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetPivotY(this RectTransform self, float y) {
            self.pivot = new Vector2(self.pivot.x, Mathf.Clamp01(y));
        }


        /// ----------------------------------------------------------------------------
        // ���W�ݒ�
    }


    public static class RectTransformUtil {



    }

}