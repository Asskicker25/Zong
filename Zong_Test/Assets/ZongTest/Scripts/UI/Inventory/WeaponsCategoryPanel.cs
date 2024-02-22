using DG.Tweening;
using Scripts.UI;
using Scripts.Weapons;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Inventory
{
    public class WeaponsCategoryPanel : BaseInventoryCategory
    {
        [SerializeField] private Transform tabParentPanel;
        [SerializeField] private Transform categoryParentPanel;

        private WeaponInventoryConfig _weaponConfig;

        private eInvetoryType _currentWeaponCategory = eInvetoryType.NONE;

        private Dictionary<eInvetoryType, BaseWeaponCategoryPanel> listOfWeaponPanels = new Dictionary<eInvetoryType, BaseWeaponCategoryPanel>();


        protected override void Reset()
        {
            base.Reset();
            windowType = eUIWindowType.INV_WEAPONS;
        }

        public override void Open(float time = 0.5F)
        {
            base.Open(time);
        }

        public override void Close(float time = 0.5F)
        {
            base.Close(time);
        }

        public override void Setup(BaseInventoryConfig config, InventoryCategoryUIElement categoryTab)
        {
            base.Setup(config, categoryTab);
            _weaponConfig = (WeaponInventoryConfig)config;

            foreach (BaseWeaponCategoryConfig weapon in _weaponConfig.listOfWeaponCategories)
            {
                if(_currentWeaponCategory == eInvetoryType.NONE) {  _currentWeaponCategory = weapon.inventoryType; }

                InventoryCategoryUIElement spawnedTabPanel = Instantiate(_weaponConfig.categoryTab, tabParentPanel);
                BaseWeaponCategoryPanel spawnedCategoryPanel = Instantiate(_weaponConfig.categoryPanel, categoryParentPanel);

                spawnedTabPanel.Setup(weapon);
                spawnedCategoryPanel.Setup(weapon, spawnedTabPanel);

                spawnedTabPanel.OnCategorySelected += CategoryTab_OnCategorySelected;

                listOfWeaponPanels.Add(weapon.inventoryType, spawnedCategoryPanel);
            }

            OpenCurrentCategory();
        }

        private void OpenCurrentCategory()
        {
            listOfWeaponPanels[_currentWeaponCategory].Open();

        }

        private void CloseCurrentCategory()
        {
            listOfWeaponPanels[_currentWeaponCategory].Close();
        }

        public void OpenCategory(eInvetoryType type)
        {
            CloseCurrentCategory();
            _currentWeaponCategory = type;
            OpenCurrentCategory();
        }

        private void CategoryTab_OnCategorySelected(eInvetoryType type)
        {
            OpenCategory(type);
        }

        private void OnDestroy()
        {
            foreach (var panel in listOfWeaponPanels)
            {
                panel.Value.categoryTab.OnCategorySelected -= CategoryTab_OnCategorySelected;
            }

        }

    }

}
