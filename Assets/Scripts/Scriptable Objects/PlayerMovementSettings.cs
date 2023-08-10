using UnityEngine;

namespace Gameplay.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Settings/Player Movement", fileName = "Player Movement Settings")]
    public class PlayerMovementSettings : ScriptableObject
    {
        public float JumpingDownSpeed = 5f;
        public float JumpForce = 5f;
    }
}