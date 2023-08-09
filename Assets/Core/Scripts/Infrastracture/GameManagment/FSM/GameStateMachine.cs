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
        Reastart,
        LoadData
    }

    public class GameStateMachine : AbstractFinitStateMashine<GameActions>
    {
        public GameStateMachine(
            IGameActionsManager gameManager,
            ISceneLoader sceneLoader, 
            ISaveLoadService saveLoadService, 
            IPlayerProgressHandler playerProgressHandler)
        {
            _states = new Dictionary<System.Type, IState>()
            {
                [typeof(LoadingState)] = new LoadingState(this, sceneLoader),
                [typeof(GamePlayRunningState)] = new GamePlayRunningState(this, gameManager),
                [typeof(LostState)] = new LostState(this, gameManager),
                [typeof(LoadDataState)] = new LoadDataState(this, sceneLoader, saveLoadService, playerProgressHandler),
            };

            _transitions = new Dictionary<Transition, System.Type>()
            {
                [new Transition(GameActions.LoadData, typeof(LoadingState))] = typeof(LoadDataState),
                [new Transition(GameActions.EnterToGameplay, typeof(LoadDataState))] = typeof(GamePlayRunningState),
                [new Transition(GameActions.Lost, typeof(GamePlayRunningState))] = typeof(LostState),
                [new Transition(GameActions.Reastart, typeof(LostState))] = typeof(LoadingState),
            };

            _initialState = _states[typeof(LoadingState)];
        }
    }
}
