using Core.Interfaces;
using Core.StateMachine;

namespace Core.Inftastracture.GameManagment.FSM
{
    public class GamePlayRunningState : AbstractState<GameActions, IGameActionsManager>
    {
        public GamePlayRunningState(IStateMachine<GameActions> fsm, IGameActionsManager instance) : base(fsm, instance) { }

        public override void EnterState()
        {
            _controlledObject.StartPlay();
        }

        public override void ExitState()
        {
        }
    }
}