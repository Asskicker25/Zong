using System.Collections.Generic;
using UnityEngine;
using Scripts.UI;

namespace Scripts.Inventory
{
    [CreateAssetMenu(fileName = "InventorySystemConfig", menuName = "Configs/Inventory/InventorySystemConfig")]
    public class InventorySystemConfig : ScriptableObject
    {
        public List<BaseInventoryConfig> listOfInventoryConfigs = new List<BaseInventoryConfig>();

        public InventoryCategoryUIElement categoryUIElement;
    }

}
