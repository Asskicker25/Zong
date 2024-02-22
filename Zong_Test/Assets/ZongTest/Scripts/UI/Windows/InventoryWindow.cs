using Scripts.Inventory;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Player;
using UnityEngine.UI;
using System;
using DG.Tweening;
using System.Linq;

namespace Scripts.UI
{
    public class InventoryWindow : UIWindow
    {
        public static event Action OnInventoryClosed = delegate { };

        [SerializeField] private InventorySystemConfig inventorySystemConfig;
        [SerializeField] private Transform categoryContentPanel;
        [SerializeField] private Transform categoryTabParentPanel;
        [SerializeField] private Transform categoryParentPanel;
        [SerializeField] private Button closeButton;

        private eInvetoryType _currentCategory = eInvetoryType.WEAPON;

        private Dictionary<eInvetoryType, BaseInventoryCategory> listOfCategories = new Dictionary<eInvetoryType, BaseInventoryCategory>();

        private void OnEnable()
        {
            PlayerController.OnInventoryOpen += PlayerController_OnInventoryOpen;
        }

        private void OnDisable()
        {
            PlayerController.OnInventoryOpen -= PlayerController_OnInventoryOpen;
        }


        protected override void Reset()
        {
            base.Reset();
            windowType = eUIWindowType.INVENTORY;
        }

        private void Start()
        {
            SpawnCategories();
            OpenCurrentCategory();
            categoryContentPanel.transform.localScale = Vector3.zero;

            closeButton.onClick.AddListener(CloseInventory);
        }

        private void OpenCurrentCategory()
        {
            listOfCategories[_currentCategory].Open();
        }

        private void CloseCurrentCategory()
        {
            listOfCategories[_currentCategory].Close();
        }

        public void OpenCategory(eInvetoryType type)
        {
            CloseCurrentCategory();
            _currentCategory = type;
            OpenCurrentCategory();
        }

        private void PlayerController_OnInventoryOpen()
        {
            categoryContentPanel.transform.DOScale(Vector3.one, 0.5f);

            windowService.OpenWindow(windowType);
            OpenCurrentCategory();
        }

        private void SpawnCategories()
        {
            foreach (BaseInventoryConfig config in inventorySystemConfig.listOfInventoryConfigs)
            {
                if(_currentCategory == eInvetoryType.NONE) { _currentCategory = config.inventoryType; }

                InventoryCategoryUIElement spawnedCategoryTab = Instantiate(inventorySystemConfig.categoryUIElement,categoryTabParentPanel);
                BaseInventoryCategory spawnedCategoryPanel = Instantiate(config.uiCategoryPanel, categoryParentPanel);

                spawnedCategoryTab.Setup(config);
                spawnedCategoryTab.OnCategorySelected += CategoryTab_OnCategorySelected;

                spawnedCategoryPanel.Setup(config, spawnedCategoryTab);

                listOfCategories.Add(config.inventoryType, spawnedCategoryPanel);
            }

        }

        private void CategoryTab_OnCategorySelected(eInvetoryType type)
        {
            OpenCategory(type);
        }

        private void CloseInventory()
        {
            categoryContentPanel.transform.DOScale(Vector3.zero, 0.5f);
            windowService.CloseWindow(windowType);

            OnInventoryClosed.Invoke();

            OpenCategory(listOfCategories.First().Key);
        }

        private void OnDestroy()
        {
            foreach(var panel in listOfCategories)
            {
                panel.Value.categoryTab.OnCategorySelected -= CategoryTab_OnCategorySelected; 
            }

        }


    }

}
