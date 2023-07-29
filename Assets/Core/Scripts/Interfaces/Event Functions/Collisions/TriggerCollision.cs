using UnityEngine;

namespace Main.Interfaces.EventFunctions.Collisions
{
    public interface ITriggerEnter
    {
        public void OnTriggerEnter(Collider other);
    }

    public interface ITriggerStay
    {
        public void OnTriggerStay(Collider other);
    }

    public interface ITriggerExit2D
    {
        public void OnTriggerExit(Collider2D other);
    }

    public interface ITriggerEnter2D
    {
        public void OnTriggerEnter(Collider2D other);
    }

    public interface ITriggerStay2D
    {
        public void OnTriggerStay(Collider other);
    }

    public interface ITriggerExit
    {
        public void OnTriggerExit(Collider other);
    }
}