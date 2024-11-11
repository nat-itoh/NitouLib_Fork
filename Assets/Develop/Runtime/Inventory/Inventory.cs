using System;
using System.Collections.Generic;
using UniRx;

namespace nitou.InventorySystem {

    /// <summary>
    /// �V���v���ȃC���x���g���̊��N���X�D
    /// </summary>
    public abstract class Inventory<TItem> : IDisposable
        where TItem : IInventoryItem {

        protected readonly ReactiveCollection<TItem> _items = new ();

        /// <summary>
        /// �O������̍w�Ǘp�D
        /// </summary>
        public IReadOnlyReactiveCollection<TItem> Items => _items;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public Inventory() {

        }

        /// <summary>
        /// �I�������D
        /// </summary>
        public void Dispose() {
            _items.Dispose();
        }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// 
        /// </summary>
        public virtual void AddItem(TItem item) {
            _items.Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void RemoveItem(TItem item) {
            _items.Remove(item);
        }

        public IReadOnlyList<TItem> GetItems() {
            return _items;
        }

    }

}
