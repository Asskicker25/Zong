using UnityEngine;
using Scripts.ItemSpawner;
using Scripts.Inventory;
using UnityEngine.Events;
using TMPro;

namespace Scripts.Chest
{
    public class ChestBehavior : MonoBehaviour
    {

        [SerializeField] private string boxName;
        [SerializeField] private float collectObjectDistance = 1.0f;
        [SerializeField] private ParticleSystem particles;
        [SerializeField] private Transform particleParent;
        [SerializeField] private TextMeshPro uiText;

        public UnityEvent OnItemCollected;

        private AudioSource particleAudio;


        private void OnEnable()
        {
            ItemSpawnService.OnItemDropped += ItemSpawnService_OnItemDropped;
        }

        private void OnDisable()
        {
            ItemSpawnService.OnItemDropped -= ItemSpawnService_OnItemDropped;
        }

        private void Start()
        {
            if(particles != null)
            {
                particles = Instantiate(particles, particleParent);
                particleAudio = particles.GetComponent<AudioSource>();
            }

            uiText.SetText(boxName);
        }

        private void ItemSpawnService_OnItemDropped(BaseInventoryItem item, Vector3 position)
        {
            Vector3 difference = position - transform.position;

            if(difference.sqrMagnitude <= collectObjectDistance * collectObjectDistance)
            {
                item.CollectItem();
                PlayParticles();
                OnItemCollected?.Invoke();
            }
        }

        public void PlayParticles()
        {
            if (particles == null) return;

            particleAudio.Play();
            particles.Play();
        }
    }

}
