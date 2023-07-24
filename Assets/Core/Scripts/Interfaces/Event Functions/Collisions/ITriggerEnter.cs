using UnityEngine;

namespace Main.Interfaces.EventFunctions.Collision
{
    public interface ITriggerEnter
    {
        public void OnTriggerEnter(Collider other);
    }
}
