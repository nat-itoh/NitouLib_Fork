using UnityEngine;

namespace nitou.InventorySystem {

    /// <summary>
    /// �A�C�e���ɑ΂���R�}���h�D
    /// </summary>
    public abstract class ItemCommand<TItem>
        where TItem : IInventoryItem {

        /// <summary>
        /// �R�}���h�����s����D
        /// </summary>
        public abstract void Execute(TItem item);
    }


    /// <summary>
    /// �A�C�e���ɑ΂���R�}���h�D
    /// </summary>
    public abstract class ItemCommand<TItem, TInventory>
        where TItem : IInventoryItem 
        where TInventory : Inventory<TItem>{

        /// <summary>
        /// �R�}���h�����s����D
        /// </summary>
        public abstract void Execute(TItem item, TInventory inventory);
    }

}
