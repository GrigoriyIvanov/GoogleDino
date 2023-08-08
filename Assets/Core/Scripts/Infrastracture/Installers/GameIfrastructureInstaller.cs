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
            Container.BindInterfacesTo<CoroutineRunner>().FromNewComponentOnNewPrefab(_coroutineRunner).AsSingle();

            Container.BindInterfacesTo<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<GameActionsManager>().AsSingle();

            Container.BindInterfacesTo<GameStateMachine>().AsSingle();
        }
    }
}
