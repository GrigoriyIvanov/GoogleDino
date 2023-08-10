using Core.Interfaces.EventFunctions.Updates;
using Gameplay.Interfaces.PlayerFSM;

namespace Gameplay.Player.FSM
{
    public class JumpingState : AliveState, IFixedUpdate, IExecuteDownMove
    {
        private bool isJumpedOnThisFrame;
        public JumpingState(Core.StateMachine.IStateMachine<PlayerActions> fsm, Player instance) : base(fsm, instance) { }

        public override void EnterState()
        {
            _controlledObject.ProduceJump();
            _controlledObject.Animator.SetBool("Jump", true);
            isJumpedOnThisFrame = true;
        }

        public override void ExitState() => _controlledObject.Animator.SetBool("Jump", false);

        public void FixedUpdate()
        {
            if (isJumpedOnThisFrame)
            {
                isJumpedOnThisFrame = false;
                return;
            }

            if (_controlledObject.IsGrounded)
                _fsm.ActionRespond(PlayerActions.Land);
        }

        public void ExecuteDownMove() => 
            _controlledObject.ProduceDownJump();
    }
}