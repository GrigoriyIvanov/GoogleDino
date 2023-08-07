namespace Gameplay.Player.FSM
{
    public class StraightRunningState : RunningState, IExecuteDownMove
    {
        public StraightRunningState(Core.StateMachine.IStateMachine<PlayerActions> fsm, Player instance) : base(fsm, instance) { }

        public override void EnterState() => 
            _controlledObject.Animator.SetBool("StraightRun", true);

        public override void ExitState() => 
            _controlledObject.Animator.SetBool("StraightRun", false);

        public void ExecuteDownMove() => 
            _fsm.ActionRespond(PlayerActions.RunIncline);
    }
}