using Core.Interfaces;
using Core.Interfaces.EventFunctions;
using Gameplay.Interfaces;

namespace Gameplay.Data
{
    public class SpeedCounterService : ISpeedCounter, ILost
    {
        private float _speed;
        private float _startSpeed = 5f;
        private float _speedIncrement = 0.001f;

        private bool enabled;

        public float Speed => _speed;

        public SpeedCounterService(float startSpeed, float speedIncrement, IEventContainer<ILost> lostContainer)
        {
            _startSpeed = startSpeed;
            _speed = _startSpeed;
            _speedIncrement = speedIncrement;

            enabled = true;

            lostContainer.AddCallback(this);
        }

        public void UpdateSpeed()
        {
            if (!enabled)
                return;

            _speed += _speedIncrement;
        }

        private void Disable()
        {
            enabled = false;
            _speed = 0;
        }

        public void OnLost() =>
            Disable();
    }
}