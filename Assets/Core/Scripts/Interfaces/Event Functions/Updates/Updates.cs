namespace Core.Interfaces.EventFunctions.Updates
{
    public interface IUpdate
    {
        public void Update();
    }

    public interface IFixedUpdate
    {
        public void FixedUpdate();
    }

    public interface ILateUpdate
    {
        public void LateUpdate();
    }
}