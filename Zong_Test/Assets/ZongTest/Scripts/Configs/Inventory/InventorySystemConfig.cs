using System.Collections.Generic;
using UnityEngine;
using Scripts.UI;

namespace Scripts.Inventory
{
    [CreateAssetMenu(fileName = "InventorySystemConfig", menuName = "Configs/Inventory/InventorySystemConfig")]
    public class InventorySystemConfig : ScriptableObject
    {

        public InventoryCategoryUIElement categoryUIElement;

        public List<BaseInventoryConfig> listOfInventoryConfigs = new List<BaseInventoryConfig>();

        private Dictionary<eInvetoryType, BaseInventoryConfig> inventoryConfigs = new Dictionary<eInvetoryType, BaseInventoryConfig>();

        public BaseInventoryConfig GetInventoryConfig(eInvetoryType type) { return inventoryConfigs[type]; }

        public void Initialize()
        {
            foreach(BaseInventoryConfig config in listOfInventoryConfigs)
            {
                inventoryConfigs.Add(config.inventoryType, config);
            }
        }


    }

}
