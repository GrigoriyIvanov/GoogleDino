using Zenject;

public class BestScoreInstaller : MonoInstaller
{
    public override void InstallBindings() =>
        Container.Bind<BestScoreService>().FromNew().AsSingle().NonLazy();
}
