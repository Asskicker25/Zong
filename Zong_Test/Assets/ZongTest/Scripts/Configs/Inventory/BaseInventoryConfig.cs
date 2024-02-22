using UnityEngine;

namespace Scripts.Inventory
{
    public class BaseInventoryConfig : ScriptableObject
    {
        public string categoryName = "Unnamed";
        public eInvetoryType inventoryType;
        public BaseInventoryCategory uiCategoryPanel;
    }

}
