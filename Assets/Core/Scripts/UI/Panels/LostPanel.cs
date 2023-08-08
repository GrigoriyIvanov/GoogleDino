using Core.Inftastracture.GameManagment.FSM;
using Core.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.UI.Panels
{
    public class LostPanel : Panel
    {
        [SerializeField] private Button _restart;

        private IStateMachine<GameActions> _gameFSM;

        [Inject]
        public void Construct(IStateMachine<GameActions> gameFSM) =>
            _gameFSM = gameFSM;

        private void OnEnable() =>
            _restart.onClick.AddListener(MakeRestart);

        private void OnDisable() =>
            _restart.onClick.RemoveListener(MakeRestart);

        private void MakeRestart() =>
            _gameFSM.ActionRespond(GameActions.Reastart);
    }
}
