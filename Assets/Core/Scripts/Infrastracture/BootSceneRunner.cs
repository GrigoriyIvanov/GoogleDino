using Core.Inftastracture.GameManagment.FSM;
using Core.StateMachine;
using UnityEngine;
using Zenject;

namespace Core.Inftastracture
{
    public class BootSceneRunner : MonoBehaviour
    {
        [Inject]
        public void Constructor(IStateMachine<GameActions> gameManager) =>
            gameManager.SetInitialState();
    }
}
