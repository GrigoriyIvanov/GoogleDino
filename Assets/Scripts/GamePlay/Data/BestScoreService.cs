using Core.Interfaces;
using Core.Interfaces.EventFunctions;
using UnityEngine;
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
        if (_pointsCounter.Score > _playerProgressHandler.PlayerProgress.Progeress)
        {
            _playerProgressHandler.PlayerProgress.Progeress = _pointsCounter.Score;
            _saveLoad.Save(_playerProgressHandler.PlayerProgress);
        }

        Debug.Log(_playerProgressHandler.PlayerProgress.Progeress);
    }
}
