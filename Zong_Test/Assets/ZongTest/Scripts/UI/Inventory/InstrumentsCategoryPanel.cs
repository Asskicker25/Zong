using UnityEngine;
using Scripts.UI;
using DG.Tweening;
using System.Collections.Generic;
using Scripts.Instruments;
using Unity.VisualScripting.FullSerializer;

namespace Scripts.Inventory
{
    public class InstrumentsCategoryPanel : BaseInventoryCategory
    {
        [SerializeField] private Transform itemSpawnPanel;

        private Dictionary<eInstrumentType, InventoryGridUIItem> listOfGridElements = new Dictionary<eInstrumentType, InventoryGridUIItem>();

        private InstrumentInventoryConfig _instrumentInventoryConfig;

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
            DisplayItems();
            base.Open(time);
        }

        private void DisplayItems()
        {
            foreach (var item in _instrumentInventoryConfig.listOfInstruments)
            {
                if (listOfGridElements.TryGetValue(item.item.instrumentType, out InventoryGridUIItem value))
                {
                    value.UpdateCount(item.count);
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
