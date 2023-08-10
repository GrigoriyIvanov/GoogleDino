using Gameplay.Data;

namespace Gameplay.Interfaces
{
    public interface ISaveLoadService
    {
        public void Save(PlayerProgress playerProgress);
        public PlayerProgress Load();

    }
}