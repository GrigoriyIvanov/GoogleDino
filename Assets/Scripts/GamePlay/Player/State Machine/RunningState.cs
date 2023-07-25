namespace Gameplay.Player.FSM
{
    public class RunningState : AliveState
    {
        public RunningState(PlayerStateMachine fsm, Player instance) : base(fsm, instance) { }

        public override void EnterState()
        {
            _instance.Animator.SetBool("Running", true);
        }

        public override void ExitState()
        {
            _instance.Animator.SetBool("Running", false);
        }
    }
}