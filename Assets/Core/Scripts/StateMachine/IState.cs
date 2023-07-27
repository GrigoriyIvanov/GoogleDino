namespace Main.StateMachine
{
    public interface IState
    {
        public void EnterState();
        public void ExitState();
    }
}
