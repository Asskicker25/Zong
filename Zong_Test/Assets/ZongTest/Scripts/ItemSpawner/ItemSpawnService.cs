using Scripts.Inventory;
using System.Collections.Generic;
using UnityEngine;
using Scripts.ObjectPooling;
using System;
using Random = UnityEngine.Random;

namespace Scripts.ItemSpawner
{
    public class ItemSpawnService : MonoBehaviour
    {
        public static event Action<BaseInventoryItem, Vector3> OnItemDropped = delegate { };

        [SerializeField] private InventoryItem_PoolingService poolingService;
        [SerializeField] private List<BaseInventoryItemConfig> inventoryItemConfigs;
        [SerializeField] float spawnRadius = 50;
        [SerializeField] float dropDistanceFromPlayer = 2;
        [SerializeField] int spawnAmount = 10;

        private Dictionary<Collider, BaseInventoryItem> listOfSpawnedItems = new Dictionary<Collider, BaseInventoryItem>();

        public BaseInventoryItem GetItem(Collider collider) { return listOfSpawnedItems[collider]; }

        private void OnEnable()
        {
            PlayerInventory.OnItemDropped += PlayerInventory_OnItemDropped;
        }


        private void OnDisable()
        {
            PlayerInventory.OnItemDropped -= PlayerInventory_OnItemDropped;
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                int index = Random.Range(0, inventoryItemConfigs.Count);

                //var spawnedItem = Instantiate(inventoryItemConfigs[index].inventoryItem, transform);

                var spawnedItem = poolingService.SpawnObject(inventoryItemConfigs[index], transform);

                Vector3 randomDir = new Vector3(Random.Range(0, 1.0f), 0, Random.Range(0, 1.0f));
                randomDir.Normalize();

                spawnedItem.transform.position = transform.position + randomDir * Random.Range(0, spawnRadius);
                spawnedItem.transform.localScale = Vector3.one;

                listOfSpawnedItems.Add(spawnedItem.colliderAttached, spawnedItem);
            }
        }

        private void PlayerInventory_OnItemDropped(BaseInventoryItemConfig config, Transform playerTransform)
        {
            var spawnItem = poolingService.SpawnObject(config, transform);
            spawnItem.transform.position = playerTransform.position + playerTransform.forward * dropDistanceFromPlayer;
            spawnItem.transform.localScale = Vector3.one;

            OnItemDropped.Invoke(spawnItem, spawnItem.transform.position);
        }

    }

}

