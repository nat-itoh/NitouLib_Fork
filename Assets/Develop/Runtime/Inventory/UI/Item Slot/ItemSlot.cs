using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UniRx;
using Sirenix.OdinInspector;


// [�Q�l]
//  Unity Comunity: How to detect interactable state change in selectable objects (Buttons, etc.) https://discussions.unity.com/t/how-to-detect-interactable-state-change-in-selectable-objects-buttons-etc/150644

namespace nitou.UI.View {

    /// <summary>
    /// �A�C�e����\�����邽�߂̃X���b�gView�D
    /// </summary>
    public class ItemSlot : Selectable, 
        IPointerClickHandler, IEventSystemHandler, ISubmitHandler {

        /// --------------------------------------------------------------------
        #region Inner Definition

        /// <summary>
        /// View�p�̃A�C�e���f�[�^��`
        /// ��GUID�݂̂ŏ\������Presenter�Ńf�[�^��List�œn�������̂ł܂��͂����
        /// </summary>
        public struct ItemSlotData {
            public string Name;
            public Sprite Icon;
            public ItemRarity Rarity;   // ���A�x
            public float Durability;    // �ϋv�l
            public int Attack;          // �U����
            // -----
            public string Guid;         // GUID
            public object ItemPtr;      // 
        }

        /// <summary>
        /// �A�C�e���̃��A�x
        /// </summary>
        public enum ItemRarity {
            C,
            B,
            A,
            S
        }
        #endregion


        /// --------------------------------------------------------------------
        // View Component

        [Header("View Components")]

        [SerializeField] private Image _iconImage;
        [SerializeField] private Image _backdropImage;

        // �A�C�R�����e�L�X�g
        [SerializeField] private TextMeshProUGUI _iconText;

        [Header("Switching Objects")]

        [LabelText("when slot is interactable")]
        [SerializeField] private GameObject _activeObject;

        [LabelText("when slot is not interactable")]
        [SerializeField] private GameObject _deactiveObject;

        [LabelText("when slot is selected")]
        [SerializeField] private GameObject _highlitingObj;


        /// --------------------------------------------------------------------
        // View State

        public ItemSlotData ViewState { get; private set; }

        public int Index { get; set; } = -1;

        /// <summary>
        /// �N���b�N���̃C�x���g�ʒm
        /// </summary>
        public Subject<ItemSlotData> OnClickSubject = new();


        /// --------------------------------------------------------------------
        // MonoBehaviour Method

        protected override void Awake() {
            base.Awake();
            _highlitingObj.SetActive(false);
        }

        protected override void OnDestroy() {
            base.OnDestroy();
            OnClickSubject.Dispose();
        }


        /// --------------------------------------------------------------------
        // Interface Method

        public override void OnSelect(BaseEventData eventData) {
            base.OnSelect(eventData);
            _highlitingObj.SetActive(true);
        }

        public override void OnDeselect(BaseEventData eventData) {
            base.OnDeselect(eventData);
            _highlitingObj?.SetActive(false);
        }

        public virtual void OnPointerClick(PointerEventData eventData) {
            if (interactable) {
                OnClickSubject.OnNext(this.ViewState);

            }
        }

        public virtual void OnSubmit(BaseEventData eventData) {
            if (interactable) {
                OnClickSubject.OnNext(this.ViewState);
            }
        }


        /// --------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �A�C�e������ݒ肷��
        /// </summary>
        public void SetItemData(ItemSlotData data) {
            ViewState = data;

            // View�X�V
            this.interactable = true;
            this._iconImage.sprite = ViewState.Icon;
        }

        /// <summary>
        /// �A�C�e����������������
        /// </summary>
        public void ClearItemData() {
            ViewState = new ItemSlotData();

            // View�X�V
            this.interactable = false;
            this._iconImage.sprite = null;
            this._iconText.text = $"";
            this.Index = -1;
        }

        /// <summary>
        /// �A�C�R�����̃e�L�X�g��ݒ肷��
        /// </summary>
        public void SetIconText(string str) {
            this._iconText.text = str;
        }


        /// --------------------------------------------------------------------
        // Private Method

        /// <summary>
        /// �X�e�[�g���ω������Ƃ��̏���
        /// </summary>
        protected override void DoStateTransition(SelectionState state, bool instant) {

            if (state == SelectionState.Disabled) {
                _activeObject.SetActive(false);
                _deactiveObject.SetActive(true);
            } else {
                _activeObject.SetActive(true);
                _deactiveObject.SetActive(false);
            }
        }

    }

}