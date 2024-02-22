using DG.Tweening;
using UnityEngine;
using Scripts.Player;
using UnityEngine.UIElements;
using TMPro;

namespace Scripts.Inventory
{
    public class BaseInventoryItem : MonoBehaviour
    {
        [SerializeField] private float showUITextDistance = 3;
        [SerializeField] private Renderer meshRenderer;
        [SerializeField] private Transform uiTextTransform;
        [SerializeField] private TextMeshPro uiText;

        public Collider colliderAttached;

        [HideInInspector]
        public BaseInventoryItemConfig config;

        private bool _uiTextVisible = false;

        private void OnEnable()
        {
            PlayerController.OnPlayerMove += OnPlayerMove;
        }
        private void OnDisable()
        {
            PlayerController.OnPlayerMove -= OnPlayerMove;
        }


        private void Reset()
        {
            meshRenderer = GetComponentInChildren<Renderer>();
            colliderAttached = GetComponentInChildren<Collider>();
        }

        public void Setup(BaseInventoryItemConfig config)
        {
            this.config = config;
            meshRenderer.material = config.modelMaterial;
            uiText.SetText(config.pickUpMessage);

        }

        public void CollectItem()
        {
            transform.DOScale(0, 0.5f);
            gameObject.SetActive(false);
        }

        public void OnPlayerMove(Vector3 position, Vector3 forward)
        {
            Vector3 difference = position - transform.position;

            if(difference.sqrMagnitude < showUITextDistance * showUITextDistance)
            {
                transform.LookAt(position, Vector3.up);
                ShowText();
            }
            else
            {
                HideText();
            }
        }

        private void ShowText()
        {

            if (_uiTextVisible) return;

            _uiTextVisible = true;

            uiTextTransform.DOScale(1, 0.5f);
        }

        private void HideText()
        {
            if (!_uiTextVisible) return;

            _uiTextVisible = false;

            uiTextTransform.DOScale(0, 0.5f);

        }

    }

}
