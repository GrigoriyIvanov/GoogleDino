using Main.Interfaces.EventFunctions.Collision;
using Main.StateMachine;
using UnityEngine;

namespace Gameplay.Player.FSM
{
    public abstract class AliveState : AbstractState<PlayerActions, Player>, ITriggerEnter
    {
        public AliveState(IStateMachine<PlayerActions> fsm, Player instance) : base(fsm, instance) { }

        public void OnTriggerEnter(Collider2D other)
        {
            if (other.gameObject.layer == 7)
                _fsm.ActionRespond(PlayerActions.Die);
        }
    }
}
