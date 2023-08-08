namespace Core.StateMachine
{
    public abstract class AbstractState<TActions, TObject> : IState where TActions : struct where TObject : class
    {
        private protected IStateMachine<TActions> _fsm;
        private protected TObject _controlledObject;

        public AbstractState(IStateMachine<TActions> fsm, TObject instance)
        {
            _fsm = fsm;
            _controlledObject = instance;
        }

        public abstract void EnterState();

        public abstract void ExitState();
    }
}
