using Gameplay.Environment;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstaclesInstaller : MonoInstaller
{
    [SerializeField] private List<Transform> _obstacles;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<ObstaclePool>().FromNew().AsSingle().WithArguments(_obstacles);
    }
}
