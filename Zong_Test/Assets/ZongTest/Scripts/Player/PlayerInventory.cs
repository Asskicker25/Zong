using UnityEngine;

namespace Scripts.Inventory
{
    public class PlayerInventory : MonoBehaviour
    {
        private InventoryService inventoryService;

        public void Setup(InventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }

    }

}
