using UnityEngine;
using Zenject;

public class PointsCounter : MonoBehaviour, IPointsCounter
{
    private ISpeedCounter _speedCounter;
    private IPlayerProgressHandler _playerProgressHandler;

    private float _score;

    public int Score => (int)_score;

    [Inject]
    public void Construct(ISpeedCounter speedCounter, IPlayerProgressHandler playerProgressHandler)
    {
        _speedCounter = speedCounter;

        _playerProgressHandler = playerProgressHandler;
    }

    private void FixedUpdate() =>
        _score += _speedCounter.Speed * Time.fixedDeltaTime;
}
