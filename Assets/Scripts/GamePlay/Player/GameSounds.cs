using Gameplay.ScriptableObjects;
using UnityEngine;

namespace Gameplay.Player
{
    public class GameSounds
    {
        private AudioSource _audioSource;
        private SoundsConfig _soundsConfig;

        public GameSounds(SoundsConfig soundsConfig, AudioSource audioSource)
        {
            _audioSource = audioSource;
            _soundsConfig = soundsConfig;
        }

        public void PlayDeathSound() =>
            PlaySound(_soundsConfig.Death);

        public void PlayJumpSound() =>
            PlaySound(_soundsConfig.Jump);

        public void PlayScoreUpdateSound() =>
            PlaySound(_soundsConfig.ScoreUpdated);

        private void PlaySound(AudioClip audioClip) =>
            _audioSource.PlayOneShot(audioClip);
    }
}
