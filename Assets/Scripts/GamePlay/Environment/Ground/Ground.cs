using Gameplay.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay.Environment.Ground
{
    public class Ground : MonoBehaviour
    {
        [SerializeField] private List<Transform> _groundUnits;

        private IHorizontalMovement _movement;

        private const float _lengthOfGroundUnit = 24f;

        [Inject]
        public void Constructor(IHorizontalMovement movement) =>
            _movement = movement;

        private void FixedUpdate()
        {
            _movement.Move(_groundUnits);

            for (int i = 0; i < _groundUnits.Count; i++)
            {
                if (_groundUnits[i].position.x <= -_lengthOfGroundUnit)
                    _groundUnits[i].position = new Vector3(_groundUnits[i].position.x + _lengthOfGroundUnit * 3f, 0, 0);
            }
        }
    }
}
