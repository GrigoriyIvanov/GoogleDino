using Main.Interfaces.EventFunctions.Collision;
using Main.StateMachine;
using UnityEngine;

namespace Gameplay.Player.FSM
{
    public abstract class AliveState : AbstractState<PlayerStateMachine, Player>, ITriggerEnter
    {
        public AliveState(PlayerStateMachine fsm, Player instance) : base(fsm, instance) { }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 7)
                _fsm.ActionRespond(PlayerActions.Die);
        }
    }
}
