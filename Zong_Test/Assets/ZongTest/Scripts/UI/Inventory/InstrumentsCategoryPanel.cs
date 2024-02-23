using UnityEngine;
using Scripts.UI;
using DG.Tweening;
using System.Collections.Generic;
using Scripts.Instruments;
using System;
using Unity.VisualScripting;


namespace Scripts.Inventory
{
    public class InstrumentsCategoryPanel : BaseInventoryCategory
    {
        public static event Action OnSelected = delegate { };

        [SerializeField] private Transform itemSpawnPanel;
        [SerializeField] private Transform noItemsText;

        private Dictionary<eInstrumentType, InventoryGridUIItem> listOfGridElements = new Dictionary<eInstrumentType, InventoryGridUIItem>();

        private InstrumentInventoryConfig _instrumentInventoryConfig;

        private void OnEnable()
        {
            PlayerInventory.OnItemDropped += PlayerInventory_OnItemDropped;
        }

      
        private void OnDisable()
        {
            PlayerInventory.OnItemDropped -= PlayerInventory_OnItemDropped;
        }

        protected override void Reset()
        {
            base.Reset();
            windowType = eUIWindowType.INV_INSTRUMENTS;
        }

        private void Start()
        {
            _instrumentInventoryConfig = (InstrumentInventoryConfig)config;
        }

        public override void Open(float time = 0.5F)
        {
            OnSelected.Invoke();
            DisplayItems(time);
            base.Open(time);
        }

        private void PlayerInventory_OnItemDropped(BaseInventoryItemConfig arg1, Transform arg2)
        {
            DisplayItems();
        }


        private void DisplayItems(float time = 0.5f)
        {
            if (_instrumentInventoryConfig.listOfInstruments.Count == 0)
            {
                noItemsText.transform.DOScale(1.0f, time);
            }
            else
            {
                noItemsText.transform.localScale = Vector3.zero;
            }

            foreach (var item in listOfGridElements)
            {
                item.Value.gameObject.SetActive(false);
            }


            foreach (var item in _instrumentInventoryConfig.listOfInstruments)
            {
                if (listOfGridElements.TryGetValue(item.item.instrumentType, out InventoryGridUIItem value))
                {
                    if (item.count == 0)
                    {
                        value.gameObject.SetActive(false);
                    }
                    else
                    {
                        value.gameObject.SetActive(true);
                        value.UpdateCount(item.count);
                    }

                }
                else
                {
                    var spawnedElement = Instantiate(_instrumentInventoryConfig.gridElement, itemSpawnPanel);
                    spawnedElement.Setup(item.item, item.count);

                    listOfGridElements.Add(item.item.instrumentType, spawnedElement);
                }
            }
        }
    }

}
