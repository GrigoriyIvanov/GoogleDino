using UnityEngine;

namespace Gameplay.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Settings/Speed Settings", fileName = "Speed Config")]
    public class SpeedConfig : ScriptableObject
    {
        [SerializeField] public float _initialSpeed = 5f;
        [SerializeField] public float _speedIncrement = 0.001f;

        public float InitialSpeed => _initialSpeed;
        public float SpeedIncrement => _speedIncrement;
    }
}