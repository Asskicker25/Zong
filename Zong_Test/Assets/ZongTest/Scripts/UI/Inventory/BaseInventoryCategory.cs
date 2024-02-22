using UnityEngine;
using Scripts.UI;

namespace Scripts.Inventory
{
    public class BaseInventoryCategory : UIWindow
    {
        public InventoryCategoryUIElement categoryTab;

        public void Setup(InventoryCategoryUIElement categoryTab)
        {
            this.categoryTab = categoryTab; 
        }

        public override void Open(float time = 0.5F)
        {
            base.Open(time);
            categoryTab.SetState(true);
        }

        public override void Close(float time = 0.5F)
        {
            base.Close(time);
            categoryTab.SetState(false);
        }
    }
}
