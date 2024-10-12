using UnityEngine;

namespace nitou{

    /// <summary>
    /// <see cref="Canvas"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class CanvasExtensions{

        /// <summary>
        /// �X�N���[�����W�擾�̊g�����\�b�h
        /// </summary>
        public static Vector2 GetScreenPosition(this Canvas canvas, Vector2 worldPos, Camera camera = null) {
            // �f�t�H���g�J�����̐ݒ�
            camera ??= Camera.main;

            // �X�N���[�����W
            return canvas.renderMode switch {
                RenderMode.ScreenSpaceOverlay => worldPos,
                RenderMode.ScreenSpaceCamera => RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, worldPos),
                RenderMode.WorldSpace => RectTransformUtility.WorldToScreenPoint(camera, worldPos),
                _ => throw new System.NotImplementedException()
            };
        }

        /// <summary>
        /// �X�N���[��Rect�擾�̊g�����\�b�h
        /// </summary>
        public static Rect GetScreenRect(this Canvas canvas, Vector2 worldMin, Vector2 worldMax, Camera camera = null) {
            Vector2 screenMin, screenMax;
            camera ??= Camera.main;

            // �X�N���[�����W
            switch (canvas.renderMode) {
                case RenderMode.ScreenSpaceOverlay:
                    screenMin = worldMin;
                    screenMax = worldMax;
                    break;
                case RenderMode.ScreenSpaceCamera:
                    screenMin = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, worldMin);
                    screenMax = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, worldMax);
                    break;
                case RenderMode.WorldSpace:
                    screenMin = RectTransformUtility.WorldToScreenPoint(camera, worldMin);
                    screenMax = RectTransformUtility.WorldToScreenPoint(camera, worldMax);
                    break;
                default:
                    throw new System.NotImplementedException();
            }

            return RectUtil.MinMaxRect(screenMin, screenMax);
        }
    }
}
