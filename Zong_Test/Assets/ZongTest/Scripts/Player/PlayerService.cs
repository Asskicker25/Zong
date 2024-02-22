using UnityEngine;
using Scripts.GameLoop;
using Scripts.Inventory;
using Scripts.ItemSpawner;

namespace Scripts.Player
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private InventoryService inventoryService;
        [SerializeField] private ItemSpawnService itemSpawnService;
        [SerializeField] private Vector3 playerSpawnPosition = Vector3.zero;
        [HideInInspector] public PlayerController _playerController;

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

            _playerController.transform.position = playerSpawnPosition;

            _inventoryServiceInstance = Instantiate(inventoryService, transform);

            _playerController.playerInventory.Setup(_inventoryServiceInstance, itemSpawnService);
            _playerController.Disable();

        }
    }

}
