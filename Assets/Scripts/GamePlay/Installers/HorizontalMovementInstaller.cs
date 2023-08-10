using Zenject;

namespace Gameplay.Installers
{
    public class HorizontalMovementInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            Container.BindInterfacesTo<Environment.HorizontalMovement>().FromNew().AsSingle();
    }
}