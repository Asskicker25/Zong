using DG.Tweening;
using UnityEngine;

namespace Scripts.Inventory
{
    public class BaseInventoryItem : MonoBehaviour
    {
        [SerializeField] private Renderer meshRenderer;
        public Collider colliderAttached;

        public BaseInventoryItemConfig config;

        private void Reset()
        {
            meshRenderer = GetComponentInChildren<Renderer>();
            colliderAttached = GetComponentInChildren<Collider>();
        }

        public void Setup(BaseInventoryItemConfig config)
        {
            this.config = config;
            meshRenderer.material = config.modelMaterial;
        }

        public void CollectItem()
        {
            transform.DOScale(0, 0.5f);
            Destroy(gameObject, 0.5f);
        }
       
    }

}
