using Gameplay.Player.FSM;
using Main.StateMachine;
using Zenject;

public class OnLostListners : MonoInstaller
{
    private IState _runningStraightState;
    private IState _runningInclineState;
    private IState _jumpingState;
    private IState _deadState;

    public override void InstallBindings()
    {
        _runningStraightState = new StraightRunningState();
        _runningInclineState = new InclineRunningState();
        _jumpingState = new JumpingState();
        _deadState = new DeadState();

        Container.Bind<IState>().WithId(typeof(StraightRunningState)).FromInstance(_runningStraightState).AsSingle();
        Container.Bind<IState>().WithId(typeof(InclineRunningState)).FromInstance(_runningInclineState).AsSingle();
        Container.Bind<IState>().WithId(typeof(JumpingState)).FromInstance(_jumpingState).AsSingle();
        Container.Bind<IState>().WithId(typeof(DeadState)).FromInstance(_deadState).AsSingle();
    }
}
