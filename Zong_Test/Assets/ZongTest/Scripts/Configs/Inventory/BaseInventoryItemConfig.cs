using UnityEngine;

namespace Scripts.Inventory
{
    public class BaseInventoryItemConfig : ScriptableObject
    {

        public Sprite itemUISprite;
        public Color itemUIColor = Color.white;

        public BaseInventoryItem inventoryItem;
        public Material modelMaterial;

        public eInvetoryType invetoryType;
    }

}
