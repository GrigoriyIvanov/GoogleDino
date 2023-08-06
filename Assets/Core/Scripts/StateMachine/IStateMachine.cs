namespace Core.StateMachine
{
    public interface IStateMachine<TActions> where TActions : struct
    {
        public void SetInitialState();
        public void ActionRespond(TActions action);
    }
}