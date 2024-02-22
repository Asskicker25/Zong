using UnityEngine;

namespace Scripts.Score
{
    public class ScoreService : MonoBehaviour
    {
        [SerializeField] private ScoreConfig config;

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
