namespace Main.StateMachine
{
    public abstract class State<TFSM, TObject> : IState where TFSM : class where TObject : class
    {
        private protected TFSM _fsm;
        private protected TObject _instance;

        public State(TFSM fsm, TObject instance)
        {
            _fsm = fsm;
            _instance = instance;
        }

        public abstract void EnterState();

        public abstract void ExitState();
    }
}
