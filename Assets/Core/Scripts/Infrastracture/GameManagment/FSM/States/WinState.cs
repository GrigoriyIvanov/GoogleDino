using Core.Interfaces;
using Core.StateMachine;

namespace Core.Inftastracture.GameManagment.FSM
{
    public class WinState : AbstractState<GameActions, IGameManager>
    {
        public WinState(IStateMachine<GameActions> fsm, IGameManager instance) : base(fsm, instance)
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
