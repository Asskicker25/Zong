using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public GameObject playerController;
    }

}

