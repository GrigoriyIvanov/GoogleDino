using Main.StateMachine;

namespace Gameplay.Player.FSM
{
    public class DeadState : AbstractState<PlayerStateMachine, Player>
    {
        public DeadState(PlayerStateMachine fsm, Player instance) : base(fsm, instance) { }

        public override void EnterState() { }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }
    }
}