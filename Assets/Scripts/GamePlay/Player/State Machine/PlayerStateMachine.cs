using Main.StateMachine;

namespace Gameplay.Player.FSM
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

        private IState _runningState;
        private IState _jumpingState;
        private IState _deadState;

        private protected override void InitializeStates()
        {
            _runningState = new RunningState(this, _player);
            _jumpingState = new JumpingState(this, _player);
            _deadState = new DeadState(this, _player);

            _initialState = _runningState;

            _transitions.Add(new Transition(PlayerActions.Jump, _runningState), _jumpingState);
            _transitions.Add(new Transition(PlayerActions.Land, _jumpingState), _runningState);

            _transitions.Add(new Transition(PlayerActions.Die, _runningState), _deadState);
            _transitions.Add(new Transition(PlayerActions.Die, _jumpingState), _deadState);
        }
    }
}
