using UnityEngine;

namespace Gameplay.Player
{
    public class GroundChecker
    {
        private Transform _groundPoint;
        private LayerMask _layerMask;

        public bool isGrounded => Physics2D.Raycast(_groundPoint.position, -Vector2.up, 0.9722006f / 1.9f, _layerMask);

        public GroundChecker(Transform groundPoint)
        {
            _groundPoint = groundPoint;
            _layerMask = 1 << LayerMask.NameToLayer("Ground");
        }
    }
}
