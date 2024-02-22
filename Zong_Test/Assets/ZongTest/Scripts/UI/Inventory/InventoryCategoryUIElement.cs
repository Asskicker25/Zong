using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System;

namespace Scripts.Inventory
{
    public class InventoryCategoryUIElement : MonoBehaviour
    {
        public event Action<eInvetoryType> OnCategorySelected = delegate { };

        [SerializeField] private TextMeshProUGUI textCached;
        [SerializeField] private Image imageCached;
        [SerializeField] private Button buttonCached;

        private BaseInventoryConfig config;

        public void Setup(BaseInventoryConfig config)
        {
            this.config = config;
          
            textCached.SetText(config.categoryName);

            imageCached.color  = config.tabUnSelectedColor;

            buttonCached.onClick.AddListener(SelectCategory);
        }

        public void SetState(bool selected)
        {
            imageCached.DOColor(selected ? config.tabSelectedColor : config.tabUnSelectedColor, 0.5f);
        }

        private void SelectCategory()
        {
            OnCategorySelected.Invoke(config.inventoryType);
        }

        private void Reset()
        {
            imageCached = GetComponentInChildren<Image>();
            buttonCached = GetComponentInChildren<Button>();
            textCached = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

}
