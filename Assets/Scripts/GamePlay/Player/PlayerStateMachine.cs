using Main.StateMachine;

namespace Gameplay.Dino
{
    public enum PlayerActions
    {
        Run,
        Die,
        Jump,
        Land
    }

    public class PlayerStateMachine : AbstractFinitStateMashine<PlayerActions, Player>
    {
        private Player _player;

        private protected override void InitializeStates()
        {
            throw new System.NotImplementedException();
        }
    }
}
