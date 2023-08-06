using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Core.Inftastracture.Installers
{
    public class CoroutineRunnerInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;

        public override void InstallBindings()
        {
            Container.Bind<CoroutineRunner>().FromInstance(_coroutineRunner).AsSingle();
        }
    }
}