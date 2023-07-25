namespace Gameplay.Player.FSM
{
    public class JumpingState : AliveState
    {
        public JumpingState(PlayerStateMachine fsm, Player instance) : base(fsm, instance) { }

        public override void EnterState()
        {
            _instance.ProduceJump();
            _instance.Animator.SetBool("Jump", true);
        }

        public override void ExitState()
        {
            _instance.Animator.SetBool("Jump", false);
        }
    }
}