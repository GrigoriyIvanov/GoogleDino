using UnityEngine;

namespace Main.Interfaces.EventFunctions.Collisions
{
    public interface ICollisionEnter
    {
        public void OnCollisionEnter(Collision collision);
    }

    public interface ICollisionStay
    {
        public void OnCollisionStay(Collision collision);
    }

    public interface ICollisionExit
    {
        public void OnCollisionExit(Collision collision);
    }

    public interface ICollisionEnter2D
    {
        public void OnCollisionEnter(Collision2D collision);
    }

    public interface ICollisionStay2D
    {
        public void OnCollisionStay(Collision2D collision);
    }

    public interface ICollisionExit2D
    {
        public void OnCollisionExit(Collision2D collision);
    }
}
