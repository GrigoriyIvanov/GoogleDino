using UnityEngine;

namespace Main.Interfaces.EventFunctions.Collision
{
    public interface ITriggerExit
    {
        public void OnTriggerExit(Collider other);
    }
}
