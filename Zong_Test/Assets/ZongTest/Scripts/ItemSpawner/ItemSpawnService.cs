using Scripts.Inventory;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.ItemSpawner
{
    public class ItemSpawnService : MonoBehaviour
    {
        [SerializeField] private List<BaseInventoryItemConfig> inventoryItemConfigs;
        [SerializeField] float spawnRadius = 50;
        [SerializeField] int spawnAmount = 10;

        private Dictionary<Collider, BaseInventoryItem> listOfSpawnedItems = new Dictionary<Collider, BaseInventoryItem>();

        public BaseInventoryItem GetItem(Collider collider) { return listOfSpawnedItems[collider]; }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                int index = Random.Range(0, inventoryItemConfigs.Count);

                var spawnedItem = Instantiate(inventoryItemConfigs[index].inventoryItem, transform);
                spawnedItem.Setup(inventoryItemConfigs[index]);

                Vector3 randomDir = new Vector3(Random.Range(0, 1.0f), 0, Random.Range(0, 1.0f));
                randomDir.Normalize();

                spawnedItem.transform.position = transform.position + randomDir * Random.Range(0, spawnRadius);

                listOfSpawnedItems.Add(spawnedItem.colliderAttached, spawnedItem);
            }
        }



    }

}

