using Core.Interfaces;
using Core.StateMachine;

namespace Core.Inftastracture.GameManagment.FSM
{
    public class LostState : AbstractState<GameActions, IGameActionsManager>
    {
        public LostState(IStateMachine<GameActions> fsm, IGameActionsManager instance) : base(fsm, instance) { }

        public override void EnterState() =>
            _controlledObject.Lost();

        public override void ExitState() { }
    }
}