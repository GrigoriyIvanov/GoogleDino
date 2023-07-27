using UnityEngine;

namespace Gameplay.Environment
{
    public class GroundMover : MonoBehaviour
    {
        [SerializeField] private float _lengthOfGroundUnit = 24f;
        [SerializeField] private Transform[] _groundUnits;

        [SerializeField] private float _startSpeed = 5f;

        private int _unitsAmount;
         
        private void Awake() => _unitsAmount = _groundUnits.Length;

        private void FixedUpdate()
        {
            for (int i = 0; i < _unitsAmount; i++)
            {
                _groundUnits[i].position = Vector2.MoveTowards(
                                                _groundUnits[i].position, 
                                                _groundUnits[i].position + Vector3.left, 
                                                _startSpeed * Time.fixedDeltaTime);

                if (_groundUnits[i].position.x <= -_lengthOfGroundUnit)
                    _groundUnits[i].position = new Vector3(_lengthOfGroundUnit * 2f, 0, 0);
            }
        }
    }
}
