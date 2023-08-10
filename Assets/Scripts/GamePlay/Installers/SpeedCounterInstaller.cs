using Gameplay.Data;
using Gameplay.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
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
}