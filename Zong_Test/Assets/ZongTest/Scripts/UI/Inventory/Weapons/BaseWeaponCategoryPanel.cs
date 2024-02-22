using UnityEngine;
using Scripts.UI;
using Scripts.Inventory;
using DG.Tweening;

namespace Scripts.Weapons
{
    public class BaseWeaponCategoryPanel : BaseInventoryCategory
    {
        [SerializeField] private Transform noWeaponsText;

        protected override void Reset()
        {
            noWeaponsText = transform.GetChild(0);
        }

        public override void Open(float time = 0.5F)
        {
            base.Open(time);
            noWeaponsText.transform.DOScale(1.0f, time);
        }

        public override void Close(float time = 0.5F)
        {
            base.Close(time);
            noWeaponsText.transform.DOScale(0.0f, time);
        }
    }

}
