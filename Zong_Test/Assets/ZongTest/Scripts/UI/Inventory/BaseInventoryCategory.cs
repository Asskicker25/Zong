using UnityEngine;
using Scripts.UI;
using DG.Tweening;

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
            transform.DOScale(1.0f, time);
            categoryTab.SetState(true);

            base.Open(time);
        }

        public override void Close(float time = 0.5F)
        {
            transform.DOScale(0.0f, time);
            categoryTab.SetState(false);

            base.Close(time);
        }
    }
}
