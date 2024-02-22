using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.UI
{
    //The class that caches all the windows and handles opening and closing them through their ID
    public class UIWindowService : MonoBehaviour
    {
        [SerializeField]
        private List<UIWindow> _windows = new List<UIWindow>();

        private Dictionary<eUIWindowType, UIWindow> _windowsCached = new Dictionary<eUIWindowType, UIWindow>();

        // Start is called before the first frame update
        private void Reset()
        {
            _windows = GetComponentsInChildren<UIWindow>().ToList();
        }

        private void Start()
        {
            foreach (var window in _windows)
            {
                _windowsCached[window.windowType] = window;

                window.SetWindowService(this);

                if (window.awakeOnStart)
                {
                    window.Open(0);
                }
                else
                {
                    window.Close(0);
                }
            }
        }

        public void OpenWindow(eUIWindowType type)
        {
            _windowsCached[type].Open();
        }

        public void CloseWindow(eUIWindowType type)
        {
            _windowsCached[type].Close();
        }
    }

}
