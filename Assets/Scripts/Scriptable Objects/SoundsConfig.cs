using UnityEngine;

namespace Gameplay.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Settings/Sounds", fileName = "Sounds")]
    public class SoundsConfig : ScriptableObject
    {
        [SerializeField] private AudioClip _jump;
        [SerializeField] private AudioClip _death;
        [SerializeField] private AudioClip _scoreUpdated;

        public AudioClip Jump => _jump;
        public AudioClip Death => _death;
        public AudioClip ScoreUpdated => _scoreUpdated;
    }
}
