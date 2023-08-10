using Core.Inftastracture.GameManagment.FSM;
using Core.Interfaces;
using Core.StateMachine;
using Gameplay.Data;
using Gameplay.Interfaces;

public class LoadDataState : AbstractState<GameActions, ISceneLoader>
{
    private ISaveLoadService _saveLoad;
    private IPlayerProgressHandler _playerProgressHandler;

    public LoadDataState(
        IStateMachine<GameActions> fsm,
        ISceneLoader instance,
        ISaveLoadService saveLoad,
        IPlayerProgressHandler playerProgressHandler) : base(fsm, instance)
    {
        _saveLoad = saveLoad;
        _playerProgressHandler = playerProgressHandler;
    }

    public override void EnterState()
    {
        _playerProgressHandler.PlayerProgress = _saveLoad.Load();

        if (_playerProgressHandler.PlayerProgress == null)
            _playerProgressHandler.PlayerProgress = new PlayerProgress(0);

        _controlledObject.Load(
            "Main",
            () => _fsm.ActionRespond(GameActions.EnterToGameplay));
    }

    public override void ExitState()
    {
    }
}
