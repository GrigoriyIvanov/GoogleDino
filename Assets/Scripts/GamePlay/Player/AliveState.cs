using Main.Interfaces.EventFunctions.Collision;
using Main.StateMachine;
using UnityEngine;

namespace Gameplay.Dino
{
    public class AliveState : AbstractState<PlayerStateMachine, Player>, ITriggerEnter
    {
        public AliveState(PlayerStateMachine fsm, Player instance) : base(fsm, instance) { }

        public override void EnterState()
        {
            throw new System.NotImplementedException();
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }

        public void OnTriggerEnter(Collider other)
        {
            throw new System.NotImplementedException();
        }
    }
}
