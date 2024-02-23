
using UnityEngine;

namespace Scripts.UI
{
    public class FadeWindow : UIWindow
    {
        protected override void Reset()
        {
            windowType = eUIWindowType.FADE;
            base.Reset();
        }
    }

}
