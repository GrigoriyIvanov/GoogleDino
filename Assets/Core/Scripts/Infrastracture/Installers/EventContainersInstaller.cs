using Core.Interfaces.EventFunctions;
using Zenject;

namespace Core.Inftastracture.Installers
{
    public class EventContainersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EventContainer<IWin>>().FromNew().AsSingle();
            Container.BindInterfacesTo<EventContainer<ILost>>().FromNew().AsSingle();
            Container.BindInterfacesTo<EventContainer<IPouse>>().FromNew().AsSingle();
            Container.BindInterfacesTo<EventContainer<IStartPlay>>().FromNew().AsSingle();
        }
    }
}
