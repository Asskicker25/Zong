using UnityEngine;
using Scripts.UI;

namespace Scripts.Inventory
{
    public class InstrumentsCategoryPanel : BaseInventoryCategory
    {
        protected override void Reset()
        {
            base.Reset();
            windowType = eUIWindowType.INV_INSTRUMENTS;
        }
    }

}
