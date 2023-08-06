using Core;
using Zenject;

public class GameManagerInstaller : MonoInstaller<GameManagerInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IGameManager>().To<GameManager>().AsSingle();
    }
}
