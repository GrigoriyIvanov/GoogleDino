using Core.Interfaces;
using Core.StateMachine;

namespace Core.Inftastracture.GameManagment.FSM
{
    public class WinState : AbstractState<GameActions, IGameActionsManager>
    {
        public WinState(IStateMachine<GameActions> fsm, IGameActionsManager instance) : base(fsm, instance)
        {
        }

        public override void EnterState() =>
            _controlledObject.Win();

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }
    }
}
