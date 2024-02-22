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

        [Foldout("Raycast")]
        [SerializeField] private float _raycastDistance;
        [Foldout("Raycast")]
        [SerializeField] private LayerMask _raycastMask;

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
        }

        private void OnDisable()
        {
            InventoryWindow.OnInventoryClosed -= InventoryWindow_OnInventoryClosed;
            InstrumentsCategoryPanel.OnSelected -= InstrumentsCategoryPanel_OnSelected;
        }

        private void Update()
        {
            if (!Raycast()) return;

            SetInput();
        }

        private bool Raycast()
        {
            if(!_canRaycast) return false;

            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hitInfo, _raycastDistance, _raycastMask))
            {
                //Getting component by caching collider in dictionary is fasted than compare tag.
                _rayHitItem = _itemSpawnService.GetItem(_hitInfo.collider);
                return true;
            }

            _rayHitItem = null;
            return false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 posInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Gizmos.DrawLine(posInWorld, posInWorld + Camera.main.transform.forward * _raycastDistance);
        }

        private void SetInput()
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F))
            {
                _canRaycast = false;
                OnItemPicked.Invoke(_rayHitItem.config);
            }
        }


        private void InventoryWindow_OnInventoryClosed()
        {
            _rayHitItem = null;
            _canRaycast = true;
        }

        private void InstrumentsCategoryPanel_OnSelected()
        {
            if(_rayHitItem == null) { return; }

            _rayHitItem.CollectItem();
            _inventoryService.AddItem(_rayHitItem.config);
        }


    }

}
