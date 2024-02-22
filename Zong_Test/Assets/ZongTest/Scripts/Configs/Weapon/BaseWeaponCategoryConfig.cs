using UnityEngine;
using Scripts.UI;
using Scripts.Inventory;
using System.Collections.Generic;

namespace Scripts.Weapons
{
    [CreateAssetMenu(fileName = "BaseWeaponCategoryConfig", menuName = "Configs/Weapons/BaseWeaponCategoryConfig")]
    public class BaseWeaponCategoryConfig : BaseInventoryConfig
    {
        public List<BaseWeaponConfig> listOfWeaponConfigs = new List<BaseWeaponConfig>();
    }

}
