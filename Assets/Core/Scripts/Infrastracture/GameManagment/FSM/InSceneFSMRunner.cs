using Core.StateMachine;
using UnityEngine;
using Zenject;

public abstract class InSceneFSMRunner<TFSM, TActions> : MonoBehaviour
    where TFSM : IStateMachine<TActions>
    where TActions : struct
{
    [Inject] private protected TFSM _fsm;

    //[Inject]
    //public virtual void Construct(TFSM fsm)
    //    => _fsm = fsm;
}
