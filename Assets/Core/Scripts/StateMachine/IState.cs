namespace Core.StateMachine
{
    public interface IState
    {
        public void EnterState();
        public void ExitState();
    }
}
