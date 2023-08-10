using UniRx;

namespace Gameplay.Data
{
    public class PlayerProgress
    {
        public ReactiveProperty<int> Progeress;

        public PlayerProgress(int progeress) =>
             Progeress = new ReactiveProperty<int>(progeress);
    }
}