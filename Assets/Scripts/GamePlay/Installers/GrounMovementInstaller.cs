using Gameplay.Environment;
using Zenject;

public class GrounMovementInstaller : MonoInstaller
{
    public override void InstallBindings() =>
        Container.Bind<GroundMovement>().FromNew().AsSingle();
}
