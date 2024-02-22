using UnityEngine;
using NaughtyAttributes;
using System;
using Scripts.UI;
using Scripts.Inventory;

namespace Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        public static event Action OnInventoryOpen = delegate { };
        public static event Action OnInventoryClose = delegate { };

        [Foldout("Move Variables")]
        [SerializeField] private float _moveSpeed = 10;
        [Foldout("Move Variables")]
        [SerializeField] private Vector2 _input = Vector2.zero;

        [Foldout("Componenets")]
        [SerializeField] private Rigidbody _rigidbody;
        [Foldout("Componenets")]
        [SerializeField] private FirstPersonCameraController _camController;
        [Foldout("Componenets")]
        public PlayerInventory playerInventory;


        private bool _canMove = false;

        private Vector3 _moveDir = Vector3.zero;

        private void Awake()
        {
            InventoryWindow.OnInventoryClosed += HandleInventoryClose;
        }

        private void OnDestroy()
        {
            InventoryWindow.OnInventoryClosed -= HandleInventoryClose;
        }
        public void Enable()
        {
            enabled = true;
            _camController.enabled = true;
            Cursor.visible = false;
        }

        public void Disable()
        {
            enabled = false;
            _camController.enabled = false;
            _rigidbody.velocity = Vector3.zero;
            Cursor.visible = true;
        }

        private void Update()
        {
            if (!(_canMove = SetInput() != 0)) { return; }
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        //This avoids having the drag-drop to refer.
        //And since we can call it in editor time, when creating an asset, no issues with performance.
        private void Reset()
        {
            _camController = GetComponentInChildren<FirstPersonCameraController>();
            _rigidbody = GetComponentInChildren<Rigidbody>();
            playerInventory = GetComponentInChildren<PlayerInventory>();
        }

        private float SetInput()
        {
            _input.x = Input.GetAxisRaw("Horizontal");
            _input.y = Input.GetAxisRaw("Vertical");

            _input.Normalize();

            HandleInventoryOpen();

            return _input.magnitude;
        }

        private void HandleMovement()
        {
            // Calling in fixed update. So can avoid deltaTime multiplication.

            _moveDir = transform.forward * _input.y;
            _moveDir += transform.right * _input.x;

            _rigidbody.velocity = _moveDir;
        }

        private void HandleInventoryOpen()
        {
            if(Input.GetKey(KeyCode.Space))
            {
                OpenInventory();
            }
        }

        private void OpenInventory()
        {
            Disable();
            OnInventoryOpen.Invoke();
        }

        private void HandleInventoryClose()
        {
            Enable();
        }

    }

}
