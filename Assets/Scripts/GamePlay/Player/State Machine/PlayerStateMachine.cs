using Core.Interfaces.EventFunctions.Updates;
using Main.Interfaces.EventFunctions.Collision;
using Main.StateMachine;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Gameplay.Player.FSM
{
    public enum PlayerActions
    {
        Run,
        RunIncline,
        Die,
        Jump,
        Land
    }

    public class PlayerStateMachine : AbstractFinitStateMashine<PlayerActions, Player>
    {
        [SerializeField] private Player _player;

        private PlayerInput _inputActions;

        private bool isDownMove;

        private IState _runningStraightState;
        private IState _runningInclineState;
        private IState _jumpingState;
        private IState _deadState;

        #region Initialize
        private protected override void Initialize()
        {
            base.Initialize();

            _player.InitializeParametrs();

            InitializeInputs();
        }

        private void OnDisable() => DeinitializeInputs();

        private protected override void InitializeStates()
        {
            _runningStraightState = new StraightRunningState(this, _player);
            _runningInclineState = new InclineRunningState(this, _player);
            _jumpingState = new JumpingState(this, _player);
            _deadState = new DeadState(this, _player);

            _initialState = _runningStraightState;

            _transitions.Add(new Transition(PlayerActions.RunIncline, _runningStraightState), _runningInclineState);
            _transitions.Add(new Transition(PlayerActions.Run, _runningInclineState), _runningStraightState);

            _transitions.Add(new Transition(PlayerActions.Jump, _runningStraightState), _jumpingState);
            _transitions.Add(new Transition(PlayerActions.Land, _jumpingState), _runningStraightState);

            _transitions.Add(new Transition(PlayerActions.Die, _runningStraightState), _deadState);
            _transitions.Add(new Transition(PlayerActions.Die, _jumpingState), _deadState);
        }

        public void InitializeInputs()
        {
            _inputActions = new PlayerInput();
            _inputActions.Enable();

            _inputActions.Movement.Jump.performed += OnJumpPressed;
            _inputActions.Movement.GoDown.performed += OnGoDownPressed;
            _inputActions.Movement.GoDown.performed += OnGoDownPressed;
            _inputActions.Movement.GoDown.canceled += OnGoDownCanceled;
        }

        public void DeinitializeInputs()
        {
            _inputActions.Movement.Jump.performed -= OnJumpPressed;
            _inputActions.Movement.GoDown.performed -= OnGoDownPressed;
            _inputActions.Movement.GoDown.canceled -= OnGoDownCanceled;
        }
        #endregion

        private void FixedUpdate()
        {
            (_currentState as IFixedUpdate)?.FixedUpdate();

            if (isDownMove)
                (_currentState as IExecuteDownMove)?.ExecuteDownMove();
            else
                (_currentState as ICancelDownMove)?.CancelDownMove();
        }

        private void OnJumpPressed(CallbackContext callbackContext) => (_currentState as IExecuteJump)?.ExecuteJump();

        private void OnGoDownPressed(CallbackContext callbackContext) => isDownMove = true;

        private void OnGoDownCanceled(CallbackContext callbackContext) => isDownMove = false;

        private void OnTriggerEnter2D(Collider2D collision) => (_currentState as ITriggerEnter)?.OnTriggerEnter(collision);
        
        private void OnValidate() => _player.OnValidate(transform);
    }
}
