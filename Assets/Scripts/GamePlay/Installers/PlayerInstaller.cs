using Gameplay.Player;
using Gameplay.Player.FSM;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerStateMachine _player;
    [SerializeField] private Transform _spawnPosition;

    [SerializeField] private PlayerMovementSettings _movementSettings;

    private Player _playerComponent;
    private PlayerInput inputService;

    public override void InstallBindings()
    {
        _playerComponent = new Player(_movementSettings);
        Container.Bind<Player>().FromInstance(_playerComponent).AsSingle();

        inputService = new PlayerInput();
        Container.Bind<PlayerInput>().FromInstance(inputService).AsSingle();

        //var playerInstance = Container.InstantiatePrefabForComponent<PlayerStateMachine>(_player, _spawnPosition.position, Quaternion.identity, null);
        //Container.Bind<PlayerStateMachine>().FromInstance(playerInstance).AsSingle();
    }
}
