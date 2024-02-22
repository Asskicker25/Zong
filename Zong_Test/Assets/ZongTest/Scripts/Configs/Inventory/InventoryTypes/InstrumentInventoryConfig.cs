using Scripts.Instruments;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Inventory
{
    [System.Serializable]
    public class InstrumentList
    {
        public InstrumentList(BaseInstrumentItemConfig item, int count = 1)
        {
            this.item = item;
            this.count = count;
        }

        public BaseInstrumentItemConfig item;
        public int count = 0;
    }

    [CreateAssetMenu(fileName = "InstrumentInventoryConfig", menuName = "Configs/Inventory/InstrumentInventoryConfig")]
    public class InstrumentInventoryConfig : BaseInventoryConfig
    {
        public List<InstrumentList> listOfInstruments = new List<InstrumentList>();

        private void Reset()
        {
            inventoryType = eInvetoryType.INSTRUMENTS;
        }

        public void AddItem(BaseInstrumentItemConfig itemConfig)
        {
            InstrumentList result = listOfInstruments.FirstOrDefault(x => x.item.instrumentType == itemConfig.instrumentType);

            if(result != null)
            {
                result.count++;
            }
            else
            {
                listOfInstruments.Add(new InstrumentList(itemConfig));
            }
        }

        public void RemoveItem(BaseInstrumentItemConfig itemConfig)
        {
            InstrumentList result = listOfInstruments.FirstOrDefault(x => x.item.instrumentType == itemConfig.instrumentType);

            if (result != null)
            {
                result.count--;

                if(result.count == 0)
                {
                    listOfInstruments.Remove(result);
                }
            }
        }


    }

}
