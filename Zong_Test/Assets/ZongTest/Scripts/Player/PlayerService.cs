using UnityEngine;
using Scripts.GameLoop;
using Scripts.Inventory;

namespace Scripts.Player
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField] PlayerConfig playerConfig;
        [SerializeField] InventoryService inventoryService;

        private PlayerController _playerController;
        private InventoryService _inventoryServiceInstance;

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


            _inventoryServiceInstance = Instantiate(inventoryService, transform);

            _playerController.playerInventory.Setup(_inventoryServiceInstance);
            _playerController.Disable();

        }
    }

}
