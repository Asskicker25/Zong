using UnityEngine;
using Scripts.ItemSpawner;
using NaughtyAttributes;
using System;
using Scripts.UI;

namespace Scripts.Inventory
{
    public class PlayerInventory : MonoBehaviour
    {
        public static event Action<BaseInventoryItemConfig> OnItemPicked = delegate { };
        public static event Action<BaseInventoryItemConfig, Transform> OnItemDropped = delegate { };

        [Foldout("Raycast")]
        [SerializeField] private float _raycastDistance;
        [Foldout("Raycast")]
        [SerializeField] private LayerMask _raycastMask;
        [Foldout("Raycast")]
        [SerializeField] private LayerMask _chestMask;

        private bool _canRaycast = true;

        private InventoryService _inventoryService;
        private ItemSpawnService _itemSpawnService;

        private Ray _ray;
        private RaycastHit _hitInfo;
        private BaseInventoryItem _rayHitItem;

        public void Setup(InventoryService inventoryService, ItemSpawnService itemSpawnService)
        {
            this._inventoryService = inventoryService;
            this._itemSpawnService = itemSpawnService;
        }

        private void OnEnable()
        {
            InventoryWindow.OnInventoryClosed += InventoryWindow_OnInventoryClosed;
            InstrumentsCategoryPanel.OnSelected += InstrumentsCategoryPanel_OnSelected;
            InventoryGridUIItem.OnDropItemClicked += InventoryGridUIItem_OnDropItemClicked;
        }


        private void OnDisable()
        {
            InventoryWindow.OnInventoryClosed -= InventoryWindow_OnInventoryClosed;
            InstrumentsCategoryPanel.OnSelected -= InstrumentsCategoryPanel_OnSelected;
            InventoryGridUIItem.OnDropItemClicked -= InventoryGridUIItem_OnDropItemClicked;
        }

        private void Update()
        {
            Raycast();
        }

        private void Raycast()
        {
            if (!_canRaycast) return;

            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hitInfo, _raycastDistance, _raycastMask))
            {
                //Getting component by caching collider in dictionary is fasted than compare tag.
                _rayHitItem = _itemSpawnService.GetItem(_hitInfo.collider);

                if (InteractPressed()) return;
            }
            else
            {
                _rayHitItem = null;
            }

            if (Physics.Raycast(_ray, out _hitInfo, _raycastDistance, _chestMask))
            {
                if (InteractPressed()) return;
            }

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 posInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Gizmos.DrawLine(posInWorld, posInWorld + Camera.main.transform.forward * _raycastDistance);
        }

        private bool InteractPressed()
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F))
            {
                _canRaycast = false;
                OnItemPicked.Invoke(_rayHitItem == null? null : _rayHitItem.config);

                return true;
            }
            return false;
        }

        private void InventoryWindow_OnInventoryClosed()
        {
            _rayHitItem = null;
            _canRaycast = true;
        }

        private void InstrumentsCategoryPanel_OnSelected()
        {
            if (_rayHitItem == null) { return; }

            _rayHitItem.CollectItem();
            _inventoryService.AddItem(_rayHitItem.config);
        }
        private void InventoryGridUIItem_OnDropItemClicked(BaseInventoryItemConfig config)
        {
            _inventoryService.RemoveItem(config);

            OnItemDropped.Invoke(config, transform);
        }

        public void ResetPlayer()
        {
            _canRaycast = true;
        }


    }

}
