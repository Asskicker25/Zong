using System.Collections.Generic;
using UnityEngine;
using Scripts.Weapons;

namespace Scripts.Inventory
{
    [CreateAssetMenu(fileName = "WeaponInventory", menuName = "Configs/Inventory/WeaponInventory")]
    public class WeaponInventoryConfig : BaseInventoryConfig
    {
        public List<BaseWeaponConfig> listOfWeaponConfigs = new List<BaseWeaponConfig>();

        private void Reset()
        {
            inventoryType = eInvetoryType.WEAPON;
        }
    }
}
