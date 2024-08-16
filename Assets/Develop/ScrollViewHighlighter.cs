using UnityEngine;
using UnityEngine.UI;
using nitou;
using nitou.Inspector;

namespace Project {
    public class ScrollViewHighlighter : MonoBehaviour {

        [SerializeField, Indent] ScrollRect _scrollView;
        [SerializeField, Indent] RectTransform _selectedItem;
        [SerializeField, Indent] ScrollVarTick _icon;

        [Title("Info")]

        [ReadOnly]
        [SerializeField, Indent] float normalizedY = 0;


        void Update() {

            var itemPosition = _selectedItem.GetWorldCenterPosition();
            
            // Content���̑��Έʒu
            var contentRect = _scrollView.content.GetWorldRect();   // ���J�n����Content SizeFitter�̃T�C�Y��0�ɂȂ�̂Œ���
            if (contentRect.size == Vector2.zero) return;
            var relativePos = RectUtil.GetRelativePosition(itemPosition, contentRect);

            //Debug.Log($"contentRect :{contentRect}");


            //Debug.Log($"relativePos :{relativePos}");
            normalizedY = relativePos.y;

            _icon.Rate = normalizedY;

        }


    }
}
