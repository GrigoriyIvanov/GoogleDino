using Gameplay.Interfaces.PlayerFSM;

namespace Gameplay.Player.FSM
{
    public class InclineRunningState : RunningState, ICancelDownMove
    {
        public InclineRunningState(PlayerStateMachine fsm, Player instance) : base(fsm, instance) { }

        public override void EnterState() => 
            _controlledObject.Animator.SetBool("InclineRun", true);

        public override void ExitState() => 
            _controlledObject.Animator.SetBool("InclineRun", false);

        public void CancelDownMove() => 
            _fsm.ActionRespond(PlayerActions.Run);
    }
}