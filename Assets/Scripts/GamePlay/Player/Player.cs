using System;
using UnityEngine;

namespace Gameplay.Player
{
    [Serializable]
    public class Player
    {
        [SerializeField] private PlayerMovementSettings _movementSettings;

        [SerializeField, HideInInspector] private Rigidbody2D _rigidbody;
        [SerializeField, HideInInspector] private Animator _animator;

        private GroundChecker _groundChecker;

        public Rigidbody2D Rigidbody => _rigidbody;
        public Animator Animator => _animator;
        public bool IsGrounded => _groundChecker.isGrounded;

        public void InitializeParametrs()
        {
            _groundChecker = new GroundChecker(_rigidbody.transform);
        }

        public void ProduceJump() => _rigidbody.velocity = Vector2.up * _movementSettings.JumpForce;

        public void ProduceDownJump() => _rigidbody.velocity = -Vector2.up * _movementSettings.JumpForce;

        public void OnValidate(Transform transform)
        {
            if(_rigidbody == null) _rigidbody = transform.GetComponentInChildren<Rigidbody2D>();
            if(_animator == null) _animator = transform.GetComponentInChildren<Animator>();
        }
    }
}
