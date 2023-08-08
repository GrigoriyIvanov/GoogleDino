using UnityEngine;

namespace Gameplay.Environment
{
    public class GroundMovement
    {
        private ISpeedCounter _speedCounter;

        private const float _lengthOfGroundUnit = 24f;

        public GroundMovement(ISpeedCounter speedCounter) =>
            _speedCounter = speedCounter;

        public void Move(Transform[] transform)
        {
            for (int i = 0; i < transform.Length; i++)
            {
                transform[i].position = Vector2.MoveTowards(
                                                transform[i].position,
                                                transform[i].position + Vector3.left,
                                                _speedCounter.Speed * Time.fixedDeltaTime);

                if (transform[i].position.x <= -_lengthOfGroundUnit)
                    transform[i].position = new Vector3(_lengthOfGroundUnit * 2f, 0, 0);
            }
        }
    }
}
