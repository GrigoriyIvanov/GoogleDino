using Gameplay.Data;
using Zenject;

namespace Core.Inftastracture.Installers
{
    public class DataServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerProgressHandler>().FromNew().AsSingle();
            Container.BindInterfacesTo<SaveLoadService>().FromNew().AsSingle();
        }
    }
}