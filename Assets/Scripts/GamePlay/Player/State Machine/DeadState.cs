using Main.StateMachine;

namespace Gameplay.Player.FSM
{
    public class DeadState : AbstractState<PlayerActions, Player>
    {
        public DeadState(IStateMachine<PlayerActions> fsm, Player instance) : base(fsm, instance) { }

        public override void EnterState()
        {
            _controlledObject.Animator.SetBool("Dead", true);
            GameManager.MakeLost();
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }
    }
}