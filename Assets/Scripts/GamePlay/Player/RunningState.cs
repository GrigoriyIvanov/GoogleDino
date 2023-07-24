using Gameplay.Dino;

namespace Gameplay.Dino
{
    public class RunningState : AliveState
    {
        public RunningState(PlayerStateMachine fsm, Player instance) : base(fsm, instance) { }
    }
}