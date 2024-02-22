using UnityEngine;

namespace Scripts.Score
{
    [CreateAssetMenu(fileName = "ScoreConfig", menuName = "Configs/ScoreConfig")]
    public class ScoreConfig : ScriptableObject
    {
        public int score = 0;
    }

}
