using Gameplay.Player;
using Gameplay.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class AudioInstaller : MonoInstaller
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private SoundsConfig _soundsConfig;

        public override void InstallBindings() =>
             Container.Bind<GameSounds>().FromNew().AsSingle().WithArguments(_soundsConfig, _audioSource);
    }
}
