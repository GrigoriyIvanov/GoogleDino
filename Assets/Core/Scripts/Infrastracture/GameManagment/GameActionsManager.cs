using Core.Interfaces;
using Core.Interfaces.EventFunctions;
using UnityEngine;
using Zenject;

namespace Core.Inftastracture.GameManagment
{
    public class GameActionsManager : IGameActionsManager
    {
        private IEventContainer<IWin> _winListenersContainer;
        private IEventContainer<ILost> _lostListenersContainer;
        private IEventContainer<IStartPlay> _startListenersContainer;

        [Inject]
        public GameActionsManager(
            IEventContainer<IWin> winListenersContainer,
            IEventContainer<ILost> lostListenersContainer,
            IEventContainer<IStartPlay> startListenersContainer
            )
        {
            _winListenersContainer = winListenersContainer;
            _lostListenersContainer = lostListenersContainer;
            _startListenersContainer = startListenersContainer;
        }

        public void Win() =>
            _winListenersContainer.ExecuteEvent((winingObject) => winingObject.OnWin());

        public void Lost() =>
            _lostListenersContainer.ExecuteEvent((lostingObject) => lostingObject.OnLost());

        public void Restart() { }

        public void StartPlay()
        {
            _winListenersContainer.Clear();
            _lostListenersContainer.Clear();
            _startListenersContainer.Clear();

            _startListenersContainer.ExecuteEvent((startingObject) => startingObject.OnStartPlay());
            Time.timeScale = 1;
        }

        public void Pouse()
        {
            
        }
    }
}
