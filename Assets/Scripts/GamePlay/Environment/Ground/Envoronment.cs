using Gameplay.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay.Environment.Ground
{
    public class Envoronment : MonoBehaviour
    {
        [SerializeField] private List<Transform> _groundUnits;
        [SerializeField] private List<Transform> _clouds;

        private IHorizontalMovement _movement;

        private const float _lengthOfGroundUnit = 24f;

        [Inject]
        public void Constructor(IHorizontalMovement movement) =>
            _movement = movement;

        private void FixedUpdate()
        {
            _movement.Move(_groundUnits);
            _movement.Move(_clouds, 0.3f);

            for (int i = 0; i < _groundUnits.Count; i++)
            {
                if (_groundUnits[i].position.x <= -_lengthOfGroundUnit)
                    _groundUnits[i].position = new Vector3(_groundUnits[i].position.x + _lengthOfGroundUnit * 3f, 0, 0);
            }

            for (int i = 0; i < _clouds.Count; i++)
            {
                if (_clouds[i].position.x <= -_lengthOfGroundUnit)
                    _clouds[i].position = new Vector3(_clouds[i].position.x + _lengthOfGroundUnit * 3f, Random.Range(0.75f, 3f), 0);
            }
        }
    }
}
