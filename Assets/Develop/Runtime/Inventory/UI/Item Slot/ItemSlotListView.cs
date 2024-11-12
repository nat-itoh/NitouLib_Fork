using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;
using Sirenix.OdinInspector;

using ItemSlotData = nitou.UI.View.ItemSlot.ItemSlotData;



namespace nitou.UI.View {

    /// <summary>
    /// ItemSlot�̃��X�g��\������View
    /// </summary>
    public class ItemSlotListView : SlotListView<ItemSlot, ItemSlot.ItemSlotData> {

        /// --------------------------------------------------------------------
        #region Inner Definition

        /// <summary>
        /// 
        /// </summary>
        public enum SortType {
            Rarity,
            Durability,
            Attack,
        }
        #endregion

        /// --------------------------------------------------------------------

        [Title("Information Bar")]
        [SerializeField] TextMeshProUGUI _sortTypeText;
        [SerializeField] TextMeshProUGUI _countText;

        // ���݂̃^�C�v
        public SortType CurrentType { get; private set; }

        // �C�x���g�ʒm
        public event System.Action OnSetSlotInfo;
        public event System.Action OnClearSlotInfo;
        public event System.Action OnSlotSorted;


        /// --------------------------------------------------------------------
        // Public Method 

        /// <summary>
        /// �X���b�g����o�^����
        /// </summary>
        public override void SetSlotInfo(IReadOnlyList<ItemSlotData> slotDataList, System.Action<ItemSlotData> onCleck = null) {
            if (FilledSlotNum > 0) ClearSlotInfo();

            var itemNum = slotDataList.Count;
            for (int i = 0; i < itemNum && i < AllSlotNum; i++) {
                // �X���b�g�̃Z�b�g�A�b�v
                var slot = _slotList[i];
                slot.SetItemData(slotDataList[i]);
                slot.interactable = true;
                slot.OnClickSubject.Subscribe(x => onCleck?.Invoke(x));
            }

            // �㏈��
            OnSetSlotInfo?.Invoke();    // �C�x���g�ʒm
            UpdateInfomationBar();      // View�X�V
        }

        /// <summary>
        /// �X���b�g������������
        /// </summary>
        public override void ClearSlotInfo() {
            foreach (var slot in _slotList) {
                slot.ClearItemData();
                slot.interactable = false;
            }

            // �㏈��
            OnClearSlotInfo?.Invoke();  // �C�x���g�ʒm
        }

        /// <summary>
        /// �X���b�g���X�g���\�[�g����
        /// </summary>
        public virtual void SortSlots(SortType sortType = SortType.Attack) {
            if (FilledSlotNum <= 1 || CurrentType == sortType) return;
            CurrentType = sortType;

            // 
            var filledSlots = _slotList.GetRange(0, FilledSlotNum);                             // �f�[�^�����͂��ꂽ�X���b�g
            var emptySlots = _slotList.GetRange(FilledSlotNum, AllSlotNum - FilledSlotNum);     // �����͂̃X���b�g

            // �w��v�f�Ń\�[�g
            var orderdList = CurrentType switch {
                SortType.Rarity => filledSlots.OrderByDescending(x => x.ViewState.Rarity).ToList(),
                SortType.Attack => filledSlots.OrderByDescending(x => x.ViewState.Attack).ToList(),
                SortType.Durability => filledSlots.OrderByDescending(x => x.ViewState.Durability).ToList(),
                _ => throw new System.NotImplementedException()
            };

            // ���X�g�X�V
            orderdList.AddRange(emptySlots);
            //_slotList = orderdList;

            // �q�G�����L�[�X�V
            for (int i = 0; i < FilledSlotNum; i++) {
                _slotList[i].transform.SetSiblingIndex(i);
            }

            // �㏈��
            OnSlotSorted?.Invoke();
            UpdateInfomationBar();      // View�X�V
        }


        /// --------------------------------------------------------------------
        // Private Method 

        /// <summary>
        ///  �\�[�g���@�e�L�X�g���X�V����
        /// </summary>
        private void UpdateSortTypeText() {

            // �A�C�R���e�L�X�g�X�V
            foreach (var slot in FilledSlotList) {
                var str = CurrentType switch {
                    SortType.Rarity => slot.ViewState.Rarity.ToString(),
                    SortType.Durability => $"{slot.ViewState.Durability:#}",    // ���������̂ݕ\��
                    SortType.Attack => $"{slot.ViewState.Attack}",
                    _ => ""
                };
                slot.SetIconText(str);
            }

            // 
            // �\�[�g�e�L�X�g
            _sortTypeText.text = $"> {CurrentType}";
            //_sortTypeText.DOFade(1, .2f).From(0);
        }

        /// <summary>
        /// �X���b�g���e�L�X�g���X�V����
        /// </summary>
        private void UpdateSlotCountText() {
            _countText.text = $"{FilledSlotNum}/{AllSlotNum}";
        }

        /// <summary>
        /// �C���t�H���[�V�����o�[�̕\�����X�V����
        /// </summary>
        private void UpdateInfomationBar() {
            UpdateSortTypeText();
            UpdateSlotCountText();
        }




        /// --------------------------------------------------------------------
        // Test Code

        //private void Update() {
        //    if (Keyboard.current.qKey.wasPressedThisFrame) {
        //        SortSlots(Type.Attack);

        //    } else if (Keyboard.current.wKey.wasPressedThisFrame) {
        //        SortSlots(Type.Rarity);

        //    } else if (Keyboard.current.eKey.wasPressedThisFrame) {
        //        SortSlots(Type.Durability);

        //    }
        //}


    }


}