using NaughtyAttributes;
using Scripts.Instruments;
using UnityEngine;

namespace Scripts.Inventory
{
    public class InventoryService : MonoBehaviour
    {
        [SerializeField] private InventorySystemConfig inventorySystemConfig;

        private void Awake()
        {
            inventorySystemConfig.Initialize();
        }

        public void AddItem(BaseInventoryItemConfig inventoryItem)
        {
            switch (inventoryItem.invetoryType)
            {
                case eInvetoryType.INSTRUMENTS: HandleAddingToInstruments(inventoryItem); break; 
            }
        }

        public void RemoveItem(BaseInventoryItemConfig inventoryItem)
        {
            switch (inventoryItem.invetoryType)
            {
                case eInvetoryType.INSTRUMENTS: HandleRemovingFromInstuments(inventoryItem); break;
            }
        }

        private void HandleAddingToInstruments(BaseInventoryItemConfig inventoryItem)
        {
            BaseInstrumentItemConfig config = (BaseInstrumentItemConfig)inventoryItem;

            InstrumentInventoryConfig inventoryConfig = (InstrumentInventoryConfig)inventorySystemConfig.GetInventoryConfig(config.invetoryType);

            inventoryConfig.AddItem(config);
        }

        private void HandleRemovingFromInstuments(BaseInventoryItemConfig inventoryItem)
        {
            BaseInstrumentItemConfig config = (BaseInstrumentItemConfig)inventoryItem;
            InstrumentInventoryConfig inventoryConfig = (InstrumentInventoryConfig)inventorySystemConfig.GetInventoryConfig(config.invetoryType);

            inventoryConfig.RemoveItem(config);

        }



    }
}
