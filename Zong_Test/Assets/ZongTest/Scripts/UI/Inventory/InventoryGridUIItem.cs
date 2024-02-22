using UnityEngine;
using Scripts.Inventory;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

namespace Scripts.UI
{
    public class InventoryGridUIItem : MonoBehaviour, IPointerClickHandler
    {
        public static event Action<BaseInventoryItemConfig> OnDropItemClicked = delegate { };

        [SerializeField] Button _buttonCached;
        [SerializeField] Image _imageCached;
        [SerializeField] TextMeshProUGUI _textCached;

        private BaseInventoryItemConfig _config;

        private void Reset()
        {
            _imageCached = GetComponentInChildren<Image>(); 
            _buttonCached = GetComponentInChildren<Button>();
            _textCached =  GetComponentInChildren <TextMeshProUGUI>();
        }

        public void Setup(BaseInventoryItemConfig config, int count)
        {
            this._config = config;

            _imageCached.sprite = config.itemUISprite;
            _imageCached.color = config.itemUIColor;

            _textCached.SetText(count + "");
        }

        public void UpdateCount(int count)
        {
            _textCached.SetText(count + "");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Right)
            {
                OnDropItemClicked.Invoke(_config);
            }
        }
    }

}
