public interface IStateMachine<TActions> where TActions : struct
{
    public void ActionRespond(TActions action);
}
