using Core.Interfaces.EventFunctions.Updates;
using Core.StateMachine;
using Gameplay.Player.FSM;
using Main.Interfaces.EventFunctions.Collisions;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class PlayerRunner : InSceneFSMRunner<IStateMachine<PlayerActions>, PlayerActions>
    {
        [SerializeField, HideInInspector] private Rigidbody2D _rigidbody;
        [SerializeField, HideInInspector] private Animator _animator;

        private Player _player;

        [Inject]
        public void Constructor(Player player) =>
            _player = player;

        private void Awake()
        {
            _player.SetComponents(_rigidbody, _animator);
            _fsm.SetInitialState();
        }

        public void FixedUpdate() =>
            (_fsm as IFixedUpdate)?.FixedUpdate();

        private void OnTriggerEnter2D(Collider2D collision) =>
            (_fsm as ITriggerEnter2D)?.OnTriggerEnter(collision);

        private void OnValidate()
        {
            if(_rigidbody.Equals(null)) 
                _rigidbody = GetComponentInChildren<Rigidbody2D>();

            if(_animator.Equals(null))
                _animator = GetComponentInChildren<Animator>();
        }
    }
}