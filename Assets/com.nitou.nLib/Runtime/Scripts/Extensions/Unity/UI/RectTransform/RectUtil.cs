using UnityEngine;

namespace nitou{

    /// <summary>
    /// <see cref="Rect"/>�Ɋւ���ėp���\�b�h�W
    /// </summary>
    public static class RectUtil{


        /// ----------------------------------------------------------------------------
        // ���΍��W

        /// <summary>
        /// �<see cref="Rect"/>�ɑ΂��鑊�Έʒu���擾����
        /// </summary>
        public static Vector2 GetRelativePosition(Vector2 targetPos, Rect baseRect) {
            float x = (targetPos.x - baseRect.x) / baseRect.width;
            float y = (targetPos.y - baseRect.y) / baseRect.height;
            return new Vector2(x, y);
        }

        /// <summary>
        /// �<see cref="Rect"/>�ɑ΂��鑊�΃T�C�Y���擾����
        /// </summary>
        public static Vector2 GetRelativeSize(Vector2 targetSize, Rect baseRect) {
            float width = targetSize.x / baseRect.width;
            float height = targetSize.y / baseRect.height;
            return new Vector2(width, height);
        }

        /// <summary>
        /// �<see cref="Rect"/>�ɑ΂��鑊�Έʒu�E�T�C�Y���擾����
        /// </summary>
        public static Rect GetRelativeRect(Rect targetRect, Rect baseRect) {
            Vector2 position = GetRelativePosition(targetRect.min, baseRect);
            Vector2 size = GetRelativeSize(targetRect.size, baseRect);
            return new Rect(position, size);
        }


        /// ----------------------------------------------------------------------------


        public static Rect Create(Vector2 center, Vector2 size) {
            float x = center.x - size.x / 2;
            float y = center.y - size.y / 2;
            return new Rect(x, y, size.x, size.y);
        }


        /// <summary>
        /// �ŏ��E�ő�_����Rect�𐶐�����
        /// </summary>
        public static Rect MinMaxRect(Vector2 min, Vector2 max) {
            return Rect.MinMaxRect(min.x, min.y, max.x, max.y);
        }
    }
}
