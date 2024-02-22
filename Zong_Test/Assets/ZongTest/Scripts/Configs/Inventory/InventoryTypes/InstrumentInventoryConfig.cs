using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Inventory
{
    [CreateAssetMenu(fileName = "InstrumentInventoryConfig", menuName = "Configs/Inventory/InstrumentInventoryConfig")]
    public class InstrumentInventoryConfig : BaseInventoryConfig
    {
        private void Reset()
        {
            inventoryType = eInvetoryType.INSTRUMENTS;
        }
    }

}
