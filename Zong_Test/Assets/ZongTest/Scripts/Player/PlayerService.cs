using UnityEngine;
using Scripts.GameLoop;

namespace Scripts.Player
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField] PlayerConfig playerConfig;

        private PlayerController _playerController;

        public void OnEnable()
        {
            GameService.OnGameplayStart += GameService_OnGameplayStart;
        }


        public void OnDisable()
        {
            GameService.OnGameplayStart -= GameService_OnGameplayStart;
        }

        private void GameService_OnGameplayStart()
        {
            _playerController.Enable();
        }

        private void Awake()
        {
            _playerController = transform.childCount == 0 ?
                Instantiate(playerConfig.playerController, transform)
                : transform.GetChild(0).GetComponent<PlayerController>();

            _playerController.Disable();

        }
    }

}
