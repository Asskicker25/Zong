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

        [SerializeField] private Color selectedColor = Color.black;
        [SerializeField] private Color unSelectedColor = Color.grey;

        [SerializeField] private TextMeshProUGUI textCached;
        [SerializeField] private Image imageCached;
        [SerializeField] private Button buttonCached;

        private BaseInventoryConfig _config;

        public void Setup(BaseInventoryConfig config)
        {
            _config = config;

            textCached.text = config.categoryName;
            imageCached.color = unSelectedColor;

            buttonCached.onClick.AddListener(SelectCategory);
        }

        public void SetState(bool selected)
        {
            imageCached.DOColor(selected ? selectedColor : unSelectedColor, 0.5f);
        }

        private void SelectCategory()
        {
            OnCategorySelected.Invoke(_config.inventoryType);
        }

        private void Reset()
        {
            imageCached = GetComponentInChildren<Image>();
            buttonCached = GetComponentInChildren<Button>();
            textCached = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

}
