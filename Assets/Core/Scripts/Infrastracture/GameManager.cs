using Core.Interfaces;
using Core.Interfaces.EventFunctions;
using UnityEngine;
using Zenject;

namespace Core.Inftastracture.GameManagment
{
    public class GameManager : IGameManager
    {
        private IEventContainer<IWin> _winListenersContainer;
        private IEventContainer<ILost> _lostListenersContainer;
        private IEventContainer<IStartPlay> _startListenersContainer;
        private IEventContainer<IPouse> _pouseListenersContainer;

        [Inject]
        public GameManager(
            IEventContainer<IWin> winListenersContainer,
            IEventContainer<ILost> lostListenersContainer,
            IEventContainer<IStartPlay> startListenersContainer,
            IEventContainer<IPouse> pouseListenersContainer)
        {
            _winListenersContainer = winListenersContainer;
            _lostListenersContainer = lostListenersContainer;
            _startListenersContainer = startListenersContainer;
            _pouseListenersContainer = pouseListenersContainer;
        }

        public void Win() =>
            _winListenersContainer.ExecuteEvent((winingObject) => winingObject.OnWin());

        public void Lost() =>
            _lostListenersContainer.ExecuteEvent((lostingObject) => lostingObject.OnLost());

        public void Restart() =>
            throw new System.NotImplementedException();

        public void StartPlay()
        {
            Debug.Log("StartPlay");
            _startListenersContainer.ExecuteEvent((startingObject) => startingObject.OnStartPlay());
            Time.timeScale = 1;
        }

        public void Pouse()
        {
            Debug.Log("Pouse");
            _pouseListenersContainer.ExecuteEvent((pousingObject) => pousingObject.OnPouse());
            Time.timeScale = 0;
        }
    }
}
