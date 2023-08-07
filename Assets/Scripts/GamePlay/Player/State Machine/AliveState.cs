using Core.StateMachine;
using Main.Interfaces.EventFunctions.Collisions;
using UnityEngine;

namespace Gameplay.Player.FSM
{
    public abstract class AliveState : AbstractState<PlayerActions, Player>, ITriggerEnter2D
    {
        public AliveState(IStateMachine<PlayerActions> fsm, Player instance) : base(fsm, instance) { }

        public void OnTriggerEnter(Collider2D other)
        {
            if (other.gameObject.layer == 7)
                _fsm.ActionRespond(PlayerActions.Die);
        }
    }
}
