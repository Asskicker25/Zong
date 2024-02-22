using UnityEngine;
using Scripts.Inventory;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;

namespace Scripts.ObjectPooling
{
    public class InventoryItem_PoolingService : MonoBehaviour
    {
        [SerializeField] private float poolAmount = 10.0f;

        private Dictionary<eInvetoryType, List<BaseInventoryItem>> inventoryItemPool;


        private void Awake()
        {
            inventoryItemPool = new Dictionary<eInvetoryType, List<BaseInventoryItem>>();
        }

        public BaseInventoryItem SpawnObject(BaseInventoryItemConfig config, Transform parent)
        {
            if (inventoryItemPool.TryGetValue(config.invetoryType, out List<BaseInventoryItem> listOfItems))
            {
                BaseInventoryItem item = GetItem(listOfItems);

                item.Setup(config);
                item.gameObject.SetActive(true);
                item.transform.parent = parent;

                return item;
            }
            else
            {
                List<BaseInventoryItem> baseInventoryItems = new List<BaseInventoryItem>();

                GrowPoolList(config, baseInventoryItems);

                inventoryItemPool.Add(config.invetoryType, baseInventoryItems);

                return SpawnObject(config, parent);
            }
        }

        public void GrowPoolList(BaseInventoryItemConfig config, List<BaseInventoryItem> list)
        {
            for (int i = 0; i < poolAmount; i++)
            {
                var spawnedItem = Instantiate(config.inventoryItem, transform);

                spawnedItem.gameObject.SetActive(false);

                list.Add(spawnedItem);
            }
        }

        public BaseInventoryItem GetItem(List<BaseInventoryItem> listOfItems)
        {
            foreach (BaseInventoryItem item in listOfItems)
            {
                if (item.gameObject.activeSelf == true) continue;

                return item;
            }

            GrowPoolList(listOfItems[0].config, listOfItems);

            return GetItem(listOfItems);
        }
    }

}
