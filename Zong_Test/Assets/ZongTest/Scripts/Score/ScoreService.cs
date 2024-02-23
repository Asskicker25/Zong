using Scripts.Chest;
using UnityEngine;

namespace Scripts.Score
{
    public class ScoreService : MonoBehaviour
    {
        [SerializeField] private ScoreConfig config;

        private void OnEnable()
        {
            ChestBehavior.OnChestCollected += ChestBehavior_OnChestCollected;
        }

        private void OnDisable()
        {
            ChestBehavior.OnChestCollected -= ChestBehavior_OnChestCollected;
        }

        private void ChestBehavior_OnChestCollected(string obj)
        {
            AddScore(100);
        }

        public void AddScore(int amount)
        {
            config.score += amount;
        }

        public int GetScore()
        {
            return config.score;
        }
    }

}
