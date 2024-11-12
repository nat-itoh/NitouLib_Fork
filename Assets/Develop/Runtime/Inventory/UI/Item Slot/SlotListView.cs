using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Sirenix.OdinInspector;

namespace nitou.UI.View {

    /// <summary>
    /// �X���b�g���ꗗ�\������View�N���X
    /// </summary>
    public abstract class SlotListView<Slot, SlotInfo> : MonoBehaviour
        where Slot : Selectable {

        [Title("Slot")]

        [AssetsOnly]
        [SerializeField] private Slot _slotPrefab;

        // �i�[����e�I�u�W�F�N�g
        [SerializeField] private Transform _contentParent;

        protected readonly List<Slot> _slotList = new();
        private bool _isInitialized = false;

        // �萔
        protected const int DEFAULT_SLOT_NUM = 20;


        /// --------------------------------------------------------------------
        // Properity
        protected List<Slot> FilledSlotList => _slotList.GetRange(0, FilledSlotNum);

        /// <summary>
        /// ��񂪓o�^�ς݂̃X���b�g��
        /// </summary>
        public int FilledSlotNum => (_slotList != null) ? _slotList.Count(x => x.interactable) : 0;

        /// <summary>
        /// ��������Ă���S�X���b�g��
        /// </summary>
        public int AllSlotNum { get; private set; }

        /// <summary>
        /// ���������������Ă��邩�ǂ���
        /// </summary>
        public bool IsInitialized => _isInitialized;

        // ---

        /// <summary>
        /// UI Selection�̑Ώۃ��X�g
        /// </summary>
        public List<Selectable> Selectables => _slotList.OfType<Selectable>().ToList();

        /// <summary>
        /// �f�t�H���g�̑I��Ώ�
        /// </summary>
        public virtual Selectable DefaultSelection => _slotList.Count > 0 ? _slotList[0] : null;


        /// --------------------------------------------------------------------
        // Lifecycle Events

        protected virtual void OnDestroy() {
            DestroySlots();
        }


        /// --------------------------------------------------------------------
        // Public Method 

        /// <summary>
        /// View�̏�����
        /// </summary>
        public virtual void Initialize() {
            if (_isInitialized) return;

            CreateSlots(DEFAULT_SLOT_NUM);
            _isInitialized = true;
        }

        /// <summary>
        /// �X���b�g����o�^����
        /// </summary>
        public abstract void SetSlotInfo(IReadOnlyList<SlotInfo> slotDataList, System.Action<SlotInfo> onClick);

        /// <summary>
        /// �X���b�g������������
        /// </summary>
        public abstract void ClearSlotInfo();


        /// --------------------------------------------------------------------
        // private Method

        /// <summary>
        /// �X���b�g���X�g�𐶐�����
        /// </summary>
        protected void CreateSlots(int slotNum) {
            // ������
            DestroySlots();

            // �X���b�g��
            AllSlotNum = slotNum;

            // �X���b�g���X�g�̐���
            for (int i = 0; i < slotNum; i++) {
                var slot = InstantiateSlot();
                slot.name = $"Slot[{i + 1}/{AllSlotNum}]";

                _slotList.Add(slot);
            }
        }

        /// <summary>
        /// �X���b�g���X�g���폜����
        /// </summary>
        protected virtual void DestroySlots() {
            // ���X�g������
            if (_slotList != null) {
                _slotList.Clear();
            }

            // �q�G�����L�[������
            foreach (Transform child in _contentParent) {
                Destroy(child.gameObject);
            }
        }

        /// <summary>
        /// �X���b�g�̃C���X�^���X��
        /// </summary>
        protected virtual Slot InstantiateSlot() {
            var slot = GameObject.Instantiate<Slot>(_slotPrefab, parent: _contentParent);
            slot.interactable = false;

            return slot;
        }

    }

}