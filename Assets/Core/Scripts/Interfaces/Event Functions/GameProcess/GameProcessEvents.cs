namespace Core.Interfaces.EventFunctions
{
    public interface ILost
    {
        public void OnLost();
    }

    public interface IWin
    {
        public void OnWin();
    }

    public interface IPouse
    {
        public void OnPouse();
    }

    public interface IStartPlay
    {
        public void OnStartPlay();
    }
}