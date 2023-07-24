using System;
using UnityEngine;

namespace Gameplay.Dino
{
    [Serializable]
    public class Player
    {
        [SerializeField] private float _jumpForce = 10f;

        [SerializeField, HideInInspector] private Rigidbody2D _rigidbody;
        [SerializeField, HideInInspector] private Animator _animator;

        public void InitializeParametrs(Rigidbody2D rigidbody, Animator animator)
        {
            _rigidbody = rigidbody;
            _animator = animator;
        }

        public void OnJump()
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            //_animator
        }

        public void OnLended()
        {
            //_animator
        }
    }
}
