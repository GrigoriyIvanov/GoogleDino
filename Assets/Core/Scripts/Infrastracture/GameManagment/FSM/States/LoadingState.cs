using Core.Interfaces;
using Core.StateMachine;
using UnityEngine;

namespace Core.Inftastracture.GameManagment.FSM
{
    internal class LoadingState : AbstractState<GameActions, ISceneLoader>
    {
        public LoadingState(IStateMachine<GameActions> fsm, ISceneLoader instance) : base(fsm, instance) { }
        
        public override void EnterState() => 
            _fsm.ActionRespond(GameActions.LoadData);
    
        public override void ExitState()
        {
            Debug.Log("GameIsLoaded");
        }
    }
}