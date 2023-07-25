using System;
using UnityEngine;

namespace Gameplay.Player
{
    [Serializable]
    public class Player
    {
        [SerializeField] private float _jumpForce = 10f;

        [SerializeField, HideInInspector] private Rigidbody2D _rigidbody;
        [SerializeField, HideInInspector] private Animator _animator;

        public Rigidbody2D Rigidbody => _rigidbody;
        public Animator Animator => _animator;

        public void InitializeParametrs(Rigidbody2D rigidbody, Animator animator)
        {
            _rigidbody = rigidbody;
            _animator = animator;
        }

        public void ProduceJump() => _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
