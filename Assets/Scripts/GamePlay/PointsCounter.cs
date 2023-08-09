using UnityEngine;
using Zenject;

public class PointsCounter : MonoBehaviour, IPointsCounter
{
    private ISpeedCounter _speedCounter;

    private float _score;

    public int Score => (int)_score;

    [Inject]
    public void Construct(ISpeedCounter speedCounter) =>
        _speedCounter = speedCounter;

    private void FixedUpdate() =>
        _score += _speedCounter.Speed * Time.fixedDeltaTime;
}
