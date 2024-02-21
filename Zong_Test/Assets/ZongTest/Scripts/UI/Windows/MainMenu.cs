using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.UI
{
    public class MainMenu : UIWindow
    {
        override protected void Reset()
        {
            base.Reset();

            awakeOnStart = true;
        }
    }

}
