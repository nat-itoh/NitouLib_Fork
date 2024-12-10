using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityScreenNavigator.Runtime.Core.Modal;
using Sirenix.OdinInspector;

namespace nitou.UI.BasicScreens {

    /// <summary>
    /// �m�F���[�_���̊��N���X�D
    /// </summary>
    public abstract class ConfirmModalBase : Modal {

        [TitleGroup("Text")]
        [SerializeField, Indent] protected TextMeshProUGUI _titleText;

        [TitleGroup("Text")]
        [SerializeField, Indent] protected TextMeshProUGUI _messageText;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �\���e�L�X�g��ݒ肷��
        /// </summary>
        public void SetText(string title, string message) {
            if (_titleText != null) {
                _titleText.text = title;
            }

            if (_messageText != null) {
                _messageText.text = message;
            }
        }


        /// ----------------------------------------------------------------------------
        // Lifecycle Events

        /// <summary>
        /// �I������
        /// </summary>
        public override Task Cleanup() {
            return base.Cleanup();
        }
    }
        

}