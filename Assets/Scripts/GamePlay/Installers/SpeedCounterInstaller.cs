using UnityEngine;
using Zenject;

public class SpeedCounterInstaller : MonoInstaller
{
    [SerializeField] private SpeedConfig _speedConfig;

    public override void InstallBindings() =>
        Container.
        BindInterfacesTo<SpeedCounterService>().
        FromNew().
        AsSingle().
        WithArguments(_speedConfig.InitialSpeed, _speedConfig.SpeedIncrement);
}
