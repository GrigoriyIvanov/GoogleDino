using Core.Interfaces;
using Core.StateMachine;

namespace Core.Inftastracture.GameManagment.FSM
{
    public class GamePlayRunningState : AbstractState<GameActions, IGameManager>
    {
        public GamePlayRunningState(IStateMachine<GameActions> fsm, IGameManager instance) : base(fsm, instance) { }

        public override void EnterState()
        {
            _controlledObject.StartPlay();
        }

        public override void ExitState()
        {
        }
    }
}