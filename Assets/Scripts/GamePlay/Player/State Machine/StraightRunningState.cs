namespace Gameplay.Player.FSM
{
    public class StraightRunningState : RunningState, IExecuteDownMove
    {
        public StraightRunningState(Main.StateMachine.IStateMachine<PlayerActions> fsm, Player instance) : base(fsm, instance) { }

        public override void EnterState() => _instance.Animator.SetBool("StraightRun", true);

        public override void ExitState() => _instance.Animator.SetBool("StraightRun", false);

        public void ExecuteDownMove() => _fsm.ActionRespond(PlayerActions.RunIncline);
    }
}