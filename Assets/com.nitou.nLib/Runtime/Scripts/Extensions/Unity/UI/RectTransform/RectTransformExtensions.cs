using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// [�Q�l]
//  �˂������V�e�B: RectTransform�̃T�C�Y���X�N���v�g����ύX���� https://nekojara.city/unity-rect-transform-size
//  _: nGUI�Ȃǂ�RectTransform��width��height�Ȃǂ̒l��ύX������@ https://nekosuko.jp/1792/
//  Unity Forums: Best algorithm to clamp a UI window within the canvas? https://forum.unity.com/threads/best-algorithm-to-clamp-a-ui-window-within-the-canvas.314034/
//  Hatena: RectTransform�̃X�N���[�����W��Rect���擾���� https://hacchi-man.hatenablog.com/entry/2020/12/11/220000

namespace nitou {

    // [NOTE]
    //  ���[�X�P�[�X���������Ă���
    //  �E
    //  �E
    //  �E
    //  �E
    //  �E

    /// <summary>
    /// <see cref="RectTransform"/>�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static partial class RectTransformExtensions {

        // [NOTE] RectTransform.GetCorners��0:�����A1����A2:�E��A3:�E���̏��œ_���i�[�����

        // �v�Z�p
        private static readonly Vector3[] _corners = new Vector3[4];
        private static readonly Vector3[] _corners2 = new Vector3[4];

        // �萔
        private const int CORNER_COUNT = 4;

        /// <summary>
        /// Rect�̊e�R�[�i�[
        /// </summary>
        public enum Corner {
            Min = 0,
            MinX_MaxY = 1,
            Max = 2,
            MaxX_MinY = 3
        }


        // ----------------------------------------------------------------------------
        #region WORLD���W

        /// <summary>
        /// ���[���h���W�ł̈ʒu���擾����
        /// </summary>
        public static Vector2 GetWorldPosition(this RectTransform self, Corner corner = Corner.Min) {
            self.GetWorldCorners(_corners);

            return _corners[(int)corner];  // ��Z�͖���
        }

        /// <summary>
        /// ���[���h���W�ł̒��S�ʒu���擾����
        /// </summary>
        public static Vector2 GetWorldCenterPosition(this RectTransform self) {
            self.GetWorldCorners(_corners);

            return _corners.GetCenter();
        }

        /// <summary>
        /// ���[���h���W�ł̃T�C�Y���擾����
        /// </summary>
        public static Vector2 GetWorldSize(this RectTransform self) {
            self.GetWorldCorners(_corners);

            var min = _corners[(int)Corner.Min];
            var max = _corners[(int)Corner.Max];
            return max - min;
        }

        /// <summary>
        /// ���[���h���W�ł̈ʒu�ƃT�C�Y���擾����
        /// </summary>
        public static Rect GetWorldRect(this RectTransform self) {
            self.GetWorldCorners(_corners);

            var min = _corners[(int)Corner.Min];
            var max = _corners[(int)Corner.Max];
            return new Rect(min, max -min);
        }
        #endregion


        // ----------------------------------------------------------------------------
        #region SCREEN���W

        // [�Q�l]
        //  �e���V���[��: Screen�̍��W��World�i3D�j���W�̕ϊ��ɂ��� https://tsubakit1.hateblo.jp/entry/2016/03/01/020510
        //  LIGHT11: uGUI�ɃA���t�@�t���̃}�X�N���|���� https://light11.hatenadiary.com/entry/2019/04/24/232041

