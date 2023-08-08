using System;
using System.Collections.Generic;

namespace Core.StateMachine
{
    public abstract class AbstractFinitStateMashine<TActions> : IStateMachine<TActions> where TActions : struct
    {
        public class Transition
        {
            public TActions action;
            public Type currentState;

            public Transition(TActions action, Type currentState)
            {
                this.action = action;
                this.currentState = currentState;
            }

            public override int GetHashCode() =>
                17 + 31 * this.currentState.GetHashCode() + 31 * this.action.GetHashCode();

            public override bool Equals(object obj)
            {
                Transition other = obj as Transition;
                return obj as Transition != null && this.currentState.Equals(other.currentState) && this.action.Equals(other.action);
            }
        }

        private protected IState _currentState;
        private protected IState _initialState;

        private protected Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
        private protected Dictionary<Transition, Type> _transitions = new Dictionary<Transition, Type>();

        public void SetInitialState() => SetState(_initialState);

        private void SetState(IState newState)
        {
            if (newState == null)
                throw new ArgumentNullException(nameof(newState));

            _currentState?.ExitState();
            _currentState = newState;
            _currentState.EnterState();
        }

        public void ActionRespond(TActions action)
        {
            var trans = new Transition(action, _currentState.GetType());

            if (_transitions.TryGetValue(trans, out Type stateType))
                SetState(_states[stateType]);
            //else
            //    throw new InvalidOperationException("Attemp to make invalid transition");
        }
    }
}
