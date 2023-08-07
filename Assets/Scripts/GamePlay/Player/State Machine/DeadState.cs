using Core.Inftastracture.GameManagment.FSM;
using Core.StateMachine;

namespace Gameplay.Player.FSM
{
    public class DeadState : AbstractState<PlayerActions, Player>
    {
        private IStateMachine<GameActions> _gameFSM;

        public DeadState(IStateMachine<PlayerActions> fsm, Player instance, IStateMachine<GameActions> gameFSM) : base(fsm, instance)
        {
            _gameFSM = gameFSM;
        }

        public override void EnterState()
        {
            _controlledObject.Animator.SetBool("Dead", true);
            _gameFSM.ActionRespond(GameActions.Lost);
        }

        public override void ExitState() => throw new System.NotImplementedException();
    }
}