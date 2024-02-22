using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.UI
{
    public class InventoryWindow : UIWindow
    {
        protected override void Reset()
        {
            base.Reset();
            windowType = eUIWindowType.INVENTORY;
        }
    }

}
