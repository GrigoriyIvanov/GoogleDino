using Gameplay.Dino;
using Main.StateMachine;

namespace Gameplay.Dino
{
    public class DeadState : AbstractState<PlayerStateMachine, Player>
    {
        public DeadState(PlayerStateMachine fsm, Player instance) : base(fsm, instance) { }

        public override void EnterState()
        {
            throw new System.NotImplementedException();
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }
    }
}