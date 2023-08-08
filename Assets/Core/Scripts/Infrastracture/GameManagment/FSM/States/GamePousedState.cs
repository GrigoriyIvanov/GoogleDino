using Core.Interfaces;
using Core.StateMachine;

namespace Core.Inftastracture.GameManagment.FSM
{
    public class GamePousedState : AbstractState<GameActions, IGameActionsManager>
    {
        public GamePousedState(IStateMachine<GameActions> fsm, IGameActionsManager instance) : base(fsm, instance) { }

        public override void EnterState() =>
            _controlledObject.Pouse();

        public override void ExitState()
        {
        }
    }
}