using UnityEngine;

namespace Gameplay.Player
{
    public class Player
    {
        private PlayerMovementSettings _movementSettings;

        private Rigidbody2D _rigidbody;
        private Animator _animator;

        private GroundChecker _groundChecker;

        public Rigidbody2D Rigidbody => _rigidbody;
        public Animator Animator => _animator;
        public bool IsGrounded => _groundChecker.isGrounded;

        public Player(PlayerMovementSettings movementSettings)
        {
            _movementSettings = movementSettings;
        }

        public void InitializeParametrs(Rigidbody2D rigidbody, Animator animator)
        {
            Debug.Log("InitializeParametrs");
            _rigidbody = rigidbody;
            _animator = animator;
            _groundChecker = new GroundChecker(_rigidbody.transform);
        }

        public void ProduceJump() => _rigidbody.velocity = Vector2.up * _movementSettings.JumpForce;

        public void ProduceDownJump() => _rigidbody.velocity = -Vector2.up * _movementSettings.JumpForce;
    }
}
