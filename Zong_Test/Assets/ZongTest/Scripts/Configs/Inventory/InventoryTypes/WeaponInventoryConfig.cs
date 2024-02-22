using System.Collections.Generic;
using UnityEngine;
using Scripts.Weapons;

namespace Scripts.Inventory
{
    [CreateAssetMenu(fileName = "WeaponInventory", menuName = "Configs/Inventory/WeaponInventory")]
    public class WeaponInventoryConfig : BaseInventoryConfig
    {
        public List<BaseWeaponCategoryConfig> listOfWeaponCategories = new List<BaseWeaponCategoryConfig>();

        public InventoryCategoryUIElement categoryTab;
        public BaseWeaponCategoryPanel categoryPanel;

        private void Reset()
        {
            inventoryType = eInvetoryType.WEAPON;
        }
    }
}
