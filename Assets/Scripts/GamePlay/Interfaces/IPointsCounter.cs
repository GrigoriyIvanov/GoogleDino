using UniRx;

namespace Gameplay.Interfaces
{
    public interface IPointsCounter
    {
        public ReactiveProperty<int> Score { get; }
    }
}