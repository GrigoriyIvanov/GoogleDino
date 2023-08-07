using Core.Inftastracture.GameManagment.FSM;
using Core.Interfaces;
using Core.Interfaces.EventFunctions;
using Core.StateMachine;
using Core.UI.Panels;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.UI
{
    public class MainCanvasManager : MonoBehaviour, IWin, ILost, IPouse, IStartPlay
    {
        [SerializeField] private Panel[] _panels;

        public Dictionary<Type, IPanel> _panelsByType = new Dictionary<Type, IPanel>();

        private IPanel _currentActive;

        private IStateMachine<GameActions> _gameStateMachine;

        [Inject]
        public void Construct(
            IStateMachine<GameActions> gameStateMachine,
            IEventContainer<IWin> winContainer,
            IEventContainer<ILost> lostContainer,
            IEventContainer<IStartPlay> startContainer,
            IEventContainer<IPouse> pouseContainer)
        {
            _gameStateMachine = gameStateMachine;

            winContainer.AddCallback(this);
            pouseContainer.AddCallback(this);
            lostContainer.AddCallback(this);
            startContainer.AddCallback(this);
            pouseContainer.AddCallback(this);
        }

        private void Awake() =>
            InitializePanelsDictionary();

        private void InitializePanelsDictionary()
        {
            for (int i = 0; i < _panels.Length; i++)
                _panelsByType.Add(_panels[i].GetType(), _panels[i]);
        }

        private void ChangePanelTo(Type newPanelType)
        {
            _currentActive?.Hide();
            _panelsByType[newPanelType].Show();
            _currentActive = _panelsByType[newPanelType];
        }

        public void OnWin() =>
            ChangePanelTo(typeof(WinPanel));

        public void OnLost() =>
            ChangePanelTo(typeof(LostPanel));

        public void OnStartPlay() =>
            ChangePanelTo(typeof(PlayPanel));

        public void OnPouse() =>
            ChangePanelTo(typeof(PousePanel));

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                _gameStateMachine.ActionRespond(GameActions.Pouse);
        }
    }
}