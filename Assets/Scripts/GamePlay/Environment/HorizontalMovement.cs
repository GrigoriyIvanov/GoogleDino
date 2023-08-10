using Gameplay.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Environment
{
    public class HorizontalMovement : IHorizontalMovement
    {
        public ISpeedCounter _speedCounter;

        public HorizontalMovement(ISpeedCounter speedCounter) =>
            _speedCounter = speedCounter;

        public void Move(List<Transform> transform, float speedMultiplayer = 1f)
        {
            for (int i = 0; i < transform.Count; i++)
            {
                transform[i].position = Vector2.MoveTowards(
                                                transform[i].position,
                                                transform[i].position + Vector3.left,
                                                _speedCounter.Speed * speedMultiplayer * Time.fixedDeltaTime);
            }
        }
    }
}
