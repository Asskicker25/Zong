using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField] PlayerConfig playerConfig;

        private void Awake()
        {
            if (transform.childCount == 0)
            {
                Instantiate(playerConfig.playerController, transform);
            }
        }
    }

}
