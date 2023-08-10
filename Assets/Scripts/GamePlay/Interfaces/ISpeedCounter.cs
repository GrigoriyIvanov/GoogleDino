namespace Gameplay.Interfaces
{
    public interface ISpeedCounter
    {
        public float Speed { get; }

        public void UpdateSpeed();
    }
}