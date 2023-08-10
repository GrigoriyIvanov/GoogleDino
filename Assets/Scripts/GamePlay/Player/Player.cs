using Gameplay.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class Player
    {
        private Rigidbody2D _rigidbody;
        private Animator _animator;

        private PlayerMovementSettings _movementSettings;

        private GroundChecker _groundChecker;

        public Animator Animator => _animator;
        public bool IsGrounded => _groundChecker.isGrounded;

        [Inject]
        public void Construct(PlayerMovementSettings movementSettings) =>
            _movementSettings = movementSettings;

        public void SetComponents(Rigidbody2D rigidbody, Animator animator)
        {
            _rigidbody = rigidbody;
            _animator = animator;
            _groundChecker = new GroundChecker(_rigidbody.transform);
        }

        public void ProduceJump() => MakeJump();

        public void ProduceDownJump() => MakeJump(-1);

        public void MakeDead()
        {
            Animator.SetBool("Dead", true);
            _rigidbody.simulated = false;
        }

        public void MakeJump(float directionY = 1) =>
            _rigidbody.velocity = directionY * Vector2.up * _movementSettings.JumpForce;
    }
}
