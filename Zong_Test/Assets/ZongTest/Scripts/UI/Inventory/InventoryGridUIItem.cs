using UnityEngine;
using Scripts.Inventory;
using UnityEngine.UI;
using TMPro;

namespace Scripts.UI
{
    public class InventoryGridUIItem : MonoBehaviour
    {
        [SerializeField] Button _buttonCached;
        [SerializeField] Image _imageCached;
        [SerializeField] TextMeshProUGUI _textCached;

        private void Reset()
        {
            _imageCached = GetComponentInChildren<Image>(); 
            _buttonCached = GetComponentInChildren<Button>();
            _textCached =  GetComponentInChildren <TextMeshProUGUI>();
        }

        public void Setup(BaseInventoryItemConfig config, int count)
        {
            _imageCached.sprite = config.itemUISprite;
            _imageCached.color = config.itemUIColor;

            _textCached.SetText(count + "");
        }

        public void UpdateCount(int count)
        {
            _textCached.SetText(count + "");
        }

    }

}
