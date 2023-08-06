using System;

namespace Core.Interfaces
{
    public interface IGameManager
    {
        public void StartPlay();
        public void Win();
        public void Lost();
        public void Pouse();
        public void Restart();
    }

    public interface IGameManagerActions
    {
        public Action OnStartPlay { get; set; }
        public Action OnLost { get; set; }
        public Action OnRestart { get; set; }
        public Action OnPouse { get; set; }
    }
}