using UnityEngine;
using Scripts.UI;
using System;

namespace Scripts.GameLoop
{
    public class GameService : MonoBehaviour
    {
        public static event Action OnGameplayStart = delegate { };

        private void OnEnable()
        {
            MainMenuWindow.OnTapToStart += MainMenu_OnTapToStart;
        }

        private void OnDisable()
        {
            MainMenuWindow.OnTapToStart -= MainMenu_OnTapToStart;
        }

        private void MainMenu_OnTapToStart()
        {
            OnGameplayStart.Invoke();
        }
    }

}
