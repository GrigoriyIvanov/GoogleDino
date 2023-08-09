using Core.Interfaces;
using Core.Interfaces.EventFunctions;
using Zenject;

public class BestScoreService : ILost
{
    private IPlayerProgressHandler _playerProgressHandler;
    private IPointsCounter _pointsCounter;
    private ISaveLoadService _saveLoad;

    [Inject]
    public void Construct(
        IEventContainer<ILost> lostContainer,
        IPlayerProgressHandler playerProgressHandler,
        IPointsCounter pointsCounter,
        ISaveLoadService saveLoad)
    {
        lostContainer.AddCallback(this);

        _playerProgressHandler = playerProgressHandler;
        _pointsCounter = pointsCounter;
        _saveLoad = saveLoad;
    }

    public void OnLost() =>
        CheckAndSave();

    private void CheckAndSave()
    {
        if (_pointsCounter.Score.Value > _playerProgressHandler.PlayerProgress.Progeress.Value)
        {
            _playerProgressHandler.PlayerProgress.Progeress.Value = _pointsCounter.Score.Value;
            _saveLoad.Save(_playerProgressHandler.PlayerProgress);
        }
    }
}
