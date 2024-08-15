using UnityEngine;
using UnityEngine.UI;
using nitou;
using nitou.Inspector;

namespace Project {
    public class ScrollViewHighlighter : MonoBehaviour {

        [SerializeField] ScrollRect _scrollView;
        [SerializeField] RectTransform _selectedItem;
        [SerializeField] ScrollVarTick _icon;

        [Title("Info")]
        public float normalizedY = 0;


        void Update() {
            // Content���̑��Έʒu
            var selectedCenter = _selectedItem.GetWorldCenterPosition();
            Debug.Log($"selectedCenter :{selectedCenter}");

            // ��Content SizeFitter�̃T�C�Y��0�ɂȂ�
            var contentRect = _scrollView.content.GetWorldRect();
            Debug.Log($"contentRect :{contentRect}");

            if (contentRect.size == Vector2.zero) return;

            var relativePos = RectUtil.GetRelativePosition(selectedCenter, contentRect);
            Debug.Log($"relativePos :{relativePos}");
            normalizedY = relativePos.y;

            _icon.Rate = normalizedY;

        }


    }
}
