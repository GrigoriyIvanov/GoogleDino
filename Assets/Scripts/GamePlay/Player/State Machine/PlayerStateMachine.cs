using Core.Interfaces;
using Core.Interfaces.EventFunctions.Updates;
using Core.StateMachine;
using Main.Interfaces.EventFunctions.Collisions;
using System.Collections.Generic;
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

    public class PlayerStateMachine : AbstractFinitStateMashine<PlayerActions>, PlayerInput.IMovementActions, IFixedUpdate, ITriggerEnter2D
    {
        private PlayerInput _inputService;

        private bool isDownMove;

        public PlayerStateMachine(Player player, PlayerInput inputService, IGameManager gameManager)
        {
            _states = new Dictionary<System.Type, IState>()
            {
                [typeof(StraightRunningState)] = new StraightRunningState(this, player),
                [typeof(InclineRunningState)] = new InclineRunningState(this, player),
                [typeof(JumpingState)] = new JumpingState(this, player),
                [typeof(DeadState)] = new DeadState(this, player, gameManager),
            };

            _transitions = new Dictionary<Transition, System.Type>()
            {
                [new Transition(PlayerActions.RunIncline, typeof(StraightRunningState))] = typeof(InclineRunningState),
                [new Transition(PlayerActions.Run, typeof(InclineRunningState))] = typeof(StraightRunningState),
                [new Transition(PlayerActions.Jump, typeof(StraightRunningState))] = typeof(JumpingState),
                [new Transition(PlayerActions.Land, typeof(JumpingState))] = typeof(StraightRunningState),
                [new Transition(PlayerActions.Die, typeof(StraightRunningState))] = typeof(DeadState),
                [new Transition(PlayerActions.Die, typeof(JumpingState))] = typeof(DeadState),
            };

            _inputService = inputService;
            InitializeInputs();

            _initialState = _states[typeof(StraightRunningState)];
        }

        #region Initialize

        public void InitializeInputs()
        {
            _inputService.Enable();
            _inputService.Movement.SetCallbacks(this);
        }
        #endregion

        public void FixedUpdate()
        {
            (_currentState as IFixedUpdate)?.FixedUpdate();

            if (isDownMove)
                (_currentState as IExecuteDownMove)?.ExecuteDownMove();
            else
                (_currentState as ICancelDownMove)?.CancelDownMove();
        }

        public void OnTriggerEnter(Collider2D collision) =>
            (_currentState as ITriggerEnter2D)?.OnTriggerEnter(collision);

        #region InputCallbacks
        public void OnJump(CallbackContext context) =>
            (_currentState as IExecuteJump)?.ExecuteJump();

        public void OnGoDown(CallbackContext context) =>
            isDownMove = context.performed;
        #endregion
    }
}
