using UnityEngine;
using Scripts.UI;

namespace Scripts.Inventory
{
    public class BaseInventoryCategory : UIWindow
    {
        [HideInInspector]
        public InventoryCategoryUIElement categoryTab;

        [SerializeField] BaseInventoryConfig config;

        public virtual void Setup(BaseInventoryConfig config, InventoryCategoryUIElement categoryTab)
        {
            this.config = config;
            this.categoryTab = categoryTab;

            Close();
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
