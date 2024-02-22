using UnityEngine;
using Scripts.Inventory;

namespace Scripts.Instruments
{
    [CreateAssetMenu(fileName = "BaseInstrumentItemConfig", menuName = "Configs/Instruments/BaseInstrumentItemConfig")]
    public class BaseInstrumentItemConfig : BaseInventoryItemConfig
    {
        public eInstrumentType instrumentType;
    }

}
