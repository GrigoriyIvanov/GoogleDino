namespace Gameplay.Player.FSM
{
    public abstract class RunningState : AliveState, IExecuteJump
    {
        protected RunningState(Core.StateMachine.IStateMachine<PlayerActions> fsm, Player instance) : base(fsm, instance) { }

        public void ExecuteJump()
        {
            if (_controlledObject.IsGrounded)
                _fsm.ActionRespond(PlayerActions.Jump);
        }
    }
}