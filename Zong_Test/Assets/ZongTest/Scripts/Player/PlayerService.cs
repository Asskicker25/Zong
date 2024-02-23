using UnityEngine;
using Scripts.GameLoop;
using Scripts.Inventory;
using Scripts.ItemSpawner;
using Scripts.UI;
using Scripts.Utilites;

namespace Scripts.Player
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private UIWindowService uiWindowService;
        [SerializeField] private InventoryService inventoryService;
        [SerializeField] private ItemSpawnService itemSpawnService;
        [HideInInspector] public PlayerController _playerController;

        private InventoryService _inventoryServiceInstance;
        private Vector3 playerInitPos;
        private Quaternion playerInitRot;

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

            _playerController.playerInventory.Setup(_inventoryServiceInstance, itemSpawnService);
            _playerController.Disable();

            playerInitPos = _playerController.transform.position;
            playerInitRot = _playerController.transform.rotation;
        }

        public void ResetPlayer()
        {
            uiWindowService.OpenWindow(eUIWindowType.FADE);
            uiWindowService.CloseWindow(eUIWindowType.INVENTORY);

            Timer.Delay(0.6f, () =>
            {
                _playerController.transform.position = playerInitPos;
                _playerController.transform.rotation = playerInitRot;
                _playerController.ResetPlayer();

                uiWindowService.CloseWindow(eUIWindowType.FADE);

                Timer.Delay(0.5f, () =>
                {
                    _playerController.Enable();
                });
            });
        }

      

    }

}
