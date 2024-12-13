using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

namespace nitou {
    
    public class ScrollViewHighlighter : MonoBehaviour {

        [SerializeField, Indent] ScrollRect _scrollView;
        [SerializeField, Indent] ScrollVarTick _icon;


        // ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// 
        /// </summary>
        public bool SetTarget(RectTransform target) {
            if (_scrollView == null || _scrollView.content == null || _icon == null) return false;

            if (target == null || target.parent != _scrollView.content) {
                Debug.Log("target is null or not contents element.");
                return false;
            }

            var relativePos = GetNormalizedPosition(target);
            _icon.Rate = relativePos.y;
            return true;
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        private Vector2 GetNormalizedPosition(RectTransform selectedItem) {

            var itemPosition = selectedItem.GetWorldCenterPosition();

            // Content��Rect���
            var contentRect = _scrollView.content.GetWorldRect();   // ���J�n����Content SizeFitter�̃T�C�Y��0�ɂȂ�̂Œ���
            if (contentRect.size == Vector2.zero) return Vector2.zero;

            // Content���̑��Έʒu
            var relativePos = RectUtils.GetRelativePosition(itemPosition, contentRect);
            return relativePos;
        }
    }
}
