using UnityEngine;

namespace Scripts.Inventory
{
    public class BaseInventoryConfig : ScriptableObject
    {
        public string categoryName = "Unnamed";
        public eInvetoryType inventoryType;
        public BaseInventoryCategory uiCategoryPanel;

        public Color tabSelectedColor = new Color(0.05f, 0.05f, 0.05f, 1);
        public Color tabUnSelectedColor = new Color(0.25f, 0.25f, 0.25f, 1);
    }

}
