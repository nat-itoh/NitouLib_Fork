using UnityEngine;
using UnityEngine.UI;
using nitou; // RectTransformExtensions �̂��閼�O���

namespace Project {
    public class TestMono : MonoBehaviour {

        public RectTransformExtensions.Corner corner;

        [SerializeField] private RectTransform _worldCanvasRect;  // ����Ώۂ� RectTransform
        [SerializeField] private Button[] _buttons;               // �{�^���z��i�����̃{�^���j
        private int _currentButtonIndex = 0;                      // ���݂̃{�^���Q��

        private void Start() {
            // �e�{�^���ɈقȂ���W�ւ̈ړ��C�x���g��ǉ�
            for (int i = 0; i < _buttons.Length; i++) {
                int index = i;  // �N���[�W���΍�
                _buttons[i].onClick.AddListener(() => OnButtonClicked(index));
            }
        }

        /// <summary>
        /// �{�^�����N���b�N���ꂽ�Ƃ��̏���
        /// </summary>
        /// <param name="buttonIndex">�����ꂽ�{�^���̃C���f�b�N�X</param>
        private void OnButtonClicked(int buttonIndex) {
            // �{�^�����ƂɈقȂ�^�[�Q�b�g�ʒu��ݒ�
            Vector2[] targetPositions = new Vector2[]
            {
                new Vector2(1, 1),  // �{�^��1���������Ƃ��̃^�[�Q�b�g�ʒu
                new Vector2(2, 2),  // �{�^��2���������Ƃ��̃^�[�Q�b�g�ʒu
                new Vector2(-2, 1),  // �{�^��3���������Ƃ��̃^�[�Q�b�g�ʒu
                new Vector2(0       , 0),  // �{�^��3���������Ƃ��̃^�[�Q�b�g�ʒu
            };

            // RectTransform �̈ʒu�� SetWorldPosition �ňړ�
            if (buttonIndex < targetPositions.Length) {
                //_worldCanvasRect.SetWorldPosition(targetPositions[buttonIndex], corner);
                _worldCanvasRect.SetWorldCenterPosition(targetPositions[buttonIndex]);
                Debug.Log($"Button {buttonIndex + 1} clicked: New Position = {targetPositions[buttonIndex]}");
            } else {
                Debug.LogWarning("Invalid button index or target position");
            }

            // ���݂̍��W���X�V����
            UpdateButtonText(_buttons[buttonIndex], targetPositions[buttonIndex]);
        }

        /// <summary>
        /// �{�^���̃e�L�X�g�Ɍ��݂̈ʒu��\��
        /// </summary>
        /// <param name="button">�Ώۂ̃{�^��</param>
        /// <param name="position">�\��������W</param>
        private void UpdateButtonText(Button button, Vector2 position) {
            var buttonText = button.GetComponentInChildren<Text>();
            if (buttonText != null) {
                buttonText.text = $"Move to ({position.x}, {position.y})";
            }
        }
    }
}
