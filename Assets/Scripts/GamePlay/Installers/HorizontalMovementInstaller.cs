using Zenject;

public class HorizontalMovementInstaller : MonoInstaller
{
    public override void InstallBindings() =>
        Container.BindInterfacesTo<Gameplay.Environment.HorizontalMovement>().FromNew().AsSingle();
}
