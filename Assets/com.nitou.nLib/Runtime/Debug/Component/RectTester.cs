using UnityEngine;
using nitou;

namespace test {

    public class RectTester : MonoBehaviour {

        [SerializeField] RectTransform _target;
        [SerializeField] Canvas _canvas;
        private RectTransform _canvasRect;

        [Header("Screen")]
        public Rect screen;

        [Header("viewport")]
        public Rect viewport;

        [Header("Relative")]
        public Rect relative;

        [Space]
        public Vector2 canvasSize;
        public Vector2 selfSize;



        private void Update() {
            if (_canvas == null || _target == null) {
                viewport = Rect.zero;
                return;
            }

            if(_canvasRect == null) {
                _canvasRect = _canvas.GetComponent<RectTransform>();
            }

            // 
            screen = _target.GetScreenRect(_canvas);

            // �r���[�|�[�g���W
            viewport.position = _target.GetViewportPos(_canvas);

            // ����
            relative = _target.GetRelativeRect(_canvasRect);




            // �T�C�Y
            canvasSize = _canvasRect.GetWorldSize();
            selfSize = _target.GetWorldSize();
        }


    }




}