        /// <summary>
        /// �X�N���[�����W�ł̈ʒu���擾����
        /// </summary>
        public static Vector2 GetScreenPosition(this RectTransform self, Canvas canvas = null, Corner corner = Corner.Min) {
            if (self == null) throw new System.ArgumentNullException(nameof(self));
            if (canvas == null) {
                canvas = self.GetBelongedCanvas();
            }

            // ���[���h���W
            var worldPos = self.GetWorldPosition(corner);

            // �X�N���[�����W
            return canvas.renderMode switch {
                RenderMode.ScreenSpaceOverlay => worldPos,
                RenderMode.ScreenSpaceCamera => RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, worldPos),
                RenderMode.WorldSpace => RectTransformUtility.WorldToScreenPoint(Camera.main, worldPos),
                _ => throw new System.NotImplementedException()
            };
        }

        /// <summary>
        /// �X�N���[�����W�ł̈ʒu���擾����
        /// </summary>
        public static Rect GetScreenRect(this RectTransform self, Canvas canvas = null) {
            if (self == null) throw new System.ArgumentNullException(nameof(self));
            if (canvas == null) {
                canvas = self.GetBelongedCanvas();
            }

            // ���[���h���W
            var worldMin = self.GetWorldPosition(Corner.Min);
            var worldMax = self.GetWorldPosition(Corner.Max);

            // �X�N���[�����W
            Vector2 screenMin, screenMax;
            switch (canvas.renderMode) {
                case RenderMode.ScreenSpaceOverlay: {
                        screenMin = worldMin;
                        screenMax = worldMax;
                        return RectUtil.MinMaxRect(screenMin, screenMax);
                    }
                case RenderMode.ScreenSpaceCamera: {
                        screenMin = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, worldMin);
                        screenMax = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, worldMax);
                        return RectUtil.MinMaxRect(screenMin, screenMax);
                    }
                case RenderMode.WorldSpace: {   // ��WorldCanvas���Rect���K�v�Ȃ瑊�΍��W���g�p����
                        screenMin = RectTransformUtility.WorldToScreenPoint(Camera.main, worldMin);
                        screenMax = RectTransformUtility.WorldToScreenPoint(Camera.main, worldMax);
                        return RectUtil.MinMaxRect(screenMin, screenMax);
                    }
                default:
                    throw new System.NotImplementedException();
            }
        }
        #endregion



        // ----------------------------------------------------------------------------
        #region VIEW PORT���W

        /// <summary>
        /// �r���[�|�[�g���W�n�ł̈ʒu���擾����
        /// </summary>
        public static Vector2 GetViewportPos(this RectTransform self, Canvas canvas = null, Corner corner = Corner.Min) {

            // �X�N���[�����W
            var screenPos = self.GetScreenPosition(canvas, corner);
            
            // �r���[�|�[�g���W
            return new Vector2(screenPos.x / Screen.width, screenPos.y / Screen.height);
        }

        /// <summary>
        /// �r���[�|�[�g���W�n�ł̈ʒu�ƃT�C�Y���擾����
        /// </summary>
        public static Rect GetViewportRect(this RectTransform self, Canvas canvas = null) {
            
            // �X�N���[�����W
            var screenRect = self.GetScreenRect(canvas);

            // �r���[�|�[�g���W
            var viewportMin = new Vector2(screenRect.min.x / Screen.width, screenRect.min.y / Screen.height);
            var viewportSize = new Vector2(screenRect.size.x / Screen.width, screenRect.size.y / Screen.height);
            return new Rect(viewportMin, viewportSize);
        }

        #endregion


        // ----------------------------------------------------------------------------
        #region RELATIVE���W

        // [FIXME] �ǂ���ɑ΂��鑊�Έʒu�A�T�C�Y�Ȃ̂��B���Ȃ̂𓝈ꂷ��

        /// <summary>
        /// ���ΓI�Ȉʒu���擾����
        /// </summary>
        public static Vector2 GetRelativePosition(this RectTransform self, Vector2 position) {
            if (self == null) throw new System.ArgumentNullException(nameof(self), "self recttransform cannot be null.");

            // ���[���h���W�ł̈ʒu (��pixel���W�ł͂Ȃ�)
            var selfRect = self.GetWorldRect();

            // ���Έʒu
            return RectUtil.GetRelativePosition(position, selfRect);
        }

        /// <summary>
        /// ���ΓI�Ȉʒu�ƃT�C�Y���擾����
        /// </summary>
        public static Rect GetRelativeRect(this RectTransform self, RectTransform other) {
            if (self == null) throw new System.ArgumentNullException(nameof(self), "self recttransform cannot be null.");
            if (other == null) throw new System.ArgumentNullException(nameof(other), "other recttransform cannot be null.");

            // ���[���h���W�ł̈ʒu�E�T�C�Y (��pixel���W�ł͂Ȃ�)
            var selfRect = self.GetWorldRect();
            var otherRect = other.GetWorldRect();

            // ���Έʒu
            var relativePos = new Vector2(
                (selfRect.position.x - otherRect.position.x) / otherRect.size.x,
                (selfRect.position.y - otherRect.position.y) / otherRect.size.y);
            // ���΃T�C�Y
            var relativeSize = new Vector2(
                selfRect.size.x / otherRect.size.x,
                selfRect.size.y / otherRect.size.y);

            return new Rect(relativePos, relativeSize);
        }

        #endregion




        private static Vector3 GetCenter(this Vector3[] corners) {
            return (corners[(int)Corner.Min] + corners[(int)Corner.Max]) / 2f;
        }

        private static Vector2 GetCenter(Vector2 min, Vector2 max) {
            return (min + max) / 2f;
        }








        // ----------------------------------------------------------------------------
        #region �R���|�[�l���g�擾

        /// <summary>
        /// �e�K�w�����ǂ��ď�������<see cref="Canvas"/>���擾����g�����\�b�h
        /// </summary>
        public static Canvas GetBelongedCanvas(this RectTransform self) {
            var currentTrans = self.transform;
            while (currentTrans != null) {
                if (currentTrans.TryGetComponent<Canvas>(out var canvas)) {
                    return canvas;
                }
                currentTrans = currentTrans.parent;
            }
            return null;
        }

        /// <summary>
        /// �e�K�w�����ǂ��ď�������<see cref="CanvasScaler"/>���擾����g�����\�b�h
        /// </summary>
        public static CanvasScaler GetBelongedCanvasScaler(this RectTransform self) {
            var canvas = self.GetBelongedCanvas();
            if (canvas is null) return null;

            return canvas.GetComponent<CanvasScaler>();
        }
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
            for (var i = 0; i < CORNER_COUNT; i++) {

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
        #region ���̑�

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

        #endregion
    }


}
