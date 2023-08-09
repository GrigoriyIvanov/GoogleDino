using UniRx;
using UnityEngine;
using Zenject;

public class PointsCounter : MonoBehaviour, IPointsCounter
{
    private ISpeedCounter _speedCounter;

    private float _score;
    private ReactiveProperty<int> _scoreInt;

    public ReactiveProperty<int> Score => _scoreInt;

    [Inject]
    public void Construct(ISpeedCounter speedCounter)
    {
        _speedCounter = speedCounter;
        _scoreInt = new ReactiveProperty<int>();
    }


    private void FixedUpdate()
    {
        _score += _speedCounter.Speed * Time.fixedDeltaTime;
        _scoreInt.Value = (int)_score;
    }
}
