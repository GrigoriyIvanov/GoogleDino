using Core.Interfaces;
using Core.StateMachine;
using UnityEngine;

namespace Core.Inftastracture.GameManagment.FSM
{
    internal class LoadingState : AbstractState<GameActions, ISceneLoader>
    {
        private string _startSceneName;

        public LoadingState(IStateMachine<GameActions> fsm, ISceneLoader instance, string startSceneName) : base(fsm, instance)
            => _startSceneName = startSceneName;

        public override void EnterState()
        {
            _controlledObject.Load(
                _startSceneName,
                () => _fsm.ActionRespond(GameActions.EnterToGameplay));
        }

        public override void ExitState()
        {
            Debug.Log("GameIsLoaded");
        }
    }
}