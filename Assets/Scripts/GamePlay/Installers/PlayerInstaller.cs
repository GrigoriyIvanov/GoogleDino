using Gameplay.Player;
using Gameplay.Player.FSM;
using Gameplay.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private PlayerRunner _playerRunner;
        [SerializeField] private PlayerMovementSettings _movementSettings;

        public override void InstallBindings()
        {
            Container.Bind<Player.Player>().FromNew().AsSingle().WithArguments(_movementSettings);
            Container.Bind<PlayerInput>().FromNew().AsSingle();
            Container.BindInterfacesTo<PlayerStateMachine>().FromNew().AsSingle();

            Container.InstantiatePrefabForComponent<PlayerRunner>(_playerRunner, _spawnPosition.position, Quaternion.identity, null);
        }
    }
}
