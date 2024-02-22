using Scripts.Score;
using Scripts.UI;
using TMPro;
using UnityEngine;


namespace Scripts.Inventory
{
    public class PointsCategoryPanel : BaseInventoryCategory
    {
        [SerializeField] private ScoreConfig _scoreConfig;
        [SerializeField] private TextMeshProUGUI _textCached;

        private const string pointsSuffix = " pts";

        protected override void Reset()
        {
            base.Reset();
            windowType = eUIWindowType.INV_POINTS;
        }

        public override void Open(float time = 0.5F)
        {
            UpdateText();
            base.Open(time);
        }

        private void UpdateText() 
        {
            _textCached.SetText(_scoreConfig.score + pointsSuffix);
        }
    }

}
