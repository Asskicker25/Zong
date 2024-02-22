using Scripts.UI;
using UnityEngine;


namespace Scripts.Inventory
{
    public class PointsCategoryPanel : BaseInventoryCategory
    {
        protected override void Reset()
        {
            base.Reset();
            windowType = eUIWindowType.INV_POINTS;
        }
    }

}
