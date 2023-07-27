using System;
using System.Collections.Generic;
using UnityEngine;

namespace Main.StateMachine
{
    public abstract class AbstractFinitStateMashine<TActions, TControlledInstance> : MonoBehaviour, IStateMachine<TActions> where TActions : struct where TControlledInstance : class
    {
        public class Transition
        {
            public TActions action;
            public IState currentState;

            public Transition(TActions action, IState currentState)
            {
                this.action = action;
                this.currentState = currentState;
            }

            public override int GetHashCode()
            {
                return 17 + 31 * this.currentState.GetHashCode() + 31 * this.action.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                Transition other = obj as Transition;
                return other != null && this.currentState.Equals(other.currentState) && this.action.Equals(other.action);
            }
        }

        private protected TControlledInstance _instance;

        private protected IState _currentState;
        private protected IState _initialState;

        private protected Dictionary<Transition, IState> _transitions = new Dictionary<Transition, IState>();

        #region Initialize
        private void Awake()
        {
            Initialize();
        }

        private protected virtual void Initialize()
        {
            InitializeStates();
            SetInitialState();
        }

        private protected abstract void InitializeStates();

        private void SetInitialState() => SetState(_initialState);
        #endregion

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
            var trans = new Transition(action, _currentState);

            if (_transitions.TryGetValue(trans, out IState state))
                SetState(state);
        }
    }
}
