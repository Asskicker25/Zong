using UnityEngine;
using UnityEngine.UI;
using System;

namespace Scripts.UI
{
    public class MainMenuWindow : UIWindow
    {
        public static event Action OnTapToStart = delegate { };

        [SerializeField] private Button _button;

        override protected void Reset()
        {
            base.Reset();
            awakeOnStart = true;

            _button = GetComponentInChildren<Button>();
            
        }

        private void Start()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            windowService.CloseWindow(windowType);

            OnTapToStart.Invoke();
        }
    }

}
