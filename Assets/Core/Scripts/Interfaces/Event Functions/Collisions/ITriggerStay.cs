using UnityEngine;

namespace Main.Interfaces.EventFunctions.Collision
{
    public interface ITriggerStay
    {
        public void OnTriggerStay(Collider other);
    }
}
