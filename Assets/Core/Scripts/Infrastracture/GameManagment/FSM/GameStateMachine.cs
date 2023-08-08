using Core.Interfaces;
using Core.StateMachine;
using System.Collections.Generic;

namespace Core.Inftastracture.GameManagment.FSM
{
    public enum GameActions
    {
        Initialize,
        EnterToGameplay,
        Start,
        Lost,
        Pouse,
        Reastart
    }

    public class GameStateMachine : AbstractFinitStateMashine<GameActions>
    {
        public GameStateMachine(IGameActionsManager gameManager, ISceneLoader sceneLoader)
        {
            _states = new Dictionary<System.Type, IState>()
            {
                [typeof(BootStrapState)] = new BootStrapState(this, sceneLoader, "Main"),
                [typeof(GamePlayRunningState)] = new GamePlayRunningState(this, gameManager),
                [typeof(GamePousedState)] = new GamePousedState(this, gameManager),
                [typeof(LostState)] = new LostState(this, gameManager),
            };

            _transitions = new Dictionary<Transition, System.Type>()
            {
                [new Transition(GameActions.EnterToGameplay, typeof(BootStrapState))] = typeof(GamePlayRunningState),
                [new Transition(GameActions.Pouse, typeof(GamePlayRunningState))] = typeof(GamePousedState),
                [new Transition(GameActions.Start, typeof(GamePousedState))] = typeof(GamePlayRunningState),
                [new Transition(GameActions.Lost, typeof(GamePlayRunningState))] = typeof(LostState),
            };

            _initialState = _states[typeof(BootStrapState)];
        }
    }
}
