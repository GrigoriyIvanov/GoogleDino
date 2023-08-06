using Gameplay;
using System;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : IGameManager
    {
        public void Restart() => SceneManager.LoadScene(1);

        private ILostAction[] _lostActions;

        public void Lost()
        {
            for (int i = 0; i < _lostActions.Length; i++)
                _lostActions[i].OnLost();
        }

        public void StartPlay()
        {
            Restart();
        }

        public void Pouse()
        {
            throw new NotImplementedException();
        }
    }
}
