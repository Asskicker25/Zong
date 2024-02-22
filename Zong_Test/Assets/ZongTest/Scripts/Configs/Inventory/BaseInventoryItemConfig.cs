using UnityEngine;

namespace Scripts.Inventory
{
    public class BaseInventoryItemConfig : ScriptableObject
    {
        public string pickUpMessage = "Pick Up Item";
        public Sprite itemUISprite;
        public Color itemUIColor = Color.white;

        public BaseInventoryItem inventoryItem;
        public Material modelMaterial;

        public eInvetoryType invetoryType;
    }

}
