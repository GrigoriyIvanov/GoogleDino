using Core.Interfaces.EventFunctions.Updates;

namespace Gameplay.Player.FSM
{
    public class JumpingState : AliveState, IFixedUpdate, IExecuteDownMove
    {
        private bool isJumpedOnThisFrame;

        public JumpingState(Main.StateMachine.IStateMachine<PlayerActions> fsm, Player instance) : base(fsm, instance) { }

        public override void EnterState()
        {
            _instance.ProduceJump();
            _instance.Animator.SetBool("Jump", true);
            isJumpedOnThisFrame = true;
        }

        public override void ExitState() => _instance.Animator.SetBool("Jump", false);

        public void FixedUpdate()
        {
            if (isJumpedOnThisFrame)
            {
                isJumpedOnThisFrame = false;
                return;
            }

            if (_instance.IsGrounded)
                _fsm.ActionRespond(PlayerActions.Land);
        }

        public void ExecuteDownMove() => _instance.ProduceDownJump();
    }
}