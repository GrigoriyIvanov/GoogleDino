using Core.Interfaces.EventFunctions.Updates;
using Core.StateMachine;
using Main.Interfaces.EventFunctions.Collisions;
using UnityEngine;
using Zenject;
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

    public class PlayerStateMachine : AbstractFinitStateMashine<PlayerActions>, PlayerInput.IMovementActions
    {
        private PlayerInput _inputService;

        private bool isDownMove;

        [Inject(Id = typeof(StraightRunningState))] private IState _runningStraightState;
        [Inject(Id = typeof(InclineRunningState))] private IState _runningInclineState;
        [Inject(Id = typeof(JumpingState))] private IState _jumpingState;
        [Inject(Id = typeof(DeadState))] private IState _deadState;

        #region Initialize

        [Inject]
        private void PlayerFSM(Player player, PlayerInput inputService)
        {
            //_instance = player;
            _inputService = inputService;
        }

        //private protected override void Initialize()
        //{
        //    //_instance.InitializeParametrs(
        //    //    transform.GetComponent<Rigidbody2D>(),
        //    //    transform.GetComponentInChildren<Animator>());

        //    //base.Initialize();

        //    InitializeInputs();
        //}

        //private protected override void InitializeStates()
        //{
        //    //_runningStraightState = new StraightRunningState(this, _instance);
        //    //_runningInclineState = new InclineRunningState(this, _instance);
        //    //_jumpingState = new JumpingState(this, _instance);
        //    //_deadState = new DeadState(this, _instance);

        //    _initialState = _runningStraightState;

        //    AddTranstions();
        //}

        private void AddTranstions()
        {
            //_transitions.Add(new Transition(PlayerActions.RunIncline, _runningStraightState), _runningInclineState);
            //_transitions.Add(new Transition(PlayerActions.Run, _runningInclineState), _runningStraightState);
            //_transitions.Add(new Transition(PlayerActions.Jump, _runningStraightState), _jumpingState);
            //_transitions.Add(new Transition(PlayerActions.Land, _jumpingState), _runningStraightState);
            //_transitions.Add(new Transition(PlayerActions.Die, _runningStraightState), _deadState);
            //_transitions.Add(new Transition(PlayerActions.Die, _jumpingState), _deadState);
        }

        public void InitializeInputs()
        {
            _inputService.Enable();
            _inputService.Movement.SetCallbacks(this);
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

        #region InputCallbacks
        public void OnJump(CallbackContext context) => (_currentState as IExecuteJump)?.ExecuteJump();

        public void OnGoDown(CallbackContext context) => isDownMove = context.performed;
        #endregion

        private void OnTriggerEnter2D(Collider2D collision) => (_currentState as ITriggerEnter2D)?.OnTriggerEnter(collision);

        //private void OnValidate() => (_instance as IValidateTroughTransform)?.Validate(transform);
    }
}
