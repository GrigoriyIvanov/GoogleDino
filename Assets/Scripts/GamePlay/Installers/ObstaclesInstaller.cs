using Gameplay.Environment.Obstacles;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class ObstaclesInstaller : MonoInstaller
    {
        [SerializeField] private List<Transform> _obstacles;

        public override void InstallBindings() =>
            Container.BindInterfacesTo<ObstaclePool>().FromNew().AsSingle().WithArguments(_obstacles);
    }
}