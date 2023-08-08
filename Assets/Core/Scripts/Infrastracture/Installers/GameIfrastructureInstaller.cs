using Core.Inftastracture.GameManagment;
using Core.Inftastracture.GameManagment.FSM;
using UnityEngine;
using Zenject;

namespace Core.Inftastracture.Installers
{
    public class GameIfrastructureInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;

        public override void InstallBindings()
        {
            CoroutineRunner coroutineRunner = Container.InstantiatePrefabForComponent<CoroutineRunner>(_coroutineRunner);
            Container.BindInterfacesTo<CoroutineRunner>().FromInstance(coroutineRunner).AsSingle();

            Container.BindInterfacesTo<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<GameActionsManager>().AsSingle();

            Container.BindInterfacesTo<GameStateMachine>().AsSingle();
        }
    }
}
