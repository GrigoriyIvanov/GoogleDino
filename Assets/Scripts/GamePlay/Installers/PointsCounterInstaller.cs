using Gameplay.Data;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class PointsCounterInstaller : MonoInstaller
    {
        [SerializeField] private PointsCounter _pointsCounter;

        public override void InstallBindings() =>
            Container.BindInterfacesTo<PointsCounter>().FromInstance(_pointsCounter).AsSingle();
    }
}
