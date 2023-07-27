using UnityEngine;

namespace Gameplay.Environment
{
    public class Ground : MonoBehaviour
    {
        [SerializeField] private Transform[] _groundUnits;
        private Transform _unitToSpawnOn;

        private GrundMovement _movement;

        public Transform UnitToSpawnOn => GetMostRighPlatform();

        private void Awake() => _movement = new GrundMovement(_groundUnits);

        private void FixedUpdate() => _movement.Move();

        private Transform GetMostRighPlatform()
        {
            _unitToSpawnOn = _groundUnits[0];

            for (int i = 1; i < _groundUnits.Length; i++)
                if (_groundUnits[i].position.x > _unitToSpawnOn.position.x)
                    _unitToSpawnOn = _groundUnits[i];

            return _unitToSpawnOn;
        }
    }
}
