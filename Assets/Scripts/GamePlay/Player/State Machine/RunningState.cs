namespace Gameplay.Player.FSM
{
    public abstract class RunningState : AliveState, IExecuteJump
    {
        protected RunningState(Main.StateMachine.IStateMachine<PlayerActions> fsm, Player instance) : base(fsm, instance) { }

        public void ExecuteJump()
        {
            if (_instance.IsGrounded)
                _fsm.ActionRespond(PlayerActions.Jump);
        }
    }
}