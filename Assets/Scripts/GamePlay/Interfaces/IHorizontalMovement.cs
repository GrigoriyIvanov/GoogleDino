using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Interfaces
{
    public interface IHorizontalMovement
    {
        public void Move(List<Transform> transform, float speedMultiplayer = 1f);
    }
}