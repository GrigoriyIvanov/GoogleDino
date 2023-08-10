using UniRx;

public interface IPointsCounter
{
    public ReactiveProperty<int> Score { get; }
}