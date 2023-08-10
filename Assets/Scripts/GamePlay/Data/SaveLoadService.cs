using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay.Data
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string _progressKey = "PlayerProgress";

        public PlayerProgress Load() =>
            PlayerPrefs.GetString(_progressKey).DeserializeTo<PlayerProgress>();

        public void Save(PlayerProgress playerProgress) =>
            PlayerPrefs.SetString(_progressKey, playerProgress.Serialize());
    }
}