using UnityEngine;
using Zenject;

public class SpeedUpdater : MonoBehaviour
{
    private ISpeedCounter _speedCounter;

    [Inject]
    public void Construct(ISpeedCounter speedCounter) =>
        _speedCounter = speedCounter;

    private void FixedUpdate() =>
        _speedCounter.UpdateSpeed();
}
