using Core.Interfaces;
using Core.StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay.Player.FSM
{
    public class DeadState : AbstractState<PlayerActions, Player>
    {
        private IGameManager _gameManager;

        public DeadState(IStateMachine<PlayerActions> fsm, Player instance, IGameManager gameManager) : base(fsm, instance) 
        {
            _gameManager = gameManager;
        }

        [Inject]
        public void InitGameManager(IGameManager gameManager)
        {
            Debug.Log("InitGameManager");
            _gameManager = gameManager;
        }

        public override void EnterState()
        {
            _controlledObject.Animator.SetBool("Dead", true);
            _gameManager.Lost();
        }

        public override void ExitState() => throw new System.NotImplementedException();
    }
}