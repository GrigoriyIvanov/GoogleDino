using Gameplay.ScriptableObjects;
using UnityEngine;

namespace Gameplay.Player
{
    public class Player
    {
        private Rigidbody2D _rigidbody;
        private Animator _animator;

        private PlayerMovementSettings _movementSettings;

        private GroundChecker _groundChecker;
        private GameSounds _gameSounds;

        public Animator Animator => _animator;
        public bool IsGrounded => _groundChecker.isGrounded;

        public Player(PlayerMovementSettings movementSettings, GameSounds gameSounds)
        {
            _movementSettings = movementSettings;
            _gameSounds = gameSounds;
        }

        public void SetComponents(Rigidbody2D rigidbody, Animator animator)
        {
            _rigidbody = rigidbody;
            _animator = animator;
            _groundChecker = new GroundChecker(_rigidbody.transform);
        }

        public void ProduceJump()
        {
            _gameSounds.PlayJumpSound();
            MakeJump();
        }

        public void ProduceDownJump() => MakeJump(-1);

        public void MakeDead()
        {
            _gameSounds.PlayDeathSound();
            Animator.SetBool("Dead", true);
            _rigidbody.simulated = false;
            Time.timeScale = 0;
        }

        public void MakeJump(float directionY = 1) =>
            _rigidbody.velocity = directionY * Vector2.up * _movementSettings.JumpForce;
    }
}
