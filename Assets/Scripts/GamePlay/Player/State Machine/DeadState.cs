using Core.Interfaces;
using Core.StateMachine;
using Zenject;

namespace Gameplay.Player.FSM
{
    public class DeadState : AbstractState<PlayerActions, Player>
    {
        private IGameManager _gameManager;

        public DeadState(IStateMachine<PlayerActions> fsm, Player instance) : base(fsm, instance) { }

        [Inject]
        public void InitGameManager(IGameManager gameManager)
        {
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