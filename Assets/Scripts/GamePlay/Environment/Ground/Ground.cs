using Core.Interfaces;
using Core.Interfaces.EventFunctions;
using UnityEngine;
using Zenject;

namespace Gameplay.Environment
{
    public class Ground : MonoBehaviour
    {
        [SerializeField] private Transform[] _groundUnits;
        private Transform _unitToSpawnOn;

        private GroundMovement _movement;

        public Transform UnitToSpawnOn => GetMostRighPlatform();

        [Inject]
        public void Constructor(IEventContainer<ILost> lostEventContainer, GroundMovement movement) => 
            _movement = movement; 

        private void FixedUpdate() => 
            _movement.Move(_groundUnits);

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
