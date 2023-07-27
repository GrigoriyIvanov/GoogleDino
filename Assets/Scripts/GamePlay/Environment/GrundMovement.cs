using UnityEngine;

namespace Gameplay.Environment
{
    public class GrundMovement
    {
        private Transform[] _groundUnits;
        private float _speed;
        private int _unitsAmount;

        private const float _startSpeed = 5f;
        private const float _speedIncrement = 0.001f;

        private const float _lengthOfGroundUnit = 24f;

        public GrundMovement(Transform[] groundUnits)
        {
            _groundUnits = groundUnits;
            _unitsAmount = _groundUnits.Length;
            _speed = _startSpeed;
        }

        public void Move()
        {
            for (int i = 0; i < _unitsAmount; i++)
            {
                _groundUnits[i].position = Vector2.MoveTowards(
                                                _groundUnits[i].position,
                                                _groundUnits[i].position + Vector3.left,
                                                _speed * Time.fixedDeltaTime);

                if (_groundUnits[i].position.x <= -_lengthOfGroundUnit)
                    _groundUnits[i].position = new Vector3(_lengthOfGroundUnit * 2f, 0, 0);
            }

            _speed += _speedIncrement;
        }
    }
}
