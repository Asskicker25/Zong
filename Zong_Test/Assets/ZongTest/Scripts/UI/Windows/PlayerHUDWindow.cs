using UnityEngine;

namespace Scripts.UI
{
    public class PlayerHUDWindow : UIWindow
    {
        protected override void Reset()
        {
            windowType = eUIWindowType.PLAYER_HUD;
            base.Reset();
        }

    }

}
